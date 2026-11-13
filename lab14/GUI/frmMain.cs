using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Lab14_AdvancedReport.BUS;

namespace Lab14_AdvancedReport.GUI
{
    public partial class frmMain : Form
    {
        private readonly BaoCaoBUS _bus = new BaoCaoBUS();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "Hệ thống Báo cáo Nâng cao Crystal Report & Excel sẵn sàng.";
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            timerClock.Start();
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        /// <summary>
        /// Mở form con an toàn, chống mở trùng lặp (Singleton pattern)
        /// </summary>
        private void OpenChildForm<T>() where T : Form, new()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is T)
                {
                    form.WindowState = FormWindowState.Normal;
                    form.BringToFront();
                    form.Activate();
                    lblStatus.Text = $"Đã kích hoạt cửa sổ đang mở: {form.Text}";
                    return;
                }
            }

            T newForm = new T();
            newForm.FormClosed += (s, args) =>
            {
                lblStatus.Text = $"Đã đóng và giải phóng tài nguyên: {newForm.Text}";
            };
            newForm.Show();
            lblStatus.Text = $"Đang hiển thị cửa sổ: {newForm.Text}";
        }

        private void mnuBaoCaoTheoKhoa_Click(object sender, EventArgs e) => OpenChildForm<frmBaoCaoTheoKhoa>();
        private void mnuBaoCaoKhoangDiem_Click(object sender, EventArgs e) => OpenChildForm<frmBaoCaoKhoangDiem>();
        private void mnuBaoCaoTopN_Click(object sender, EventArgs e) => OpenChildForm<frmBaoCaoTopN>();
        private void mnuBaoCaoDangKyHocKy_Click(object sender, EventArgs e) => OpenChildForm<frmBaoCaoDangKyHocKy>();
        private void mnuBaoCaoBieuDo_Click(object sender, EventArgs e) => OpenChildForm<frmBaoCaoBieuDo>();
        private void mnuXuatDgvExcel_Click(object sender, EventArgs e) => OpenChildForm<frmXuatDataGridViewExcel>();
        private void mnuTrungTamBaoCao_Click(object sender, EventArgs e) => OpenChildForm<frmReportCenter>();

        private void btnNavKhoa_Click(object sender, EventArgs e) => OpenChildForm<frmBaoCaoTheoKhoa>();
        private void btnNavDiem_Click(object sender, EventArgs e) => OpenChildForm<frmBaoCaoKhoangDiem>();
        private void btnNavTopN_Click(object sender, EventArgs e) => OpenChildForm<frmBaoCaoTopN>();
        private void btnNavHocKy_Click(object sender, EventArgs e) => OpenChildForm<frmBaoCaoDangKyHocKy>();
        private void btnNavBieuDo_Click(object sender, EventArgs e) => OpenChildForm<frmBaoCaoBieuDo>();
        private void btnNavCenter_Click(object sender, EventArgs e) => OpenChildForm<frmReportCenter>();

        /// <summary>
        /// Kiểm thử xuất hàng loạt báo cáo sang Excel và PDF
        /// </summary>
        private void mnuKiemThuXuatBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                string rootDir = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\.."));

                DataTable dtSv = _bus.GetStudentsByDepartment();
                DataTable dtDiem = _bus.GetByScoreRange(7.0m, 10.0m);
                DataTable dtTop = _bus.GetTopStudents(5);
                DataTable dtHk = _bus.GetRegistrationBySemester();

                // Xuất Excel
                ExcelExportHelper.ExportDataTableToExcel(dtSv, Path.Combine(rootDir, "BaoCaoSinhVien_TheoKhoa.xlsx"), "BÁO CÁO SINH VIÊN THEO KHOA", "Tất cả các khoa");
                ExcelExportHelper.ExportDataTableToExcel(dtDiem, Path.Combine(rootDir, "BaoCao_KhoangDiem.xlsx"), "BÁO CÁO KHOẢNG ĐIỂM", "Điểm từ 7.0 đến 10.0");
                ExcelExportHelper.ExportDataTableToExcel(dtTop, Path.Combine(rootDir, "BaoCao_TopN_SinhVien.xlsx"), "BÁO CÁO TOP 5 SINH VIÊN", "Vinh danh sinh viên tiêu biểu");
                ExcelExportHelper.ExportDataTableToExcel(dtHk, Path.Combine(rootDir, "BaoCao_DangKy_HocKy.xlsx"), "BÁO CÁO ĐĂNG KÝ THEO HỌC KỲ", "Toàn bộ học kỳ");

                // Xuất PDF
                PdfExportHelper.ExportSinhVienTheoKhoaPdf(dtSv, Path.Combine(rootDir, "BaoCaoSinhVien_TheoKhoa.pdf"), "Tất cả các khoa", DateTime.Now);
                PdfExportHelper.ExportKhoangDiemPdf(dtDiem, Path.Combine(rootDir, "BaoCao_KhoangDiem.pdf"), 7.0m, 10.0m);
                PdfExportHelper.ExportTopNPdf(dtTop, Path.Combine(rootDir, "BaoCao_TopN_SinhVien.pdf"), 5);
                PdfExportHelper.ExportDangKyHocKyPdf(dtHk, Path.Combine(rootDir, "BaoCao_DangKy_HocKy.pdf"));

                MessageBox.Show(
                    "Kiểm thử xuất tự động 4 báo cáo sang Excel (.xlsx) và PDF (.pdf) thành công 100%!\n\n" +
                    "Các tệp đã được tạo tại thư mục dự án:\n" +
                    "1. BaoCaoSinhVien_TheoKhoa.xlsx / .pdf\n" +
                    "2. BaoCao_KhoangDiem.xlsx / .pdf\n" +
                    "3. BaoCao_TopN_SinhVien.xlsx / .pdf\n" +
                    "4. BaoCao_DangKy_HocKy.xlsx / .pdf",
                    "Kiểm thử thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                lblStatus.Text = "Kiểm thử kết xuất toàn bộ báo cáo hoàn thành xuất sắc.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kiểm thử xuất báo cáo: {ex.Message}", "Lỗi kiểm thử", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuThongTin_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "LAB 14: BÁO CÁO THAM SỐ, NHÓM, THỐNG KÊ VÀ XUẤT EXCEL\n" +
                "Học phần: Lập trình .NET (IT3212)\n" +
                "Khoa Công nghệ Thông tin - Trường Đại học Công nghệ Đông Á (EAUT)\n\n" +
                "Sinh viên thực hiện:\n" +
                "- Họ và tên: Phan Văn Thắng\n" +
                "- Mã sinh viên: 24002545\n" +
                "- Lớp: IT3212\n" +
                "- Ngày sinh: 26/03/2006",
                "Thông tin sinh viên",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
