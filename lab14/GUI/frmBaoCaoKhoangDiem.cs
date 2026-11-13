using System;
using System.Data;
using System.Windows.Forms;
using Lab14_AdvancedReport.BUS;

namespace Lab14_AdvancedReport.GUI
{
    public partial class frmBaoCaoKhoangDiem : Form
    {
        private readonly BaoCaoBUS _bus = new BaoCaoBUS();
        private DataTable _dataTable;

        public frmBaoCaoKhoangDiem()
        {
            InitializeComponent();
        }

        private void frmBaoCaoKhoangDiem_Load(object sender, EventArgs e)
        {
            LoadKhoaComboBox();
            FilterData();
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

        private void btnLocDiem_Click(object sender, EventArgs e)
        {
            FilterData();
        }

        private void FilterData()
        {
            decimal min = nudMinScore.Value;
            decimal max = nudMaxScore.Value;

            if (min > max)
            {
                MessageBox.Show("Điểm tối thiểu (Min) không được lớn hơn điểm tối đa (Max)!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string selectedKhoa = cboKhoa.SelectedValue?.ToString() ?? "ALL";
                _dataTable = _bus.GetByScoreRange(min, max, selectedKhoa);

                dgvPreview.DataSource = _dataTable;
                FormatGridHeaders();

                lblTotal.Text = $"Tổng số sinh viên thỏa mãn: {_dataTable.Rows.Count}";
                lblStatus.Text = $"Đã lọc các sinh viên có điểm từ {min:N1} đến {max:N1} tại {cboKhoa.Text} lúc {DateTime.Now:HH:mm:ss}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lọc dữ liệu khoảng điểm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatGridHeaders()
        {
            if (dgvPreview.Columns["MaSV"] != null) dgvPreview.Columns["MaSV"].HeaderText = "Mã SV";
            if (dgvPreview.Columns["HoTen"] != null) dgvPreview.Columns["HoTen"].HeaderText = "Họ và Tên";
            if (dgvPreview.Columns["NgaySinh"] != null)
            {
                dgvPreview.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
                dgvPreview.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvPreview.Columns["NgaySinh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvPreview.Columns["GioiTinh"] != null) dgvPreview.Columns["GioiTinh"].HeaderText = "Phái";
            if (dgvPreview.Columns["TenKhoa"] != null) dgvPreview.Columns["TenKhoa"].HeaderText = "Tên Khoa";
            if (dgvPreview.Columns["DiemTB"] != null)
            {
                dgvPreview.Columns["DiemTB"].HeaderText = "Điểm TB";
                dgvPreview.Columns["DiemTB"].DefaultCellStyle.Format = "N2";
                dgvPreview.Columns["DiemTB"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dgvPreview.Columns["XepLoai"] != null)
            {
                dgvPreview.Columns["XepLoai"].HeaderText = "Xếp Loại";
                dgvPreview.Columns["XepLoai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvPreview.Columns["Email"] != null) dgvPreview.Columns["Email"].HeaderText = "Email";
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            decimal min = nudMinScore.Value;
            decimal max = nudMaxScore.Value;
            string khoaName = cboKhoa.Text;

            frmReportViewer viewer = new frmReportViewer(
                ReportViewMode.KhoangDiem,
                _dataTable,
                "BÁO CÁO SINH VIÊN THEO KHOẢNG ĐIỂM",
                $"Khoảng điểm: [{min:N1} - {max:N1}] | Khoa: {khoaName} | Ngày lập: {DateTime.Now:dd/MM/yyyy HH:mm}")
            {
                ParamMinScore = min,
                ParamMaxScore = max,
                ParamDepartment = khoaName
            };
            viewer.ShowDialog(this);
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                dlg.FileName = $"BaoCao_KhoangDiem_{nudMinScore.Value:N0}_{nudMaxScore.Value:N0}.xlsx";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExcelExportHelper.ExportDataTableToExcel(_dataTable, dlg.FileName, "BÁO CÁO SINH VIÊN THEO KHOẢNG ĐIỂM", $"Khoảng điểm: [{nudMinScore.Value:N1} - {nudMaxScore.Value:N1}] - {cboKhoa.Text}");
                        MessageBox.Show($"Đã xuất báo cáo khoảng điểm sang Excel:\n{dlg.FileName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                dlg.FileName = $"BaoCao_KhoangDiem_{nudMinScore.Value:N0}_{nudMaxScore.Value:N0}.pdf";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        PdfExportHelper.ExportKhoangDiemPdf(_dataTable, dlg.FileName, nudMinScore.Value, nudMaxScore.Value, cboKhoa.Text);
                        MessageBox.Show($"Đã xuất báo cáo khoảng điểm ra PDF:\n{dlg.FileName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
