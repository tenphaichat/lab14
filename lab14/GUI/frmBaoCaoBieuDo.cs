using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Lab14_AdvancedReport.BUS;

namespace Lab14_AdvancedReport.GUI
{
    public partial class frmBaoCaoBieuDo : Form
    {
        private readonly BaoCaoBUS _bus = new BaoCaoBUS();
        private DataTable _dtGradeDist;
        private DataTable _dtDeptDist;
        private int _chartType = 0; // 0: Xep loai (Pie), 1: Khoa (Bar)

        public frmBaoCaoBieuDo()
        {
            InitializeComponent();
        }

        private void frmBaoCaoBieuDo_Load(object sender, EventArgs e)
        {
            cboLoaiBieuDo.SelectedIndex = 0;
            LoadChartData();
        }

        private void cboLoaiBieuDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _chartType = cboLoaiBieuDo.SelectedIndex;
            LoadChartData();
        }

        private void LoadChartData()
        {
            try
            {
                _dtGradeDist = _bus.GetGradeDistribution();
                _dtDeptDist = _bus.GetDepartmentStatistics();

                if (_chartType == 0)
                {
                    dgvData.DataSource = _dtGradeDist;
                    if (dgvData.Columns["XepLoai"] != null) dgvData.Columns["XepLoai"].HeaderText = "Phân Loại Học Lực";
                    if (dgvData.Columns["SoLuong"] != null) dgvData.Columns["SoLuong"].HeaderText = "Số Lượng Sinh Viên";
                    if (dgvData.Columns["TyLe"] != null)
                    {
                        dgvData.Columns["TyLe"].HeaderText = "Tỷ Lệ (%)";
                        dgvData.Columns["TyLe"].DefaultCellStyle.Format = "N1";
                    }
                    lblChartTitle.Text = "BIỂU ĐỒ TRÒN: PHÂN BỐ XẾP LOẠI HỌC LỰC TOÀN TRƯỜNG";
                }
                else
                {
                    dgvData.DataSource = _dtDeptDist;
                    if (dgvData.Columns["MaKhoa"] != null) dgvData.Columns["MaKhoa"].HeaderText = "Mã Khoa";
                    if (dgvData.Columns["TenKhoa"] != null) dgvData.Columns["TenKhoa"].HeaderText = "Tên Khoa";
                    if (dgvData.Columns["SoLuongSinhVien"] != null) dgvData.Columns["SoLuongSinhVien"].HeaderText = "Số SV";
                    if (dgvData.Columns["DiemTBKhoa"] != null)
                    {
                        dgvData.Columns["DiemTBKhoa"].HeaderText = "ĐTB Khoa";
                        dgvData.Columns["DiemTBKhoa"].DefaultCellStyle.Format = "N2";
                    }
                    lblChartTitle.Text = "BIỂU ĐỒ CỘT: THỐNG KÊ SỐ LƯỢNG SINH VIÊN VÀ ĐTB THEO KHOA";
                }

                pnlCanvas.Invalidate();
                lblStatus.Text = $"Đã cập nhật dữ liệu biểu đồ vào lúc {DateTime.Now:HH:mm:ss}";
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Lỗi nạp dữ liệu biểu đồ: {ex.Message}";
            }
        }

        private void pnlCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            int w = pnlCanvas.Width;
            int h = pnlCanvas.Height;

