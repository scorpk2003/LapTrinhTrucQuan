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
            btnIncidents = new Button();
            btnReport = new Button();
            btnContract = new Button();
            btnBill = new Button();
            btnCreate = new Button();
            btnHome = new Button();
            panelSearch = new Panel();
            btnResetStatus = new Button();
            cboFilterStatus = new ComboBox();
            lblFilterStatus = new Label();
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
            btnSearch = new Button();
            txtSearch = new TextBox();
            flowPanelRooms = new FlowLayoutPanel();
            panelRoomManagement = new Panel();
            lblNoResults = new Label();
            panelTop.SuspendLayout();
            panelMenu.SuspendLayout();
            panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudAreaTo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudAreaFrom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPriceTo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPriceFrom).BeginInit();
            panelRoomManagement.SuspendLayout();
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
            lblTitle.Size = new Size(541, 81);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Owner Dashboard";
            // 
            // lblOwnerName
            // 
            lblOwnerName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblOwnerName.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            lblOwnerName.ForeColor = Color.WhiteSmoke;
            lblOwnerName.Location = new Point(1750, 58);
            lblOwnerName.Margin = new Padding(8, 0, 8, 0);
            lblOwnerName.Name = "lblOwnerName";
            lblOwnerName.Size = new Size(700, 53);
            lblOwnerName.TabIndex = 1;
            lblOwnerName.Text = "Chào mừng, [Owner Name]";
            lblOwnerName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(41, 128, 185);
            panelMenu.Controls.Add(btnLogout);
            panelMenu.Controls.Add(btnIncidents);
            panelMenu.Controls.Add(btnReport);
            panelMenu.Controls.Add(btnContract);
            panelMenu.Controls.Add(btnBill);
            panelMenu.Controls.Add(btnCreate);
            panelMenu.Controls.Add(btnHome);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 167);
            panelMenu.Margin = new Padding(8, 8, 8, 8);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(463, 1481);
            panelMenu.TabIndex = 1;
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
            // btnIncidents
            // 
            btnIncidents.Dock = DockStyle.Top;
            btnIncidents.Font = new Font("Segoe UI", 11F);
            btnIncidents.Location = new Point(0, 617);
            btnIncidents.Margin = new Padding(8, 8, 8, 8);
            btnIncidents.Name = "btnIncidents";
            btnIncidents.Size = new Size(463, 124);
            btnIncidents.TabIndex = 7;
            btnIncidents.Text = "Thông báo";
            btnIncidents.UseVisualStyleBackColor = true;
            // 
            // btnReport
            // 
            btnReport.Dock = DockStyle.Top;
            btnReport.Font = new Font("Segoe UI", 11F);
            btnReport.Location = new Point(0, 497);
            btnReport.Margin = new Padding(8, 8, 8, 8);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(463, 120);
            btnReport.TabIndex = 4;
            btnReport.Text = "Báo cáo / Thống kê";
            btnReport.UseVisualStyleBackColor = true;
            // 
            // btnContract
            // 
            btnContract.Dock = DockStyle.Top;
            btnContract.Font = new Font("Segoe UI", 11F);
            btnContract.Location = new Point(0, 371);
            btnContract.Margin = new Padding(8, 8, 8, 8);
            btnContract.Name = "btnContract";
            btnContract.Size = new Size(463, 126);
            btnContract.TabIndex = 3;
            btnContract.Text = "Quản lý hợp đồng";
            btnContract.UseVisualStyleBackColor = true;
            // 
            // btnBill
            // 
            btnBill.Dock = DockStyle.Top;
            btnBill.Font = new Font("Segoe UI", 11F);
            btnBill.Location = new Point(0, 246);
            btnBill.Margin = new Padding(8, 8, 8, 8);
            btnBill.Name = "btnBill";
            btnBill.Size = new Size(463, 125);
            btnBill.TabIndex = 2;
            btnBill.Text = "Quản lí hóa đơn";
            btnBill.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            btnCreate.Dock = DockStyle.Top;
            btnCreate.Font = new Font("Segoe UI", 11F);
            btnCreate.Location = new Point(0, 125);
            btnCreate.Margin = new Padding(8, 8, 8, 8);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(463, 121);
            btnCreate.TabIndex = 0;
            btnCreate.Text = "Thêm phòng mới";
            btnCreate.UseVisualStyleBackColor = true;
            // 
            // btnHome
            // 
            btnHome.Dock = DockStyle.Top;
            btnHome.Font = new Font("Segoe UI", 11.1F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHome.Location = new Point(0, 0);
            btnHome.Margin = new Padding(8, 8, 8, 8);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(463, 125);
            btnHome.TabIndex = 6;
            btnHome.Text = "Quản lí Phòng";
            btnHome.UseVisualStyleBackColor = true;
            // 
            // panelSearch
            // 
            panelSearch.BackColor = Color.White;
            panelSearch.Controls.Add(btnResetStatus);
            panelSearch.Controls.Add(cboFilterStatus);
            panelSearch.Controls.Add(lblFilterStatus);
            panelSearch.Controls.Add(btnResetArea);
            panelSearch.Controls.Add(nudAreaTo);
            panelSearch.Controls.Add(label4);
            panelSearch.Controls.Add(nudAreaFrom);
            panelSearch.Controls.Add(lblFilterArea);
            panelSearch.Controls.Add(btnResetPrice);
            panelSearch.Controls.Add(nudPriceTo);
            panelSearch.Controls.Add(label2);
            panelSearch.Controls.Add(nudPriceFrom);
            panelSearch.Controls.Add(lblFilterPrice);
            panelSearch.Controls.Add(btnSearch);
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Dock = DockStyle.Top;
            panelSearch.Location = new Point(0, 0);
            panelSearch.Margin = new Padding(5, 5, 5, 5);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(2015, 167);
            panelSearch.TabIndex = 3;
            // 
            // btnResetStatus
            // 
            btnResetStatus.Font = new Font("Segoe UI", 10F);
            btnResetStatus.Location = new Point(1517, 95);
            btnResetStatus.Margin = new Padding(5, 5, 5, 5);
            btnResetStatus.Name = "btnResetStatus";
            btnResetStatus.Size = new Size(57, 54);
            btnResetStatus.TabIndex = 17;
            btnResetStatus.Text = "🔄";
            btnResetStatus.UseVisualStyleBackColor = true;
            // 
            // cboFilterStatus
            // 
            cboFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilterStatus.Font = new Font("Segoe UI", 10F);
            cboFilterStatus.FormattingEnabled = true;
            cboFilterStatus.Location = new Point(1267, 95);
            cboFilterStatus.Margin = new Padding(5, 5, 5, 5);
            cboFilterStatus.Name = "cboFilterStatus";
            cboFilterStatus.Size = new Size(247, 53);
            cboFilterStatus.TabIndex = 16;
            // 
            // lblFilterStatus
            // 
            lblFilterStatus.AutoSize = true;
            lblFilterStatus.Font = new Font("Segoe UI", 10F);
            lblFilterStatus.Location = new Point(1100, 100);
            lblFilterStatus.Margin = new Padding(5, 0, 5, 0);
            lblFilterStatus.Name = "lblFilterStatus";
            lblFilterStatus.Size = new Size(175, 46);
            lblFilterStatus.TabIndex = 15;
            lblFilterStatus.Text = "Trạng thái:";
            // 
            // btnResetArea
            // 
            btnResetArea.Font = new Font("Segoe UI", 10F);
            btnResetArea.Location = new Point(1008, 97);
            btnResetArea.Margin = new Padding(5, 5, 5, 5);
            btnResetArea.Name = "btnResetArea";
            btnResetArea.Size = new Size(57, 52);
            btnResetArea.TabIndex = 14;
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
            nudAreaTo.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(867, 107);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(30, 41);
            label4.TabIndex = 12;
            label4.Text = "-";
            // 
            // nudAreaFrom
            // 
            nudAreaFrom.Font = new Font("Segoe UI", 10F);
            nudAreaFrom.Location = new Point(750, 97);
            nudAreaFrom.Margin = new Padding(5, 5, 5, 5);
            nudAreaFrom.Name = "nudAreaFrom";
            nudAreaFrom.Size = new Size(117, 52);
            nudAreaFrom.TabIndex = 11;
            // 
            // lblFilterArea
            // 
            lblFilterArea.AutoSize = true;
            lblFilterArea.Font = new Font("Segoe UI", 10F);
            lblFilterArea.Location = new Point(600, 100);
            lblFilterArea.Margin = new Padding(5, 0, 5, 0);
            lblFilterArea.Name = "lblFilterArea";
            lblFilterArea.Size = new Size(160, 46);
            lblFilterArea.TabIndex = 10;
            lblFilterArea.Text = "Di?n tích:";
            // 
            // btnResetPrice
            // 
            btnResetPrice.Font = new Font("Segoe UI", 10F);
            btnResetPrice.Location = new Point(508, 97);
            btnResetPrice.Margin = new Padding(5, 5, 5, 5);
            btnResetPrice.Name = "btnResetPrice";
            btnResetPrice.Size = new Size(57, 51);
            btnResetPrice.TabIndex = 9;
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
            nudPriceTo.TabIndex = 8;
            nudPriceTo.ThousandsSeparator = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(300, 107);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(30, 41);
            label2.TabIndex = 7;
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
            nudPriceFrom.TabIndex = 6;
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
            lblFilterPrice.TabIndex = 5;
            lblFilterPrice.Text = "Giá:";
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
            btnSearch.Visible = false;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Font = new Font("Segoe UI", 12F);
            txtSearch.Location = new Point(42, 20);
            txtSearch.Margin = new Padding(5, 5, 5, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(1931, 61);
            txtSearch.TabIndex = 0;
            // 
            // flowPanelRooms
            // 
            flowPanelRooms.AutoScroll = true;
            flowPanelRooms.BackColor = Color.WhiteSmoke;
            flowPanelRooms.Dock = DockStyle.Fill;
            flowPanelRooms.Location = new Point(0, 167);
            flowPanelRooms.Margin = new Padding(8, 8, 8, 8);
            flowPanelRooms.Name = "flowPanelRooms";
            flowPanelRooms.Padding = new Padding(33, 33, 33, 33);
            flowPanelRooms.Size = new Size(2015, 1314);
            flowPanelRooms.TabIndex = 2;
            // 
            // panelRoomManagement
            // 
            panelRoomManagement.Controls.Add(lblNoResults);
            panelRoomManagement.Controls.Add(flowPanelRooms);
            panelRoomManagement.Controls.Add(panelSearch);
            panelRoomManagement.Dock = DockStyle.Fill;
            panelRoomManagement.Location = new Point(463, 167);
            panelRoomManagement.Margin = new Padding(5, 5, 5, 5);
            panelRoomManagement.Name = "panelRoomManagement";
            panelRoomManagement.Size = new Size(2015, 1481);
            panelRoomManagement.TabIndex = 4;
            // 
            // lblNoResults
            // 
            lblNoResults.AutoSize = true;
            lblNoResults.Font = new Font("Segoe UI", 14F, FontStyle.Italic);
            lblNoResults.ForeColor = Color.Gray;
            lblNoResults.Location = new Point(50, 200);
            lblNoResults.Margin = new Padding(5, 0, 5, 0);
            lblNoResults.Name = "lblNoResults";
            lblNoResults.Size = new Size(1037, 62);
            lblNoResults.TabIndex = 4;
            lblNoResults.Text = "Không có phòng nào trùng với thông tin tìm kiếm.";
            lblNoResults.Visible = false;
            // 
            // Owner_TrangChu
            // 
            AutoScaleDimensions = new SizeF(240F, 240F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(2478, 1648);
            Controls.Add(panelRoomManagement);
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
            ((System.ComponentModel.ISupportInitialize)nudAreaTo).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudAreaFrom).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPriceTo).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPriceFrom).EndInit();
            panelRoomManagement.ResumeLayout(false);
            panelRoomManagement.PerformLayout();
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
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Panel panelRoomManagement;
        private System.Windows.Forms.Label lblNoResults;
        private System.Windows.Forms.Button btnIncidents;
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
        private System.Windows.Forms.Label lblFilterStatus;
        private System.Windows.Forms.ComboBox cboFilterStatus;
        private System.Windows.Forms.Button btnResetStatus;
    }
}
