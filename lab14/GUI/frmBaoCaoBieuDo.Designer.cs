namespace Lab14_AdvancedReport.GUI
{
    partial class frmBaoCaoBieuDo
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.GroupBox grpControl;
        private System.Windows.Forms.Label lblLoai;
        private System.Windows.Forms.ComboBox cboLoaiBieuDo;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Panel pnlChartContainer;
        private System.Windows.Forms.Panel pnlDataContainer;
        private System.Windows.Forms.Panel pnlCanvas;
        private System.Windows.Forms.Label lblChartTitle;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;

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
            this.grpControl = new System.Windows.Forms.GroupBox();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.cboLoaiBieuDo = new System.Windows.Forms.ComboBox();
            this.lblLoai = new System.Windows.Forms.Label();
            this.pnlChartContainer = new System.Windows.Forms.Panel();
            this.pnlDataContainer = new System.Windows.Forms.Panel();
            this.pnlCanvas = new System.Windows.Forms.Panel();
            this.lblChartTitle = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelTop.SuspendLayout();
            this.grpControl.SuspendLayout();
            this.pnlChartContainer.SuspendLayout();
            this.pnlDataContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
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
            this.panelTop.Size = new System.Drawing.Size(984, 55);
            this.panelTop.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(16, 12);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(567, 31);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "BÁO CÁO TRỰC QUAN HÓA BẰNG BIỂU ĐỒ (BÀI 8)";
            // 
            // grpControl
            // 
            this.grpControl.Controls.Add(this.btnXuatExcel);
            this.grpControl.Controls.Add(this.cboLoaiBieuDo);
            this.grpControl.Controls.Add(this.lblLoai);
            this.grpControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpControl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpControl.Location = new System.Drawing.Point(0, 55);
            this.grpControl.Name = "grpControl";
            this.grpControl.Size = new System.Drawing.Size(984, 70);
            this.grpControl.TabIndex = 1;
            this.grpControl.TabStop = false;
            this.grpControl.Text = "Tùy chọn hiển thị biểu đồ";
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXuatExcel.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcel.Location = new System.Drawing.Point(540, 25);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(185, 32);
            this.btnXuatExcel.TabIndex = 2;
            this.btnXuatExcel.Text = "📊 Xuất Dữ Liệu Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = false;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // cboLoaiBieuDo
            // 
            this.cboLoaiBieuDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiBieuDo.FormattingEnabled = true;
            this.cboLoaiBieuDo.Items.AddRange(new object[] {
            "Biểu đồ tròn (Pie Chart): Phân bố xếp loại học lực",
            "Biểu đồ cột (Bar Chart): Số lượng sinh viên theo khoa"});
            this.cboLoaiBieuDo.Location = new System.Drawing.Point(155, 27);
            this.cboLoaiBieuDo.Name = "cboLoaiBieuDo";
            this.cboLoaiBieuDo.Size = new System.Drawing.Size(360, 28);
            this.cboLoaiBieuDo.TabIndex = 1;
            this.cboLoaiBieuDo.SelectedIndexChanged += new System.EventHandler(this.cboLoaiBieuDo_SelectedIndexChanged);
            // 
            // lblLoai
            // 
            this.lblLoai.AutoSize = true;
            this.lblLoai.Location = new System.Drawing.Point(22, 31);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(125, 20);
            this.lblLoai.TabIndex = 0;
            this.lblLoai.Text = "Chọn loại biểu đồ:";
            // 
            // pnlChartContainer
            // 
            this.pnlChartContainer.Controls.Add(this.pnlCanvas);
            this.pnlChartContainer.Controls.Add(this.lblChartTitle);
            this.pnlChartContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlChartContainer.Location = new System.Drawing.Point(0, 125);
            this.pnlChartContainer.Name = "pnlChartContainer";
            this.pnlChartContainer.Padding = new System.Windows.Forms.Padding(10);
            this.pnlChartContainer.Size = new System.Drawing.Size(580, 490);
            this.pnlChartContainer.TabIndex = 2;
            // 
            // pnlDataContainer
            // 
            this.pnlDataContainer.Controls.Add(this.dgvData);
            this.pnlDataContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDataContainer.Location = new System.Drawing.Point(580, 125);
            this.pnlDataContainer.Name = "pnlDataContainer";
            this.pnlDataContainer.Padding = new System.Windows.Forms.Padding(10);
            this.pnlDataContainer.Size = new System.Drawing.Size(404, 490);
            this.pnlDataContainer.TabIndex = 4;
            // 
            // pnlCanvas
            // 
            this.pnlCanvas.BackColor = System.Drawing.Color.White;
            this.pnlCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCanvas.Location = new System.Drawing.Point(10, 42);
            this.pnlCanvas.Name = "pnlCanvas";
            this.pnlCanvas.Size = new System.Drawing.Size(560, 438);
            this.pnlCanvas.TabIndex = 1;
            this.pnlCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCanvas_Paint);
            // 
            // lblChartTitle
            // 
            this.lblChartTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChartTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblChartTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(76)))), ((int)(((byte)(120)))));
            this.lblChartTitle.Location = new System.Drawing.Point(10, 10);
            this.lblChartTitle.Name = "lblChartTitle";
            this.lblChartTitle.Size = new System.Drawing.Size(560, 32);
            this.lblChartTitle.TabIndex = 0;
            this.lblChartTitle.Text = "TIÊU ĐỀ BIỂU ĐỒ";
            this.lblChartTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(10, 10);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersWidth = 30;
            this.dgvData.RowTemplate.Height = 26;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(380, 470);
            this.dgvData.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 615);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(984, 26);
            this.statusStrip1.TabIndex = 3;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(969, 20);
            this.lblStatus.Spring = true;
            this.lblStatus.Text = "Sẵn sàng";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmBaoCaoBieuDo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 641);
            this.Controls.Add(this.pnlDataContainer);
            this.Controls.Add(this.pnlChartContainer);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grpControl);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.Name = "frmBaoCaoBieuDo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Biểu Đồ Thống Kê";
            this.Load += new System.EventHandler(this.frmBaoCaoBieuDo_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.grpControl.ResumeLayout(false);
            this.grpControl.PerformLayout();
            this.pnlChartContainer.ResumeLayout(false);
            this.pnlDataContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
