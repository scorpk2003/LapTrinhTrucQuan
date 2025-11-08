namespace QuanLyPhongTro
{
    partial class Owner_TrangChu
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
            panelTop = new Panel();
            lblTitle = new Label();
            lblOwnerName = new Label();
            panelMenu = new Panel();
            btnLogout = new Button();
            btnReport = new Button();
            btnContract = new Button();
            btnBill = new Button();
            btnCreate = new Button();
            flowPanelRooms = new FlowLayoutPanel();
            panelSearch = new Panel();
            btnSearch = new Button();
            txtSearch = new TextBox();
            panelTop.SuspendLayout();
            panelMenu.SuspendLayout();
            panelSearch.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(25, 42, 86);
            panelTop.Controls.Add(lblTitle);
            panelTop.Controls.Add(lblOwnerName);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(8, 8, 8, 8);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(2500, 167);
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
            lblTitle.Size = new Size(632, 81);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🏠 Owner Dashboard";
            // 
            // lblOwnerName
            // 
            lblOwnerName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblOwnerName.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            lblOwnerName.ForeColor = Color.WhiteSmoke;
            lblOwnerName.Location = new Point(1772, 58);
            lblOwnerName.Margin = new Padding(8, 0, 8, 0);
            lblOwnerName.Name = "lblOwnerName";
            lblOwnerName.Size = new Size(700, 53);
            lblOwnerName.TabIndex = 1;
            lblOwnerName.Text = "Welcome, [Owner Name]";
            lblOwnerName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(41, 128, 185);
            panelMenu.Controls.Add(btnLogout);
            panelMenu.Controls.Add(btnReport);
            panelMenu.Controls.Add(btnContract);
            panelMenu.Controls.Add(btnBill);
            panelMenu.Controls.Add(btnCreate);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 167);
            panelMenu.Margin = new Padding(8, 8, 8, 8);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(463, 1500);
            panelMenu.TabIndex = 1;
            // 
            // btnLogout
            // 
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.Font = new Font("Segoe UI", 11F);
            btnLogout.Location = new Point(0, 1408);
            btnLogout.Margin = new Padding(17, 17, 17, 17);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(463, 92);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "Đăng xuất";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnReport
            // 
            btnReport.Dock = DockStyle.Top;
            btnReport.Font = new Font("Segoe UI", 11F);
            btnReport.Location = new Point(0, 276);
            btnReport.Margin = new Padding(8, 8, 8, 8);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(463, 92);
            btnReport.TabIndex = 4;
            btnReport.Text = "Báo cáo / Thống kê";
            btnReport.UseVisualStyleBackColor = true;
            // 
            // btnContract
            // 
            btnContract.Dock = DockStyle.Top;
            btnContract.Font = new Font("Segoe UI", 11F);
            btnContract.Location = new Point(0, 184);
            btnContract.Margin = new Padding(8, 8, 8, 8);
            btnContract.Name = "btnContract";
            btnContract.Size = new Size(463, 92);
            btnContract.TabIndex = 3;
            btnContract.Text = "Quản lí Hợp đồng";
            btnContract.UseVisualStyleBackColor = true;
            // 
            // btnBill
            // 
            btnBill.Dock = DockStyle.Top;
            btnBill.Font = new Font("Segoe UI", 11F);
            btnBill.Location = new Point(0, 92);
            btnBill.Margin = new Padding(8, 8, 8, 8);
            btnBill.Name = "btnBill";
            btnBill.Size = new Size(463, 92);
            btnBill.TabIndex = 2;
            btnBill.Text = "Quản lí Hóa đơn";
            btnBill.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            btnCreate.Dock = DockStyle.Top;
            btnCreate.Font = new Font("Segoe UI", 11F);
            btnCreate.Location = new Point(0, 0);
            btnCreate.Margin = new Padding(8, 8, 8, 8);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(463, 92);
            btnCreate.TabIndex = 0;
            btnCreate.Text = "Thêm phòng mới";
            btnCreate.UseVisualStyleBackColor = true;
            // 
            // flowPanelRooms
            // 
            flowPanelRooms.AutoScroll = true;
            flowPanelRooms.BackColor = Color.WhiteSmoke;
            flowPanelRooms.Dock = DockStyle.Fill;
            flowPanelRooms.Location = new Point(463, 284);
            flowPanelRooms.Margin = new Padding(8, 8, 8, 8);
            flowPanelRooms.Name = "flowPanelRooms";
            flowPanelRooms.Padding = new Padding(33, 33, 33, 33);
            flowPanelRooms.Size = new Size(2037, 1383);
            flowPanelRooms.TabIndex = 2;
            // 
            // panelSearch
            // 
            panelSearch.BackColor = Color.White;
            panelSearch.Controls.Add(btnSearch);
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Dock = DockStyle.Top;
            panelSearch.Location = new Point(463, 167);
            panelSearch.Margin = new Padding(5, 5, 5, 5);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(2037, 117);
            panelSearch.TabIndex = 3;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Segoe UI", 10F);
            btnSearch.Location = new Point(733, 30);
            btnSearch.Margin = new Padding(5, 5, 5, 5);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(200, 60);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 12F);
            txtSearch.Location = new Point(42, 30);
            txtSearch.Margin = new Padding(5, 5, 5, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(664, 61);
            txtSearch.TabIndex = 0;
            // 
            // Owner_TrangChu
            // 
            AutoScaleDimensions = new SizeF(240F, 240F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(2500, 1667);
            Controls.Add(flowPanelRooms);
            Controls.Add(panelSearch);
            Controls.Add(panelMenu);
            Controls.Add(panelTop);
            Margin = new Padding(8, 8, 8, 8);
            Name = "Owner_TrangChu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Owner Dashboard";
            WindowState = FormWindowState.Maximized;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelMenu.ResumeLayout(false);
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblOwnerName;
        private System.Windows.Forms.Panel panelMenu;
        public System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnBill;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnLogout;
        public System.Windows.Forms.FlowLayoutPanel flowPanelRooms;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnContract;
    }
}