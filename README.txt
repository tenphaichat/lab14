================================================================================
TRƯỜNG ĐẠI HỌC CÔNG NGHỆ ĐÔNG Á (EAUT)
KHOA CÔNG NGHỆ THÔNG TIN - BỘ MÔN CÔNG NGHỆ PHẦN MỀM
HỌC PHẦN: LẬP TRÌNH .NET (IT3212)
LAB 14: BÁO CÁO THAM SỐ, NHÓM, THỐNG KÊ VÀ XUẤT EXCEL
================================================================================
Sinh viên thực hiện: Phan Văn Thắng
Mã số sinh viên    : 24002545
Lớp học phần       : IT3212
Ngày sinh          : 26/03/2006
Kho lưu trữ Github : https://github.com/tenphaichat/14.git
================================================================================

1. THÔNG TIN PHIÊN BẢN CRYSTAL REPORTS, THƯ VIỆN VÀ RUNTIME SỬ DỤNG
--------------------------------------------------------------------------------
- Công cụ phát triển: Visual Studio 2022 / .NET 9.0 Windows Forms Desktop SDK
- Phiên bản SAP Crystal Reports Engine: 13.0.4003 (SP33)
- Phiên bản SAP Crystal Reports Shared: 13.0.4003
- Phiên bản SAP Crystal Reports Windows Forms Viewer: 13.0.4003
- Thư viện xuất Excel chuyên nghiệp: ClosedXML v0.104.2 (OpenXML native .xlsx)
- Thư viện xuất PDF vector tiêu chuẩn: PDFsharp v6.1.1 (Standard A4 layout)
- Cơ sở dữ liệu: Microsoft SQL Server LocalDB ((localdb)\MSSQLLocalDB) - CSDL QLSinhVien

2. CẤU TRÚC DỰ ÁN VÀ KIẾN TRÚC 3 TẦNG (3-TIER ARCHITECTURE)
--------------------------------------------------------------------------------
IT3212_Labs.sln
│
├── Lab14_Database_Setup.sql           : Kịch bản SQL tạo 3 Views và nạp dữ liệu (35 SV, 13 HP, 28 ĐK)
├── 24002545_PhanVanThang_Lab14.docx   : Báo cáo thực hành chi tiết theo định dạng chuẩn EAUT
├── 24002545_PhanVanThang_Lab14.zip    : Gói nộp bài hoàn chỉnh, sạch sẽ (không chứa bin/obj/.vs)
├── README.txt                         : Hướng dẫn cấu hình, kiểm thử và vận hành hệ thống
│
├── [Các tệp mẫu Excel & PDF kết xuất từ ứng dụng]:
│   ├── BaoCaoSinhVien_TheoKhoa.xlsx   : Báo cáo danh sách sinh viên theo khoa (Excel)
│   ├── BaoCaoSinhVien_TheoKhoa.pdf    : Báo cáo danh sách sinh viên theo khoa (PDF)
│   ├── BaoCao_KhoangDiem.xlsx         : Báo cáo sinh viên theo khoảng điểm (Excel)
│   ├── BaoCao_KhoangDiem.pdf          : Báo cáo sinh viên theo khoảng điểm (PDF)
│   ├── BaoCao_TopN_SinhVien.xlsx      : Báo cáo vinh danh Top N sinh viên tiêu biểu (Excel)
│   ├── BaoCao_TopN_SinhVien.pdf       : Báo cáo vinh danh Top N sinh viên tiêu biểu (PDF)
│   ├── BaoCao_DangKy_HocKy.xlsx       : Báo cáo tổng hợp số lượng đăng ký theo học kỳ (Excel)
│   └── BaoCao_DangKy_HocKy.pdf        : Báo cáo tổng hợp số lượng đăng ký theo học kỳ (PDF)
│
├── screenshots/                       : Trọn bộ 10 ảnh minh chứng từ Bài 1 đến Bài 10
│   ├── hinh01.png                     : Bài 1 - Báo cáo theo tham số khoa (pTenKhoa, pNgayLap)
│   ├── hinh02.png                     : Bài 2 - Nhóm dữ liệu theo khoa (Group Header/Footer, Count)
│   ├── hinh03.png                     : Bài 3 - Thống kê điểm TB, Max, Min & Công thức @XepLoai
│   ├── hinh04.png                     : Bài 4 - Báo cáo theo khoảng điểm Min - Max và kiểm tra dữ liệu
│   ├── hinh05.png                     : Bài 5 - Xuất Crystal Report sang định dạng Excel (.xlsx)
│   ├── hinh06.png                     : Bài 6 - Báo cáo Top N sinh viên theo điểm và theo khoa
│   ├── hinh07.png                     : Bài 7 - Báo cáo đăng ký học phần theo học kỳ
│   ├── hinh08.png                     : Bài 8 - Báo cáo biểu đồ thống kê trực quan (Pie & Bar)
│   ├── hinh09.png                     : Bài 9 - Viết hàm xuất DataGridView ra Excel định dạng chuẩn
│   └── hinh10.png                     : Bài 10 - Trung tâm Báo cáo Tổng hợp (Report Center)
│
└── lab14/
    ├── DAL/
    │   ├── DbConnectionFactory.cs     : Cấp phát SqlConnection chuẩn từ App.config
    │   └── BaoCaoDAL.cs               : Truy vấn tham số hóa trích xuất dữ liệu từ các Views
    ├── BUS/
    │   ├── BaoCaoBUS.cs               : Xử lý nghiệp vụ logic, kiểm tra dữ liệu hợp lệ
    │   ├── ExcelExportHelper.cs       : Xử lý trích xuất DataTable/DataGridView sang Excel qua ClosedXML
    │   └── PdfExportHelper.cs         : Xử lý kết xuất báo cáo vector sang tệp PDF qua PDFsharp
    ├── DTO/
    │   ├── SinhVienReportDTO.cs       : Đối tượng truyền dữ liệu báo cáo sinh viên
    │   └── ReportSupportDTOs.cs       : DTO bổ trợ (Khoa, Đăng ký học kỳ, Thống kê xếp loại)
    ├── GUI/
    │   ├── frmMain.cs / Designer      : Dashboard chính tích hợp menu điều hướng và kiểm thử hàng loạt
    │   ├── frmReportCenter.cs / Des.  : Trung tâm Báo cáo Tổng hợp (Bài 10)
    │   ├── frmBaoCaoTheoKhoa.cs / Des.: Báo cáo tham số và phân nhóm theo khoa (Bài 1, 2, 3, 5)
    │   ├── frmBaoCaoKhoangDiem.cs /Des: Báo cáo lọc theo khoảng điểm Min/Max (Bài 4)
    │   ├── frmBaoCaoTopN.cs / Designer: Báo cáo vinh danh Top N sinh viên (Bài 6)
    │   ├── frmBaoCaoDangKyHocKy.cs/Des: Báo cáo đăng ký môn học theo học kỳ (Bài 7)
    │   ├── frmBaoCaoBieuDo.cs / Des.  : Biểu đồ trực quan Pie Chart và Bar Chart GDI+ (Bài 8)
    │   ├── frmXuatDataGridViewExcel.cs: Giao diện lọc động và xuất DataGridView sang Excel (Bài 9)
    │   └── frmReportViewer.cs / Des.  : Canvas xem trước báo cáo Crystal Report tương tác
    ├── Reports/
    │   ├── CrystalReportWrappers.cs   : Lớp kế thừa ReportClass theo chuẩn SAP CR
    │   ├── CrystalReportSinhVienTheoKhoa.rpt: Bản mẫu báo cáo sinh viên nhóm theo khoa
    │   ├── CrystalReportKhoangDiem.rpt: Bản mẫu báo cáo sinh viên theo khoảng điểm
    │   ├── CrystalReportTopN.rpt      : Bản mẫu báo cáo Top N sinh viên xuất sắc
    │   └── CrystalReportDangKyHocKy.rpt: Bản mẫu báo cáo đăng ký môn học theo kỳ
    ├── App.config                     : Chuỗi kết nối QLSinhVienConnection
    ├── Lab14_AdvancedReport.csproj    : Tệp dự án .NET 9 WinForms Desktop
    ├── Program.cs                     : Điểm khởi động ứng dụng & hỗ trợ cờ --capture
    └── ScreenshotCapture.cs           : Tự động xuất 4 Excel, 4 PDF và chụp 10 ảnh minh chứng

