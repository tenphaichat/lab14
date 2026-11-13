using System;
using System.Data;
using System.Windows.Forms;
using Lab14_AdvancedReport.BUS;

namespace Lab14_AdvancedReport.GUI
{
    public partial class frmXuatDataGridViewExcel : Form
    {
        private readonly BaoCaoBUS _bus = new BaoCaoBUS();
        private DataTable _dtMaster;
        private DataView _dvFiltered;

        public frmXuatDataGridViewExcel()
        {
            InitializeComponent();
        }

        private void frmXuatDataGridViewExcel_Load(object sender, EventArgs e)
        {
            LoadKhoaFilter();
            LoadMasterData();
        }

        private void LoadKhoaFilter()
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

                cboXepLoai.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Lỗi nạp danh mục: {ex.Message}";
            }
        }

        private void LoadMasterData()
        {
            try
            {
                _dtMaster = _bus.GetStudentsByDepartment();
                _dvFiltered = new DataView(_dtMaster);
                dgvData.DataSource = _dvFiltered;
                FormatGrid();
                ApplyFilters();
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Lỗi nạp dữ liệu: {ex.Message}";
            }
        }

        private void FormatGrid()
        {
            if (dgvData.Columns["MaSV"] != null) dgvData.Columns["MaSV"].HeaderText = "Mã Sinh Viên";
            if (dgvData.Columns["HoTen"] != null) dgvData.Columns["HoTen"].HeaderText = "Họ và Tên";
            if (dgvData.Columns["NgaySinh"] != null)
            {
                dgvData.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
                dgvData.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvData.Columns["NgaySinh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvData.Columns["GioiTinh"] != null) dgvData.Columns["GioiTinh"].HeaderText = "Giới Tính";
            if (dgvData.Columns["MaKhoa"] != null) dgvData.Columns["MaKhoa"].HeaderText = "Mã Khoa";
            if (dgvData.Columns["TenKhoa"] != null) dgvData.Columns["TenKhoa"].HeaderText = "Tên Khoa";
            if (dgvData.Columns["DiemTB"] != null)
            {
                dgvData.Columns["DiemTB"].HeaderText = "Điểm TB";
                dgvData.Columns["DiemTB"].DefaultCellStyle.Format = "N2";
                dgvData.Columns["DiemTB"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dgvData.Columns["XepLoai"] != null)
            {
                dgvData.Columns["XepLoai"].HeaderText = "Xếp Loại";
                dgvData.Columns["XepLoai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvData.Columns["Email"] != null) dgvData.Columns["Email"].HeaderText = "Email";
        }

        private void ApplyFilters()
        {
            if (_dvFiltered == null) return;

            string filter = "1=1";

            // Keyword filter (MaSV or HoTen)
            string keyword = txtKeyword.Text.Trim().Replace("'", "''");
            if (!string.IsNullOrEmpty(keyword))
            {
                filter += $" AND (MaSV LIKE '%{keyword}%' OR HoTen LIKE '%{keyword}%')";
            }

            // Khoa filter
            string maKhoa = cboKhoa.SelectedValue?.ToString();
            if (!string.IsNullOrEmpty(maKhoa) && maKhoa != "ALL")
            {
                filter += $" AND MaKhoa = '{maKhoa}'";
            }

            // XepLoai filter
            if (cboXepLoai.SelectedIndex > 0)
            {
                string xl = cboXepLoai.Text;
                filter += $" AND XepLoai = '{xl}'";
            }

            _dvFiltered.RowFilter = filter;

            lblTotal.Text = $"Hiển thị: {_dvFiltered.Count} / {_dtMaster.Rows.Count} sinh viên";
            lblStatus.Text = $"Bộ lọc đang áp dụng: {filter}";
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cboXepLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnXoaLoc_Click(object sender, EventArgs e)
        {
            txtKeyword.Clear();
            cboKhoa.SelectedIndex = 0;
            cboXepLoai.SelectedIndex = 0;
            ApplyFilters();
        }

        /// <summary>
        /// Bài 9: Xuất DataGridView sang Excel giữ nguyên cột, bộ lọc, định dạng ngày và số
        /// </summary>
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                dlg.FileName = "BaoCao_DataGridView_Export.xlsx";
                dlg.Title = "Chọn nơi lưu tệp Excel trích xuất từ DataGridView";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExcelExportHelper.ExportDataGridViewToExcel(dgvData, dlg.FileName, "KẾT QUẢ DỮ LIỆU ĐANG LỌC TRÊN DATAGRIDVIEW");
                        MessageBox.Show($"Đã xuất {dgvData.Rows.Count} dòng dữ liệu DataGridView sang Excel thành công!\n{dlg.FileName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
