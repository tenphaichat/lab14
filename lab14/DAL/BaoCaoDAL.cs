using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Lab14_AdvancedReport.DTO;

namespace Lab14_AdvancedReport.DAL
{
    public class BaoCaoDAL
    {
        /// <summary>
        /// Bài 1: Lấy danh sách sinh viên theo khoa (hỗ trợ tham số pTenKhoa)
        /// </summary>
        public DataTable GetStudentsByDepartment(string maKhoa = null)
        {
            DataTable table = new DataTable("SinhVienReport");
            using (SqlConnection conn = DbConnectionFactory.Create())
            {
                string sql = @"SELECT MaSV, HoTen, NgaySinh, GioiTinh, MaKhoa, TenKhoa, DiemTB, Email 
                               FROM vw_BaoCaoSinhVien";
                if (!string.IsNullOrWhiteSpace(maKhoa) && maKhoa != "ALL")
                {
                    sql += " WHERE MaKhoa = @MaKhoa";
                }
                sql += " ORDER BY TenKhoa, HoTen";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (!string.IsNullOrWhiteSpace(maKhoa) && maKhoa != "ALL")
                    {
                        cmd.Parameters.AddWithValue("@MaKhoa", maKhoa);
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }
                }
            }
            AddCalculatedColumns(table);
            return table;
        }

