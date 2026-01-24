namespace QuanLyPhongTro
{
    partial class ucReportItem
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
            components = new System.ComponentModel.Container();
            lblTitle = new Label();
            lblRoom = new Label();
            lblDate = new Label();
            lblStatus = new Label();
            pnlBorder = new Panel();
            toolTip = new ToolTip(components);
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.Font = new Font("Segoe UI", 15.9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(26, 16);
            lblTitle.Margin = new Padding(5, 0, 5, 0);
            lblTitle.MaximumSize = new Size(0, 130);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(846, 130);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Tiêu đề báo cáo";
            // 
            // lblRoom
            // 
            lblRoom.AutoSize = true;
            lblRoom.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoom.ForeColor = Color.DimGray;
            lblRoom.Location = new Point(26, 160);
            lblRoom.Margin = new Padding(5, 0, 5, 0);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(166, 54);
            lblRoom.TabIndex = 1;
            lblRoom.Text = "🏠  N/A";
            // 
            // lblDate
            // 
            lblDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 11F);
            lblDate.ForeColor = Color.Gray;
            lblDate.Location = new Point(550, 164);
            lblDate.Margin = new Padding(5, 0, 5, 0);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(366, 50);
            lblDate.TabIndex = 2;
            lblDate.Text = "📅 12/10/2023 08:30";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblStatus.Location = new Point(26, 230);
            lblStatus.Margin = new Padding(5, 0, 5, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(238, 54);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "● Đang chờ";
            // 
            // pnlBorder
            // 
            pnlBorder.BackColor = Color.LightGray;
            pnlBorder.Dock = DockStyle.Bottom;
            pnlBorder.Location = new Point(0, 285);
            pnlBorder.Margin = new Padding(5);
            pnlBorder.Name = "pnlBorder";
            pnlBorder.Size = new Size(916, 17);
            pnlBorder.TabIndex = 4;
            // 
            // toolTip
            // 
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 500;
            toolTip.ReshowDelay = 100;
            // 
            // ucReportItem
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pnlBorder);
            Controls.Add(lblStatus);
            Controls.Add(lblDate);
            Controls.Add(lblRoom);
            Controls.Add(lblTitle);
            Cursor = Cursors.Hand;
            Margin = new Padding(8);
            Name = "ucReportItem";
            Size = new Size(916, 302);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblRoom;
        private Label lblDate;
        private Label lblStatus;
        private Panel pnlBorder;
        private ToolTip toolTip;
    }
}
