using System;
using System.Data;
using System.Windows.Forms;
using Lab14_AdvancedReport.BUS;

namespace Lab14_AdvancedReport.GUI
{
    public partial class frmReportCenter : Form
    {
        private readonly BaoCaoBUS _bus = new BaoCaoBUS();
        private DataTable _currentData;

        public frmReportCenter()
        {
            InitializeComponent();
        }

        private void frmReportCenter_Load(object sender, EventArgs e)
        {
            LoadKhoaComboBox();
            cboReportType.SelectedIndex = 0;
            LoadReportData();
        }

        private void LoadKhoaComboBox()
        {
            try
            {
                DataTable dtKhoa = _bus.GetAllKhoa();
                DataRow r = dtKhoa.NewRow();
                r["MaKhoa"] = "ALL";
                r["TenKhoa"] = "-- Tất cả các khoa --";
                dtKhoa.Rows.InsertAt(r, 0);

                cboKhoa.DataSource = dtKhoa;
                cboKhoa.DisplayMember = "TenKhoa";
                cboKhoa.ValueMember = "MaKhoa";
                cboKhoa.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Lỗi nạp khoa: {ex.Message}";
            }
        }

        private void cboReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateParamVisibility();
            LoadReportData();
        }

        private void UpdateParamVisibility()
        {
            int idx = cboReportType.SelectedIndex;
            // 0: Theo Khoa, 1: Khoang diem, 2: Top N, 3: Dang ky hoc ky, 4: Thong ke xep loai
            pnlKhoa.Visible = (idx == 0 || idx == 1 || idx == 2);
            pnlKhoangDiem.Visible = (idx == 1);
            pnlTopN.Visible = (idx == 2);
            pnlHocKy.Visible = (idx == 3);
        }

        private void btnTaiDuLieu_Click(object sender, EventArgs e)
        {
            LoadReportData();
        }

        private void LoadReportData()
        {
            try
            {
                int type = cboReportType.SelectedIndex;
                string maKhoa = cboKhoa.SelectedValue?.ToString();

                switch (type)
                {
                    case 0: // Theo khoa
                        _currentData = _bus.GetStudentsByDepartment(maKhoa);
                        break;
                    case 1: // Khoang diem
                        _currentData = _bus.GetByScoreRange(nudMin.Value, nudMax.Value, maKhoa);
                        break;
                    case 2: // Top N
                        _currentData = _bus.GetTopStudents((int)nudTopN.Value, maKhoa);
                        break;
                    case 3: // Dang ky hoc ky
                        int? hk = null;
                        if (cboHocKy.SelectedIndex == 1) hk = 1;
                        else if (cboHocKy.SelectedIndex == 2) hk = 2;
                        else if (cboHocKy.SelectedIndex == 3) hk = 3;
                        _currentData = _bus.GetRegistrationBySemester(hk);
                        break;
                    case 4: // Thong ke xep loai
                        _currentData = _bus.GetGradeDistribution();
                        break;
                }

                dgvPreview.DataSource = _currentData;
                FormatGrid();

                lblTotal.Text = $"Tổng số bản ghi: {_currentData?.Rows.Count ?? 0}";
                lblStatus.Text = $"Nạp thành công {cboReportType.Text} vào lúc {DateTime.Now:HH:mm:ss}";
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Lỗi nạp dữ liệu: {ex.Message}";
            }
        }

