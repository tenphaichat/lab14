namespace Lab14_AdvancedReport.GUI
{
    partial class frmReportCenter
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.GroupBox grpSelection;
        private System.Windows.Forms.Label lblReportType;
        private System.Windows.Forms.ComboBox cboReportType;
        private System.Windows.Forms.FlowLayoutPanel flowParams;
        private System.Windows.Forms.Panel pnlKhoa;
        private System.Windows.Forms.Label lblKhoa;
        private System.Windows.Forms.ComboBox cboKhoa;
        private System.Windows.Forms.Panel pnlKhoangDiem;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.NumericUpDown nudMin;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.NumericUpDown nudMax;
        private System.Windows.Forms.Panel pnlTopN;
        private System.Windows.Forms.Label lblTopN;
        private System.Windows.Forms.NumericUpDown nudTopN;
        private System.Windows.Forms.Panel pnlHocKy;
        private System.Windows.Forms.Label lblHocKy;
        private System.Windows.Forms.ComboBox cboHocKy;
        private System.Windows.Forms.Button btnTaiDuLieu;
        private System.Windows.Forms.Button btnXemBaoCao;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Button btnXuatPdf;
        private System.Windows.Forms.GroupBox grpPreview;
        private System.Windows.Forms.DataGridView dgvPreview;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblTotal;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.grpSelection = new System.Windows.Forms.GroupBox();
            this.btnXuatPdf = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnXemBaoCao = new System.Windows.Forms.Button();
            this.btnTaiDuLieu = new System.Windows.Forms.Button();
            this.flowParams = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlKhoa = new System.Windows.Forms.Panel();
            this.cboKhoa = new System.Windows.Forms.ComboBox();
            this.lblKhoa = new System.Windows.Forms.Label();
            this.pnlKhoangDiem = new System.Windows.Forms.Panel();
            this.nudMax = new System.Windows.Forms.NumericUpDown();
            this.lblMax = new System.Windows.Forms.Label();
            this.nudMin = new System.Windows.Forms.NumericUpDown();
            this.lblMin = new System.Windows.Forms.Label();
            this.pnlTopN = new System.Windows.Forms.Panel();
            this.nudTopN = new System.Windows.Forms.NumericUpDown();
            this.lblTopN = new System.Windows.Forms.Label();
            this.pnlHocKy = new System.Windows.Forms.Panel();
            this.cboHocKy = new System.Windows.Forms.ComboBox();
            this.lblHocKy = new System.Windows.Forms.Label();
            this.cboReportType = new System.Windows.Forms.ComboBox();
            this.lblReportType = new System.Windows.Forms.Label();
            this.grpPreview = new System.Windows.Forms.GroupBox();
            this.dgvPreview = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelTop.SuspendLayout();
            this.grpSelection.SuspendLayout();
            this.flowParams.SuspendLayout();
            this.pnlKhoa.SuspendLayout();
            this.pnlKhoangDiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMin)).BeginInit();
            this.pnlTopN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTopN)).BeginInit();
            this.pnlHocKy.SuspendLayout();
            this.grpPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(76)))), ((int)(((byte)(120)))));
            this.panelTop.Controls.Add(this.lblHeaderTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1004, 55);
            this.panelTop.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(16, 12);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(650, 31);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "TRUNG TÂM BÁO CÁO TỔNG HỢP & XUẤT ĐA ĐỊNH DẠNG (BÀI 10)";
            // 
            // grpSelection
            // 
            this.grpSelection.Controls.Add(this.btnXuatPdf);
            this.grpSelection.Controls.Add(this.btnXuatExcel);
            this.grpSelection.Controls.Add(this.btnXemBaoCao);
            this.grpSelection.Controls.Add(this.btnTaiDuLieu);
            this.grpSelection.Controls.Add(this.flowParams);
            this.grpSelection.Controls.Add(this.cboReportType);
            this.grpSelection.Controls.Add(this.lblReportType);
            this.grpSelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSelection.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpSelection.Location = new System.Drawing.Point(0, 55);
            this.grpSelection.Name = "grpSelection";
            this.grpSelection.Size = new System.Drawing.Size(1004, 115);
            this.grpSelection.TabIndex = 1;
            this.grpSelection.TabStop = false;
            this.grpSelection.Text = "Chọn loại báo cáo & Thiết lập tham số động";
            // 
            // btnXuatPdf
            // 
            this.btnXuatPdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnXuatPdf.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXuatPdf.ForeColor = System.Drawing.Color.White;
            this.btnXuatPdf.Location = new System.Drawing.Point(880, 24);
            this.btnXuatPdf.Name = "btnXuatPdf";
            this.btnXuatPdf.Size = new System.Drawing.Size(110, 35);
            this.btnXuatPdf.TabIndex = 6;
            this.btnXuatPdf.Text = "📄 Xuất PDF";
            this.btnXuatPdf.UseVisualStyleBackColor = false;
            this.btnXuatPdf.Click += new System.EventHandler(this.btnXuatPdf_Click);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXuatExcel.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcel.Location = new System.Drawing.Point(755, 24);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(115, 35);
            this.btnXuatExcel.TabIndex = 5;
            this.btnXuatExcel.Text = "📊 Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = false;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // btnXemBaoCao
            // 
            this.btnXemBaoCao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(100)))), ((int)(((byte)(160)))));
            this.btnXemBaoCao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXemBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnXemBaoCao.Location = new System.Drawing.Point(620, 24);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(125, 35);
            this.btnXemBaoCao.TabIndex = 4;
            this.btnXemBaoCao.Text = "🔍 Xem Báo Cáo";
            this.btnXemBaoCao.UseVisualStyleBackColor = false;
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);
            // 
            // btnTaiDuLieu
            // 
            this.btnTaiDuLieu.Location = new System.Drawing.Point(520, 24);
            this.btnTaiDuLieu.Name = "btnTaiDuLieu";
            this.btnTaiDuLieu.Size = new System.Drawing.Size(90, 35);
            this.btnTaiDuLieu.TabIndex = 3;
            this.btnTaiDuLieu.Text = "Tải Dữ Liệu";
            this.btnTaiDuLieu.UseVisualStyleBackColor = true;
            this.btnTaiDuLieu.Click += new System.EventHandler(this.btnTaiDuLieu_Click);
            // 
            // flowParams
            // 
            this.flowParams.Controls.Add(this.pnlKhoa);
            this.flowParams.Controls.Add(this.pnlKhoangDiem);
            this.flowParams.Controls.Add(this.pnlTopN);
            this.flowParams.Controls.Add(this.pnlHocKy);
            this.flowParams.Location = new System.Drawing.Point(12, 65);
            this.flowParams.Name = "flowParams";
            this.flowParams.Size = new System.Drawing.Size(980, 42);
            this.flowParams.TabIndex = 2;
            // 
            // pnlKhoa
            // 
            this.pnlKhoa.Controls.Add(this.cboKhoa);
            this.pnlKhoa.Controls.Add(this.lblKhoa);
            this.pnlKhoa.Location = new System.Drawing.Point(3, 3);
            this.pnlKhoa.Name = "pnlKhoa";
            this.pnlKhoa.Size = new System.Drawing.Size(260, 35);
            this.pnlKhoa.TabIndex = 0;
            // 
            // cboKhoa
            // 
            this.cboKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoa.FormattingEnabled = true;
            this.cboKhoa.Location = new System.Drawing.Point(85, 4);
            this.cboKhoa.Name = "cboKhoa";
            this.cboKhoa.Size = new System.Drawing.Size(165, 28);
            this.cboKhoa.TabIndex = 1;
            // 
            // lblKhoa
            // 
            this.lblKhoa.AutoSize = true;
            this.lblKhoa.Location = new System.Drawing.Point(5, 8);
            this.lblKhoa.Name = "lblKhoa";
            this.lblKhoa.Size = new System.Drawing.Size(81, 20);
            this.lblKhoa.TabIndex = 0;
            this.lblKhoa.Text = "Chọn Khoa:";
            // 
            // pnlKhoangDiem
            // 
            this.pnlKhoangDiem.Controls.Add(this.nudMax);
            this.pnlKhoangDiem.Controls.Add(this.lblMax);
            this.pnlKhoangDiem.Controls.Add(this.nudMin);
            this.pnlKhoangDiem.Controls.Add(this.lblMin);
            this.pnlKhoangDiem.Location = new System.Drawing.Point(269, 3);
            this.pnlKhoangDiem.Name = "pnlKhoangDiem";
            this.pnlKhoangDiem.Size = new System.Drawing.Size(260, 35);
            this.pnlKhoangDiem.TabIndex = 1;
            // 
            // nudMax
            // 
            this.nudMax.DecimalPlaces = 1;
            this.nudMax.Location = new System.Drawing.Point(195, 5);
            this.nudMax.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudMax.Name = "nudMax";
            this.nudMax.Size = new System.Drawing.Size(55, 27);
            this.nudMax.TabIndex = 3;
            this.nudMax.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(125, 8);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(69, 20);
            this.lblMax.TabIndex = 2;
            this.lblMax.Text = "Đến max:";
            // 
            // nudMin
            // 
            this.nudMin.DecimalPlaces = 1;
            this.nudMin.Location = new System.Drawing.Point(65, 5);
            this.nudMin.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudMin.Name = "nudMin";
            this.nudMin.Size = new System.Drawing.Size(55, 27);
            this.nudMin.TabIndex = 1;
            this.nudMin.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Location = new System.Drawing.Point(5, 8);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(59, 20);
            this.lblMin.TabIndex = 0;
            this.lblMin.Text = "Từ min:";
            // 
            // pnlTopN
            // 
            this.pnlTopN.Controls.Add(this.nudTopN);
            this.pnlTopN.Controls.Add(this.lblTopN);
            this.pnlTopN.Location = new System.Drawing.Point(535, 3);
            this.pnlTopN.Name = "pnlTopN";
            this.pnlTopN.Size = new System.Drawing.Size(160, 35);
            this.pnlTopN.TabIndex = 2;
            // 
            // nudTopN
            // 
            this.nudTopN.Location = new System.Drawing.Point(85, 5);
            this.nudTopN.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudTopN.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTopN.Name = "nudTopN";
            this.nudTopN.Size = new System.Drawing.Size(60, 27);
            this.nudTopN.TabIndex = 1;
            this.nudTopN.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lblTopN
            // 
            this.lblTopN.AutoSize = true;
            this.lblTopN.Location = new System.Drawing.Point(5, 8);
            this.lblTopN.Name = "lblTopN";
            this.lblTopN.Size = new System.Drawing.Size(76, 20);
            this.lblTopN.TabIndex = 0;
            this.lblTopN.Text = "Lấy Top N:";
            // 
            // pnlHocKy
            // 
            this.pnlHocKy.Controls.Add(this.cboHocKy);
            this.pnlHocKy.Controls.Add(this.lblHocKy);
            this.pnlHocKy.Location = new System.Drawing.Point(701, 3);
            this.pnlHocKy.Name = "pnlHocKy";
            this.pnlHocKy.Size = new System.Drawing.Size(260, 35);
            this.pnlHocKy.TabIndex = 3;
            // 
            // cboHocKy
            // 
            this.cboHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHocKy.FormattingEnabled = true;
            this.cboHocKy.Items.AddRange(new object[] {
            "-- Tất cả học kỳ --",
            "Học kỳ 1",
            "Học kỳ 2",
            "Học kỳ 3"});
            this.cboHocKy.Location = new System.Drawing.Point(75, 4);
            this.cboHocKy.Name = "cboHocKy";
            this.cboHocKy.Size = new System.Drawing.Size(175, 28);
            this.cboHocKy.TabIndex = 1;
            // 
            // lblHocKy
            // 
            this.lblHocKy.AutoSize = true;
            this.lblHocKy.Location = new System.Drawing.Point(5, 8);
            this.lblHocKy.Name = "lblHocKy";
            this.lblHocKy.Size = new System.Drawing.Size(60, 20);
            this.lblHocKy.TabIndex = 0;
            this.lblHocKy.Text = "Học kỳ:";
            // 
            // cboReportType
            // 
            this.cboReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReportType.FormattingEnabled = true;
            this.cboReportType.Items.AddRange(new object[] {
            "1. Báo cáo Sinh viên theo Khoa (Nhóm & Thống kê)",
            "2. Báo cáo Sinh viên theo Khoảng điểm lọc",
            "3. Báo cáo Top N Sinh viên xuất sắc tiêu biểu",
            "4. Báo cáo Đăng ký học phần theo Học kỳ",
            "5. Báo cáo Thống kê phân bố Xếp loại học lực"});
            this.cboReportType.Location = new System.Drawing.Point(125, 28);
            this.cboReportType.Name = "cboReportType";
            this.cboReportType.Size = new System.Drawing.Size(380, 28);
            this.cboReportType.TabIndex = 1;
            this.cboReportType.SelectedIndexChanged += new System.EventHandler(this.cboReportType_SelectedIndexChanged);
            // 
            // lblReportType
            // 
            this.lblReportType.AutoSize = true;
            this.lblReportType.Location = new System.Drawing.Point(15, 32);
            this.lblReportType.Name = "lblReportType";
            this.lblReportType.Size = new System.Drawing.Size(101, 20);
            this.lblReportType.TabIndex = 0;
            this.lblReportType.Text = "Loại Báo Cáo:";
            // 
            // grpPreview
            // 
            this.grpPreview.Controls.Add(this.dgvPreview);
            this.grpPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPreview.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpPreview.Location = new System.Drawing.Point(0, 170);
            this.grpPreview.Name = "grpPreview";
            this.grpPreview.Padding = new System.Windows.Forms.Padding(10);
            this.grpPreview.Size = new System.Drawing.Size(1004, 445);
            this.grpPreview.TabIndex = 2;
            this.grpPreview.TabStop = false;
            this.grpPreview.Text = "Xem trước bảng dữ liệu nguồn báo cáo";
            // 
            // dgvPreview
            // 
            this.dgvPreview.AllowUserToAddRows = false;
            this.dgvPreview.AllowUserToDeleteRows = false;
            this.dgvPreview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPreview.BackgroundColor = System.Drawing.Color.White;
            this.dgvPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPreview.Location = new System.Drawing.Point(10, 30);
            this.dgvPreview.MultiSelect = false;
            this.dgvPreview.Name = "dgvPreview";
            this.dgvPreview.ReadOnly = true;
            this.dgvPreview.RowHeadersWidth = 35;
            this.dgvPreview.RowTemplate.Height = 26;
            this.dgvPreview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPreview.Size = new System.Drawing.Size(984, 405);
            this.dgvPreview.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblTotal});
            this.statusStrip1.Location = new System.Drawing.Point(0, 615);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1004, 26);
            this.statusStrip1.TabIndex = 3;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(789, 20);
            this.lblStatus.Spring = true;
            this.lblStatus.Text = "Sẵn sàng";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(200, 20);
            this.lblTotal.Text = "Tổng số bản ghi: 0";
            // 
            // frmReportCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 641);
            this.Controls.Add(this.grpPreview);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grpSelection);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.Name = "frmReportCenter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trung Tâm Báo Cáo - Crystal Reports (Lab 14)";
            this.Load += new System.EventHandler(this.frmReportCenter_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.grpSelection.ResumeLayout(false);
            this.grpSelection.PerformLayout();
            this.flowParams.ResumeLayout(false);
            this.pnlKhoa.ResumeLayout(false);
            this.pnlKhoa.PerformLayout();
            this.pnlKhoangDiem.ResumeLayout(false);
            this.pnlKhoangDiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMin)).EndInit();
            this.pnlTopN.ResumeLayout(false);
            this.pnlTopN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTopN)).EndInit();
            this.pnlHocKy.ResumeLayout(false);
            this.pnlHocKy.PerformLayout();
            this.grpPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