3. HƯỚNG DẪN CÀI ĐẶT VÀ VẬN HÀNH CHƯƠNG TRÌNH
--------------------------------------------------------------------------------
Bước 1: Khởi tạo View và Dữ liệu CSDL
   - Kết nối tới SQL Server LocalDB: (localdb)\MSSQLLocalDB
   - Thực thi kịch bản `Lab14_Database_Setup.sql` trên cơ sở dữ liệu `QLSinhVien`.
   - Script tạo 3 Views:
     + `vw_BaoCaoSinhVien`: 35 sinh viên (>= 20 sinh viên theo quy định).
     + `vw_BaoCaoDangKyHocKy`: 13 học phần theo từng học kỳ.
     + `vw_ChiTietDangKyHocKy`: 28 lượt đăng ký chi tiết.

Bước 2: Biên dịch ứng dụng
   - Mở Terminal tại thư mục `c:\Users\USER\Downloads\orracle\lab14`:
       dotnet build IT3212_Labs.sln
   - Dự án biên dịch thành công 100% với 0 Warning(s) và 0 Error(s).

Bước 3: Chạy ứng dụng
   - Khởi động giao diện chính:
       dotnet run --project lab14\Lab14_AdvancedReport.csproj
   - Chạy chế độ xuất báo cáo và chụp ảnh tự động:
       dotnet run --project lab14\Lab14_AdvancedReport.csproj -- --capture

4. DANH SÁCH 10 BÀI TẬP VÀ KẾT QUẢ ĐẠT ĐƯỢC
--------------------------------------------------------------------------------
1. Bài 1: Báo cáo theo tham số khoa (pTenKhoa, pNgayLap) với bộ lọc linh hoạt.
2. Bài 2: Nhóm dữ liệu theo khoa (Group by TenKhoa, tiêu đề nhóm và đếm số SV).
3. Bài 3: Thống kê Average, Max, Min theo khoa; công thức @XepLoai phân loại tự động.
4. Bài 4: Báo cáo danh sách sinh viên theo khoảng điểm Min - Max (0 <= Min <= Max <= 10).
5. Bài 5: Xuất Crystal Report sang bảng tính Excel (.xlsx) nguyên vẹn cấu trúc và định dạng.
6. Bài 6: Báo cáo Top N sinh viên có điểm trung bình cao nhất theo khoa / toàn trường.
7. Bài 7: Báo cáo phân nhóm đăng ký môn học theo học kỳ và chi tiết sinh viên.
8. Bài 8: Báo cáo kết hợp biểu đồ thống kê (Pie Chart phân bố học lực & Bar Chart quy mô khoa).
9. Bài 9: Viết hàm xuất DataGridView ra Excel chuẩn định dạng ngày tháng và số thực N2.
10. Bài 10: Xây dựng Trung tâm Báo cáo Tổng hợp (Report Center) điều phối tham số động.
================================================================================
