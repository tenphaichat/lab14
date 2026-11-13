using System;
using System.Data;
using System.Windows.Forms;
using Lab14_AdvancedReport.BUS;

namespace Lab14_AdvancedReport.GUI
{
    public partial class frmBaoCaoTheoKhoa : Form
    {
        private readonly BaoCaoBUS _bus = new BaoCaoBUS();
        private DataTable _dataTable;
        private decimal _statAvg = 0;
        private decimal _statMax = 0;
        private decimal _statMin = 0;

        public frmBaoCaoTheoKhoa()
        {
            InitializeComponent();
        }

        private void frmBaoCaoTheoKhoa_Load(object sender, EventArgs e)
        {
            LoadKhoaComboBox();
            LoadReportData();
        }

        private void LoadKhoaComboBox()
        {
            try
            {
                DataTable dtKhoa = _bus.GetAllKhoa();
                DataRow allRow = dtKhoa.NewRow();
                allRow["MaKhoa"] = "ALL";
                allRow["TenKhoa"] = "-- Tất cả các khoa --";
                dtKhoa.Rows.InsertAt(allRow, 0);

                cboKhoa.DataSource = dtKhoa;
                cboKhoa.DisplayMember = "TenKhoa";
                cboKhoa.ValueMember = "MaKhoa";
                cboKhoa.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi nạp danh mục khoa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadReportData()
        {
            try
            {
                string selectedKhoa = cboKhoa.SelectedValue?.ToString() ?? "ALL";
                _dataTable = _bus.GetStudentsByDepartment(selectedKhoa);

                dgvSinhVien.DataSource = _dataTable;
                FormatGridHeaders();

                // Bài 3: Tính toán thống kê Average, Max, Min theo nhóm
                CalculateStatistics();

                lblStatus.Text = $"Nạp thành công {_dataTable.Rows.Count} sinh viên vào lúc {DateTime.Now:HH:mm:ss}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateStatistics()
        {
            if (_dataTable == null || _dataTable.Rows.Count == 0)
            {
                _statAvg = 0; _statMax = 0; _statMin = 0;
                lblTotal.Text = "Tổng số sinh viên: 0";
                lblStats.Text = "Điểm TB: 0.00 | Cao nhất: 0.00 | Thấp nhất: 0.00";
                return;
            }

            int count = _dataTable.Rows.Count;
            decimal sum = 0;
            decimal max = decimal.MinValue;
            decimal min = decimal.MaxValue;

            foreach (DataRow row in _dataTable.Rows)
            {
                decimal dtb = row["DiemTB"] != DBNull.Value ? Convert.ToDecimal(row["DiemTB"]) : 0.0m;
                sum += dtb;
                if (dtb > max) max = dtb;
                if (dtb < min) min = dtb;
            }

            _statAvg = sum / count;
            _statMax = max;
            _statMin = min;

            lblTotal.Text = $"Tổng số sinh viên: {count}";
            lblStats.Text = $"Điểm TB: {_statAvg:N2} | Cao nhất: {_statMax:N2} | Thấp nhất: {_statMin:N2}";
        }

        private void FormatGridHeaders()
        {
            if (dgvSinhVien.Columns["MaSV"] != null) dgvSinhVien.Columns["MaSV"].HeaderText = "Mã SV";
            if (dgvSinhVien.Columns["HoTen"] != null) dgvSinhVien.Columns["HoTen"].HeaderText = "Họ và Tên";
            if (dgvSinhVien.Columns["NgaySinh"] != null)
            {
                dgvSinhVien.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
                dgvSinhVien.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvSinhVien.Columns["NgaySinh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvSinhVien.Columns["GioiTinh"] != null)
            {
                dgvSinhVien.Columns["GioiTinh"].HeaderText = "Giới Tính";
                dgvSinhVien.Columns["GioiTinh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvSinhVien.Columns["MaKhoa"] != null) dgvSinhVien.Columns["MaKhoa"].HeaderText = "Mã Khoa";
            if (dgvSinhVien.Columns["TenKhoa"] != null) dgvSinhVien.Columns["TenKhoa"].HeaderText = "Tên Khoa";
            if (dgvSinhVien.Columns["DiemTB"] != null)
            {
                dgvSinhVien.Columns["DiemTB"].HeaderText = "Điểm TB";
                dgvSinhVien.Columns["DiemTB"].DefaultCellStyle.Format = "N2";
                dgvSinhVien.Columns["DiemTB"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dgvSinhVien.Columns["XepLoai"] != null)
            {
                dgvSinhVien.Columns["XepLoai"].HeaderText = "Xếp Loại (Bài 3)";
                dgvSinhVien.Columns["XepLoai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvSinhVien.Columns["Email"] != null) dgvSinhVien.Columns["Email"].HeaderText = "Email";
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            LoadReportData();
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            string khoaName = cboKhoa.Text;
            frmReportViewer viewer = new frmReportViewer(
                ReportViewMode.SinhVienTheoKhoa,
                _dataTable,
                "BÁO CÁO DANH SÁCH SINH VIÊN THEO KHOA",
                $"Khoa áp dụng: {khoaName} | Ngày lập: {DateTime.Now:dd/MM/yyyy HH:mm}")
            {
                ParamDepartment = khoaName,
                StatAvg = _statAvg,
                StatMax = _statMax,
                StatMin = _statMin
            };
            viewer.ShowDialog(this);
        }

        /// <summary>
        /// Bài 5: Xuất Crystal Report sang định dạng Excel Workbook
        /// </summary>
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "Excel Workbook (*.xlsx)|*.xlsx|Excel 97-2003 (*.xls)|*.xls";
                dlg.FileName = "BaoCaoSinhVien_TheoKhoa.xlsx";
                dlg.Title = "Chọn nơi lưu tệp Báo cáo Excel";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExcelExportHelper.ExportDataTableToExcel(_dataTable, dlg.FileName, "BÁO CÁO SINH VIÊN THEO KHOA", $"Khoa: {cboKhoa.Text}");
                        MessageBox.Show($"Đã xuất báo cáo sang Excel thành công:\n{dlg.FileName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnXuatPdf_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "PDF Document (*.pdf)|*.pdf";
                dlg.FileName = "BaoCaoSinhVien_TheoKhoa.pdf";
                dlg.Title = "Chọn nơi lưu tệp Báo cáo PDF";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        PdfExportHelper.ExportSinhVienTheoKhoaPdf(_dataTable, dlg.FileName, cboKhoa.Text, DateTime.Now, _statAvg, _statMax, _statMin);
                        MessageBox.Show($"Đã xuất báo cáo ra tệp PDF thành công:\n{dlg.FileName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xuất PDF: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (_dataTable != null)
            {
                _dataTable.Dispose();
                _dataTable = null;
            }
            base.OnFormClosed(e);
        }
    }
}
