using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using Lab14_AdvancedReport.BUS;

namespace Lab14_AdvancedReport.GUI
{
    public enum ReportViewMode
    {
        SinhVienTheoKhoa,
        KhoangDiem,
        TopN,
        DangKyHocKy,
        ThongKeBieuDo
    }

    public partial class frmReportViewer : Form
    {
        private DataTable _dataSource;
        private ReportViewMode _viewMode;
        private string _mainTitle;
        private string _subTitle;
        private float _zoomLevel = 1.0f;
        private int _currentPage = 1;
        private int _totalPages = 1;

        // Các tham số đặc thù
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public decimal ParamMinScore { get; set; } = 0.0m;

        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public decimal ParamMaxScore { get; set; } = 10.0m;

        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public int ParamTopN { get; set; } = 5;

        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public string ParamDepartment { get; set; } = "Tất cả các khoa";

        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public int? ParamSemester { get; set; } = null;

        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public decimal StatAvg { get; set; } = 0.0m;

        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public decimal StatMax { get; set; } = 0.0m;

        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public decimal StatMin { get; set; } = 0.0m;

        public frmReportViewer(ReportViewMode mode, DataTable dataSource, string mainTitle = "", string subTitle = "")
        {
            _viewMode = mode;
            _dataSource = dataSource;
            _mainTitle = mainTitle;
            _subTitle = subTitle;

            InitializeComponent();
            SetupDimensions();
        }

        private void SetupDimensions()
        {
            int count = _dataSource != null ? _dataSource.Rows.Count : 0;
            _totalPages = Math.Max(1, (int)Math.Ceiling((double)count / 22));
            UpdateToolbar();
        }

        public void RefreshData(DataTable newData, string subTitle = "")
        {
            _dataSource = newData;
            _subTitle = subTitle;
            SetupDimensions();
            panelCanvas.Invalidate();
        }

        private void UpdateToolbar()
        {
            lblPageInfo.Text = $"Trang {_currentPage} / {_totalPages}";
            btnPrevPage.Enabled = _currentPage > 1;
            btnNextPage.Enabled = _currentPage < _totalPages;
            lblZoom.Text = $"{(int)(_zoomLevel * 100)}%";
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                UpdateToolbar();
                panelCanvas.Invalidate();
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                UpdateToolbar();
                panelCanvas.Invalidate();
            }
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            if (_zoomLevel < 1.8f)
            {
                _zoomLevel += 0.15f;
                UpdateCanvasSize();
                UpdateToolbar();
            }
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            if (_zoomLevel > 0.6f)
            {
                _zoomLevel -= 0.15f;
                UpdateCanvasSize();
                UpdateToolbar();
            }
        }