        private void FormatGrid()
        {
            if (_currentData == null) return;
            foreach (DataGridViewColumn col in dgvPreview.Columns)
            {
                if (col.Name == "MaSV" || col.Name == "MaHP" || col.Name == "MaKhoa" || col.Name == "HocKy")
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (col.Name == "DiemTB" || col.Name == "DiemTrungBinhMon" || col.Name == "DiemTBKhoa" || col.Name == "TyLe")
                {
                    col.DefaultCellStyle.Format = "N2";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                if (col.Name == "NgaySinh")
                {
                    col.DefaultCellStyle.Format = "dd/MM/yyyy";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                if (col.Name == "XepLoai" || col.Name == "GioiTinh")
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            if (_currentData == null || _currentData.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xem báo cáo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int type = cboReportType.SelectedIndex;
            ReportViewMode mode = ReportViewMode.SinhVienTheoKhoa;
            string mainTitle = cboReportType.Text.ToUpper();
            string subTitle = $"Thời điểm: {DateTime.Now:dd/MM/yyyy HH:mm}";

            decimal avg = 0, max = 0, min = 0;
            if (_currentData.Columns.Contains("DiemTB"))
            {
                decimal sum = 0;
                max = decimal.MinValue; min = decimal.MaxValue;
                foreach (DataRow r in _currentData.Rows)
                {
                    decimal d = r["DiemTB"] != DBNull.Value ? Convert.ToDecimal(r["DiemTB"]) : 0;
                    sum += d;
                    if (d > max) max = d;
                    if (d < min) min = d;
                }
                avg = _currentData.Rows.Count > 0 ? sum / _currentData.Rows.Count : 0;
            }

            switch (type)
            {
                case 0:
                    mode = ReportViewMode.SinhVienTheoKhoa;
                    subTitle = $"Khoa: {cboKhoa.Text}";
                    break;
                case 1:
                    mode = ReportViewMode.KhoangDiem;
                    subTitle = $"Khoảng điểm: [{nudMin.Value:N1} - {nudMax.Value:N1}] - {cboKhoa.Text}";
                    break;
                case 2:
                    mode = ReportViewMode.TopN;
                    subTitle = $"Top {nudTopN.Value} sinh viên tiêu biểu - {cboKhoa.Text}";
                    break;
                case 3:
                    mode = ReportViewMode.DangKyHocKy;
                    subTitle = $"Đăng ký học phần: {cboHocKy.Text}";
                    break;
                default:
                    mode = ReportViewMode.SinhVienTheoKhoa;
                    break;
            }

            frmReportViewer viewer = new frmReportViewer(mode, _currentData, mainTitle, subTitle)
            {
                ParamDepartment = cboKhoa.Text,
                ParamMinScore = nudMin.Value,
                ParamMaxScore = nudMax.Value,
                ParamTopN = (int)nudTopN.Value,
                StatAvg = avg,
                StatMax = max,
                StatMin = min
            };
            viewer.ShowDialog(this);
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (_currentData == null || _currentData.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất Excel.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                dlg.FileName = $"ReportCenter_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExcelExportHelper.ExportDataTableToExcel(_currentData, dlg.FileName, cboReportType.Text, $"Trung tâm báo cáo - Kết xuất lúc {DateTime.Now:dd/MM/yyyy HH:mm}");
                        MessageBox.Show($"Đã xuất báo cáo sang Excel thành công:\n{dlg.FileName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnXuatPdf_Click(object sender, EventArgs e)
        {
            if (_currentData == null || _currentData.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất PDF.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "PDF Document (*.pdf)|*.pdf";
                dlg.FileName = $"ReportCenter_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        int type = cboReportType.SelectedIndex;
                        switch (type)
                        {
                            case 0:
                                PdfExportHelper.ExportSinhVienTheoKhoaPdf(_currentData, dlg.FileName, cboKhoa.Text, DateTime.Now);
                                break;
                            case 1:
                                PdfExportHelper.ExportKhoangDiemPdf(_currentData, dlg.FileName, nudMin.Value, nudMax.Value, cboKhoa.Text);
                                break;
                            case 2:
                                PdfExportHelper.ExportTopNPdf(_currentData, dlg.FileName, (int)nudTopN.Value, cboKhoa.Text);
                                break;
                            case 3:
                                int? hk = null;
                                if (cboHocKy.SelectedIndex == 1) hk = 1;
                                else if (cboHocKy.SelectedIndex == 2) hk = 2;
                                else if (cboHocKy.SelectedIndex == 3) hk = 3;
                                PdfExportHelper.ExportDangKyHocKyPdf(_currentData, dlg.FileName, hk);
                                break;
                            default:
                                PdfExportHelper.ExportSinhVienTheoKhoaPdf(_currentData, dlg.FileName, cboKhoa.Text, DateTime.Now);
                                break;
                        }

                        MessageBox.Show($"Đã xuất báo cáo sang PDF thành công:\n{dlg.FileName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi xuất PDF: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
