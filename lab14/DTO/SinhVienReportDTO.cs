using System;

namespace Lab14_AdvancedReport.DTO
{
    public class SinhVienReportDTO
    {
        public string MaSV { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; } = "Nam";
        public string MaKhoa { get; set; } = string.Empty;
        public string TenKhoa { get; set; } = string.Empty;
        public decimal DiemTB { get; set; } = 0.0m;
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Bài 3: Công thức xếp loại học lực theo thang điểm 10 chuẩn đào tạo
        /// </summary>
        public string XepLoai
        {
            get
            {
                if (DiemTB >= 9.0m) return "Xuất sắc";
                if (DiemTB >= 8.0m) return "Giỏi";
                if (DiemTB >= 6.5m) return "Khá";
                if (DiemTB >= 5.0m) return "Trung bình";
                return "Yếu";
            }
        }

        public SinhVienReportDTO() { }

        public SinhVienReportDTO(string maSV, string hoTen, DateTime ngaySinh, string gioiTinh, string maKhoa, string tenKhoa, decimal diemTB, string email)
        {
            MaSV = maSV;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            MaKhoa = maKhoa;
            TenKhoa = tenKhoa;
            DiemTB = diemTB;
            Email = email;
        }
    }
}