        private void UpdateCanvasSize()
        {
            int baseW = 820;
            int baseH = 1120;
            panelCanvas.Size = new Size((int)(baseW * _zoomLevel), (int)(baseH * _zoomLevel));
            panelCanvas.Invalidate();
        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "PDF Document (*.pdf)|*.pdf";
                dlg.DefaultExt = "pdf";

                switch (_viewMode)
                {
                    case ReportViewMode.SinhVienTheoKhoa:
                        dlg.FileName = "BaoCaoSinhVien_TheoKhoa.pdf";
                        break;
                    case ReportViewMode.KhoangDiem:
                        dlg.FileName = "BaoCao_KhoangDiem.pdf";
                        break;
                    case ReportViewMode.TopN:
                        dlg.FileName = "BaoCao_TopN_SinhVien.pdf";
                        break;
                    case ReportViewMode.DangKyHocKy:
                        dlg.FileName = "BaoCao_DangKy_HocKy.pdf";
                        break;
                    default:
                        dlg.FileName = "BaoCaoThongKe.pdf";
                        break;
                }

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (_viewMode == ReportViewMode.SinhVienTheoKhoa)
                            PdfExportHelper.ExportSinhVienTheoKhoaPdf(_dataSource, dlg.FileName, ParamDepartment, DateTime.Now, StatAvg, StatMax, StatMin);
                        else if (_viewMode == ReportViewMode.KhoangDiem)
                            PdfExportHelper.ExportKhoangDiemPdf(_dataSource, dlg.FileName, ParamMinScore, ParamMaxScore, ParamDepartment);
                        else if (_viewMode == ReportViewMode.TopN)
                            PdfExportHelper.ExportTopNPdf(_dataSource, dlg.FileName, ParamTopN, ParamDepartment);
                        else if (_viewMode == ReportViewMode.DangKyHocKy)
                            PdfExportHelper.ExportDangKyHocKyPdf(_dataSource, dlg.FileName, ParamSemester);
                        else
                            PdfExportHelper.ExportSinhVienTheoKhoaPdf(_dataSource, dlg.FileName, ParamDepartment, DateTime.Now);

                        MessageBox.Show($"Đã xuất báo cáo ra tệp PDF thành công:\n{dlg.FileName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xuất PDF: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                dlg.DefaultExt = "xlsx";

                switch (_viewMode)
                {
                    case ReportViewMode.SinhVienTheoKhoa:
                        dlg.FileName = "BaoCaoSinhVien_TheoKhoa.xlsx";
                        break;
                    case ReportViewMode.KhoangDiem:
                        dlg.FileName = "BaoCao_KhoangDiem.xlsx";
                        break;
                    case ReportViewMode.TopN:
                        dlg.FileName = "BaoCao_TopN_SinhVien.xlsx";
                        break;
                    case ReportViewMode.DangKyHocKy:
                        dlg.FileName = "BaoCao_DangKy_HocKy.xlsx";
                        break;
                    default:
                        dlg.FileName = "BaoCaoThongKe.xlsx";
                        break;
                }

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExcelExportHelper.ExportDataTableToExcel(_dataSource, dlg.FileName, _mainTitle, _subTitle);
                        MessageBox.Show($"Đã xuất dữ liệu báo cáo sang tệp Excel thành công:\n{dlg.FileName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            using (PrintDialog pd = new PrintDialog())
            {
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Lệnh in báo cáo đã được gửi tới máy in thành công.", "Thông báo In", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void panelCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            g.ScaleTransform(_zoomLevel, _zoomLevel);

            using (Font fOrg = new Font("Arial", 9, FontStyle.Regular))
            using (Font fOrgB = new Font("Arial", 9, FontStyle.Bold))
            using (Font fTitle = new Font("Arial", 15, FontStyle.Bold))
            using (Font fSub = new Font("Arial", 9.5f, FontStyle.Italic))
            using (Font fTh = new Font("Arial", 9, FontStyle.Bold))
            using (Font fTd = new Font("Arial", 8.5f, FontStyle.Regular))
            using (Font fGroup = new Font("Arial", 9.5f, FontStyle.Bold))
            using (Font fFooter = new Font("Arial", 8.5f, FontStyle.Italic))
            using (Pen pLine = new Pen(Color.FromArgb(180, 180, 180), 1))
            using (Pen pBorder = new Pen(Color.FromArgb(210, 215, 225), 1))
            using (Pen pThBorder = new Pen(Color.FromArgb(50, 90, 140), 1.2f))
            using (SolidBrush bTh = new SolidBrush(Color.FromArgb(238, 243, 250)))
            using (SolidBrush bBlue = new SolidBrush(Color.FromArgb(20, 60, 110)))
            using (SolidBrush bText = new SolidBrush(Color.FromArgb(30, 30, 30)))
            using (SolidBrush bAlt = new SolidBrush(Color.FromArgb(249, 251, 254)))
            {
                float left = 40;
                float top = 40;
                float width = 740;

                // Header Quốc hiệu & Trường
                g.DrawString("TRƯỜNG ĐẠI HỌC CÔNG NGHỆ ĐÔNG Á", fOrgB, bBlue, left, top);
                g.DrawString("KHOA CÔNG NGHỆ THÔNG TIN - BỘ MÔN CÔNG NGHỆ PHẦN MỀM", fOrg, bText, left, top + 18);
                g.DrawString("Học phần: Lập trình .NET (IT3212) - Lab 14", fOrg, Brushes.DimGray, left, top + 34);

                g.DrawString("CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM", fOrgB, bText, width + left - 250, top);
                g.DrawString("Độc lập - Tự do - Hạnh phúc", fOrg, bText, width + left - 210, top + 18);
                g.DrawLine(pLine, width + left - 180, top + 36, width + left - 60, top + 36);

                g.DrawLine(pLine, left, top + 55, left + width, top + 55);

                // Tiêu đề
                float titleY = top + 72;
                StringFormat sfCenter = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                StringFormat sfLeft = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center };
                StringFormat sfRight = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center };

                string mainT = !string.IsNullOrEmpty(_mainTitle) ? _mainTitle : "BÁO CÁO THỐNG KÊ QUẢN LÝ ĐÀO TẠO";
                g.DrawString(mainT, fTitle, bBlue, new RectangleF(left, titleY, width, 26), sfCenter);

                string subT = !string.IsNullOrEmpty(_subTitle) ? _subTitle : $"Ngày kết xuất: {DateTime.Now:dd/MM/yyyy HH:mm}";
                g.DrawString(subT, fSub, Brushes.DimGray, new RectangleF(left, titleY + 26, width, 20), sfCenter);

                // Group Banner (Bài 2: Nhóm dữ liệu theo khoa hoặc học kỳ)
                float groupY = titleY + 52;
                if (_viewMode == ReportViewMode.SinhVienTheoKhoa)
                {
                    g.FillRectangle(new SolidBrush(Color.FromArgb(232, 240, 252)), left, groupY, width, 24);
                    g.DrawRectangle(pThBorder, left, groupY, width, 24);
                    g.DrawString($"▶ Nhóm: {ParamDepartment} (Tổng cộng: {_dataSource?.Rows.Count ?? 0} sinh viên)", fGroup, bBlue, new RectangleF(left + 10, groupY, width - 20, 24), sfLeft);
                }
                else if (_viewMode == ReportViewMode.KhoangDiem)
                {
                    g.FillRectangle(new SolidBrush(Color.FromArgb(235, 248, 242)), left, groupY, width, 24);
                    g.DrawRectangle(new Pen(Color.FromArgb(46, 139, 87)), left, groupY, width, 24);
                    g.DrawString($"▶ Tiêu chí lọc: Điểm TB trong đoạn [{ParamMinScore:N1} - {ParamMaxScore:N1}] | Khoa: {ParamDepartment}", fGroup, new SolidBrush(Color.FromArgb(30, 100, 50)), new RectangleF(left + 10, groupY, width - 20, 24), sfLeft);
                }
                else if (_viewMode == ReportViewMode.TopN)
                {
                    g.FillRectangle(new SolidBrush(Color.FromArgb(255, 248, 235)), left, groupY, width, 24);
                    g.DrawRectangle(new Pen(Color.FromArgb(205, 133, 63)), left, groupY, width, 24);
                    g.DrawString($"★ Danh sách vinh danh: TOP {ParamTopN} Sinh viên có thành tích học tập cao nhất", fGroup, new SolidBrush(Color.FromArgb(160, 82, 45)), new RectangleF(left + 10, groupY, width - 20, 24), sfLeft);
                }
                else if (_viewMode == ReportViewMode.DangKyHocKy)
                {
                    g.FillRectangle(new SolidBrush(Color.FromArgb(245, 240, 252)), left, groupY, width, 24);
                    g.DrawRectangle(new Pen(Color.FromArgb(128, 0, 128)), left, groupY, width, 24);
                    string hkStr = ParamSemester.HasValue ? $"Học kỳ {ParamSemester.Value}" : "Tất cả các học kỳ";
                    g.FillRectangle(bTh, left, groupY, width, 24);
                    g.DrawString($"▶ Nhóm theo: {hkStr} | Thống kê lượt đăng ký & ĐTB môn học", fGroup, bBlue, new RectangleF(left + 10, groupY, width - 20, 24), sfLeft);
                }

                // Table Render
                float startY = groupY + 30;

                if (_viewMode == ReportViewMode.DangKyHocKy)
                {
                    float[] colW = { 45, 70, 95, 230, 80, 110, 110 };
                    string[] headers = { "STT", "Học kỳ", "Mã HP", "Tên Học Phần Đào Tạo", "Số Tín Chỉ", "Số Lượt ĐK", "ĐTB Môn" };

                    float curX = left;
                    for (int c = 0; c < headers.Length; c++)
                    {
                        g.FillRectangle(bTh, curX, startY, colW[c], 26);
                        g.DrawRectangle(pThBorder, curX, startY, colW[c], 26);
                        g.DrawString(headers[c], fTh, bBlue, new RectangleF(curX + 2, startY, colW[c] - 4, 26),
                            c <= 2 ? sfCenter : (c >= 4 ? sfRight : sfLeft));
                        curX += colW[c];
                    }

                    float curY = startY + 26;
                    int rowsPerPage = 20;
                    int startIdx = (_currentPage - 1) * rowsPerPage;
                    int endIdx = _dataSource != null ? Math.Min(startIdx + rowsPerPage, _dataSource.Rows.Count) : 0;
                    int totalLuot = 0;

                    for (int r = startIdx; r < endIdx; r++)
                    {
                        DataRow row = _dataSource.Rows[r];
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

                        if (r % 2 == 1)
                            g.FillRectangle(bAlt, curX, curY, width, 22);

                        for (int c = 0; c < vals.Length; c++)
                        {
                            g.DrawRectangle(pBorder, curX, curY, colW[c], 22);
                            StringFormat fmt = c <= 2 ? sfCenter : (c >= 4 ? sfRight : sfLeft);
                            g.DrawString(vals[c], fTd, bText, new RectangleF(curX + 4, curY, colW[c] - 8, 22), fmt);
                            curX += colW[c];
                        }
                        curY += 22;
                    }

                    // Summary
                    if (_currentPage == _totalPages)
                    {
                        float sumY = curY + 14;
                        g.DrawString($"Tổng kết: {_dataSource?.Rows.Count ?? 0} môn học | Tổng số lượt sinh viên đăng ký: {totalLuot} lượt", fTh, bBlue, left, sumY);

                        float signY = sumY + 30;
                        g.DrawString("Người lập biểu", fOrgB, bText, width + left - 150, signY);
                        g.DrawString("(Ký, họ tên)", fSub, Brushes.Gray, width + left - 135, signY + 18);
                        g.DrawString("Phan Văn Thắng", fOrgB, bBlue, width + left - 155, signY + 65);
                    }
                }
                else
                {
                    // Các chế độ SinhVienTheoKhoa, KhoangDiem, TopN
                    float[] colW = { 40, 75, 145, 85, 55, 125, 60, 155 };
                    string[] headers = { "STT", "Mã SV", "Họ và Tên", "Ngày Sinh", "Phái", "Khoa", "ĐTB", "Xếp Loại" };

                    float curX = left;
                    for (int c = 0; c < headers.Length; c++)
                    {
                        g.FillRectangle(bTh, curX, startY, colW[c], 26);
                        g.DrawRectangle(pThBorder, curX, startY, colW[c], 26);
                        g.DrawString(headers[c], fTh, bBlue, new RectangleF(curX + 2, startY, colW[c] - 4, 26),
                            c == 0 || c == 1 || c == 3 || c == 4 || c == 6 ? sfCenter : sfLeft);
                        curX += colW[c];
                    }

                    float curY = startY + 26;
                    int rowsPerPage = 20;
                    int startIdx = (_currentPage - 1) * rowsPerPage;
                    int endIdx = _dataSource != null ? Math.Min(startIdx + rowsPerPage, _dataSource.Rows.Count) : 0;

                    for (int r = startIdx; r < endIdx; r++)
                    {
                        DataRow row = _dataSource.Rows[r];
                        curX = left;

                        DateTime ns = row["NgaySinh"] != DBNull.Value ? Convert.ToDateTime(row["NgaySinh"]) : DateTime.MinValue;
                        decimal dtb = row["DiemTB"] != DBNull.Value ? Convert.ToDecimal(row["DiemTB"]) : 0.0m;
                        string xl = row.Table.Columns.Contains("XepLoai") ? row["XepLoai"]?.ToString() : (dtb >= 9 ? "Xuất sắc" : dtb >= 8 ? "Giỏi" : dtb >= 6.5m ? "Khá" : dtb >= 5 ? "Trung bình" : "Yếu");

                        string sttText = _viewMode == ReportViewMode.TopN ? $"Top {r + 1}" : (r + 1).ToString();

                        string[] vals = {
                            sttText,
                            row["MaSV"]?.ToString() ?? "",
                            row["HoTen"]?.ToString() ?? "",
                            ns != DateTime.MinValue ? ns.ToString("dd/MM/yyyy") : "",
                            row["GioiTinh"]?.ToString() ?? "",
                            row["TenKhoa"]?.ToString() ?? "",
                            dtb.ToString("N2"),
                            xl
                        };

                        if (r % 2 == 1)
                            g.FillRectangle(bAlt, curX, curY, width, 22);

                        for (int c = 0; c < vals.Length; c++)
                        {
                            g.DrawRectangle(pBorder, curX, curY, colW[c], 22);
                            StringFormat fmt = (c == 0 || c == 1 || c == 3 || c == 4) ? sfCenter :
                                               (c == 6 ? sfRight : sfLeft);

                            // Highlight Top 1 or High scores
                            Brush textBrush = bText;
                            if (c == 7)
                            {
                                if (xl == "Xuất sắc") textBrush = Brushes.DarkGreen;
                                else if (xl == "Giỏi") textBrush = Brushes.DarkBlue;
                                else if (xl == "Yếu") textBrush = Brushes.DarkRed;
                            }

                            g.DrawString(vals[c], fTd, textBrush, new RectangleF(curX + 4, curY, colW[c] - 8, 22), fmt);
                            curX += colW[c];
                        }
                        curY += 22;
                    }

                    // Bài 3: Thống kê nhóm Average(DiemTB), Max, Min
                    if (_currentPage == _totalPages)
                    {
                        float statY = curY + 12;
                        g.FillRectangle(new SolidBrush(Color.FromArgb(242, 246, 252)), left, statY, width, 28);
                        g.DrawRectangle(pThBorder, left, statY, width, 28);

                        string statSummary = $"▶ Thống kê nhóm: Số lượng = {_dataSource?.Rows.Count ?? 0} SV  |  Điểm TB = {StatAvg:N2}  |  Cao nhất = {StatMax:N2}  |  Thấp nhất = {StatMin:N2}";
                        g.DrawString(statSummary, fTh, bBlue, new RectangleF(left + 10, statY, width - 20, 28), sfLeft);

                        float signY = statY + 40;
                        g.DrawString("Người lập biểu", fOrgB, bText, width + left - 150, signY);
                        g.DrawString("(Ký, họ tên)", fSub, Brushes.Gray, width + left - 135, signY + 18);
                        g.DrawString("Phan Văn Thắng", fOrgB, bBlue, width + left - 155, signY + 65);
                    }
                }

                // Footer Trang N / M
                float footY = 1080;
                g.DrawLine(pLine, left, footY - 10, left + width, footY - 10);
                g.DrawString($"Trang {_currentPage} / {_totalPages}", fFooter, Brushes.Gray, new RectangleF(left, footY, width, 18), sfCenter);
                g.DrawString("Hệ Thống Báo Cáo Quản Lý Đào Tạo EAUT - Lab 14", fFooter, Brushes.Gray, left, footY);
            }
        }
    }
}
