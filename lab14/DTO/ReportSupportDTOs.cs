namespace Lab14_AdvancedReport.DTO
{
    public class KhoaReportDTO
    {
        public string MaKhoa { get; set; } = string.Empty;
        public string TenKhoa { get; set; } = string.Empty;
        public int SoLuongSinhVien { get; set; } = 0;
        public decimal DiemTrungBinhKhoa { get; set; } = 0.0m;
        public decimal DiemMax { get; set; } = 0.0m;
        public decimal DiemMin { get; set; } = 0.0m;

        public KhoaReportDTO() { }

        public KhoaReportDTO(string maKhoa, string tenKhoa, int soLuong, decimal dtb, decimal dmax, decimal dmin)
        {
            MaKhoa = maKhoa;
            TenKhoa = tenKhoa;
            SoLuongSinhVien = soLuong;
            DiemTrungBinhKhoa = dtb;
            DiemMax = dmax;
            DiemMin = dmin;
        }
    }

    public class DangKyHocKyDTO
    {
        public int HocKy { get; set; } = 1;
        public string MaHP { get; set; } = string.Empty;
        public string TenHP { get; set; } = string.Empty;
        public int SoTinChi { get; set; } = 3;
        public int SoLuotDangKy { get; set; } = 0;
        public decimal DiemTrungBinhMon { get; set; } = 0.0m;

        public DangKyHocKyDTO() { }

        public DangKyHocKyDTO(int hocKy, string maHP, string tenHP, int soTinChi, int soLuotDangKy, decimal diemTB)
        {
            HocKy = hocKy;
            MaHP = maHP;
            TenHP = tenHP;
            SoTinChi = soTinChi;
            SoLuotDangKy = soLuotDangKy;
            DiemTrungBinhMon = diemTB;
        }
    }

    public class ThongKeXepLoaiDTO
    {
        public string XepLoai { get; set; } = string.Empty;
        public int SoLuong { get; set; } = 0;
        public double TyLePhanTram { get; set; } = 0.0;

        public ThongKeXepLoaiDTO() { }

        public ThongKeXepLoaiDTO(string xepLoai, int soLuong, double tyLe)
        {
            XepLoai = xepLoai;
            SoLuong = soLuong;
            TyLePhanTram = tyLe;
        }
    }
}
