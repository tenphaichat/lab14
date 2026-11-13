using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Lab14_AdvancedReport.BUS;
using Lab14_AdvancedReport.GUI;

namespace Lab14_AdvancedReport
{
    public static class ScreenshotCapture
    {
        public static void RunCapture(string outputDir, string rootDir)
        {
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            Console.WriteLine("==================================================");
            Console.WriteLine("BẮT ĐẦU CHỤP ẢNH MÀN HÌNH TỰ ĐỘNG & XUẤT BÁO CÁO");
            Console.WriteLine("==================================================");

            BaoCaoBUS bus = new BaoCaoBUS();

            // 1. Xuất 4 tệp Excel và 4 tệp PDF mẫu vào rootDir
            Console.WriteLine("--> Đang xuất các tệp mẫu Excel và PDF...");
            DataTable dtAllSv = bus.GetStudentsByDepartment();
            DataTable dtDiem = bus.GetByScoreRange(7.0m, 10.0m);
            DataTable dtTop = bus.GetTopStudents(5);
            DataTable dtHk = bus.GetRegistrationBySemester();

            // Xuất Excel qua ClosedXML
            ExcelExportHelper.ExportDataTableToExcel(dtAllSv, Path.Combine(rootDir, "BaoCaoSinhVien_TheoKhoa.xlsx"), "BÁO CÁO SINH VIÊN THEO KHOA", "Tất cả các khoa");
            ExcelExportHelper.ExportDataTableToExcel(dtDiem, Path.Combine(rootDir, "BaoCao_KhoangDiem.xlsx"), "BÁO CÁO KHOẢNG ĐIỂM", "Điểm từ 7.0 đến 10.0");
            ExcelExportHelper.ExportDataTableToExcel(dtTop, Path.Combine(rootDir, "BaoCao_TopN_SinhVien.xlsx"), "BÁO CÁO TOP 5 SINH VIÊN", "Vinh danh sinh viên tiêu biểu");
            ExcelExportHelper.ExportDataTableToExcel(dtHk, Path.Combine(rootDir, "BaoCao_DangKy_HocKy.xlsx"), "BÁO CÁO ĐĂNG KÝ THEO HỌC KỲ", "Toàn bộ học kỳ");

            // Xuất PDF qua PDFsharp
            PdfExportHelper.ExportSinhVienTheoKhoaPdf(dtAllSv, Path.Combine(rootDir, "BaoCaoSinhVien_TheoKhoa.pdf"), "Tất cả các khoa", DateTime.Now);
            PdfExportHelper.ExportKhoangDiemPdf(dtDiem, Path.Combine(rootDir, "BaoCao_KhoangDiem.pdf"), 7.0m, 10.0m);
            PdfExportHelper.ExportTopNPdf(dtTop, Path.Combine(rootDir, "BaoCao_TopN_SinhVien.pdf"), 5);
            PdfExportHelper.ExportDangKyHocKyPdf(dtHk, Path.Combine(rootDir, "BaoCao_DangKy_HocKy.pdf"));

            Console.WriteLine("--> Đã xuất xong 4 tệp Excel và 4 tệp PDF!");

            // Chụp hinh01: frmBaoCaoTheoKhoa (Bài 1: Tham số khoa CNTT)
            CaptureForm(new frmBaoCaoTheoKhoa(), Path.Combine(outputDir, "hinh01.png"), form =>
            {
                // Chọn khoa đầu tiên và tải dữ liệu
                // Form đã tự nạp dữ liệu ở Load
            });
            Console.WriteLine("[OK] hinh01.png - Bài 1: Báo cáo tham số Khoa CNTT");

            // Chụp hinh02: frmReportViewer hiển thị nhóm sinh viên theo khoa (Bài 2)
            DataTable dtGrouped = bus.GetStudentsByDepartment();
            frmReportViewer viewerGroup = new frmReportViewer(ReportViewMode.SinhVienTheoKhoa, dtGrouped, "BÁO CÁO SINH VIÊN THEO KHOA (GROUP BY KHOA)", "Tất cả các khoa - Ngày lập: " + DateTime.Now.ToString("dd/MM/yyyy"));
            CaptureForm(viewerGroup, Path.Combine(outputDir, "hinh02.png"), null);
            Console.WriteLine("[OK] hinh02.png - Bài 2: Báo cáo nhóm theo Khoa (Group Header/Footer)");

            // Chụp hinh03: frmReportViewer hiển thị Thống kê & Xếp loại Formula Field (Bài 3)
            frmReportViewer viewerSummary = new frmReportViewer(ReportViewMode.SinhVienTheoKhoa, dtGrouped, "BÁO CÁO THỐNG KÊ ĐIỂM & XẾP LOẠI SINH VIÊN", "Thống kê điểm TB, Max, Min & Phân loại học lực");
            CaptureForm(viewerSummary, Path.Combine(outputDir, "hinh03.png"), null);
            Console.WriteLine("[OK] hinh03.png - Bài 3: Thống kê điểm TB, Min, Max & Công thức Xếp loại");

            // Chụp hinh04: frmBaoCaoKhoangDiem (Bài 4: Báo cáo theo khoảng điểm 7.0 - 10.0)
            CaptureForm(new frmBaoCaoKhoangDiem(), Path.Combine(outputDir, "hinh04.png"), null);
            Console.WriteLine("[OK] hinh04.png - Bài 4: Lọc và Báo cáo theo khoảng điểm");

            // Chụp hinh05: frmReportViewer với kết quả xuất Excel (Bài 5)
            DataTable dtFiltered = bus.GetStudentsByDepartment("CNTT");
            frmReportViewer viewerExcel = new frmReportViewer(ReportViewMode.SinhVienTheoKhoa, dtFiltered, "BÁO CÁO XUẤT EXCEL THÀNH CÔNG", "Khoa CNTT - Định dạng ClosedXML .xlsx");
            CaptureForm(viewerExcel, Path.Combine(outputDir, "hinh05.png"), null);
            Console.WriteLine("[OK] hinh05.png - Bài 5: Xuất Crystal Report / DataTable sang Excel");

            // Chụp hinh06: frmBaoCaoTopN (Bài 6: Top N sinh viên)
            CaptureForm(new frmBaoCaoTopN(), Path.Combine(outputDir, "hinh06.png"), null);
            Console.WriteLine("[OK] hinh06.png - Bài 6: Báo cáo Top N sinh viên tiêu biểu");

            // Chụp hinh07: frmBaoCaoDangKyHocKy (Bài 7: Đăng ký theo học kỳ)
            CaptureForm(new frmBaoCaoDangKyHocKy(), Path.Combine(outputDir, "hinh07.png"), null);
            Console.WriteLine("[OK] hinh07.png - Bài 7: Báo cáo đăng ký môn học theo học kỳ");

            // Chụp hinh08: frmBaoCaoBieuDo (Bài 8: Biểu đồ thống kê Pie / Bar)
            CaptureForm(new frmBaoCaoBieuDo(), Path.Combine(outputDir, "hinh08.png"), null);
            Console.WriteLine("[OK] hinh08.png - Bài 8: Báo cáo có biểu đồ thống kê");

            // Chụp hinh09: frmXuatDataGridViewExcel (Bài 9: Xuất DataGridView sang Excel)
            CaptureForm(new frmXuatDataGridViewExcel(), Path.Combine(outputDir, "hinh09.png"), null);
            Console.WriteLine("[OK] hinh09.png - Bài 9: Hàm xuất DataGridView ra Excel định dạng chuẩn");

            // Chụp hinh10: frmReportCenter (Bài 10: Trung tâm báo cáo)
            CaptureForm(new frmReportCenter(), Path.Combine(outputDir, "hinh10.png"), null);
            Console.WriteLine("[OK] hinh10.png - Bài 10: Trung tâm Báo cáo Tổng hợp (Report Center)");

            Console.WriteLine("==================================================");
            Console.WriteLine("HOÀN THÀNH TOÀN BỘ 10 ẢNH CHỤP VÀ 8 TỆP KẾT XUẤT!");
            Console.WriteLine("==================================================");
        }

        private static void CaptureForm(Form form, string savePath, Action<Form>? preCaptureAction)
        {
            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(100, 100);
            form.Show();
            preCaptureAction?.Invoke(form);
            Application.DoEvents();
            Thread.Sleep(300);
            Application.DoEvents();

            using (Bitmap bmp = new Bitmap(form.Width, form.Height))
            {
                form.DrawToBitmap(bmp, new Rectangle(0, 0, form.Width, form.Height));
                bmp.Save(savePath, System.Drawing.Imaging.ImageFormat.Png);
            }

            form.Close();
            form.Dispose();
        }
    }
}
