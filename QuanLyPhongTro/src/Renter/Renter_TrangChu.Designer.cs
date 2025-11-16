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
            lblRenterName = new Label();
            lblTitle = new Label();
            panelMenu = new Panel();
            btnLogout = new Button();
            btnProfile = new Button();
            btnReport = new Button();
            btnContract = new Button();
            btnBills = new Button();
            btnHome = new Button();
            panelMainContent = new Panel();
            panelFindRoom = new Panel();
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
            panelTop.SuspendLayout();
            panelMenu.SuspendLayout();
            panelFindRoom.SuspendLayout();
            flowPanelRooms.SuspendLayout();
            panelRenterSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudAreaTo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudAreaFrom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPriceTo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPriceFrom).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(25, 42, 86);
            panelTop.Controls.Add(lblRenterName);
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(8, 8, 8, 8);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(2478, 167);
            panelTop.TabIndex = 1;
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
            lblTitle.Size = new Size(541, 81);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Renter Dashboard";
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
            panelMenu.Margin = new Padding(8, 8, 8, 8);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(463, 1481);
            panelMenu.TabIndex = 2;
            // 
            // btnLogout
            // 
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.Font = new Font("Segoe UI", 11F);
            btnLogout.Location = new Point(0, 1389);
            btnLogout.Margin = new Padding(17, 17, 17, 17);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(463, 92);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "Ðăng xuất";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnProfile
            // 
            btnProfile.Dock = DockStyle.Top;
            btnProfile.Font = new Font("Segoe UI", 11F);
            btnProfile.Location = new Point(0, 368);
            btnProfile.Margin = new Padding(8, 8, 8, 8);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(463, 92);
            btnProfile.TabIndex = 4;
            btnProfile.Text = "Thông tin Cá nhân";
            btnProfile.UseVisualStyleBackColor = true;
            // 
            // btnReport
            // 
            btnReport.Dock = DockStyle.Top;
            btnReport.Font = new Font("Segoe UI", 11F);
            btnReport.Location = new Point(0, 276);
            btnReport.Margin = new Padding(8, 8, 8, 8);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(463, 92);
            btnReport.TabIndex = 3;
            btnReport.Text = "Gửi báo cáo / sự cố";
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
            btnContract.TabIndex = 2;
            btnContract.Text = "Hợp đồng của tôi";
            btnContract.UseVisualStyleBackColor = true;
            // 
            // btnBills
            // 
            btnBills.Dock = DockStyle.Top;
            btnBills.Font = new Font("Segoe UI", 11F);
            btnBills.Location = new Point(0, 92);
            btnBills.Margin = new Padding(8, 8, 8, 8);
            btnBills.Name = "btnBills";
            btnBills.Size = new Size(463, 92);
            btnBills.TabIndex = 1;
            btnBills.Text = "Hóa đơn của tôi";
            btnBills.UseVisualStyleBackColor = true;
            // 
            // btnHome
            // 
            btnHome.Dock = DockStyle.Top;
            btnHome.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnHome.Location = new Point(0, 0);
            btnHome.Margin = new Padding(8, 8, 8, 8);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(463, 92);
            btnHome.TabIndex = 0;
            btnHome.Text = "Phòng của tôi";
            btnHome.UseVisualStyleBackColor = true;
            // 
            // panelMainContent
            // 
            panelMainContent.Dock = DockStyle.Fill;
            panelMainContent.Location = new Point(463, 167);
            panelMainContent.Margin = new Padding(5, 5, 5, 5);
            panelMainContent.Name = "panelMainContent";
            panelMainContent.Size = new Size(2015, 1481);
            panelMainContent.TabIndex = 3;
            // 
            // panelFindRoom
            // 
            panelFindRoom.Controls.Add(flowPanelRooms);
            panelFindRoom.Controls.Add(panelRenterSearch);
            panelFindRoom.Dock = DockStyle.Fill;
            panelFindRoom.Location = new Point(463, 167);
            panelFindRoom.Margin = new Padding(5, 5, 5, 5);
            panelFindRoom.Name = "panelFindRoom";
            panelFindRoom.Size = new Size(2015, 1481);
            panelFindRoom.TabIndex = 4;
            // 
            // flowPanelRooms
            // 
            flowPanelRooms.AutoScroll = true;
            flowPanelRooms.BackColor = Color.WhiteSmoke;
            flowPanelRooms.Controls.Add(lblNoResults);
            flowPanelRooms.Dock = DockStyle.Fill;
            flowPanelRooms.Location = new Point(0, 167);
            flowPanelRooms.Margin = new Padding(5, 5, 5, 5);
            flowPanelRooms.Name = "flowPanelRooms";
            flowPanelRooms.Padding = new Padding(33, 33, 33, 33);
            flowPanelRooms.Size = new Size(2015, 1314);
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
            lblNoResults.Size = new Size(747, 62);
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
            panelRenterSearch.Margin = new Padding(5, 5, 5, 5);
            panelRenterSearch.Name = "panelRenterSearch";
            panelRenterSearch.Size = new Size(2015, 167);
            panelRenterSearch.TabIndex = 0;
            // 
            // btnResetArea
            // 
            btnResetArea.Font = new Font("Segoe UI", 10F);
            btnResetArea.Location = new Point(1008, 97);
            btnResetArea.Margin = new Padding(5, 5, 5, 5);
            btnResetArea.Name = "btnResetArea";
            btnResetArea.Size = new Size(57, 52);
            btnResetArea.TabIndex = 11;
            btnResetArea.Text = "🔄";
            btnResetArea.UseVisualStyleBackColor = true;
            // 
            // nudAreaTo
            // 
            nudAreaTo.Font = new Font("Segoe UI", 10F);
            nudAreaTo.Location = new Point(892, 97);
            nudAreaTo.Margin = new Padding(5, 5, 5, 5);
            nudAreaTo.Name = "nudAreaTo";
            nudAreaTo.Size = new Size(117, 52);
            nudAreaTo.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(867, 107);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(30, 41);
            label4.TabIndex = 9;
            label4.Text = "-";
            // 
            // nudAreaFrom
            // 
            nudAreaFrom.Font = new Font("Segoe UI", 10F);
            nudAreaFrom.Location = new Point(750, 97);
            nudAreaFrom.Margin = new Padding(5, 5, 5, 5);
            nudAreaFrom.Name = "nudAreaFrom";
            nudAreaFrom.Size = new Size(117, 52);
            nudAreaFrom.TabIndex = 8;
            // 
            // lblFilterArea
            // 
            lblFilterArea.AutoSize = true;
            lblFilterArea.Font = new Font("Segoe UI", 10F);
            lblFilterArea.Location = new Point(600, 100);
            lblFilterArea.Margin = new Padding(5, 0, 5, 0);
            lblFilterArea.Name = "lblFilterArea";
            lblFilterArea.Size = new Size(157, 46);
            lblFilterArea.TabIndex = 7;
            lblFilterArea.Text = "Diện tích:";
            // 
            // btnResetPrice
            // 
            btnResetPrice.Font = new Font("Segoe UI", 10F);
            btnResetPrice.Location = new Point(508, 97);
            btnResetPrice.Margin = new Padding(5, 5, 5, 5);
            btnResetPrice.Name = "btnResetPrice";
            btnResetPrice.Size = new Size(57, 51);
            btnResetPrice.TabIndex = 6;
            btnResetPrice.Text = "🔄";
            btnResetPrice.UseVisualStyleBackColor = true;
            // 
            // nudPriceTo
            // 
            nudPriceTo.Font = new Font("Segoe UI", 10F);
            nudPriceTo.Increment = new decimal(new int[] { 100000, 0, 0, 0 });
            nudPriceTo.Location = new Point(325, 97);
            nudPriceTo.Margin = new Padding(5, 5, 5, 5);
            nudPriceTo.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            nudPriceTo.Name = "nudPriceTo";
            nudPriceTo.Size = new Size(183, 52);
            nudPriceTo.TabIndex = 5;
            nudPriceTo.ThousandsSeparator = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(300, 107);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(30, 41);
            label2.TabIndex = 4;
            label2.Text = "-";
            // 
            // nudPriceFrom
            // 
            nudPriceFrom.Font = new Font("Segoe UI", 10F);
            nudPriceFrom.Increment = new decimal(new int[] { 100000, 0, 0, 0 });
            nudPriceFrom.Location = new Point(117, 97);
            nudPriceFrom.Margin = new Padding(5, 5, 5, 5);
            nudPriceFrom.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            nudPriceFrom.Name = "nudPriceFrom";
            nudPriceFrom.Size = new Size(183, 52);
            nudPriceFrom.TabIndex = 3;
            nudPriceFrom.ThousandsSeparator = true;
            // 
            // lblFilterPrice
            // 
            lblFilterPrice.AutoSize = true;
            lblFilterPrice.Font = new Font("Segoe UI", 10F);
            lblFilterPrice.Location = new Point(42, 100);
            lblFilterPrice.Margin = new Padding(5, 0, 5, 0);
            lblFilterPrice.Name = "lblFilterPrice";
            lblFilterPrice.Size = new Size(75, 46);
            lblFilterPrice.TabIndex = 2;
            lblFilterPrice.Text = "Giá:";
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Font = new Font("Segoe UI", 12F);
            txtSearch.Location = new Point(42, 20);
            txtSearch.Margin = new Padding(5, 5, 5, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(1931, 61);
            txtSearch.TabIndex = 1;
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
            Margin = new Padding(5, 5, 5, 5);
            Name = "Renter_TrangChu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Renter Dashboard";
            WindowState = FormWindowState.Maximized;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelMenu.ResumeLayout(false);
            panelFindRoom.ResumeLayout(false);
            flowPanelRooms.ResumeLayout(false);
            flowPanelRooms.PerformLayout();
            panelRenterSearch.ResumeLayout(false);
            panelRenterSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudAreaTo).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudAreaFrom).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPriceTo).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPriceFrom).EndInit();
            ResumeLayout(false);
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
