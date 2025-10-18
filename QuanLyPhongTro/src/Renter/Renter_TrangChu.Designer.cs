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
            btnReport = new Button();
            btnInfo = new Button();
            btnFindRoom = new Button();
            flowPanelRooms = new FlowLayoutPanel();
            panelTop.SuspendLayout();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(25, 42, 86);
            panelTop.Controls.Add(lblTitle);
            panelTop.Controls.Add(lblRenterName);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(6, 6, 6, 6);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(3400, 246);
            panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(57, 72);
            lblTitle.Margin = new Padding(6, 0, 6, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(640, 81);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🏡 Renter Dashboard";
            // 
            // lblRenterName
            // 
            lblRenterName.Anchor = AnchorStyles.Right;
            lblRenterName.AutoSize = true;
            lblRenterName.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            lblRenterName.ForeColor = Color.WhiteSmoke;
            lblRenterName.Location = new Point(2456, 92);
            lblRenterName.Margin = new Padding(6, 0, 6, 0);
            lblRenterName.Name = "lblRenterName";
            lblRenterName.Size = new Size(450, 54);
            lblRenterName.TabIndex = 1;
            lblRenterName.Text = "Welcome, [Renter Name]";
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(41, 128, 185);
            panelMenu.Controls.Add(btnLogout);
            panelMenu.Controls.Add(btnReport);
            panelMenu.Controls.Add(btnInfo);
            panelMenu.Controls.Add(btnFindRoom);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 246);
            panelMenu.Margin = new Padding(6, 6, 6, 6);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(472, 1435);
            panelMenu.TabIndex = 1;
            // 
            // btnLogout
            // 
            btnLogout.Font = new Font("Segoe UI", 12F);
            btnLogout.Location = new Point(57, 1292);
            btnLogout.Margin = new Padding(6, 6, 6, 6);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(340, 123);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnReport
            // 
            btnReport.Font = new Font("Segoe UI", 12F);
            btnReport.Location = new Point(57, 1128);
            btnReport.Margin = new Padding(6, 6, 6, 6);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(340, 123);
            btnReport.TabIndex = 2;
            btnReport.Text = "Report";
            btnReport.UseVisualStyleBackColor = true;
            // 
            // btnInfo
            // 
            btnInfo.Font = new Font("Segoe UI", 12F);
            btnInfo.Location = new Point(57, 266);
            btnInfo.Margin = new Padding(6, 6, 6, 6);
            btnInfo.Name = "btnInfo";
            btnInfo.Size = new Size(340, 123);
            btnInfo.TabIndex = 1;
            btnInfo.Text = "Information";
            btnInfo.UseVisualStyleBackColor = true;
            btnInfo.Click += btnInfo_Click_1;
            // 
            // btnFindRoom
            // 
            btnFindRoom.Font = new Font("Segoe UI", 12F);
            btnFindRoom.Location = new Point(57, 102);
            btnFindRoom.Margin = new Padding(6, 6, 6, 6);
            btnFindRoom.Name = "btnFindRoom";
            btnFindRoom.Size = new Size(340, 123);
            btnFindRoom.TabIndex = 0;
            btnFindRoom.Text = "Find Room";
            btnFindRoom.UseVisualStyleBackColor = true;
            // 
            // flowPanelRooms
            // 
            flowPanelRooms.AutoScroll = true;
            flowPanelRooms.BackColor = Color.WhiteSmoke;
            flowPanelRooms.Dock = DockStyle.Fill;
            flowPanelRooms.Location = new Point(472, 246);
            flowPanelRooms.Margin = new Padding(6, 6, 6, 6);
            flowPanelRooms.Name = "flowPanelRooms";
            flowPanelRooms.Padding = new Padding(38, 41, 38, 41);
            flowPanelRooms.Size = new Size(2928, 1435);
            flowPanelRooms.TabIndex = 2;
            // 
            // Renter_TrangChu
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(3400, 1681);
            Controls.Add(flowPanelRooms);
            Controls.Add(panelMenu);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(6, 6, 6, 6);
            Name = "Renter_TrangChu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Renter Dashboard";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitle;
        private Label lblRenterName;
        private Panel panelMenu;
        private Button btnLogout;
        private Button btnReport;
        private Button btnInfo;
        private Button btnFindRoom;
        public FlowLayoutPanel flowPanelRooms;
    }
}