            if (_chartType == 0)
            {
                // Draw Pie Chart for Grade Distribution
                DrawPieChart(g, w, h);
            }
            else
            {
                // Draw Bar Chart for Department Student Count
                DrawBarChart(g, w, h);
            }
        }

        private void DrawPieChart(Graphics g, int w, int h)
        {
            if (_dtGradeDist == null || _dtGradeDist.Rows.Count == 0) return;

            Color[] colors = {
                Color.FromArgb(46, 139, 87),   // Xuất sắc (Green)
                Color.FromArgb(30, 100, 160),  // Giỏi (Blue)
                Color.FromArgb(218, 165, 32),  // Khá (Golden)
                Color.FromArgb(205, 92, 92),   // Trung bình (IndianRed)
                Color.FromArgb(178, 34, 34)    // Yếu (DarkRed)
            };

            int total = 0;
            foreach (DataRow r in _dtGradeDist.Rows)
                total += Convert.ToInt32(r["SoLuong"]);

            if (total == 0) return;

            int size = Math.Max(50, Math.Min(w - 280, h - 90));
            Rectangle pieRect = new Rectangle(40, 50, size, size);
            float startAngle = 0;

            for (int i = 0; i < _dtGradeDist.Rows.Count; i++)
            {
                int val = Convert.ToInt32(_dtGradeDist.Rows[i]["SoLuong"]);
                float sweepAngle = (float)val / total * 360f;

                using (SolidBrush b = new SolidBrush(colors[i % colors.Length]))
                {
                    g.FillPie(b, pieRect, startAngle, sweepAngle);
                }
                g.DrawPie(Pens.White, pieRect, startAngle, sweepAngle);
                startAngle += sweepAngle;
            }

            // Draw Legend
            int legX = pieRect.Right + 30;
            int legY = 60;
            using (Font fLeg = new Font("Segoe UI", 9.5f, FontStyle.Regular))
            using (Font fBold = new Font("Segoe UI", 9.5f, FontStyle.Bold))
            {
                for (int i = 0; i < _dtGradeDist.Rows.Count; i++)
                {
                    DataRow r = _dtGradeDist.Rows[i];
                    int val = Convert.ToInt32(r["SoLuong"]);
                    double pct = Convert.ToDouble(r["TyLe"]);

                    using (SolidBrush b = new SolidBrush(colors[i % colors.Length]))
                    {
                        g.FillRectangle(b, legX, legY + 2, 16, 16);
                        g.DrawRectangle(Pens.Gray, legX, legY + 2, 16, 16);
                    }

                    string label = $"{r["XepLoai"]}: {val} SV ({pct:N1}%)";
                    g.DrawString(label, fLeg, Brushes.Black, legX + 24, legY);
                    legY += 28;
                }

                g.DrawString($"Tổng cộng: {total} sinh viên", fBold, Brushes.Navy, legX, legY + 10);
            }
        }

        private void DrawBarChart(Graphics g, int w, int h)
        {
            if (_dtDeptDist == null || _dtDeptDist.Rows.Count == 0) return;

            int count = _dtDeptDist.Rows.Count;
            int maxVal = 1;
            foreach (DataRow r in _dtDeptDist.Rows)
            {
                int val = Convert.ToInt32(r["SoLuongSinhVien"]);
                if (val > maxVal) maxVal = val;
            }

            int left = 70;
            int bottom = h - 60;
            int top = 50;
            int right = w - 40;
            int plotHeight = bottom - top;
            int plotWidth = right - left;

            // Draw Axes
            g.DrawLine(new Pen(Color.FromArgb(120, 120, 120), 1.5f), left, bottom, right, bottom);
            g.DrawLine(new Pen(Color.FromArgb(120, 120, 120), 1.5f), left, bottom, left, top);

            using (Font fAxis = new Font("Segoe UI", 8.5f))
            using (Font fVal = new Font("Segoe UI", 9f, FontStyle.Bold))
            using (Pen pGrid = new Pen(Color.FromArgb(235, 235, 235)))
            {
                // Y-Axis markers
                int ySteps = 5;
                for (int i = 0; i <= ySteps; i++)
                {
                    int markVal = (int)Math.Ceiling((double)maxVal * i / ySteps);
                    int yPos = bottom - (int)((double)i / ySteps * plotHeight);

                    g.DrawLine(pGrid, left, yPos, right, yPos);
                    g.DrawString(markVal.ToString(), fAxis, Brushes.Gray, left - 35, yPos - 8);
                }

                // Draw Bars
                int barWidth = Math.Min(60, plotWidth / (count * 2));
                int spacing = plotWidth / count;

                Color[] barColors = {
                    Color.FromArgb(30, 100, 160),
                    Color.FromArgb(46, 139, 87),
                    Color.FromArgb(205, 133, 63),
                    Color.FromArgb(147, 112, 219),
                    Color.FromArgb(218, 112, 214)
                };

                for (int i = 0; i < count; i++)
                {
                    DataRow r = _dtDeptDist.Rows[i];
                    int val = Convert.ToInt32(r["SoLuongSinhVien"]);
                    int barH = (int)((double)val / maxVal * plotHeight);
                    int barX = left + i * spacing + (spacing - barWidth) / 2;
                    int barY = bottom - barH;

                    using (SolidBrush b = new SolidBrush(barColors[i % barColors.Length]))
                    {
                        g.FillRectangle(b, barX, barY, barWidth, barH);
                        g.DrawRectangle(new Pen(Color.FromArgb(50, 50, 50)), barX, barY, barWidth, barH);
                    }

                    // Value label on top of bar
                    g.DrawString(val.ToString(), fVal, Brushes.Black, barX + (barWidth / 2) - 8, barY - 18);

                    // X-Axis label
                    string code = r["MaKhoa"]?.ToString() ?? "";
                    g.DrawString(code, fAxis, Brushes.Black, barX + (barWidth / 2) - 14, bottom + 8);
                }
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            DataTable target = _chartType == 0 ? _dtGradeDist : _dtDeptDist;
            string title = _chartType == 0 ? "BÁO CÁO PHÂN BỐ XẾP LOẠI HỌC LỰC" : "BÁO CÁO THỐNG KÊ SINH VIÊN THEO KHOA";

            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                dlg.FileName = _chartType == 0 ? "BaoCao_PhanBo_XepLoai.xlsx" : "BaoCao_ThongKe_Khoa.xlsx";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExcelExportHelper.ExportDataTableToExcel(target, dlg.FileName, title, "Dữ liệu phục vụ trực quan hóa biểu đồ");
                        MessageBox.Show($"Đã xuất dữ liệu biểu đồ sang Excel:\n{dlg.FileName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
