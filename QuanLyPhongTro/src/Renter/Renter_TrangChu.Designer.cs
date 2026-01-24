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
            panelTop = new Panel();
            btnLogoutFindRoom = new Button();
            lblRenterName = new Label();
            lblTitle = new Label();
            panelMenu = new Panel();
            btnLogout = new Button();
            btnProfile = new Button();
            btnUploadContract = new Button();
            btnReport = new Button();
            btnContract = new Button();
            btnBills = new Button();
            btnHome = new Button();
            panelMainContent = new Panel();
            panelFindRoom = new Panel();
            splitContainer = new SplitContainer();
            flowPanelRooms = new FlowLayoutPanel();
            lblNoResults = new Label();
            panelRenterSearch = new Panel();
            btnResetArea = new Button();
            nudAreaTo = new NumericUpDown();
            label4 = new Label();
            nudAreaFrom = new NumericUpDown();
            lblFilterArea = new Label();
            btnResetPrice = new Button();
            nudPriceTo = new NumericUpDown();
            label2 = new Label();
            nudPriceFrom = new NumericUpDown();
            lblFilterPrice = new Label();
            txtSearch = new TextBox();
            panelMap = new Panel();
            lblMapPlaceholder = new Label();
            panelTop.SuspendLayout();
            panelMenu.SuspendLayout();
            panelFindRoom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            flowPanelRooms.SuspendLayout();
            panelRenterSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudAreaTo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudAreaFrom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPriceTo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPriceFrom).BeginInit();
            panelMap.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(25, 42, 86);
            panelTop.Controls.Add(btnLogoutFindRoom);
            panelTop.Controls.Add(lblRenterName);
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(8);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(2478, 167);
            panelTop.TabIndex = 1;
            // 
            // btnLogoutFindRoom
            // 
            btnLogoutFindRoom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogoutFindRoom.BackColor = Color.FromArgb(231, 76, 60);
            btnLogoutFindRoom.FlatStyle = FlatStyle.Flat;
            btnLogoutFindRoom.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogoutFindRoom.ForeColor = Color.White;
            btnLogoutFindRoom.Location = new Point(2200, 107);
            btnLogoutFindRoom.Margin = new Padding(5);
            btnLogoutFindRoom.Name = "btnLogoutFindRoom";
            btnLogoutFindRoom.Size = new Size(233, 60);
            btnLogoutFindRoom.TabIndex = 2;
            btnLogoutFindRoom.Text = "Đăng xuất";
            btnLogoutFindRoom.UseVisualStyleBackColor = false;
            btnLogoutFindRoom.Visible = false;
            // 
            // lblRenterName
            // 
            lblRenterName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblRenterName.Font = new Font("Segoe UI", 14.1F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblRenterName.ForeColor = Color.WhiteSmoke;
            lblRenterName.Location = new Point(1750, 58);
            lblRenterName.Margin = new Padding(8, 0, 8, 0);
            lblRenterName.Name = "lblRenterName";
            lblRenterName.Size = new Size(700, 53);
            lblRenterName.TabIndex = 1;
            lblRenterName.Text = "Chào mừng, [Renter Name]";
            lblRenterName.TextAlign = ContentAlignment.MiddleRight;
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
            lblTitle.Text = "Giao diện người thuê";
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(41, 128, 185);
            panelMenu.Controls.Add(btnLogout);
            panelMenu.Controls.Add(btnProfile);
            panelMenu.Controls.Add(btnUploadContract);
            panelMenu.Controls.Add(btnReport);
            panelMenu.Controls.Add(btnContract);
            panelMenu.Controls.Add(btnBills);
            panelMenu.Controls.Add(btnHome);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 167);
            panelMenu.Margin = new Padding(8);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(463, 1481);
            panelMenu.TabIndex = 2;
            // 
            // btnLogout
            // 
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.Font = new Font("Segoe UI", 14F);
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
            btnProfile.Font = new Font("Segoe UI", 14F);
            btnProfile.Location = new Point(0, 640);
            btnProfile.Margin = new Padding(8);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(463, 160);
            btnProfile.TabIndex = 4;
            btnProfile.Text = "Thông tin Cá nhân";
            btnProfile.UseVisualStyleBackColor = true;
            // 
            // btnUploadContract
            // 
            btnUploadContract.Dock = DockStyle.Top;
            btnUploadContract.Font = new Font("Segoe UI", 14F);
            btnUploadContract.Location = new Point(0, 480);
            btnUploadContract.Margin = new Padding(8);
            btnUploadContract.Name = "btnUploadContract";
            btnUploadContract.Size = new Size(463, 160);
            btnUploadContract.TabIndex = 3;
            btnUploadContract.Text = "Tải lên hợp đồng";
            btnUploadContract.UseVisualStyleBackColor = true;
            // 
            // btnReport
            // 
            btnReport.Dock = DockStyle.Top;
            btnReport.Font = new Font("Segoe UI", 14F);
            btnReport.Location = new Point(0, 320);
            btnReport.Margin = new Padding(8);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(463, 160);
            btnReport.TabIndex = 2;
            btnReport.Text = "Gửi báo cáo / sự cố";
            btnReport.UseVisualStyleBackColor = true;
            // 
            // btnContract
            // 
            btnContract.Dock = DockStyle.Top;
            btnContract.Font = new Font("Segoe UI", 14F);
            btnContract.Location = new Point(0, 160);
            btnContract.Margin = new Padding(8);
            btnContract.Name = "btnContract";
            btnContract.Size = new Size(463, 160);
            btnContract.TabIndex = 1;
            btnContract.Text = "Hợp đồng của tôi";
            btnContract.UseVisualStyleBackColor = true;
            // 
            // btnBills
            // 
            btnBills.Dock = DockStyle.Top;
            btnBills.Font = new Font("Segoe UI", 14F);
            btnBills.Location = new Point(0, 0);
            btnBills.Margin = new Padding(8);
            btnBills.Name = "btnBills";
            btnBills.Size = new Size(463, 160);
            btnBills.TabIndex = 0;
            btnBills.Text = "Hóa đơn của tôi";
            btnBills.UseVisualStyleBackColor = true;
            // 
            // btnHome
            // 
            btnHome.Dock = DockStyle.Top;
            btnHome.Font = new Font("Segoe UI", 14F);
            btnHome.Location = new Point(0, 0);
            btnHome.Margin = new Padding(8);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(463, 0);
            btnHome.TabIndex = 6;
            btnHome.Text = "Trang chủ";
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Visible = false;
            // 
            // panelMainContent
            // 
            panelMainContent.Dock = DockStyle.Fill;
            panelMainContent.Location = new Point(463, 167);
            panelMainContent.Margin = new Padding(5);
            panelMainContent.Name = "panelMainContent";
            panelMainContent.Size = new Size(2015, 1481);
            panelMainContent.TabIndex = 3;
            // 
            // panelFindRoom
            // 
            panelFindRoom.Controls.Add(splitContainer);
            panelFindRoom.Dock = DockStyle.Fill;
            panelFindRoom.Location = new Point(463, 167);
            panelFindRoom.Margin = new Padding(5);
            panelFindRoom.Name = "panelFindRoom";
            panelFindRoom.Size = new Size(2015, 1481);
            panelFindRoom.TabIndex = 4;
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(0, 0);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(flowPanelRooms);
            splitContainer.Panel1.Controls.Add(panelRenterSearch);
            splitContainer.Panel1MinSize = 800;
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(panelMap);
            splitContainer.Panel2MinSize = 400;
            splitContainer.Size = new Size(2015, 1481);
            splitContainer.SplitterDistance = 1250;
            splitContainer.SplitterWidth = 8;
            splitContainer.TabIndex = 0;
            // 
            // flowPanelRooms
            // 
            flowPanelRooms.AutoScroll = true;
            flowPanelRooms.BackColor = Color.WhiteSmoke;
            flowPanelRooms.Controls.Add(lblNoResults);
            flowPanelRooms.Dock = DockStyle.Fill;
            flowPanelRooms.Location = new Point(0, 167);
            flowPanelRooms.Margin = new Padding(5);
            flowPanelRooms.Name = "flowPanelRooms";
            flowPanelRooms.Padding = new Padding(33);
            flowPanelRooms.Size = new Size(1250, 1314);
            flowPanelRooms.TabIndex = 1;
            // 
            // lblNoResults
            // 
            lblNoResults.AutoSize = true;
            lblNoResults.Font = new Font("Segoe UI", 14F, FontStyle.Italic);
            lblNoResults.ForeColor = Color.Gray;
            lblNoResults.Location = new Point(38, 33);
            lblNoResults.Margin = new Padding(5, 0, 5, 0);
            lblNoResults.Name = "lblNoResults";
            lblNoResults.Size = new Size(758, 62);
            lblNoResults.TabIndex = 0;
            lblNoResults.Text = "Không tìm thấy phòng nào phù hợp.";
            lblNoResults.Visible = false;
            // 
            // panelRenterSearch
            // 
            panelRenterSearch.BackColor = Color.White;
            panelRenterSearch.Controls.Add(btnResetArea);
            panelRenterSearch.Controls.Add(nudAreaTo);
            panelRenterSearch.Controls.Add(label4);
            panelRenterSearch.Controls.Add(nudAreaFrom);
            panelRenterSearch.Controls.Add(lblFilterArea);
            panelRenterSearch.Controls.Add(btnResetPrice);
            panelRenterSearch.Controls.Add(nudPriceTo);
            panelRenterSearch.Controls.Add(label2);
            panelRenterSearch.Controls.Add(nudPriceFrom);
            panelRenterSearch.Controls.Add(lblFilterPrice);
            panelRenterSearch.Controls.Add(txtSearch);
            panelRenterSearch.Dock = DockStyle.Top;
            panelRenterSearch.Location = new Point(0, 0);
            panelRenterSearch.Margin = new Padding(5);
            panelRenterSearch.Name = "panelRenterSearch";
            panelRenterSearch.Size = new Size(1250, 167);
            panelRenterSearch.TabIndex = 0;
            // 
            // btnResetArea
            // 
            btnResetArea.Font = new Font("Segoe UI", 10F);
            btnResetArea.Location = new Point(1141, 97);
            btnResetArea.Margin = new Padding(5);
            btnResetArea.Name = "btnResetArea";
            btnResetArea.Size = new Size(56, 57);
            btnResetArea.TabIndex = 11;
            btnResetArea.Text = "🔄";
            btnResetArea.UseVisualStyleBackColor = true;
            // 
            // nudAreaTo
            // 
            nudAreaTo.Font = new Font("Segoe UI", 12F);
            nudAreaTo.Location = new Point(1014, 97);
            nudAreaTo.Margin = new Padding(5);
            nudAreaTo.Name = "nudAreaTo";
            nudAreaTo.Size = new Size(117, 61);
            nudAreaTo.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F);
            label4.Location = new Point(974, 104);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(37, 50);
            label4.TabIndex = 9;
            label4.Text = "-";
            // 
            // nudAreaFrom
            // 
            nudAreaFrom.Font = new Font("Segoe UI", 12F);
            nudAreaFrom.Location = new Point(850, 99);
            nudAreaFrom.Margin = new Padding(5);
            nudAreaFrom.Name = "nudAreaFrom";
            nudAreaFrom.Size = new Size(117, 61);
            nudAreaFrom.TabIndex = 8;
            // 
            // lblFilterArea
            // 
            lblFilterArea.AutoSize = true;
            lblFilterArea.Font = new Font("Segoe UI", 12F);
            lblFilterArea.Location = new Point(656, 104);
            lblFilterArea.Margin = new Padding(5, 0, 5, 0);
            lblFilterArea.Name = "lblFilterArea";
            lblFilterArea.Size = new Size(190, 54);
            lblFilterArea.TabIndex = 7;
            lblFilterArea.Text = "Diện tích:";
            // 
            // btnResetPrice
            // 
            btnResetPrice.Font = new Font("Segoe UI", 10F);
            btnResetPrice.Location = new Point(541, 96);
            btnResetPrice.Margin = new Padding(5);
            btnResetPrice.Name = "btnResetPrice";
            btnResetPrice.Size = new Size(57, 58);
            btnResetPrice.TabIndex = 6;
            btnResetPrice.Text = "🔄";
            btnResetPrice.UseVisualStyleBackColor = true;
            // 
            // nudPriceTo
            // 
            nudPriceTo.Font = new Font("Segoe UI", 12F);
            nudPriceTo.Increment = new decimal(new int[] { 100000, 0, 0, 0 });
            nudPriceTo.Location = new Point(348, 95);
            nudPriceTo.Margin = new Padding(5);
            nudPriceTo.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            nudPriceTo.Name = "nudPriceTo";
            nudPriceTo.Size = new Size(183, 61);
            nudPriceTo.TabIndex = 5;
            nudPriceTo.ThousandsSeparator = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.Location = new Point(311, 100);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(37, 50);
            label2.TabIndex = 4;
            label2.Text = "-";
            // 
            // nudPriceFrom
            // 
            nudPriceFrom.Font = new Font("Segoe UI", 12F);
            nudPriceFrom.Increment = new decimal(new int[] { 100000, 0, 0, 0 });
            nudPriceFrom.Location = new Point(123, 96);
            nudPriceFrom.Margin = new Padding(5);
            nudPriceFrom.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            nudPriceFrom.Name = "nudPriceFrom";
            nudPriceFrom.Size = new Size(183, 61);
            nudPriceFrom.TabIndex = 3;
            nudPriceFrom.ThousandsSeparator = true;
            // 
            // lblFilterPrice
            // 
            lblFilterPrice.AutoSize = true;
            lblFilterPrice.Font = new Font("Segoe UI", 12F);
            lblFilterPrice.Location = new Point(42, 100);
            lblFilterPrice.Margin = new Padding(5, 0, 5, 0);
            lblFilterPrice.Name = "lblFilterPrice";
            lblFilterPrice.Size = new Size(89, 54);
            lblFilterPrice.TabIndex = 2;
            lblFilterPrice.Text = "Giá:";
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Font = new Font("Segoe UI", 12F);
            txtSearch.Location = new Point(42, 20);
            txtSearch.Margin = new Padding(5);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(1170, 61);
            txtSearch.TabIndex = 1;
            // 
            // panelMap
            // 
            panelMap.BackColor = Color.FromArgb(240, 240, 240);
            panelMap.Controls.Add(lblMapPlaceholder);
            panelMap.Dock = DockStyle.Fill;
            panelMap.Location = new Point(0, 0);
            panelMap.Name = "panelMap";
            panelMap.Size = new Size(757, 1481);
            panelMap.TabIndex = 0;
            // 
            // lblMapPlaceholder
            // 
            lblMapPlaceholder.Dock = DockStyle.Fill;
            lblMapPlaceholder.Font = new Font("Segoe UI", 16F, FontStyle.Italic);
            lblMapPlaceholder.ForeColor = Color.Gray;
            lblMapPlaceholder.Location = new Point(0, 0);
            lblMapPlaceholder.Name = "lblMapPlaceholder";
            lblMapPlaceholder.Size = new Size(757, 1481);
            lblMapPlaceholder.TabIndex = 0;
            lblMapPlaceholder.Text = "🗺️\r\n\r\nKhu vực hiển thị bản đồ\r\n(Chức năng đang phát triển)";
            lblMapPlaceholder.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Renter_TrangChu
            // 
            AutoScaleDimensions = new SizeF(240F, 240F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(2478, 1648);
            Controls.Add(panelFindRoom);
            Controls.Add(panelMainContent);
            Controls.Add(panelMenu);
            Controls.Add(panelTop);
            Margin = new Padding(5);
            Name = "Renter_TrangChu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Renter Dashboard";
            WindowState = FormWindowState.Maximized;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelMenu.ResumeLayout(false);
            panelFindRoom.ResumeLayout(false);
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            flowPanelRooms.ResumeLayout(false);
            flowPanelRooms.PerformLayout();
            panelRenterSearch.ResumeLayout(false);
            panelRenterSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudAreaTo).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudAreaFrom).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPriceTo).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPriceFrom).EndInit();
            panelMap.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblRenterName;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnUploadContract;
        private System.Windows.Forms.Button btnContract;
        private System.Windows.Forms.Button btnBills;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Panel panelMainContent;
        private System.Windows.Forms.Panel panelFindRoom;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.FlowLayoutPanel flowPanelRooms;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnLogoutFindRoom;
        private System.Windows.Forms.Panel panelRenterSearch;
        private System.Windows.Forms.Panel panelMap;
        private System.Windows.Forms.Label lblMapPlaceholder;
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
