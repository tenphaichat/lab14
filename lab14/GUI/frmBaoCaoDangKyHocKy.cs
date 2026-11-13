using System;
using System.Data;
using System.Windows.Forms;
using Lab14_AdvancedReport.BUS;

namespace Lab14_AdvancedReport.GUI
{
    public partial class frmBaoCaoDangKyHocKy : Form
    {
        private readonly BaoCaoBUS _bus = new BaoCaoBUS();
        private DataTable _dataTableSummary;
        private DataTable _dataTableDetails;

        public frmBaoCaoDangKyHocKy()
        {
            InitializeComponent();
        }

        private void frmBaoCaoDangKyHocKy_Load(object sender, EventArgs e)
        {
            cboHocKy.SelectedIndex = 0;
            LoadRegistrationData();
        }

        private void cboHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRegistrationData();
        }

        private void LoadRegistrationData()
        {
            try
            {
                int? hocKy = null;
                if (cboHocKy.SelectedIndex == 1) hocKy = 1;
                else if (cboHocKy.SelectedIndex == 2) hocKy = 2;
                else if (cboHocKy.SelectedIndex == 3) hocKy = 3;

                _dataTableSummary = _bus.GetRegistrationBySemester(hocKy);
                _dataTableDetails = _bus.GetRegistrationDetails(hocKy);

                dgvSummary.DataSource = _dataTableSummary;
                dgvDetails.DataSource = _dataTableDetails;
                FormatHeaders();

                int totalLuot = 0;
                foreach (DataRow r in _dataTableSummary.Rows)
                {
                    if (r["SoLuotDangKy"] != DBNull.Value)
                        totalLuot += Convert.ToInt32(r["SoLuotDangKy"]);
                }

                lblTotal.Text = $"Học phần: {_dataTableSummary.Rows.Count} | Tổng lượt đăng ký: {totalLuot} lượt";
                lblStatus.Text = $"Đã tải dữ liệu đăng ký {cboHocKy.Text} vào lúc {DateTime.Now:HH:mm:ss}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi nạp dữ liệu đăng ký học kỳ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatHeaders()
        {
            if (dgvSummary.Columns["HocKy"] != null)
            {
                dgvSummary.Columns["HocKy"].HeaderText = "Học Kỳ";
                dgvSummary.Columns["HocKy"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvSummary.Columns["MaHP"] != null) dgvSummary.Columns["MaHP"].HeaderText = "Mã HP";
            if (dgvSummary.Columns["TenHP"] != null) dgvSummary.Columns["TenHP"].HeaderText = "Tên Học Phần";
            if (dgvSummary.Columns["SoTinChi"] != null)
            {
                dgvSummary.Columns["SoTinChi"].HeaderText = "Số Tín Chỉ";
                dgvSummary.Columns["SoTinChi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dgvSummary.Columns["SoLuotDangKy"] != null)
            {
                dgvSummary.Columns["SoLuotDangKy"].HeaderText = "Lượt Đăng Ký";
                dgvSummary.Columns["SoLuotDangKy"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dgvSummary.Columns["DiemTrungBinhMon"] != null)
            {
                dgvSummary.Columns["DiemTrungBinhMon"].HeaderText = "ĐTB Môn";
                dgvSummary.Columns["DiemTrungBinhMon"].DefaultCellStyle.Format = "N2";
                dgvSummary.Columns["DiemTrungBinhMon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvDetails.Columns["HocKy"] != null) dgvDetails.Columns["HocKy"].HeaderText = "HK";
            if (dgvDetails.Columns["MaHP"] != null) dgvDetails.Columns["MaHP"].HeaderText = "Mã HP";
            if (dgvDetails.Columns["TenHP"] != null) dgvDetails.Columns["TenHP"].HeaderText = "Tên Học Phần";
            if (dgvDetails.Columns["MaSV"] != null) dgvDetails.Columns["MaSV"].HeaderText = "Mã SV";
            if (dgvDetails.Columns["HoTen"] != null) dgvDetails.Columns["HoTen"].HeaderText = "Họ và Tên";
            if (dgvDetails.Columns["TenKhoa"] != null) dgvDetails.Columns["TenKhoa"].HeaderText = "Khoa";
            if (dgvDetails.Columns["Diem"] != null)
            {
                dgvDetails.Columns["Diem"].HeaderText = "Điểm";
                dgvDetails.Columns["Diem"].DefaultCellStyle.Format = "N2";
            }
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            int? hocKy = null;
            if (cboHocKy.SelectedIndex == 1) hocKy = 1;
            else if (cboHocKy.SelectedIndex == 2) hocKy = 2;
            else if (cboHocKy.SelectedIndex == 3) hocKy = 3;

            frmReportViewer viewer = new frmReportViewer(
                ReportViewMode.DangKyHocKy,
                _dataTableSummary,
                "BÁO CÁO TỔNG HỢP ĐĂNG KÝ HỌC PHẦN THEO HỌC KỲ",
                $"Phạm vi: {cboHocKy.Text} | Ngày lập: {DateTime.Now:dd/MM/yyyy HH:mm}")
            {
                ParamSemester = hocKy
            };
            viewer.ShowDialog(this);
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                dlg.FileName = "BaoCao_DangKy_HocKy.xlsx";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExcelExportHelper.ExportDataTableToExcel(_dataTableSummary, dlg.FileName, "BÁO CÁO ĐĂNG KÝ THEO HỌC KỲ", $"Nhóm theo học kỳ & học phần - {cboHocKy.Text}");
                        MessageBox.Show($"Đã xuất báo cáo đăng ký học kỳ sang Excel:\n{dlg.FileName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                dlg.FileName = "BaoCao_DangKy_HocKy.pdf";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        int? hocKy = null;
                        if (cboHocKy.SelectedIndex == 1) hocKy = 1;
                        else if (cboHocKy.SelectedIndex == 2) hocKy = 2;
                        else if (cboHocKy.SelectedIndex == 3) hocKy = 3;

                        PdfExportHelper.ExportDangKyHocKyPdf(_dataTableSummary, dlg.FileName, hocKy);
                        MessageBox.Show($"Đã xuất báo cáo đăng ký học kỳ ra PDF:\n{dlg.FileName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
