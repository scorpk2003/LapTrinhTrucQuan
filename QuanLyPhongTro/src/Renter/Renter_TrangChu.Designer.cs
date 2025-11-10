namespace QuanLyPhongTro
{
    partial class Renter_TrangChu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelTop = new Panel();
            lblTitle = new Label();
            lblRenterName = new Label();
            panelMenu = new Panel();
            btnLogout = new Button();
            btnProfile = new Button();
            btnReport = new Button();
            btnContract = new Button();
            btnBills = new Button();
            btnHome = new Button();
            flowPanelRooms = new FlowLayoutPanel();
            panelFindRoom = new Panel();
            label1 = new Label();
            panelMainContent = new Panel();
            panelTop.SuspendLayout();
            panelMenu.SuspendLayout();
            panelFindRoom.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(25, 42, 86);
            panelTop.Controls.Add(lblTitle);
            panelTop.Controls.Add(lblRenterName);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(8);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(2478, 167);
            panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(43, 48);
            lblTitle.Margin = new Padding(8, 0, 8, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(640, 81);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🏡 Renter Dashboard";
            // 
            // lblRenterName
            // 
            lblRenterName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblRenterName.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            lblRenterName.ForeColor = Color.WhiteSmoke;
            lblRenterName.Location = new Point(1750, 58);
            lblRenterName.Margin = new Padding(8, 0, 8, 0);
            lblRenterName.Name = "lblRenterName";
            lblRenterName.Size = new Size(700, 53);
            lblRenterName.TabIndex = 1;
            lblRenterName.Text = "Welcome, [Renter Name]";
            lblRenterName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(41, 128, 185);
            panelMenu.Controls.Add(btnLogout);
            panelMenu.Controls.Add(btnProfile);
            panelMenu.Controls.Add(btnReport);
            panelMenu.Controls.Add(btnContract);
            panelMenu.Controls.Add(btnBills);
            panelMenu.Controls.Add(btnHome);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 167);
            panelMenu.Margin = new Padding(8);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(463, 1481);
            panelMenu.TabIndex = 1;
            panelMenu.Visible = false;
            // 
            // btnLogout
            // 
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.Font = new Font("Segoe UI", 11F);
            btnLogout.Location = new Point(0, 1389);
            btnLogout.Margin = new Padding(17);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(463, 92);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "Đăng xuất";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnProfile
            // 
            btnProfile.Dock = DockStyle.Top;
            btnProfile.Font = new Font("Segoe UI", 11F);
            btnProfile.Location = new Point(0, 368);
            btnProfile.Margin = new Padding(8);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(463, 92);
            btnProfile.TabIndex = 4;
            btnProfile.Text = "Hồ sơ cá nhân";
            btnProfile.UseVisualStyleBackColor = true;
            // 
            // btnReport
            // 
            btnReport.Dock = DockStyle.Top;
            btnReport.Font = new Font("Segoe UI", 11F);
            btnReport.Location = new Point(0, 276);
            btnReport.Margin = new Padding(8);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(463, 92);
            btnReport.TabIndex = 3;
            btnReport.Text = "Gửi báo cáo / Sự cố";
            btnReport.UseVisualStyleBackColor = true;
            // 
            // btnContract
            // 
            btnContract.Dock = DockStyle.Top;
            btnContract.Font = new Font("Segoe UI", 11F);
            btnContract.Location = new Point(0, 184);
            btnContract.Margin = new Padding(8);
            btnContract.Name = "btnContract";
            btnContract.Size = new Size(463, 92);
            btnContract.TabIndex = 2;
            btnContract.Text = "Hợp đồng của tôi";
            btnContract.UseVisualStyleBackColor = true;
            // 
            // btnBills
            // 
            btnBills.Dock = DockStyle.Top;
            btnBills.Font = new Font("Segoe UI", 11F);
            btnBills.Location = new Point(0, 92);
            btnBills.Margin = new Padding(8);
            btnBills.Name = "btnBills";
            btnBills.Size = new Size(463, 92);
            btnBills.TabIndex = 1;
            btnBills.Text = "Hóa đơn & Thanh toán";
            btnBills.UseVisualStyleBackColor = true;
            // 
            // btnHome
            // 
            btnHome.Dock = DockStyle.Top;
            btnHome.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnHome.Location = new Point(0, 0);
            btnHome.Margin = new Padding(8);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(463, 92);
            btnHome.TabIndex = 0;
            btnHome.Text = "Trang chủ";
            btnHome.UseVisualStyleBackColor = true;
            // 
            // flowPanelRooms
            // 
            flowPanelRooms.AutoScroll = true;
            flowPanelRooms.BackColor = Color.WhiteSmoke;
            flowPanelRooms.Dock = DockStyle.Fill;
            flowPanelRooms.Location = new Point(0, 79);
            flowPanelRooms.Margin = new Padding(8);
            flowPanelRooms.Name = "flowPanelRooms";
            flowPanelRooms.Padding = new Padding(33);
            flowPanelRooms.Size = new Size(2015, 1402);
            flowPanelRooms.TabIndex = 2;
            // 
            // panelFindRoom
            // 
            panelFindRoom.Controls.Add(flowPanelRooms);
            panelFindRoom.Controls.Add(label1);
            panelFindRoom.Dock = DockStyle.Left;
            panelFindRoom.Location = new Point(463, 167);
            panelFindRoom.Margin = new Padding(5);
            panelFindRoom.Name = "panelFindRoom";
            panelFindRoom.Size = new Size(2015, 1481);
            panelFindRoom.TabIndex = 3;
            panelFindRoom.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(33, 17, 0, 0);
            label1.Size = new Size(522, 79);
            label1.TabIndex = 3;
            label1.Text = "Các phòng còn trống";
            // 
            // panelMainContent
            // 
            panelMainContent.Dock = DockStyle.Fill;
            panelMainContent.Location = new Point(2478, 167);
            panelMainContent.Margin = new Padding(5);
            panelMainContent.Name = "panelMainContent";
            panelMainContent.Size = new Size(0, 1481);
            panelMainContent.TabIndex = 4;
            // 
            // Renter_TrangChu
            // 
            AutoScaleDimensions = new SizeF(240F, 240F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(2478, 1648);
            Controls.Add(panelMainContent);
            Controls.Add(panelFindRoom);
            Controls.Add(panelMenu);
            Controls.Add(panelTop);
            Margin = new Padding(8);
            Name = "Renter_TrangChu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Renter Dashboard";
            WindowState = FormWindowState.Maximized;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelMenu.ResumeLayout(false);
            panelFindRoom.ResumeLayout(false);
            panelFindRoom.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRenterName;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnBills;
        private System.Windows.Forms.Button btnHome;
        public System.Windows.Forms.FlowLayoutPanel flowPanelRooms;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnContract;
        private System.Windows.Forms.Panel panelFindRoom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelMainContent;
    }
}