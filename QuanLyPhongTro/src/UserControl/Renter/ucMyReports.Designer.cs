namespace QuanLyPhongTro
{
    partial class ucMyReports
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            panelTop = new Panel();
            label1 = new Label();
            cboFilterStatus = new ComboBox();
            btnRefresh = new Button();
            splitContainer = new SplitContainer();
            panelLeft = new Panel();
            flpReports = new FlowLayoutPanel();
            panelRight = new Panel();
            grpDetail = new GroupBox();
            txtDescription = new TextBox();
            lblDate = new Label();
            lblRoom = new Label();
            lblStatus = new Label();
            lblTitleDetail = new Label();
            panelActions = new Panel();
            btnCreateReport = new Button();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            panelLeft.SuspendLayout();
            panelRight.SuspendLayout();
            grpDetail.SuspendLayout();
            panelActions.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(240, 244, 248);
            panelTop.Controls.Add(label1);
            panelTop.Controls.Add(cboFilterStatus);
            panelTop.Controls.Add(btnRefresh);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(0);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(21, 16, 21, 16);
            panelTop.Size = new Size(2550, 123);
            panelTop.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F);
            label1.Location = new Point(425, 37);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(403, 60);
            label1.TabIndex = 2;
            label1.Text = "Lọc theo trạng thái:";
            // 
            // cboFilterStatus
            // 
            cboFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilterStatus.Font = new Font("Segoe UI", 13F);
            cboFilterStatus.FormattingEnabled = true;
            cboFilterStatus.Items.AddRange(new object[] { "Tất cả", "Đang chờ", "Đang xử lý", "Đã giải quyết" });
            cboFilterStatus.Location = new Point(824, 30);
            cboFilterStatus.Margin = new Padding(0);
            cboFilterStatus.Name = "cboFilterStatus";
            cboFilterStatus.Size = new Size(463, 67);
            cboFilterStatus.TabIndex = 1;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(41, 128, 185);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(32, 25);
            btnRefresh.Margin = new Padding(0);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(309, 74);
            btnRefresh.TabIndex = 0;
            btnRefresh.Text = "🔄 Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.FixedPanel = FixedPanel.Panel1;
            splitContainer.Location = new Point(0, 123);
            splitContainer.Margin = new Padding(0);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(panelLeft);
            splitContainer.Panel1MinSize = 400;
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(panelRight);
            splitContainer.Panel2MinSize = 450;
            splitContainer.Size = new Size(2550, 1312);
            splitContainer.SplitterDistance = 956;
            splitContainer.SplitterWidth = 11;
            splitContainer.TabIndex = 1;
            // 
            // panelLeft
            // 
            panelLeft.Controls.Add(flpReports);
            panelLeft.Dock = DockStyle.Fill;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Margin = new Padding(0);
            panelLeft.Name = "panelLeft";
            panelLeft.Padding = new Padding(21, 20, 11, 20);
            panelLeft.Size = new Size(956, 1312);
            panelLeft.TabIndex = 0;
            // 
            // flpReports
            // 
            flpReports.AutoScroll = true;
            flpReports.BackColor = Color.FromArgb(245, 247, 250);
            flpReports.Dock = DockStyle.Fill;
            flpReports.FlowDirection = FlowDirection.TopDown;
            flpReports.Location = new Point(21, 20);
            flpReports.Margin = new Padding(0);
            flpReports.Name = "flpReports";
            flpReports.Padding = new Padding(11, 10, 11, 10);
            flpReports.Size = new Size(924, 1272);
            flpReports.TabIndex = 0;
            flpReports.WrapContents = false;
            // 
            // panelRight
            // 
            panelRight.Controls.Add(grpDetail);
            panelRight.Controls.Add(panelActions);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(0, 0);
            panelRight.Margin = new Padding(0);
            panelRight.Name = "panelRight";
            panelRight.Padding = new Padding(11, 20, 21, 20);
            panelRight.Size = new Size(1583, 1312);
            panelRight.TabIndex = 0;
            // 
            // grpDetail
            // 
            grpDetail.Controls.Add(txtDescription);
            grpDetail.Controls.Add(lblDate);
            grpDetail.Controls.Add(lblRoom);
            grpDetail.Controls.Add(lblStatus);
            grpDetail.Controls.Add(lblTitleDetail);
            grpDetail.Dock = DockStyle.Fill;
            grpDetail.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            grpDetail.Location = new Point(11, 20);
            grpDetail.Margin = new Padding(0);
            grpDetail.Name = "grpDetail";
            grpDetail.Padding = new Padding(32, 25, 32, 25);
            grpDetail.Size = new Size(1551, 1128);
            grpDetail.TabIndex = 0;
            grpDetail.TabStop = false;
            grpDetail.Text = "📋 Chi tiết thông báo";
            // 
            // txtDescription
            // 
            txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtDescription.Font = new Font("Segoe UI", 15F);
            txtDescription.Location = new Point(42, 451);
            txtDescription.Margin = new Padding(0);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ReadOnly = true;
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(1462, 631);
            txtDescription.TabIndex = 4;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 13F);
            lblDate.Location = new Point(42, 297);
            lblDate.Margin = new Padding(0, 0, 0, 16);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(224, 60);
            lblDate.TabIndex = 3;
            lblDate.Text = "Ngày gửi: ";
            // 
            // lblRoom
            // 
            lblRoom.AutoSize = true;
            lblRoom.Font = new Font("Segoe UI", 13F);
            lblRoom.Location = new Point(42, 226);
            lblRoom.Margin = new Padding(0, 0, 0, 16);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(174, 60);
            lblRoom.TabIndex = 2;
            lblRoom.Text = "Phòng: ";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 13F);
            lblStatus.Location = new Point(42, 154);
            lblStatus.Margin = new Padding(0, 0, 0, 16);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(239, 60);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Trạng thái: ";
            // 
            // lblTitleDetail
            // 
            lblTitleDetail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitleDetail.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitleDetail.ForeColor = Color.FromArgb(41, 128, 185);
            lblTitleDetail.Location = new Point(42, 66);
            lblTitleDetail.Margin = new Padding(0, 0, 0, 25);
            lblTitleDetail.Name = "lblTitleDetail";
            lblTitleDetail.Size = new Size(1466, 72);
            lblTitleDetail.TabIndex = 0;
            lblTitleDetail.Text = "Tiêu đề: ";
            // 
            // panelActions
            // 
            panelActions.Controls.Add(btnCreateReport);
            panelActions.Dock = DockStyle.Bottom;
            panelActions.Location = new Point(11, 1148);
            panelActions.Margin = new Padding(0);
            panelActions.Name = "panelActions";
            panelActions.Padding = new Padding(21, 16, 21, 16);
            panelActions.Size = new Size(1551, 144);
            panelActions.TabIndex = 1;
            // 
            // btnCreateReport
            // 
            btnCreateReport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCreateReport.BackColor = Color.FromArgb(41, 128, 185);
            btnCreateReport.FlatStyle = FlatStyle.Flat;
            btnCreateReport.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCreateReport.ForeColor = Color.White;
            btnCreateReport.Location = new Point(1126, 25);
            btnCreateReport.Margin = new Padding(11, 0, 0, 0);
            btnCreateReport.Name = "btnCreateReport";
            btnCreateReport.Size = new Size(382, 92);
            btnCreateReport.TabIndex = 0;
            btnCreateReport.Text = "➕ Gửi báo cáo mới";
            btnCreateReport.UseVisualStyleBackColor = false;
            // 
            // ucMyReports
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(splitContainer);
            Controls.Add(panelTop);
            Margin = new Padding(0);
            Name = "ucMyReports";
            Size = new Size(2550, 1435);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            panelLeft.ResumeLayout(false);
            panelRight.ResumeLayout(false);
            grpDetail.ResumeLayout(false);
            grpDetail.PerformLayout();
            panelActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Button btnRefresh;
        private ComboBox cboFilterStatus;
        private Label label1;

        private SplitContainer splitContainer;
        private Panel panelLeft;
        private FlowLayoutPanel flpReports;

        private Panel panelRight;
        private GroupBox grpDetail;
        private TextBox txtDescription;
        private Label lblDate;
        private Label lblRoom;
        private Label lblStatus;
        private Label lblTitleDetail;

        private Panel panelActions;
        private Button btnCreateReport;
    }
}
