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
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblOwnerName = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnIncidents = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnContract = new System.Windows.Forms.Button();
            this.btnBill = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.flowPanelRooms = new System.Windows.Forms.FlowLayoutPanel();
            this.panelRoomManagement = new System.Windows.Forms.Panel();
            this.lblNoResults = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.panelRoomManagement.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(42)))), ((int)(((byte)(86)))));
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Controls.Add(this.lblOwnerName);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(5);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1487, 100);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(26, 29);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(374, 48);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🏠 Owner Dashboard";
            // 
            // lblOwnerName
            // 
            this.lblOwnerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOwnerName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.lblOwnerName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblOwnerName.Location = new System.Drawing.Point(1050, 35);
            this.lblOwnerName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblOwnerName.Name = "lblOwnerName";
            this.lblOwnerName.Size = new System.Drawing.Size(420, 32);
            this.lblOwnerName.TabIndex = 1;
            this.lblOwnerName.Text = "Welcome, [Owner Name]";
            this.lblOwnerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelMenu.Controls.Add(this.btnLogout);
            this.panelMenu.Controls.Add(this.btnIncidents);
            this.panelMenu.Controls.Add(this.btnReport);
            this.panelMenu.Controls.Add(this.btnContract);
            this.panelMenu.Controls.Add(this.btnBill);
            this.panelMenu.Controls.Add(this.btnCreate);
            this.panelMenu.Controls.Add(this.btnHome);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 100);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(5);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(278, 889);
            this.panelMenu.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnLogout.Location = new System.Drawing.Point(0, 834);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(10);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(278, 55);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnIncidents
            // 
            this.btnIncidents.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnIncidents.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnIncidents.Location = new System.Drawing.Point(0, 275);
            this.btnIncidents.Margin = new System.Windows.Forms.Padding(5);
            this.btnIncidents.Name = "btnIncidents";
            this.btnIncidents.Size = new System.Drawing.Size(278, 55);
            this.btnIncidents.TabIndex = 7;
            this.btnIncidents.Text = "Sự cố / Thông báo";
            this.btnIncidents.UseVisualStyleBackColor = true;
            // 
            // btnReport
            // 
            this.btnReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReport.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnReport.Location = new System.Drawing.Point(0, 220);
            this.btnReport.Margin = new System.Windows.Forms.Padding(5);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(278, 55);
            this.btnReport.TabIndex = 4;
            this.btnReport.Text = "Báo cáo / Thống kê";
            this.btnReport.UseVisualStyleBackColor = true;
            // 
            // btnContract
            // 
            this.btnContract.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnContract.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnContract.Location = new System.Drawing.Point(0, 165);
            this.btnContract.Margin = new System.Windows.Forms.Padding(5);
            this.btnContract.Name = "btnContract";
            this.btnContract.Size = new System.Drawing.Size(278, 55);
            this.btnContract.TabIndex = 3;
            this.btnContract.Text = "Quản lí Hợp đồng";
            this.btnContract.UseVisualStyleBackColor = true;
            // 
            // btnBill
            // 
            this.btnBill.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBill.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnBill.Location = new System.Drawing.Point(0, 110);
            this.btnBill.Margin = new System.Windows.Forms.Padding(5);
            this.btnBill.Name = "btnBill";
            this.btnBill.Size = new System.Drawing.Size(278, 55);
            this.btnBill.TabIndex = 2;
            this.btnBill.Text = "Quản lí Hóa đơn";
            this.btnBill.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            this.btnCreate.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnCreate.Location = new System.Drawing.Point(0, 55);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(5);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(278, 55);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Thêm phòng mới";
            this.btnCreate.UseVisualStyleBackColor = true;
            // 
            // btnHome
            // 
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnHome.Location = new System.Drawing.Point(0, 0);
            this.btnHome.Margin = new System.Windows.Forms.Padding(5);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(278, 55);
            this.btnHome.TabIndex = 6;
            this.btnHome.Text = "Quản lí Phòng";
            this.btnHome.UseVisualStyleBackColor = true;
            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = System.Drawing.Color.White;
            this.panelSearch.Controls.Add(this.btnSearch);
            this.panelSearch.Controls.Add(this.txtSearch);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 0);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(1209, 70);
            this.panelSearch.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSearch.Location = new System.Drawing.Point(440, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 36);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Visible = false; // Ẩn nút tìm kiếm
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtSearch.Location = new System.Drawing.Point(25, 18);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(400, 39);
            this.txtSearch.TabIndex = 0;
            // 
            // flowPanelRooms
            // 
            this.flowPanelRooms.AutoScroll = true;
            this.flowPanelRooms.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowPanelRooms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelRooms.Location = new System.Drawing.Point(0, 70);
            this.flowPanelRooms.Margin = new System.Windows.Forms.Padding(5);
            this.flowPanelRooms.Name = "flowPanelRooms";
            this.flowPanelRooms.Padding = new System.Windows.Forms.Padding(20);
            this.flowPanelRooms.Size = new System.Drawing.Size(1209, 819);
            this.flowPanelRooms.TabIndex = 2;
            // 
            // panelRoomManagement
            // 
            this.panelRoomManagement.Controls.Add(this.lblNoResults);
            this.panelRoomManagement.Controls.Add(this.flowPanelRooms);
            this.panelRoomManagement.Controls.Add(this.panelSearch);
            this.panelRoomManagement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRoomManagement.Location = new System.Drawing.Point(278, 100);
            this.panelRoomManagement.Name = "panelRoomManagement";
            this.panelRoomManagement.Size = new System.Drawing.Size(1209, 889);
            this.panelRoomManagement.TabIndex = 4;
            // 
            // lblNoResults
            // 
            this.lblNoResults.AutoSize = true;
            this.lblNoResults.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Italic);
            this.lblNoResults.ForeColor = System.Drawing.Color.Gray;
            this.lblNoResults.Location = new System.Drawing.Point(30, 90);
            this.lblNoResults.Name = "lblNoResults";
            this.lblNoResults.Size = new System.Drawing.Size(499, 38);
            this.lblNoResults.TabIndex = 4;
            this.lblNoResults.Text = "Không có phòng nào trùng với thông tin tìm kiếm.";
            this.lblNoResults.Visible = false;
            // 
            // Owner_TrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1487, 989);
            this.Controls.Add(this.panelRoomManagement);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelTop);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Owner_TrangChu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Owner Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.panelRoomManagement.ResumeLayout(false);
            this.panelRoomManagement.PerformLayout();
            this.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Panel panelRoomManagement;
        private System.Windows.Forms.Label lblNoResults;
        private System.Windows.Forms.Button btnIncidents;
    }
}