        /// <summary>
        /// Bài 4: Báo cáo theo khoảng điểm min/max
        /// </summary>
        public DataTable GetByScoreRange(decimal min, decimal max, string maKhoa = null)
        {
            DataTable table = new DataTable("SinhVienReport");
            using (SqlConnection conn = DbConnectionFactory.Create())
            {
                string sql = @"SELECT MaSV, HoTen, NgaySinh, GioiTinh, MaKhoa, TenKhoa, DiemTB, Email 
                               FROM vw_BaoCaoSinhVien
                               WHERE DiemTB BETWEEN @Min AND @Max";
                if (!string.IsNullOrWhiteSpace(maKhoa) && maKhoa != "ALL")
                {
                    sql += " AND MaKhoa = @MaKhoa";
                }
                sql += " ORDER BY DiemTB DESC, HoTen ASC";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@Min", SqlDbType.Decimal).Value = min;
                    cmd.Parameters.Add("@Max", SqlDbType.Decimal).Value = max;
                    if (!string.IsNullOrWhiteSpace(maKhoa) && maKhoa != "ALL")
                    {
                        cmd.Parameters.AddWithValue("@MaKhoa", maKhoa);
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }
                }
            }
            AddCalculatedColumns(table);
            return table;
        }

        /// <summary>
        /// Bài 6: Báo cáo Top N sinh viên có điểm trung bình cao nhất
        /// </summary>
        public DataTable GetTopStudents(int topN, string maKhoa = null)
        {
            DataTable table = new DataTable("SinhVienReport");
            using (SqlConnection conn = DbConnectionFactory.Create())
            {
                string sql = $@"SELECT TOP (@TopN) MaSV, HoTen, NgaySinh, GioiTinh, MaKhoa, TenKhoa, DiemTB, Email 
                                FROM vw_BaoCaoSinhVien";
                if (!string.IsNullOrWhiteSpace(maKhoa) && maKhoa != "ALL")
                {
                    sql += " WHERE MaKhoa = @MaKhoa";
                }
                sql += " ORDER BY DiemTB DESC, HoTen ASC";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TopN", topN);
                    if (!string.IsNullOrWhiteSpace(maKhoa) && maKhoa != "ALL")
                    {
                        cmd.Parameters.AddWithValue("@MaKhoa", maKhoa);
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }
                }
            }
            AddCalculatedColumns(table);
            return table;
        }

        /// <summary>
        /// Bài 7: Báo cáo đăng ký học phần nhóm theo học kỳ
        /// </summary>
        public DataTable GetRegistrationBySemester(int? hocKy = null)
        {
            DataTable table = new DataTable("DangKyHocKyReport");
            using (SqlConnection conn = DbConnectionFactory.Create())
            {
                string sql = @"SELECT HocKy, MaHP, TenHP, SoTinChi, SoLuotDangKy, DiemTrungBinhMon 
                               FROM vw_BaoCaoDangKyHocKy";
                if (hocKy.HasValue && hocKy.Value > 0)
                {
                    sql += " WHERE HocKy = @HocKy";
                }
                sql += " ORDER BY HocKy ASC, TenHP ASC";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (hocKy.HasValue && hocKy.Value > 0)
                    {
                        cmd.Parameters.AddWithValue("@HocKy", hocKy.Value);
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }
                }
            }
            return table;
        }

        /// <summary>
        /// Bài 7 (Mở rộng): Lấy danh sách chi tiết sinh viên đăng ký học phần theo học kỳ
        /// </summary>
        public DataTable GetRegistrationDetails(int? hocKy = null)
        {
            DataTable table = new DataTable("ChiTietDangKyReport");
            using (SqlConnection conn = DbConnectionFactory.Create())
            {
                string sql = @"SELECT HocKy, MaHP, TenHP, SoTinChi, MaSV, HoTen, TenKhoa, Diem, NgayDangKy 
                               FROM vw_ChiTietDangKyHocKy";
                if (hocKy.HasValue && hocKy.Value > 0)
                {
                    sql += " WHERE HocKy = @HocKy";
                }
                sql += " ORDER BY HocKy ASC, TenHP ASC, HoTen ASC";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (hocKy.HasValue && hocKy.Value > 0)
                    {
                        cmd.Parameters.AddWithValue("@HocKy", hocKy.Value);
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }
                }
            }
            return table;
        }

        /// <summary>
        /// Bài 3 & Bài 8: Thống kê số lượng sinh viên, Điểm TB, Max, Min theo từng khoa
        /// </summary>
        public DataTable GetDepartmentStatistics()
        {
            DataTable table = new DataTable("ThongKeKhoa");
            using (SqlConnection conn = DbConnectionFactory.Create())
            {
                string sql = @"SELECT k.MaKhoa, k.TenKhoa, 
                                      COUNT(sv.MaSV) AS SoLuongSinhVien,
                                      ISNULL(AVG(sv.DiemTB), 0.0) AS DiemTBKhoa,
                                      ISNULL(MAX(sv.DiemTB), 0.0) AS DiemMaxKhoa,
                                      ISNULL(MIN(sv.DiemTB), 0.0) AS DiemMinKhoa
                               FROM Khoa k
                               LEFT JOIN SinhVien sv ON k.MaKhoa = sv.MaKhoa AND sv.IsActive = 1
                               GROUP BY k.MaKhoa, k.TenKhoa
                               ORDER BY k.TenKhoa";

                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
                {
                    adapter.Fill(table);
                }
            }
            return table;
        }

        /// <summary>
        /// Bài 8: Thống kê phân bố học lực sinh viên (Xếp loại)
        /// </summary>
        public DataTable GetGradeDistribution()
        {
            DataTable dtStudents = GetStudentsByDepartment();
            DataTable dtDistribution = new DataTable("PhanBoXepLoai");
            dtDistribution.Columns.Add("XepLoai", typeof(string));
            dtDistribution.Columns.Add("SoLuong", typeof(int));
            dtDistribution.Columns.Add("TyLe", typeof(double));

            int xs = 0, gioi = 0, kha = 0, tb = 0, yeu = 0;
            int total = dtStudents.Rows.Count;

            foreach (DataRow row in dtStudents.Rows)
            {
                decimal dtb = row["DiemTB"] != DBNull.Value ? Convert.ToDecimal(row["DiemTB"]) : 0.0m;
                if (dtb >= 9.0m) xs++;
                else if (dtb >= 8.0m) gioi++;
                else if (dtb >= 6.5m) kha++;
                else if (dtb >= 5.0m) tb++;
                else yeu++;
            }

            double safeTotal = total > 0 ? (double)total : 1.0;
            dtDistribution.Rows.Add("Xuất sắc (>= 9.0)", xs, Math.Round(xs * 100.0 / safeTotal, 1));
            dtDistribution.Rows.Add("Giỏi (8.0 - < 9.0)", gioi, Math.Round(gioi * 100.0 / safeTotal, 1));
            dtDistribution.Rows.Add("Khá (6.5 - < 8.0)", kha, Math.Round(kha * 100.0 / safeTotal, 1));
            dtDistribution.Rows.Add("Trung bình (5.0 - < 6.5)", tb, Math.Round(tb * 100.0 / safeTotal, 1));
            dtDistribution.Rows.Add("Yếu (< 5.0)", yeu, Math.Round(yeu * 100.0 / safeTotal, 1));

            return dtDistribution;
        }

        /// <summary>
        /// Lấy danh mục Khoa để nạp vào ComboBox
        /// </summary>
        public DataTable GetAllKhoa()
        {
            DataTable table = new DataTable("Khoa");
            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT MaKhoa, TenKhoa FROM Khoa ORDER BY TenKhoa", conn))
            {
                adapter.Fill(table);
            }
            return table;
        }

        /// <summary>
        /// Thêm cột tính toán XepLoai vào DataTable nếu chưa có
        /// </summary>
        private void AddCalculatedColumns(DataTable table)
        {
            if (!table.Columns.Contains("XepLoai"))
            {
                table.Columns.Add("XepLoai", typeof(string));
            }

            foreach (DataRow r in table.Rows)
            {
                decimal dtb = r["DiemTB"] != DBNull.Value ? Convert.ToDecimal(r["DiemTB"]) : 0.0m;
                if (dtb >= 9.0m) r["XepLoai"] = "Xuất sắc";
                else if (dtb >= 8.0m) r["XepLoai"] = "Giỏi";
                else if (dtb >= 6.5m) r["XepLoai"] = "Khá";
                else if (dtb >= 5.0m) r["XepLoai"] = "Trung bình";
                else r["XepLoai"] = "Yếu";
            }
        }
    }
}
