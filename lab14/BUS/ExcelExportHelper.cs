using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace Lab14_AdvancedReport.BUS
{
    /// <summary>
    /// Helper xuất báo cáo và dữ liệu sang Excel chuyên nghiệp (Bài 5 & Bài 9)
    /// Đảm bảo định dạng chuẩn: Header màu sắc, đường viền, căn chỉnh số/ngày, tự động chỉnh độ rộng cột
    /// </summary>
    public static class ExcelExportHelper
    {
        /// <summary>
        /// Bài 5: Xuất DataTable sang Excel (.xlsx) với định dạng biểu mẫu đào tạo chuẩn
        /// </summary>
        public static void ExportDataTableToExcel(DataTable data, string filePath, string sheetTitle = "Báo Cáo", string subHeader = "")
        {
            if (data == null || data.Rows.Count == 0)
            {
                throw new InvalidOperationException("Không có dữ liệu để xuất Excel.");
            }

            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add(sheetTitle);

                // 1. Header trường & tiêu ngữ
                ws.Cell("A1").Value = "TRƯỜNG ĐẠI HỌC CÔNG NGHỆ ĐÔNG Á";
                ws.Cell("A1").Style.Font.Bold = true;
                ws.Cell("A1").Style.Font.FontSize = 10;
                ws.Cell("A1").Style.Font.FontColor = XLColor.FromArgb(24, 76, 120);

                ws.Cell("A2").Value = "KHOA CÔNG NGHỆ THÔNG TIN - LẬP TRÌNH .NET (IT3212)";
                ws.Cell("A2").Style.Font.FontSize = 9;
                ws.Cell("A2").Style.Font.FontColor = XLColor.DarkSlateGray;

                // 2. Tiêu đề báo cáo
                int totalCols = Math.Max(data.Columns.Count, 5);
                string endColLetter = GetExcelColumnName(totalCols);

                ws.Range($"A4:{endColLetter}4").Merge();
                var titleCell = ws.Cell("A4");
                titleCell.Value = sheetTitle.ToUpper();
                titleCell.Style.Font.Bold = true;
                titleCell.Style.Font.FontSize = 14;
                titleCell.Style.Font.FontColor = XLColor.FromArgb(24, 76, 120);
                titleCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                if (!string.IsNullOrWhiteSpace(subHeader))
                {
                    ws.Range($"A5:{endColLetter}5").Merge();
                    var subCell = ws.Cell("A5");
                    subCell.Value = subHeader + $" | Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm}";
                    subCell.Style.Font.Italic = true;
                    subCell.Style.Font.FontSize = 9.5;
                    subCell.Style.Font.FontColor = XLColor.DimGray;
                    subCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                }

                // 3. Header bảng dữ liệu
                int startRow = 7;
                for (int c = 0; c < data.Columns.Count; c++)
                {
                    var cell = ws.Cell(startRow, c + 1);
                    cell.Value = GetDisplayColumnName(data.Columns[c].ColumnName);
                    cell.Style.Font.Bold = true;
                    cell.Style.Font.FontSize = 10;
                    cell.Style.Font.FontColor = XLColor.White;
                    cell.Style.Fill.BackgroundColor = XLColor.FromArgb(24, 76, 120);
                    cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    cell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    cell.Style.Border.OutsideBorderColor = XLColor.Navy;
                }

                // 4. Data Rows
                for (int r = 0; r < data.Rows.Count; r++)
                {
                    int curRow = startRow + 1 + r;
                    DataRow row = data.Rows[r];

                    for (int c = 0; c < data.Columns.Count; c++)
                    {
                        var cell = ws.Cell(curRow, c + 1);
                        object val = row[c];

                        if (val == DBNull.Value || val == null)
                        {
                            cell.Value = string.Empty;
                        }
                        else if (val is DateTime dt)
                        {
                            cell.Value = dt.ToString("dd/MM/yyyy");
                            cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }
                        else if (val is decimal || val is double || val is float)
                        {
                            double dVal = Convert.ToDouble(val);
                            cell.Value = dVal;
                            cell.Style.NumberFormat.Format = "#,##0.00";
                            cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        }
                        else if (val is int || val is long || val is short)
                        {
                            cell.Value = Convert.ToInt64(val);
                            cell.Style.NumberFormat.Format = "#,##0";
                            cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        }
                        else
                        {
                            cell.Value = val.ToString();
                            if (data.Columns[c].ColumnName.Contains("Ma") || data.Columns[c].ColumnName.Contains("GioiTinh"))
                            {
                                cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            }
                            else
                            {
                                cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                            }
                        }

                        // Zebra striping
                        if (r % 2 == 1)
                        {
                            cell.Style.Fill.BackgroundColor = XLColor.FromArgb(248, 250, 252);
                        }
                        cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        cell.Style.Border.OutsideBorderColor = XLColor.LightGray;
                        cell.Style.Font.FontSize = 9.5;
                    }
                }

                // 5. Tổng kết cuối bảng
                int footRow = startRow + 1 + data.Rows.Count;
                ws.Cell(footRow, 1).Value = $"Tổng cộng: {data.Rows.Count} bản ghi";
                ws.Cell(footRow, 1).Style.Font.Bold = true;
                ws.Cell(footRow, 1).Style.Font.Italic = true;

                // Sign
                int signRow = footRow + 2;
                ws.Cell(signRow, totalCols - 1).Value = "Người lập biểu:";
                ws.Cell(signRow, totalCols - 1).Style.Font.Bold = true;
                ws.Cell(signRow + 3, totalCols - 1).Value = "Phan Văn Thắng - 24002545";
                ws.Cell(signRow + 3, totalCols - 1).Style.Font.Bold = true;
                ws.Cell(signRow + 3, totalCols - 1).Style.Font.FontColor = XLColor.FromArgb(24, 76, 120);

                ws.Columns().AdjustToContents();
                wb.SaveAs(filePath);
            }
        }

        /// <summary>
        /// Bài 9: Xuất DataGridView đang hiển thị trực tiếp sang Excel
        /// Giữ nguyên bộ lọc, thứ tự cột, định dạng ngày tháng và số thực
        /// </summary>
        public static void ExportDataGridViewToExcel(DataGridView dgv, string filePath, string title = "Dữ Liệu Đang Lọc")
        {
            if (dgv == null || dgv.Rows.Count == 0)
            {
                throw new InvalidOperationException("DataGridView không có dữ liệu để xuất.");
            }

            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("DuLieuLoc");

                // Tiêu đề
                ws.Cell("A1").Value = title.ToUpper();
                ws.Cell("A1").Style.Font.Bold = true;
                ws.Cell("A1").Style.Font.FontSize = 13;
                ws.Cell("A1").Style.Font.FontColor = XLColor.FromArgb(24, 76, 120);

                ws.Cell("A2").Value = $"Kết xuất từ DataGridView | Thời gian: {DateTime.Now:dd/MM/yyyy HH:mm:ss} | Tổng số dòng: {dgv.Rows.Count}";
                ws.Cell("A2").Style.Font.Italic = true;
                ws.Cell("A2").Style.Font.FontSize = 9.5;
                ws.Cell("A2").Style.Font.FontColor = XLColor.Gray;

                // Header DataGridView
                int colIndex = 1;
                for (int c = 0; c < dgv.Columns.Count; c++)
                {
                    if (dgv.Columns[c].Visible)
                    {
                        var cell = ws.Cell(4, colIndex);
                        cell.Value = dgv.Columns[c].HeaderText;
                        cell.Style.Font.Bold = true;
                        cell.Style.Font.FontColor = XLColor.White;
                        cell.Style.Fill.BackgroundColor = XLColor.FromArgb(30, 100, 160);
                        cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        colIndex++;
                    }
                }

                // Rows
                for (int r = 0; r < dgv.Rows.Count; r++)
                {
                    colIndex = 1;
                    int curRow = 5 + r;

                    for (int c = 0; c < dgv.Columns.Count; c++)
                    {
                        if (dgv.Columns[c].Visible)
                        {
                            var cell = ws.Cell(curRow, colIndex);
                            object val = dgv.Rows[r].Cells[c].Value;

                            if (val == null || val == DBNull.Value)
                            {
                                cell.Value = string.Empty;
                            }
                            else if (val is DateTime dt)
                            {
                                cell.Value = dt.ToString("dd/MM/yyyy");
                                cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            }
                            else if (decimal.TryParse(val.ToString(), out decimal decVal))
                            {
                                cell.Value = (double)decVal;
                                cell.Style.NumberFormat.Format = "#,##0.00";
                                cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                            }
                            else
                            {
                                cell.Value = val.ToString();
                                cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                            }

                            if (r % 2 == 1)
                            {
                                cell.Style.Fill.BackgroundColor = XLColor.FromArgb(248, 250, 252);
                            }
                            cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            cell.Style.Border.OutsideBorderColor = XLColor.LightGray;

                            colIndex++;
                        }
                    }
                }

                ws.Columns().AdjustToContents();
                wb.SaveAs(filePath);
            }
        }

        private static string GetDisplayColumnName(string rawName)
        {
            switch (rawName)
            {
                case "MaSV": return "Mã Sinh Viên";
                case "HoTen": return "Họ và Tên";
                case "NgaySinh": return "Ngày Sinh";
                case "GioiTinh": return "Giới Tính";
                case "MaKhoa": return "Mã Khoa";
                case "TenKhoa": return "Tên Khoa Quản Lý";
                case "DiemTB": return "Điểm Trung Bình";
                case "Email": return "Địa Chỉ Email";
                case "XepLoai": return "Xếp Loại Học Lực";
                case "HocKy": return "Học Kỳ";
                case "MaHP": return "Mã Học Phần";
                case "TenHP": return "Tên Học Phần";
                case "SoTinChi": return "Số Tín Chỉ";
                case "SoLuotDangKy": return "Số Lượt Đăng Ký";
                case "DiemTrungBinhMon": return "Điểm TB Môn";
                case "Diem": return "Điểm Thi";
                case "NgayDangKy": return "Ngày Đăng Ký";
                case "SoLuongSinhVien": return "Số Sinh Viên";
                case "DiemTBKhoa": return "Điểm TB Khoa";
                case "DiemMaxKhoa": return "Điểm Cao Nhất";
                case "DiemMinKhoa": return "Điểm Thấp Nhất";
                default: return rawName;
            }
        }

        private static string GetExcelColumnName(int columnNumber)
        {
            string columnName = "";
            while (columnNumber > 0)
            {
                int modulo = (columnNumber - 1) % 26;
                columnName = Convert.ToChar('A' + modulo) + columnName;
                columnNumber = (columnNumber - modulo) / 26;
            }
            return columnName;
        }
    }
}
