namespace Lab14_AdvancedReport.GUI
{
    partial class frmBaoCaoTopN
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.Label lblTopN;
        private System.Windows.Forms.NumericUpDown nudTopN;
        private System.Windows.Forms.Label lblKhoa;
        private System.Windows.Forms.ComboBox cboKhoa;
        private System.Windows.Forms.Button btnTimTop;
        private System.Windows.Forms.Button btnXemBaoCao;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Button btnXuatPdf;
        private System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.DataGridView dgvTopN;
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
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.btnXuatPdf = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnXemBaoCao = new System.Windows.Forms.Button();
            this.btnTimTop = new System.Windows.Forms.Button();
            this.cboKhoa = new System.Windows.Forms.ComboBox();
            this.lblKhoa = new System.Windows.Forms.Label();
            this.nudTopN = new System.Windows.Forms.NumericUpDown();
            this.lblTopN = new System.Windows.Forms.Label();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.dgvTopN = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelTop.SuspendLayout();
            this.grpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTopN)).BeginInit();
            this.grpData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopN)).BeginInit();
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
            this.lblHeaderTitle.Size = new System.Drawing.Size(608, 31);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "BÁO CÁO TOP SINH VIÊN XUẤT SẮC THEO ĐIỂM (BÀI 6)";
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.btnXuatPdf);
            this.grpFilter.Controls.Add(this.btnXuatExcel);
            this.grpFilter.Controls.Add(this.btnXemBaoCao);
            this.grpFilter.Controls.Add(this.btnTimTop);
            this.grpFilter.Controls.Add(this.cboKhoa);
            this.grpFilter.Controls.Add(this.lblKhoa);
            this.grpFilter.Controls.Add(this.nudTopN);
            this.grpFilter.Controls.Add(this.lblTopN);
            this.grpFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpFilter.Location = new System.Drawing.Point(0, 55);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(984, 75);
            this.grpFilter.TabIndex = 1;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Tham số lọc Top N & Xuất báo cáo";
            // 
            // btnXuatPdf
            // 
            this.btnXuatPdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnXuatPdf.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXuatPdf.ForeColor = System.Drawing.Color.White;
            this.btnXuatPdf.Location = new System.Drawing.Point(850, 26);
            this.btnXuatPdf.Name = "btnXuatPdf";
            this.btnXuatPdf.Size = new System.Drawing.Size(115, 32);
            this.btnXuatPdf.TabIndex = 7;
            this.btnXuatPdf.Text = "📄 Xuất PDF";
            this.btnXuatPdf.UseVisualStyleBackColor = false;
            this.btnXuatPdf.Click += new System.EventHandler(this.btnXuatPdf_Click);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXuatExcel.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcel.Location = new System.Drawing.Point(715, 26);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(125, 32);
            this.btnXuatExcel.TabIndex = 6;
            this.btnXuatExcel.Text = "📊 Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = false;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // btnXemBaoCao
            // 
            this.btnXemBaoCao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(100)))), ((int)(((byte)(160)))));
            this.btnXemBaoCao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXemBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnXemBaoCao.Location = new System.Drawing.Point(575, 26);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(130, 32);
            this.btnXemBaoCao.TabIndex = 5;
            this.btnXemBaoCao.Text = "🔍 Xem Báo Cáo";
            this.btnXemBaoCao.UseVisualStyleBackColor = false;
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);
            // 
            // btnTimTop
            // 
            this.btnTimTop.Location = new System.Drawing.Point(475, 26);
            this.btnTimTop.Name = "btnTimTop";
            this.btnTimTop.Size = new System.Drawing.Size(90, 32);
            this.btnTimTop.TabIndex = 4;
            this.btnTimTop.Text = "Lọc Top N";
            this.btnTimTop.UseVisualStyleBackColor = true;
            this.btnTimTop.Click += new System.EventHandler(this.btnTimTop_Click);
            // 
            // cboKhoa
            // 
            this.cboKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoa.FormattingEnabled = true;
            this.cboKhoa.Location = new System.Drawing.Point(245, 28);
            this.cboKhoa.Name = "cboKhoa";
            this.cboKhoa.Size = new System.Drawing.Size(215, 28);
            this.cboKhoa.TabIndex = 3;
            // 
            // lblKhoa
            // 
            this.lblKhoa.AutoSize = true;
            this.lblKhoa.Location = new System.Drawing.Point(155, 32);
            this.lblKhoa.Name = "lblKhoa";
            this.lblKhoa.Size = new System.Drawing.Size(84, 20);
            this.lblKhoa.TabIndex = 2;
            this.lblKhoa.Text = "Chọn Khoa:";
            // 
            // nudTopN
            // 
            this.nudTopN.Location = new System.Drawing.Point(80, 28);
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
            this.nudTopN.Size = new System.Drawing.Size(65, 27);
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
            this.lblTopN.Location = new System.Drawing.Point(16, 32);
            this.lblTopN.Name = "lblTopN";
            this.lblTopN.Size = new System.Drawing.Size(59, 20);
            this.lblTopN.TabIndex = 0;
            this.lblTopN.Text = "Nhập N:";
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.dgvTopN);
            this.grpData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpData.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpData.Location = new System.Drawing.Point(0, 130);
            this.grpData.Name = "grpData";
            this.grpData.Padding = new System.Windows.Forms.Padding(10);
            this.grpData.Size = new System.Drawing.Size(984, 485);
            this.grpData.TabIndex = 2;
            this.grpData.TabStop = false;
            this.grpData.Text = "Danh sách sinh viên vinh danh xếp hạng theo điểm trung bình";
            // 
            // dgvTopN
            // 
            this.dgvTopN.AllowUserToAddRows = false;
            this.dgvTopN.AllowUserToDeleteRows = false;
            this.dgvTopN.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopN.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTopN.Location = new System.Drawing.Point(10, 30);
            this.dgvTopN.MultiSelect = false;
            this.dgvTopN.Name = "dgvTopN";
            this.dgvTopN.ReadOnly = true;
            this.dgvTopN.RowHeadersWidth = 35;
            this.dgvTopN.RowTemplate.Height = 26;
            this.dgvTopN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopN.Size = new System.Drawing.Size(964, 445);
            this.dgvTopN.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblTotal});
            this.statusStrip1.Location = new System.Drawing.Point(0, 615);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(984, 26);
            this.statusStrip1.TabIndex = 3;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(769, 20);
            this.lblStatus.Spring = true;
            this.lblStatus.Text = "Sẵn sàng";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(200, 20);
            this.lblTotal.Text = "Tổng số sinh viên: 0";
            // 
            // frmBaoCaoTopN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 641);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grpFilter);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.Name = "frmBaoCaoTopN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Top N Sinh Viên";
            this.Load += new System.EventHandler(this.frmBaoCaoTopN_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTopN)).EndInit();
            this.grpData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopN)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
