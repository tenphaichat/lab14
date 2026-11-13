using System;
using System.Data;
using System.Windows.Forms;
using Lab14_AdvancedReport.BUS;

namespace Lab14_AdvancedReport.GUI
{
    public partial class frmBaoCaoTopN : Form
    {
        private readonly BaoCaoBUS _bus = new BaoCaoBUS();
        private DataTable _dataTable;

        public frmBaoCaoTopN()
        {
            InitializeComponent();
        }

        private void frmBaoCaoTopN_Load(object sender, EventArgs e)
        {
            LoadKhoaComboBox();
            LoadTopStudents();
        }

        private void LoadKhoaComboBox()
        {
            try
            {
                DataTable dtKhoa = _bus.GetAllKhoa();
                DataRow allRow = dtKhoa.NewRow();
                allRow["MaKhoa"] = "ALL";
                allRow["TenKhoa"] = "-- Tất cả các khoa --";
                dtKhoa.Rows.InsertAt(allRow, 0);

                cboKhoa.DataSource = dtKhoa;
                cboKhoa.DisplayMember = "TenKhoa";
                cboKhoa.ValueMember = "MaKhoa";
                cboKhoa.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi nạp danh mục khoa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimTop_Click(object sender, EventArgs e)
        {
            LoadTopStudents();
        }

        private void LoadTopStudents()
        {
            try
            {
                int topN = (int)nudTopN.Value;
                string selectedKhoa = cboKhoa.SelectedValue?.ToString() ?? "ALL";
                _dataTable = _bus.GetTopStudents(topN, selectedKhoa);

                dgvTopN.DataSource = _dataTable;
                FormatGridHeaders();

                lblTotal.Text = $"Đã tải Top {_dataTable.Rows.Count} sinh viên";
                lblStatus.Text = $"Vinh danh Top {topN} sinh viên có điểm cao nhất tại {cboKhoa.Text} lúc {DateTime.Now:HH:mm:ss}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi nạp danh sách Top N: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatGridHeaders()
        {
            if (dgvTopN.Columns["MaSV"] != null) dgvTopN.Columns["MaSV"].HeaderText = "Mã SV";
            if (dgvTopN.Columns["HoTen"] != null) dgvTopN.Columns["HoTen"].HeaderText = "Họ và Tên";
            if (dgvTopN.Columns["NgaySinh"] != null)
            {
                dgvTopN.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
                dgvTopN.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvTopN.Columns["NgaySinh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvTopN.Columns["GioiTinh"] != null) dgvTopN.Columns["GioiTinh"].HeaderText = "Phái";
            if (dgvTopN.Columns["TenKhoa"] != null) dgvTopN.Columns["TenKhoa"].HeaderText = "Tên Khoa";
            if (dgvTopN.Columns["DiemTB"] != null)
            {
                dgvTopN.Columns["DiemTB"].HeaderText = "Điểm TB";
                dgvTopN.Columns["DiemTB"].DefaultCellStyle.Format = "N2";
                dgvTopN.Columns["DiemTB"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dgvTopN.Columns["XepLoai"] != null)
            {
                dgvTopN.Columns["XepLoai"].HeaderText = "Xếp Loại";
                dgvTopN.Columns["XepLoai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvTopN.Columns["Email"] != null) dgvTopN.Columns["Email"].HeaderText = "Email";
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            int topN = (int)nudTopN.Value;
            string khoaName = cboKhoa.Text;

            frmReportViewer viewer = new frmReportViewer(
                ReportViewMode.TopN,
                _dataTable,
                $"BÁO CÁO TOP {topN} SINH VIÊN XUẤT SẮC",
                $"Phạm vi: {khoaName} | Sắp xếp: Điểm TB giảm dần | Ngày lập: {DateTime.Now:dd/MM/yyyy HH:mm}")
            {
                ParamTopN = topN,
                ParamDepartment = khoaName
            };
            viewer.ShowDialog(this);
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                dlg.FileName = $"BaoCao_Top{nudTopN.Value}_SinhVien.xlsx";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExcelExportHelper.ExportDataTableToExcel(_dataTable, dlg.FileName, $"BÁO CÁO TOP {nudTopN.Value} SINH VIÊN TIÊU BIỂU", $"Phạm vi: {cboKhoa.Text}");
                        MessageBox.Show($"Đã xuất báo cáo Top N sang Excel:\n{dlg.FileName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnXuatPdf_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "PDF Document (*.pdf)|*.pdf";
                dlg.FileName = $"BaoCao_Top{nudTopN.Value}_SinhVien.pdf";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        PdfExportHelper.ExportTopNPdf(_dataTable, dlg.FileName, (int)nudTopN.Value, cboKhoa.Text);
                        MessageBox.Show($"Đã xuất báo cáo Top N ra PDF:\n{dlg.FileName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi xuất PDF: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
