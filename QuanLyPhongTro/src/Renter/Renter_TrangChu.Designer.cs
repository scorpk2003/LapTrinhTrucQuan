namespace QuanLyPhongTro
{
    partial class Renter_TrangChu
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
            this.lblRenterName = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnContract = new System.Windows.Forms.Button();
            this.btnBills = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.panelMainContent = new System.Windows.Forms.Panel();
            this.panelFindRoom = new System.Windows.Forms.Panel();
            this.flowPanelRooms = new System.Windows.Forms.FlowLayoutPanel();
            this.lblNoResults = new System.Windows.Forms.Label();

            this.panelRenterSearch = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblFilterPrice = new System.Windows.Forms.Label();
            this.nudPriceFrom = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudPriceTo = new System.Windows.Forms.NumericUpDown();
            this.btnResetPrice = new System.Windows.Forms.Button();
            this.lblFilterArea = new System.Windows.Forms.Label();
            this.nudAreaFrom = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudAreaTo = new System.Windows.Forms.NumericUpDown();
            this.btnResetArea = new System.Windows.Forms.Button();

            this.panelTop.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panelFindRoom.SuspendLayout();
            this.flowPanelRooms.SuspendLayout();
            this.panelRenterSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPriceFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPriceTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAreaFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAreaTo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(42)))), ((int)(((byte)(86)))));
            this.panelTop.Controls.Add(this.lblRenterName);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(5);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1487, 100);
            this.panelTop.TabIndex = 1;
            // 
            // lblRenterName
            // 
            this.lblRenterName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRenterName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.lblRenterName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblRenterName.Location = new System.Drawing.Point(1050, 35);
            this.lblRenterName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblRenterName.Name = "lblRenterName";
            this.lblRenterName.Size = new System.Drawing.Size(420, 32);
            this.lblRenterName.TabIndex = 1;
            this.lblRenterName.Text = "Welcome, [Renter Name]";
            this.lblRenterName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(26, 29);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(341, 48);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Renter Dashboard";
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelMenu.Controls.Add(this.btnLogout);
            this.panelMenu.Controls.Add(this.btnProfile);
            this.panelMenu.Controls.Add(this.btnReport);
            this.panelMenu.Controls.Add(this.btnContract);
            this.panelMenu.Controls.Add(this.btnBills);
            this.panelMenu.Controls.Add(this.btnHome);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 100);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(5);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(278, 889);
            this.panelMenu.TabIndex = 2;
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
            // btnProfile
            // 
            this.btnProfile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProfile.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnProfile.Location = new System.Drawing.Point(0, 220);
            this.btnProfile.Margin = new System.Windows.Forms.Padding(5);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(278, 55);
            this.btnProfile.TabIndex = 4;
            this.btnProfile.Text = "Thông tin Cá nhân";
            this.btnProfile.UseVisualStyleBackColor = true;
            // 
            // btnReport
            // 
            this.btnReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReport.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnReport.Location = new System.Drawing.Point(0, 165);
            this.btnReport.Margin = new System.Windows.Forms.Padding(5);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(278, 55);
            this.btnReport.TabIndex = 3;
            this.btnReport.Text = "Gửi Báo cáo / Sự cố";
            this.btnReport.UseVisualStyleBackColor = true;
            // 
            // btnContract
            // 
            this.btnContract.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnContract.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnContract.Location = new System.Drawing.Point(0, 110);
            this.btnContract.Margin = new System.Windows.Forms.Padding(5);
            this.btnContract.Name = "btnContract";
            this.btnContract.Size = new System.Drawing.Size(278, 55);
            this.btnContract.TabIndex = 2;
            this.btnContract.Text = "Hợp đồng của tôi";
            this.btnContract.UseVisualStyleBackColor = true;
            // 
            // btnBills
            // 
            this.btnBills.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBills.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnBills.Location = new System.Drawing.Point(0, 55);
            this.btnBills.Margin = new System.Windows.Forms.Padding(5);
            this.btnBills.Name = "btnBills";
            this.btnBills.Size = new System.Drawing.Size(278, 55);
            this.btnBills.TabIndex = 1;
            this.btnBills.Text = "Hóa đơn của tôi";
            this.btnBills.UseVisualStyleBackColor = true;
            // 
            // btnHome
            // 
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnHome.Location = new System.Drawing.Point(0, 0);
            this.btnHome.Margin = new System.Windows.Forms.Padding(5);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(278, 55);
            this.btnHome.TabIndex = 0;
            this.btnHome.Text = "Phòng của tôi";
            this.btnHome.UseVisualStyleBackColor = true;
            // 
            // panelMainContent
            // 
            this.panelMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainContent.Location = new System.Drawing.Point(278, 100);
            this.panelMainContent.Name = "panelMainContent";
            this.panelMainContent.Size = new System.Drawing.Size(1209, 889);
            this.panelMainContent.TabIndex = 3;
            // 
            // panelFindRoom
            // 
            this.panelFindRoom.Controls.Add(this.flowPanelRooms);
            this.panelFindRoom.Controls.Add(this.panelRenterSearch);
            this.panelFindRoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFindRoom.Location = new System.Drawing.Point(278, 100);
            this.panelFindRoom.Name = "panelFindRoom";
            this.panelFindRoom.Size = new System.Drawing.Size(1209, 889);
            this.panelFindRoom.TabIndex = 4;
            // 
            // flowPanelRooms
            // 
            this.flowPanelRooms.AutoScroll = true;
            this.flowPanelRooms.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowPanelRooms.Controls.Add(this.lblNoResults);
            this.flowPanelRooms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelRooms.Location = new System.Drawing.Point(0, 100);
            this.flowPanelRooms.Name = "flowPanelRooms";
            this.flowPanelRooms.Padding = new System.Windows.Forms.Padding(20);
            this.flowPanelRooms.Size = new System.Drawing.Size(1209, 789);
            this.flowPanelRooms.TabIndex = 1;
            // 
            // lblNoResults
            // 
            this.lblNoResults.AutoSize = true;
            this.lblNoResults.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Italic);
            this.lblNoResults.ForeColor = System.Drawing.Color.Gray;
            this.lblNoResults.Location = new System.Drawing.Point(23, 20);
            this.lblNoResults.Name = "lblNoResults";
            this.lblNoResults.Size = new System.Drawing.Size(469, 38);
            this.lblNoResults.TabIndex = 0;
            this.lblNoResults.Text = "Không tìm thấy phòng nào phù hợp.";
            this.lblNoResults.Visible = false;
            // 
            // panelRenterSearch
            // 
            this.panelRenterSearch.BackColor = System.Drawing.Color.White;
            this.panelRenterSearch.Controls.Add(this.btnResetArea);
            this.panelRenterSearch.Controls.Add(this.nudAreaTo);
            this.panelRenterSearch.Controls.Add(this.label4);
            this.panelRenterSearch.Controls.Add(this.nudAreaFrom);
            this.panelRenterSearch.Controls.Add(this.lblFilterArea);
            this.panelRenterSearch.Controls.Add(this.btnResetPrice);
            this.panelRenterSearch.Controls.Add(this.nudPriceTo);
            this.panelRenterSearch.Controls.Add(this.label2);
            this.panelRenterSearch.Controls.Add(this.nudPriceFrom);
            this.panelRenterSearch.Controls.Add(this.lblFilterPrice);
            this.panelRenterSearch.Controls.Add(this.txtSearch);
            this.panelRenterSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRenterSearch.Location = new System.Drawing.Point(0, 0);
            this.panelRenterSearch.Name = "panelRenterSearch";
            this.panelRenterSearch.Size = new System.Drawing.Size(1209, 100);
            this.panelRenterSearch.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtSearch.Location = new System.Drawing.Point(25, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(1160, 39);
            this.txtSearch.TabIndex = 1;
            // 
            // lblFilterPrice
            // 
            this.lblFilterPrice.AutoSize = true;
            this.lblFilterPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFilterPrice.Location = new System.Drawing.Point(25, 60);
            this.lblFilterPrice.Name = "lblFilterPrice";
            this.lblFilterPrice.Size = new System.Drawing.Size(45, 28);
            this.lblFilterPrice.TabIndex = 2;
            this.lblFilterPrice.Text = "Giá:";
            // 
            // nudPriceFrom
            // 
            this.nudPriceFrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudPriceFrom.Increment = new decimal(new int[] { 100000, 0, 0, 0 });
            this.nudPriceFrom.Location = new System.Drawing.Point(70, 58);
            this.nudPriceFrom.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.nudPriceFrom.Name = "nudPriceFrom";
            this.nudPriceFrom.Size = new System.Drawing.Size(110, 34);
            this.nudPriceFrom.TabIndex = 3;
            this.nudPriceFrom.ThousandsSeparator = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "-";
            // 
            // nudPriceTo
            // 
            this.nudPriceTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudPriceTo.Increment = new decimal(new int[] { 100000, 0, 0, 0 });
            this.nudPriceTo.Location = new System.Drawing.Point(195, 58);
            this.nudPriceTo.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.nudPriceTo.Name = "nudPriceTo";
            this.nudPriceTo.Size = new System.Drawing.Size(110, 34);
            this.nudPriceTo.TabIndex = 5;
            this.nudPriceTo.ThousandsSeparator = true;
            // 
            // btnResetPrice
            // 
            this.btnResetPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnResetPrice.Location = new System.Drawing.Point(305, 58);
            this.btnResetPrice.Name = "btnResetPrice";
            this.btnResetPrice.Size = new System.Drawing.Size(34, 34);
            this.btnResetPrice.TabIndex = 6;
            this.btnResetPrice.Text = "🔄";
            this.btnResetPrice.UseVisualStyleBackColor = true;
            // 
            // lblFilterArea
            // 
            this.lblFilterArea.AutoSize = true;
            this.lblFilterArea.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFilterArea.Location = new System.Drawing.Point(360, 60);
            this.lblFilterArea.Name = "lblFilterArea";
            this.lblFilterArea.Size = new System.Drawing.Size(91, 28);
            this.lblFilterArea.TabIndex = 7;
            this.lblFilterArea.Text = "Diện tích:";
            // 
            // nudAreaFrom
            // 
            this.nudAreaFrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudAreaFrom.Location = new System.Drawing.Point(450, 58);
            this.nudAreaFrom.Name = "nudAreaFrom";
            this.nudAreaFrom.Size = new System.Drawing.Size(70, 34);
            this.nudAreaFrom.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(520, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "-";
            // 
            // nudAreaTo
            // 
            this.nudAreaTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudAreaTo.Location = new System.Drawing.Point(535, 58);
            this.nudAreaTo.Name = "nudAreaTo";
            this.nudAreaTo.Size = new System.Drawing.Size(70, 34);
            this.nudAreaTo.TabIndex = 10;
            // 
            // btnResetArea
            // 
            this.btnResetArea.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnResetArea.Location = new System.Drawing.Point(605, 58);
            this.btnResetArea.Name = "btnResetArea";
            this.btnResetArea.Size = new System.Drawing.Size(34, 34);
            this.btnResetArea.TabIndex = 11;
            this.btnResetArea.Text = "🔄";
            this.btnResetArea.UseVisualStyleBackColor = true;
            // 
            // 
            // Renter_TrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1487, 989);
            this.Controls.Add(this.panelFindRoom);
            this.Controls.Add(this.panelMainContent);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelTop);
            this.Name = "Renter_TrangChu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Renter Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.panelFindRoom.ResumeLayout(false);
            this.flowPanelRooms.ResumeLayout(false);
            this.flowPanelRooms.PerformLayout();
            this.panelRenterSearch.ResumeLayout(false);
            this.panelRenterSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPriceFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPriceTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAreaFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAreaTo)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblRenterName;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnContract;
        private System.Windows.Forms.Button btnBills;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Panel panelMainContent;
        private System.Windows.Forms.Panel panelFindRoom;
        private System.Windows.Forms.FlowLayoutPanel flowPanelRooms;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelRenterSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblNoResults;
        private System.Windows.Forms.Label lblFilterPrice;
        private System.Windows.Forms.NumericUpDown nudPriceFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudPriceTo;
        private System.Windows.Forms.Button btnResetPrice;
        private System.Windows.Forms.Label lblFilterArea;
        private System.Windows.Forms.NumericUpDown nudAreaFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudAreaTo;
        private System.Windows.Forms.Button btnResetArea;
    }
}