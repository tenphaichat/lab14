using System;
using System.Data;
using System.IO;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace Lab14_AdvancedReport.BUS
{
    public static class PdfExportHelper
    {
        public static void ExportSinhVienTheoKhoaPdf(DataTable data, string filePath, string tenKhoa, DateTime ngayLap, decimal dtb = 0, decimal max = 0, decimal min = 0)
        {
            PdfDocument doc = new PdfDocument();
            doc.Info.Title = $"BÁO CÁO DANH SÁCH SINH VIÊN - KHOA {tenKhoa.ToUpper()}";
            doc.Info.Author = "Phan Văn Thắng - 24002545";

            int rowsPerPage = 20;
            int totalRows = data.Rows.Count;
            int totalPages = (int)Math.Ceiling((double)Math.Max(1, totalRows) / rowsPerPage);

            XFont fontHeaderOrg = new XFont("Arial", 9, XFontStyleEx.Regular);
            XFont fontHeaderBold = new XFont("Arial", 9, XFontStyleEx.Bold);
            XFont fontTitle = new XFont("Arial", 15, XFontStyleEx.Bold);
            XFont fontSubtitle = new XFont("Arial", 9.5, XFontStyleEx.Italic);
            XFont fontTh = new XFont("Arial", 9, XFontStyleEx.Bold);
            XFont fontTd = new XFont("Arial", 8.5, XFontStyleEx.Regular);
            XFont fontFooter = new XFont("Arial", 8.5, XFontStyleEx.Italic);
            XFont fontStat = new XFont("Arial", 9, XFontStyleEx.Bold);

            XPen penBorder = new XPen(XColors.LightGray, 0.7);
            XPen penThBorder = new XPen(XColors.Navy, 1.0);
            XPen penLine = new XPen(XColors.Gray, 0.8);
            XBrush brushThBg = new XSolidBrush(XColor.FromArgb(238, 244, 252));
            XBrush brushText = XBrushes.Black;
            XBrush brushTextBlue = new XSolidBrush(XColor.FromArgb(24, 76, 120));

            for (int p = 0; p < totalPages; p++)
            {
                PdfPage page = doc.AddPage();
                page.Size = PdfSharp.PageSize.A4;
                XGraphics gfx = XGraphics.FromPdfPage(page);

                double left = 35;
                double top = 35;
                double width = page.Width.Point - 70;

                // Header
                gfx.DrawString("TRƯỜNG ĐẠI HỌC CÔNG NGHỆ ĐÔNG Á", fontHeaderBold, brushTextBlue, left, top);
                gfx.DrawString("KHOA CÔNG NGHỆ THÔNG TIN - BỘ MÔN CÔNG NGHỆ PHẦN MỀM", fontHeaderOrg, XBrushes.DarkSlateGray, left, top + 14);

                gfx.DrawString("CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM", fontHeaderBold, brushText, width + left - 210, top);
                gfx.DrawString("Độc lập - Tự do - Hạnh phúc", fontHeaderOrg, brushText, width + left - 175, top + 14);
                gfx.DrawLine(penLine, width + left - 150, top + 18, width + left - 40, top + 18);
                gfx.DrawLine(penLine, left, top + 32, left + width, top + 32);

                // Title
                double titleY = top + 55;
                gfx.DrawString("BÁO CÁO DANH SÁCH SINH VIÊN THEO KHOA", fontTitle, brushTextBlue, new XRect(left, titleY, width, 22), XStringFormats.TopCenter);
                gfx.DrawString($"Tham số khoa: {tenKhoa} | Ngày lập: {ngayLap:dd/MM/yyyy HH:mm}", fontSubtitle, XBrushes.DimGray, new XRect(left, titleY + 20, width, 16), XStringFormats.TopCenter);

                // Group Banner
                double groupY = titleY + 42;
                gfx.DrawRectangle(new XSolidBrush(XColor.FromArgb(230, 240, 250)), left, groupY, width, 20);
                gfx.DrawRectangle(penThBorder, left, groupY, width, 20);
                gfx.DrawString($"▶ Nhóm: {tenKhoa} (Số sinh viên: {totalRows})", fontStat, brushTextBlue, left + 10, groupY + 14);

                // Table Header
                double startY = groupY + 24;
                double[] colWidths = { 35, 60, 115, 65, 45, 80, 50, 75 };
                string[] headers = { "STT", "Mã SV", "Họ và tên", "Ngày sinh", "Giới", "Khoa", "ĐTB", "Xếp loại" };

                double curX = left;
                for (int c = 0; c < headers.Length; c++)
                {
                    gfx.DrawRectangle(brushThBg, curX, startY, colWidths[c], 22);
                    gfx.DrawRectangle(penThBorder, curX, startY, colWidths[c], 22);
                    gfx.DrawString(headers[c], fontTh, brushTextBlue,
                        new XRect(curX + 2, startY + 4, colWidths[c] - 4, 16),
                        c == 0 || c == 1 || c == 3 || c == 4 || c == 6 ? XStringFormats.TopCenter : XStringFormats.TopLeft);
                    curX += colWidths[c];
                }

                // Table Rows
                double curY = startY + 22;
                int startRow = p * rowsPerPage;
                int endRow = Math.Min(startRow + rowsPerPage, totalRows);

                for (int r = startRow; r < endRow; r++)
                {
                    DataRow row = data.Rows[r];
                    curX = left;

                    DateTime ns = row["NgaySinh"] != DBNull.Value ? Convert.ToDateTime(row["NgaySinh"]) : DateTime.MinValue;
                    decimal d = row["DiemTB"] != DBNull.Value ? Convert.ToDecimal(row["DiemTB"]) : 0.0m;
                    string xl = row.Table.Columns.Contains("XepLoai") ? row["XepLoai"]?.ToString() : (d >= 9 ? "Xuất sắc" : d >= 8 ? "Giỏi" : d >= 6.5m ? "Khá" : d >= 5 ? "Trung bình" : "Yếu");

                    string[] vals = {
                        (r + 1).ToString(),
                        row["MaSV"]?.ToString() ?? "",
                        row["HoTen"]?.ToString() ?? "",
                        ns != DateTime.MinValue ? ns.ToString("dd/MM/yyyy") : "",
                        row["GioiTinh"]?.ToString() ?? "",
                        row["TenKhoa"]?.ToString() ?? "",
                        d.ToString("N2"),
                        xl
                    };

                    XBrush rowBg = (r % 2 == 0) ? XBrushes.White : new XSolidBrush(XColor.FromArgb(248, 250, 252));
                    gfx.DrawRectangle(rowBg, curX, curY, width, 19);

                    for (int c = 0; c < vals.Length; c++)
                    {
                        gfx.DrawRectangle(penBorder, curX, curY, colWidths[c], 19);
                        XStringFormat fmt = (c == 0 || c == 1 || c == 3 || c == 4) ? XStringFormats.TopCenter :
                                            (c == 6 ? XStringFormats.TopRight : XStringFormats.TopLeft);

                        gfx.DrawString(vals[c], fontTd, brushText,
                            new XRect(curX + 3, curY + 3.5, colWidths[c] - 6, 14), fmt);
                        curX += colWidths[c];
                    }
                    curY += 19;
                }

                // Statistics & Summary Footer (on last page)
                if (p == totalPages - 1)
                {
                    double statY = curY + 10;
                    gfx.DrawRectangle(new XSolidBrush(XColor.FromArgb(245, 248, 253)), left, statY, width, 26);
                    gfx.DrawRectangle(penThBorder, left, statY, width, 26);

                    string statText = $"Tổng số: {totalRows} sinh viên   |   Điểm trung bình nhóm: {dtb:N2}   |   Cao nhất: {max:N2}   |   Thấp nhất: {min:N2}";
                    gfx.DrawString(statText, fontStat, brushTextBlue, left + 12, statY + 17);

                    double signY = statY + 38;
                    gfx.DrawString("Người lập biểu", fontHeaderBold, brushText, width + left - 130, signY);
                    gfx.DrawString("(Ký, ghi rõ họ tên)", fontSubtitle, XBrushes.Gray, width + left - 145, signY + 14);
                    gfx.DrawString("Phan Văn Thắng", fontHeaderBold, brushTextBlue, width + left - 135, signY + 50);
                }

                // Page numbering (Page N / M)
                string pageInfo = $"Trang {p + 1} / {totalPages}";
                gfx.DrawString(pageInfo, fontFooter, XBrushes.Gray, new XRect(left, page.Height.Point - 30, width, 15), XStringFormats.TopCenter);
                gfx.DrawString("Học phần: Lập trình .NET (IT3212) - EAUT", fontFooter, XBrushes.Gray, left, page.Height.Point - 30);
            }

            doc.Save(filePath);
        }

        public static void ExportKhoangDiemPdf(DataTable data, string filePath, decimal minScore, decimal maxScore, string tenKhoa = "Tất cả")
        {
            PdfDocument doc = new PdfDocument();
            doc.Info.Title = $"BÁO CÁO SINH VIÊN THEO KHOẢNG ĐIỂM [{minScore:N1} - {maxScore:N1}]";
            doc.Info.Author = "Phan Văn Thắng - 24002545";

            PdfPage page = doc.AddPage();
            page.Size = PdfSharp.PageSize.A4;
            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont fontHeaderOrg = new XFont("Arial", 9, XFontStyleEx.Regular);
            XFont fontHeaderBold = new XFont("Arial", 9, XFontStyleEx.Bold);
            XFont fontTitle = new XFont("Arial", 15, XFontStyleEx.Bold);
            XFont fontSubtitle = new XFont("Arial", 9.5, XFontStyleEx.Italic);
            XFont fontTh = new XFont("Arial", 9, XFontStyleEx.Bold);
            XFont fontTd = new XFont("Arial", 8.5, XFontStyleEx.Regular);
            XFont fontFooter = new XFont("Arial", 8.5, XFontStyleEx.Italic);

            XPen penBorder = new XPen(XColors.LightGray, 0.7);
            XPen penThBorder = new XPen(XColors.Navy, 1.0);
            XPen penLine = new XPen(XColors.Gray, 0.8);
            XBrush brushThBg = new XSolidBrush(XColor.FromArgb(238, 244, 252));
            XBrush brushText = XBrushes.Black;
            XBrush brushTextBlue = new XSolidBrush(XColor.FromArgb(24, 76, 120));

            double left = 35;
            double top = 35;
            double width = page.Width.Point - 70;

            // Header
            gfx.DrawString("TRƯỜNG ĐẠI HỌC CÔNG NGHỆ ĐÔNG Á", fontHeaderBold, brushTextBlue, left, top);
            gfx.DrawString("KHOA CÔNG NGHỆ THÔNG TIN - LẬP TRÌNH .NET (IT3212)", fontHeaderOrg, XBrushes.DarkSlateGray, left, top + 14);

            gfx.DrawString("CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM", fontHeaderBold, brushText, width + left - 210, top);
            gfx.DrawString("Độc lập - Tự do - Hạnh phúc", fontHeaderOrg, brushText, width + left - 175, top + 14);
            gfx.DrawLine(penLine, width + left - 150, top + 18, width + left - 40, top + 18);
            gfx.DrawLine(penLine, left, top + 32, left + width, top + 32);

            // Title
            double titleY = top + 55;
            gfx.DrawString("BÁO CÁO SINH VIÊN THEO KHOẢNG ĐIỂM", fontTitle, brushTextBlue, new XRect(left, titleY, width, 22), XStringFormats.TopCenter);
            gfx.DrawString($"Khoảng điểm: từ {minScore:N1} đến {maxScore:N1} điểm | Khoa: {tenKhoa} | Ngày lập: {DateTime.Now:dd/MM/yyyy HH:mm}", fontSubtitle, XBrushes.DimGray, new XRect(left, titleY + 20, width, 16), XStringFormats.TopCenter);

            // Table Header
            double startY = titleY + 45;
            double[] colWidths = { 35, 60, 115, 65, 45, 80, 50, 75 };
            string[] headers = { "STT", "Mã SV", "Họ và tên", "Ngày sinh", "Giới", "Khoa", "ĐTB", "Xếp loại" };

            double curX = left;
            for (int c = 0; c < headers.Length; c++)
            {
                gfx.DrawRectangle(brushThBg, curX, startY, colWidths[c], 22);
                gfx.DrawRectangle(penThBorder, curX, startY, colWidths[c], 22);
                gfx.DrawString(headers[c], fontTh, brushTextBlue,
                    new XRect(curX + 2, startY + 4, colWidths[c] - 4, 16),
                    c == 0 || c == 1 || c == 3 || c == 4 || c == 6 ? XStringFormats.TopCenter : XStringFormats.TopLeft);
                curX += colWidths[c];
            }

            // Table Rows
            double curY = startY + 22;
            int maxRows = Math.Min(data.Rows.Count, 22);

            for (int r = 0; r < maxRows; r++)
            {
                DataRow row = data.Rows[r];
                curX = left;

                DateTime ns = row["NgaySinh"] != DBNull.Value ? Convert.ToDateTime(row["NgaySinh"]) : DateTime.MinValue;
                decimal d = row["DiemTB"] != DBNull.Value ? Convert.ToDecimal(row["DiemTB"]) : 0.0m;
                string xl = row.Table.Columns.Contains("XepLoai") ? row["XepLoai"]?.ToString() : (d >= 9 ? "Xuất sắc" : d >= 8 ? "Giỏi" : d >= 6.5m ? "Khá" : d >= 5 ? "Trung bình" : "Yếu");

                string[] vals = {
                    (r + 1).ToString(),
                    row["MaSV"]?.ToString() ?? "",
                    row["HoTen"]?.ToString() ?? "",
                    ns != DateTime.MinValue ? ns.ToString("dd/MM/yyyy") : "",
                    row["GioiTinh"]?.ToString() ?? "",
                    row["TenKhoa"]?.ToString() ?? "",
                    d.ToString("N2"),
                    xl
                };

                XBrush rowBg = (r % 2 == 0) ? XBrushes.White : new XSolidBrush(XColor.FromArgb(248, 250, 252));
                gfx.DrawRectangle(rowBg, curX, curY, width, 19);

                for (int c = 0; c < vals.Length; c++)
                {
                    gfx.DrawRectangle(penBorder, curX, curY, colWidths[c], 19);
                    XStringFormat fmt = (c == 0 || c == 1 || c == 3 || c == 4) ? XStringFormats.TopCenter :
                                        (c == 6 ? XStringFormats.TopRight : XStringFormats.TopLeft);

                    gfx.DrawString(vals[c], fontTd, brushText,
                        new XRect(curX + 3, curY + 3.5, colWidths[c] - 6, 14), fmt);
                    curX += colWidths[c];
                }
                curY += 19;
            }

            // Summary
            double sumY = curY + 12;
            gfx.DrawString($"Tổng cộng trong khoảng điểm: {data.Rows.Count} sinh viên", fontTh, brushTextBlue, left, sumY);

            double signY = sumY + 25;
            gfx.DrawString("Người lập biểu", fontHeaderBold, brushText, width + left - 130, signY);
            gfx.DrawString("(Ký, ghi rõ họ tên)", fontSubtitle, XBrushes.Gray, width + left - 145, signY + 14);
            gfx.DrawString("Phan Văn Thắng", fontHeaderBold, brushTextBlue, width + left - 135, signY + 50);

            gfx.DrawString("Trang 1 / 1", fontFooter, XBrushes.Gray, new XRect(left, page.Height.Point - 30, width, 15), XStringFormats.TopCenter);
            doc.Save(filePath);
        }

        public static void ExportTopNPdf(DataTable data, string filePath, int topN, string tenKhoa = "Tất cả")
        {
            PdfDocument doc = new PdfDocument();
            doc.Info.Title = $"BÁO CÁO TOP {topN} SINH VIÊN XUẤT SẮC";
            doc.Info.Author = "Phan Văn Thắng - 24002545";

            PdfPage page = doc.AddPage();
            page.Size = PdfSharp.PageSize.A4;
            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont fontHeaderOrg = new XFont("Arial", 9, XFontStyleEx.Regular);
            XFont fontHeaderBold = new XFont("Arial", 9, XFontStyleEx.Bold);
            XFont fontTitle = new XFont("Arial", 15, XFontStyleEx.Bold);
            XFont fontSubtitle = new XFont("Arial", 9.5, XFontStyleEx.Italic);
            XFont fontTh = new XFont("Arial", 9, XFontStyleEx.Bold);
            XFont fontTd = new XFont("Arial", 8.5, XFontStyleEx.Regular);
            XFont fontFooter = new XFont("Arial", 8.5, XFontStyleEx.Italic);

            XPen penBorder = new XPen(XColors.LightGray, 0.7);
            XPen penThBorder = new XPen(XColors.Navy, 1.0);
            XPen penLine = new XPen(XColors.Gray, 0.8);
            XBrush brushThBg = new XSolidBrush(XColor.FromArgb(238, 244, 252));
            XBrush brushText = XBrushes.Black;
            XBrush brushTextBlue = new XSolidBrush(XColor.FromArgb(24, 76, 120));

            double left = 35;
            double top = 35;
            double width = page.Width.Point - 70;

            // Header
            gfx.DrawString("TRƯỜNG ĐẠI HỌC CÔNG NGHỆ ĐÔNG Á", fontHeaderBold, brushTextBlue, left, top);
            gfx.DrawString("KHOA CÔNG NGHỆ THÔNG TIN - LẬP TRÌNH .NET (IT3212)", fontHeaderOrg, XBrushes.DarkSlateGray, left, top + 14);

            gfx.DrawString("CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM", fontHeaderBold, brushText, width + left - 210, top);
            gfx.DrawString("Độc lập - Tự do - Hạnh phúc", fontHeaderOrg, brushText, width + left - 175, top + 14);
            gfx.DrawLine(penLine, width + left - 150, top + 18, width + left - 40, top + 18);
            gfx.DrawLine(penLine, left, top + 32, left + width, top + 32);

            // Title
            double titleY = top + 55;
            gfx.DrawString($"BÁO CÁO TOP {topN} SINH VIÊN TIÊU BIỂU", fontTitle, brushTextBlue, new XRect(left, titleY, width, 22), XStringFormats.TopCenter);
            gfx.DrawString($"Phạm vi: {tenKhoa} | Sắp xếp theo Điểm TB giảm dần | Ngày lập: {DateTime.Now:dd/MM/yyyy HH:mm}", fontSubtitle, XBrushes.DimGray, new XRect(left, titleY + 20, width, 16), XStringFormats.TopCenter);

            // Table Header
            double startY = titleY + 45;
            double[] colWidths = { 40, 65, 125, 70, 50, 90, 55, 75 };
            string[] headers = { "Hạng", "Mã SV", "Họ và tên", "Ngày sinh", "Giới", "Khoa", "ĐTB", "Xếp loại" };

            double curX = left;
            for (int c = 0; c < headers.Length; c++)
            {
                gfx.DrawRectangle(brushThBg, curX, startY, colWidths[c], 22);
                gfx.DrawRectangle(penThBorder, curX, startY, colWidths[c], 22);
                gfx.DrawString(headers[c], fontTh, brushTextBlue,
                    new XRect(curX + 2, startY + 4, colWidths[c] - 4, 16),
                    c == 0 || c == 1 || c == 3 || c == 4 || c == 6 ? XStringFormats.TopCenter : XStringFormats.TopLeft);
                curX += colWidths[c];
            }

            // Table Rows
            double curY = startY + 22;
            int count = Math.Min(data.Rows.Count, topN);

            for (int r = 0; r < count; r++)
            {
                DataRow row = data.Rows[r];
                curX = left;

                DateTime ns = row["NgaySinh"] != DBNull.Value ? Convert.ToDateTime(row["NgaySinh"]) : DateTime.MinValue;
                decimal d = row["DiemTB"] != DBNull.Value ? Convert.ToDecimal(row["DiemTB"]) : 0.0m;
                string xl = row.Table.Columns.Contains("XepLoai") ? row["XepLoai"]?.ToString() : (d >= 9 ? "Xuất sắc" : d >= 8 ? "Giỏi" : d >= 6.5m ? "Khá" : d >= 5 ? "Trung bình" : "Yếu");

                string rank = $"Top {r + 1}";
                string[] vals = {
                    rank,
                    row["MaSV"]?.ToString() ?? "",
                    row["HoTen"]?.ToString() ?? "",
                    ns != DateTime.MinValue ? ns.ToString("dd/MM/yyyy") : "",
                    row["GioiTinh"]?.ToString() ?? "",
                    row["TenKhoa"]?.ToString() ?? "",
                    d.ToString("N2"),
                    xl
                };

                XBrush rowBg = (r == 0) ? new XSolidBrush(XColor.FromArgb(255, 250, 235)) : (r % 2 == 0 ? XBrushes.White : new XSolidBrush(XColor.FromArgb(248, 250, 252)));
                gfx.DrawRectangle(rowBg, curX, curY, width, 20);

                for (int c = 0; c < vals.Length; c++)
                {
                    gfx.DrawRectangle(penBorder, curX, curY, colWidths[c], 20);
                    XStringFormat fmt = (c == 0 || c == 1 || c == 3 || c == 4) ? XStringFormats.TopCenter :
                                        (c == 6 ? XStringFormats.TopRight : XStringFormats.TopLeft);

                    XFont rowFont = (r == 0 && c == 0) ? fontTh : fontTd;
                    XBrush textB = (r == 0 && c == 0) ? new XSolidBrush(XColor.FromArgb(180, 80, 0)) : brushText;

                    gfx.DrawString(vals[c], rowFont, textB,
                        new XRect(curX + 3, curY + 4, colWidths[c] - 6, 14), fmt);
                    curX += colWidths[c];
                }
                curY += 20;
            }

            double sumY = curY + 15;
            gfx.DrawString($"Đã vinh danh Top {count} sinh viên có thành tích học tập xuất sắc nhất.", fontTh, brushTextBlue, left, sumY);

            double signY = sumY + 25;
            gfx.DrawString("Người lập biểu", fontHeaderBold, brushText, width + left - 130, signY);
            gfx.DrawString("(Ký, ghi rõ họ tên)", fontSubtitle, XBrushes.Gray, width + left - 145, signY + 14);
            gfx.DrawString("Phan Văn Thắng", fontHeaderBold, brushTextBlue, width + left - 135, signY + 50);

            gfx.DrawString("Trang 1 / 1", fontFooter, XBrushes.Gray, new XRect(left, page.Height.Point - 30, width, 15), XStringFormats.TopCenter);
            doc.Save(filePath);
        }

        public static void ExportDangKyHocKyPdf(DataTable data, string filePath, int? hocKy = null)
        {
            PdfDocument doc = new PdfDocument();
            doc.Info.Title = "BÁO CÁO TỔNG HỢP ĐĂNG KÝ HỌC PHẦN THEO HỌC KỲ";
            doc.Info.Author = "Phan Văn Thắng - 24002545";

            PdfPage page = doc.AddPage();
            page.Size = PdfSharp.PageSize.A4;
            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont fontHeaderOrg = new XFont("Arial", 9, XFontStyleEx.Regular);
            XFont fontHeaderBold = new XFont("Arial", 9, XFontStyleEx.Bold);
            XFont fontTitle = new XFont("Arial", 15, XFontStyleEx.Bold);
            XFont fontSubtitle = new XFont("Arial", 9.5, XFontStyleEx.Italic);
            XFont fontTh = new XFont("Arial", 9, XFontStyleEx.Bold);
            XFont fontTd = new XFont("Arial", 8.5, XFontStyleEx.Regular);
            XFont fontFooter = new XFont("Arial", 8.5, XFontStyleEx.Italic);

            XPen penBorder = new XPen(XColors.LightGray, 0.7);
            XPen penThBorder = new XPen(XColors.Navy, 1.0);
            XPen penLine = new XPen(XColors.Gray, 0.8);
            XBrush brushThBg = new XSolidBrush(XColor.FromArgb(238, 244, 252));
            XBrush brushText = XBrushes.Black;
            XBrush brushTextBlue = new XSolidBrush(XColor.FromArgb(24, 76, 120));

            double left = 35;
            double top = 35;
            double width = page.Width.Point - 70;

            // Header
            gfx.DrawString("TRƯỜNG ĐẠI HỌC CÔNG NGHỆ ĐÔNG Á", fontHeaderBold, brushTextBlue, left, top);
            gfx.DrawString("KHOA CÔNG NGHỆ THÔNG TIN - LẬP TRÌNH .NET (IT3212)", fontHeaderOrg, XBrushes.DarkSlateGray, left, top + 14);

            gfx.DrawString("CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM", fontHeaderBold, brushText, width + left - 210, top);
            gfx.DrawString("Độc lập - Tự do - Hạnh phúc", fontHeaderOrg, brushText, width + left - 175, top + 14);
            gfx.DrawLine(penLine, width + left - 150, top + 18, width + left - 40, top + 18);
            gfx.DrawLine(penLine, left, top + 32, left + width, top + 32);

            // Title
            double titleY = top + 55;
            string hkStr = hocKy.HasValue && hocKy.Value > 0 ? $"HỌC KỲ {hocKy.Value}" : "TẤT CẢ CÁC HỌC KỲ";
            gfx.DrawString("BÁO CÁO THỐNG KÊ ĐĂNG KÝ HỌC PHẦN THEO HỌC KỲ", fontTitle, brushTextBlue, new XRect(left, titleY, width, 22), XStringFormats.TopCenter);
            gfx.DrawString($"Phạm vi: {hkStr} | Thời điểm trích xuất: {DateTime.Now:dd/MM/yyyy HH:mm}", fontSubtitle, XBrushes.DimGray, new XRect(left, titleY + 20, width, 16), XStringFormats.TopCenter);

            // Table Header
            double startY = titleY + 45;
            double[] colWidths = { 45, 60, 80, 185, 65, 85, 80 };
            string[] headers = { "STT", "Học kỳ", "Mã HP", "Tên học phần", "Tín chỉ", "Lượt đăng ký", "ĐTB môn" };

            double curX = left;
            for (int c = 0; c < headers.Length; c++)
            {
                gfx.DrawRectangle(brushThBg, curX, startY, colWidths[c], 22);
                gfx.DrawRectangle(penThBorder, curX, startY, colWidths[c], 22);
                gfx.DrawString(headers[c], fontTh, brushTextBlue,
                    new XRect(curX + 2, startY + 4, colWidths[c] - 4, 16),
                    c <= 2 ? XStringFormats.TopCenter : (c >= 4 ? XStringFormats.TopRight : XStringFormats.TopLeft));
                curX += colWidths[c];
            }

            // Table Rows
            double curY = startY + 22;
            int totalLuot = 0;

            for (int r = 0; r < data.Rows.Count; r++)
            {
                DataRow row = data.Rows[r];
                curX = left;

                int sldk = row["SoLuotDangKy"] != DBNull.Value ? Convert.ToInt32(row["SoLuotDangKy"]) : 0;
                totalLuot += sldk;
                decimal dtbMon = row["DiemTrungBinhMon"] != DBNull.Value ? Convert.ToDecimal(row["DiemTrungBinhMon"]) : 0.0m;

                string[] vals = {
                    (r + 1).ToString(),
                    $"HK {row["HocKy"]}",
                    row["MaHP"]?.ToString() ?? "",
                    row["TenHP"]?.ToString() ?? "",
                    row["SoTinChi"]?.ToString() ?? "3",
                    sldk.ToString("N0"),
                    dtbMon.ToString("N2")
                };

                XBrush rowBg = (r % 2 == 0) ? XBrushes.White : new XSolidBrush(XColor.FromArgb(248, 250, 252));
                gfx.DrawRectangle(rowBg, curX, curY, width, 20);

                for (int c = 0; c < vals.Length; c++)
                {
                    gfx.DrawRectangle(penBorder, curX, curY, colWidths[c], 20);
                    XStringFormat fmt = c <= 2 ? XStringFormats.TopCenter : (c >= 4 ? XStringFormats.TopRight : XStringFormats.TopLeft);

                    gfx.DrawString(vals[c], fontTd, brushText,
                        new XRect(curX + 3, curY + 4, colWidths[c] - 6, 14), fmt);
                    curX += colWidths[c];
                }
                curY += 20;
            }

            // Summary
            double sumY = curY + 15;
            gfx.DrawString($"Tổng cộng: {data.Rows.Count} học phần đào tạo   |   Tổng số lượt sinh viên đăng ký: {totalLuot} lượt", fontTh, brushTextBlue, left, sumY);

            double signY = sumY + 25;
            gfx.DrawString("Người lập biểu", fontHeaderBold, brushText, width + left - 130, signY);
            gfx.DrawString("(Ký, ghi rõ họ tên)", fontSubtitle, XBrushes.Gray, width + left - 145, signY + 14);
            gfx.DrawString("Phan Văn Thắng", fontHeaderBold, brushTextBlue, width + left - 135, signY + 50);

            gfx.DrawString("Trang 1 / 1", fontFooter, XBrushes.Gray, new XRect(left, page.Height.Point - 30, width, 15), XStringFormats.TopCenter);
            doc.Save(filePath);
        }
    }
}
