namespace Lab14_AdvancedReport.GUI
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            mnuThongTin = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            mnuBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            mnuBaoCaoTheoKhoa = new System.Windows.Forms.ToolStripMenuItem();
            mnuBaoCaoKhoangDiem = new System.Windows.Forms.ToolStripMenuItem();
            mnuBaoCaoTopN = new System.Windows.Forms.ToolStripMenuItem();
            mnuBaoCaoDangKyHocKy = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            mnuBaoCaoBieuDo = new System.Windows.Forms.ToolStripMenuItem();
            mnuXuatDgvExcel = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            mnuTrungTamBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            mnuKiemThu = new System.Windows.Forms.ToolStripMenuItem();
            mnuKiemThuXuatBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            lblTime = new System.Windows.Forms.ToolStripStatusLabel();
            timerClock = new System.Windows.Forms.Timer(components);
            pnlBanner = new System.Windows.Forms.Panel();
            lblTitle = new System.Windows.Forms.Label();
            lblSubTitle = new System.Windows.Forms.Label();
            lblStudentInfo = new System.Windows.Forms.Label();
            pnlContainer = new System.Windows.Forms.Panel();
            flpNav = new System.Windows.Forms.FlowLayoutPanel();
            btnNavKhoa = new System.Windows.Forms.Button();
            btnNavDiem = new System.Windows.Forms.Button();
            btnNavTopN = new System.Windows.Forms.Button();
            btnNavHocKy = new System.Windows.Forms.Button();
            btnNavBieuDo = new System.Windows.Forms.Button();
            btnNavCenter = new System.Windows.Forms.Button();
            grpIntro = new System.Windows.Forms.GroupBox();
            txtIntro = new System.Windows.Forms.TextBox();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            pnlBanner.SuspendLayout();
            pnlContainer.SuspendLayout();
            flpNav.SuspendLayout();
            grpIntro.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                mnuHeThong,
                mnuBaoCao,
                mnuKiemThu
            });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(984, 27);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // mnuHeThong
            // 
            mnuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                mnuThongTin,
                toolStripSeparator1,
                mnuThoat
            });
            mnuHeThong.Name = "mnuHeThong";
            mnuHeThong.Size = new System.Drawing.Size(79, 23);
            mnuHeThong.Text = "&Hệ thống";
            // 
            // mnuThongTin
            // 
            mnuThongTin.Name = "mnuThongTin";
            mnuThongTin.ShortcutKeys = System.Windows.Forms.Keys.F1;
            mnuThongTin.Size = new System.Drawing.Size(201, 24);
            mnuThongTin.Text = "Thông tin sinh viên";
            mnuThongTin.Click += mnuThongTin_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(198, 6);
            // 
            // mnuThoat
            // 
            mnuThoat.Name = "mnuThoat";
            mnuThoat.ShortcutKeys = System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4;
            mnuThoat.Size = new System.Drawing.Size(201, 24);
            mnuThoat.Text = "Thoát";
            mnuThoat.Click += mnuThoat_Click;
            // 
            // mnuBaoCao
            // 
            mnuBaoCao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                mnuBaoCaoTheoKhoa,
                mnuBaoCaoKhoangDiem,
                mnuBaoCaoTopN,
                mnuBaoCaoDangKyHocKy,
                toolStripSeparator2,
                mnuBaoCaoBieuDo,
                mnuXuatDgvExcel,
                toolStripSeparator3,
                mnuTrungTamBaoCao
            });
            mnuBaoCao.Name = "mnuBaoCao";
            mnuBaoCao.Size = new System.Drawing.Size(127, 23);
            mnuBaoCao.Text = "&Báo cáo & Xuất file";
            // 
            // mnuBaoCaoTheoKhoa
            // 
            mnuBaoCaoTheoKhoa.Name = "mnuBaoCaoTheoKhoa";
            mnuBaoCaoTheoKhoa.Size = new System.Drawing.Size(277, 24);
            mnuBaoCaoTheoKhoa.Text = "1. Báo cáo Sinh viên theo Khoa";
            mnuBaoCaoTheoKhoa.Click += mnuBaoCaoTheoKhoa_Click;
            // 
            // mnuBaoCaoKhoangDiem
            // 
            mnuBaoCaoKhoangDiem.Name = "mnuBaoCaoKhoangDiem";
            mnuBaoCaoKhoangDiem.Size = new System.Drawing.Size(277, 24);
            mnuBaoCaoKhoangDiem.Text = "2. Báo cáo theo Khoảng điểm";
            mnuBaoCaoKhoangDiem.Click += mnuBaoCaoKhoangDiem_Click;
            // 
            // mnuBaoCaoTopN
            // 
            mnuBaoCaoTopN.Name = "mnuBaoCaoTopN";
            mnuBaoCaoTopN.Size = new System.Drawing.Size(277, 24);
            mnuBaoCaoTopN.Text = "3. Báo cáo Top N Sinh viên";
            mnuBaoCaoTopN.Click += mnuBaoCaoTopN_Click;
            // 
            // mnuBaoCaoDangKyHocKy
            // 
            mnuBaoCaoDangKyHocKy.Name = "mnuBaoCaoDangKyHocKy";
            mnuBaoCaoDangKyHocKy.Size = new System.Drawing.Size(277, 24);
            mnuBaoCaoDangKyHocKy.Text = "4. Báo cáo Đăng ký theo Học kỳ";
            mnuBaoCaoDangKyHocKy.Click += mnuBaoCaoDangKyHocKy_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(274, 6);
            // 
            // mnuBaoCaoBieuDo
            // 
            mnuBaoCaoBieuDo.Name = "mnuBaoCaoBieuDo";
            mnuBaoCaoBieuDo.Size = new System.Drawing.Size(277, 24);
            mnuBaoCaoBieuDo.Text = "5. Biểu đồ Thống kê (Pie / Bar)";
            mnuBaoCaoBieuDo.Click += mnuBaoCaoBieuDo_Click;
            // 
            // mnuXuatDgvExcel
            // 
            mnuXuatDgvExcel.Name = "mnuXuatDgvExcel";
            mnuXuatDgvExcel.Size = new System.Drawing.Size(277, 24);
            mnuXuatDgvExcel.Text = "6. Xuất DataGridView sang Excel";
            mnuXuatDgvExcel.Click += mnuXuatDgvExcel_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(274, 6);
            // 
            // mnuTrungTamBaoCao
            // 
            mnuTrungTamBaoCao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            mnuTrungTamBaoCao.Name = "mnuTrungTamBaoCao";
            mnuTrungTamBaoCao.Size = new System.Drawing.Size(277, 24);
            mnuTrungTamBaoCao.Text = "7. Trung tâm Báo cáo Tổng hợp";
            mnuTrungTamBaoCao.Click += mnuTrungTamBaoCao_Click;
            // 
            // mnuKiemThu
            // 
            mnuKiemThu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                mnuKiemThuXuatBaoCao
            });
            mnuKiemThu.Name = "mnuKiemThu";
            mnuKiemThu.Size = new System.Drawing.Size(75, 23);
            mnuKiemThu.Text = "&Kiểm thử";
            // 
            // mnuKiemThuXuatBaoCao
            // 
            mnuKiemThuXuatBaoCao.Name = "mnuKiemThuXuatBaoCao";
            mnuKiemThuXuatBaoCao.Size = new System.Drawing.Size(294, 24);
            mnuKiemThuXuatBaoCao.Text = "Xuất hàng loạt 4 Báo cáo (Excel & PDF)";
            mnuKiemThuXuatBaoCao.Click += mnuKiemThuXuatBaoCao_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                lblStatus,
                lblTime
            });
            statusStrip1.Location = new System.Drawing.Point(0, 617);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(984, 24);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            lblStatus.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(769, 19);
            lblStatus.Spring = true;
            lblStatus.Text = "Hệ thống sẵn sàng.";
            lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTime
            // 
            lblTime.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblTime.ForeColor = System.Drawing.Color.FromArgb(30, 58, 138);
            lblTime.Name = "lblTime";
            lblTime.Size = new System.Drawing.Size(200, 19);
            lblTime.Text = "01/01/2026 00:00:00";
            lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timerClock
            // 
            timerClock.Interval = 1000;
            timerClock.Tick += timerClock_Tick;
            // 
            // pnlBanner
            // 
            pnlBanner.BackColor = System.Drawing.Color.FromArgb(30, 58, 138);
            pnlBanner.Controls.Add(lblStudentInfo);
            pnlBanner.Controls.Add(lblSubTitle);
            pnlBanner.Controls.Add(lblTitle);
            pnlBanner.Dock = System.Windows.Forms.DockStyle.Top;
            pnlBanner.Location = new System.Drawing.Point(0, 27);
            pnlBanner.Name = "pnlBanner";
            pnlBanner.Size = new System.Drawing.Size(984, 110);
            pnlBanner.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(20, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(760, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "LAB 14: BÁO CÁO THAM SỐ, NHÓM, THỐNG KÊ VÀ XUẤT EXCEL";
            // 
            // lblSubTitle
            // 
            lblSubTitle.AutoSize = true;
            lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Italic);
            lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(224, 231, 255);
            lblSubTitle.Location = new System.Drawing.Point(22, 47);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new System.Drawing.Size(620, 20);
            lblSubTitle.TabIndex = 1;
            lblSubTitle.Text = "Học phần Lập trình .NET (IT3212) - Trường Đại học Công nghệ Đông Á (EAUT)";
            // 
            // lblStudentInfo
            // 
            lblStudentInfo.AutoSize = true;
            lblStudentInfo.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            lblStudentInfo.ForeColor = System.Drawing.Color.FromArgb(253, 224, 71);
            lblStudentInfo.Location = new System.Drawing.Point(22, 75);
            lblStudentInfo.Name = "lblStudentInfo";
            lblStudentInfo.Size = new System.Drawing.Size(730, 19);
            lblStudentInfo.TabIndex = 2;
            lblStudentInfo.Text = "Sinh viên: Phan Văn Thắng | MSSV: 24002545 | Lớp: IT3212 | Ngày sinh: 26/03/2006";
            // 
            // pnlContainer
            // 
            pnlContainer.Controls.Add(flpNav);
            pnlContainer.Controls.Add(grpIntro);
            pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlContainer.Location = new System.Drawing.Point(0, 137);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Padding = new System.Windows.Forms.Padding(20);
            pnlContainer.Size = new System.Drawing.Size(984, 480);
            pnlContainer.TabIndex = 3;
            // 
            // flpNav
            // 
            flpNav.Controls.Add(btnNavKhoa);
            flpNav.Controls.Add(btnNavDiem);
            flpNav.Controls.Add(btnNavTopN);
            flpNav.Controls.Add(btnNavHocKy);
            flpNav.Controls.Add(btnNavBieuDo);
            flpNav.Controls.Add(btnNavCenter);
            flpNav.Dock = System.Windows.Forms.DockStyle.Top;
            flpNav.Location = new System.Drawing.Point(20, 20);
            flpNav.Name = "flpNav";
            flpNav.Size = new System.Drawing.Size(944, 160);
            flpNav.TabIndex = 0;
            // 
            // btnNavKhoa
            // 
            btnNavKhoa.BackColor = System.Drawing.Color.FromArgb(30, 58, 138);
            btnNavKhoa.Cursor = System.Windows.Forms.Cursors.Hand;
            btnNavKhoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnNavKhoa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnNavKhoa.ForeColor = System.Drawing.Color.White;
            btnNavKhoa.Location = new System.Drawing.Point(4, 4);
            btnNavKhoa.Margin = new System.Windows.Forms.Padding(4);
            btnNavKhoa.Size = new System.Drawing.Size(225, 70);
            btnNavKhoa.TabIndex = 0;
            btnNavKhoa.Text = "1. Báo cáo theo Khoa\r\n(Tham số & Nhóm)";
            btnNavKhoa.UseVisualStyleBackColor = false;
            btnNavKhoa.Click += btnNavKhoa_Click;
            // 
            // btnNavDiem
            // 
            btnNavDiem.BackColor = System.Drawing.Color.FromArgb(13, 148, 136);
            btnNavDiem.Cursor = System.Windows.Forms.Cursors.Hand;
            btnNavDiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnNavDiem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnNavDiem.ForeColor = System.Drawing.Color.White;
            btnNavDiem.Location = new System.Drawing.Point(237, 4);
            btnNavDiem.Margin = new System.Windows.Forms.Padding(4);
            btnNavDiem.Size = new System.Drawing.Size(225, 70);
            btnNavDiem.TabIndex = 1;
            btnNavDiem.Text = "2. Khoảng điểm Min-Max\r\n(Lọc & Validation)";
            btnNavDiem.UseVisualStyleBackColor = false;
            btnNavDiem.Click += btnNavDiem_Click;
            // 
            // btnNavTopN
            // 
            btnNavTopN.BackColor = System.Drawing.Color.FromArgb(217, 119, 6);
            btnNavTopN.Cursor = System.Windows.Forms.Cursors.Hand;
            btnNavTopN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnNavTopN.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnNavTopN.ForeColor = System.Drawing.Color.White;
            btnNavTopN.Location = new System.Drawing.Point(470, 4);
            btnNavTopN.Margin = new System.Windows.Forms.Padding(4);
            btnNavTopN.Size = new System.Drawing.Size(225, 70);
            btnNavTopN.TabIndex = 2;
            btnNavTopN.Text = "3. Top N Sinh viên\r\n(Xếp hạng & Tuyên dương)";
            btnNavTopN.UseVisualStyleBackColor = false;
            btnNavTopN.Click += btnNavTopN_Click;
            // 
            // btnNavHocKy
            // 
            btnNavHocKy.BackColor = System.Drawing.Color.FromArgb(109, 40, 217);
            btnNavHocKy.Cursor = System.Windows.Forms.Cursors.Hand;
            btnNavHocKy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnNavHocKy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnNavHocKy.ForeColor = System.Drawing.Color.White;
            btnNavHocKy.Location = new System.Drawing.Point(703, 4);
            btnNavHocKy.Margin = new System.Windows.Forms.Padding(4);
            btnNavHocKy.Size = new System.Drawing.Size(225, 70);
            btnNavHocKy.TabIndex = 3;
            btnNavHocKy.Text = "4. Đăng ký Học kỳ\r\n(Nhóm đa cấp & Thống kê)";
            btnNavHocKy.UseVisualStyleBackColor = false;
            btnNavHocKy.Click += btnNavHocKy_Click;
            // 
            // btnNavBieuDo
            // 
            btnNavBieuDo.BackColor = System.Drawing.Color.FromArgb(5, 150, 105);
            btnNavBieuDo.Cursor = System.Windows.Forms.Cursors.Hand;
            btnNavBieuDo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnNavBieuDo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnNavBieuDo.ForeColor = System.Drawing.Color.White;
            btnNavBieuDo.Location = new System.Drawing.Point(4, 82);
            btnNavBieuDo.Margin = new System.Windows.Forms.Padding(4);
            btnNavBieuDo.Size = new System.Drawing.Size(225, 70);
            btnNavBieuDo.TabIndex = 4;
            btnNavBieuDo.Text = "5. Biểu đồ Thống kê\r\n(Pie Chart & Bar Chart)";
            btnNavBieuDo.UseVisualStyleBackColor = false;
            btnNavBieuDo.Click += btnNavBieuDo_Click;
            // 
            // btnNavCenter
            // 
            btnNavCenter.BackColor = System.Drawing.Color.FromArgb(220, 38, 38);
            btnNavCenter.Cursor = System.Windows.Forms.Cursors.Hand;
            btnNavCenter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnNavCenter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnNavCenter.ForeColor = System.Drawing.Color.White;
            btnNavCenter.Location = new System.Drawing.Point(237, 82);
            btnNavCenter.Margin = new System.Windows.Forms.Padding(4);
            btnNavCenter.Size = new System.Drawing.Size(458, 70);
            btnNavCenter.TabIndex = 5;
            btnNavCenter.Text = "★ TRUNG TÂM BÁO CÁO TỔNG HỢP (BÀI 10)\r\nXem trước động & Xuất Excel / PDF";
            btnNavCenter.UseVisualStyleBackColor = false;
            btnNavCenter.Click += btnNavCenter_Click;
            // 
            // grpIntro
            // 
            grpIntro.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
            | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            grpIntro.Controls.Add(txtIntro);
            grpIntro.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            grpIntro.ForeColor = System.Drawing.Color.FromArgb(30, 58, 138);
            grpIntro.Location = new System.Drawing.Point(20, 190);
            grpIntro.Name = "grpIntro";
            grpIntro.Padding = new System.Windows.Forms.Padding(12);
            grpIntro.Size = new System.Drawing.Size(944, 270);
            grpIntro.TabIndex = 1;
            grpIntro.TabStop = false;
            grpIntro.Text = "MÔ TẢ CÁC NỘI DUNG VÀ TÍNH NĂNG CỦA LAB 14";
            // 
            // txtIntro
            // 
            txtIntro.BackColor = System.Drawing.Color.White;
            txtIntro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtIntro.Dock = System.Windows.Forms.DockStyle.Fill;
            txtIntro.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtIntro.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            txtIntro.Location = new System.Drawing.Point(12, 31);
            txtIntro.Multiline = true;
            txtIntro.Name = "txtIntro";
            txtIntro.ReadOnly = true;
            txtIntro.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtIntro.Size = new System.Drawing.Size(920, 227);
            txtIntro.TabIndex = 0;
            txtIntro.Text = "LAB 14 bao gồm đầy đủ 10 bài tập với các kỹ thuật báo cáo chuyên sâu:\r\n\r\n" +
                "1. Bài 1: Tạo báo cáo theo tham số khoa (pTenKhoa, pNgayLap).\r\n" +
                "2. Bài 2: Nhóm dữ liệu theo khoa (Group by TenKhoa, tính tổng số sinh viên theo khoa).\r\n" +
                "3. Bài 3: Thống kê điểm trung bình (Average, Max, Min theo khoa, xếp loại bằng Formula Field).\r\n" +
                "4. Bài 4: Báo cáo danh sách sinh viên theo khoảng điểm (pMinDiem, pMaxDiem).\r\n" +
                "5. Bài 5: Xuất Crystal Report sang định dạng Excel (.xlsx / .xls).\r\n" +
                "6. Bài 6: Báo cáo Top N sinh viên có điểm trung bình cao nhất theo khoa.\r\n" +
                "7. Bài 7: Báo cáo tổng hợp số lượng đăng ký môn học theo từng học kỳ.\r\n" +
                "8. Bài 8: Báo cáo kết hợp biểu đồ trực quan (Pie Chart phân bố học lực & Bar Chart quy mô khoa).\r\n" +
                "9. Bài 9: Viết hàm xuất dữ liệu từ DataGridView ra Excel chuẩn định dạng tiền tệ / số thực / ngày tháng.\r\n" +
                "10. Bài 10: Xây dựng Trung tâm Báo cáo (Report Center) tổng hợp tất cả báo cáo với bộ lọc linh hoạt.\r\n\r\n" +
                "Kiến trúc 3 lớp: DTO, DAL, BUS, GUI. Kết nối CSDL: MSSQLLocalDB (Database QLSinhVien).";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            ClientSize = new System.Drawing.Size(984, 641);
            Controls.Add(pnlContainer);
            Controls.Add(pnlBanner);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            MainMenuStrip = menuStrip1;
            MinimumSize = new System.Drawing.Size(1000, 680);
            Name = "frmMain";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "LAB 14 - BÁO CÁO THAM SỐ, NHÓM, THỐNG KÊ VÀ XUẤT EXCEL - PHAN VĂN THẮNG (24002545)";
            Load += frmMain_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            pnlBanner.ResumeLayout(false);
            pnlBanner.PerformLayout();
            pnlContainer.ResumeLayout(false);
            flpNav.ResumeLayout(false);
            grpIntro.ResumeLayout(false);
            grpIntro.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuHeThong;
        private System.Windows.Forms.ToolStripMenuItem mnuThongTin;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
        private System.Windows.Forms.ToolStripMenuItem mnuBaoCao;
        private System.Windows.Forms.ToolStripMenuItem mnuBaoCaoTheoKhoa;
        private System.Windows.Forms.ToolStripMenuItem mnuBaoCaoKhoangDiem;
        private System.Windows.Forms.ToolStripMenuItem mnuBaoCaoTopN;
        private System.Windows.Forms.ToolStripMenuItem mnuBaoCaoDangKyHocKy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuBaoCaoBieuDo;
        private System.Windows.Forms.ToolStripMenuItem mnuXuatDgvExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuTrungTamBaoCao;
        private System.Windows.Forms.ToolStripMenuItem mnuKiemThu;
        private System.Windows.Forms.ToolStripMenuItem mnuKiemThuXuatBaoCao;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblTime;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.Panel pnlBanner;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Label lblStudentInfo;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.FlowLayoutPanel flpNav;
        private System.Windows.Forms.Button btnNavKhoa;
        private System.Windows.Forms.Button btnNavDiem;
        private System.Windows.Forms.Button btnNavTopN;
        private System.Windows.Forms.Button btnNavHocKy;
        private System.Windows.Forms.Button btnNavBieuDo;
        private System.Windows.Forms.Button btnNavCenter;
        private System.Windows.Forms.GroupBox grpIntro;
        private System.Windows.Forms.TextBox txtIntro;
    }
}
