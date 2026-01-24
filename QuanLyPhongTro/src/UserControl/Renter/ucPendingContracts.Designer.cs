namespace QuanLyPhongTro
{
    partial class ucPendingContracts
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
            lblTitle = new Label();
            lblInfo = new Label();
            dgvPendingContracts = new DataGridView();
            btnRefresh = new Button();
            panelTop = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvPendingContracts).BeginInit();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.Location = new Point(42, 41);
            lblTitle.Margin = new Padding(6, 0, 6, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(795, 72);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Hợp đồng đang chờ thêm ảnh";
            // 
            // lblInfo
            // 
            lblInfo.Font = new Font("Segoe UI", 13F);
            lblInfo.ForeColor = Color.OrangeRed;
            lblInfo.Location = new Point(42, 144);
            lblInfo.Margin = new Padding(6, 0, 6, 0);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(1488, 62);
            lblInfo.TabIndex = 1;
            lblInfo.Text = "Đang tải...";
            // 
            // dgvPendingContracts
            // 
            dgvPendingContracts.AllowUserToAddRows = false;
            dgvPendingContracts.AllowUserToDeleteRows = false;
            dgvPendingContracts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPendingContracts.BackgroundColor = Color.White;
            dgvPendingContracts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPendingContracts.Location = new Point(42, 328);
            dgvPendingContracts.Margin = new Padding(6, 6, 6, 6);
            dgvPendingContracts.Name = "dgvPendingContracts";
            dgvPendingContracts.ReadOnly = true;
            dgvPendingContracts.RowHeadersWidth = 51;
            dgvPendingContracts.RowTemplate.Height = 29;
            dgvPendingContracts.Size = new Size(2040, 984);
            dgvPendingContracts.TabIndex = 2;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.DodgerBlue;
            btnRefresh.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(42, 226);
            btnRefresh.Margin = new Padding(6, 6, 6, 6);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(255, 82);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(lblTitle);
            panelTop.Controls.Add(lblInfo);
            panelTop.Controls.Add(btnRefresh);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(6, 6, 6, 6);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(2125, 308);
            panelTop.TabIndex = 4;
            // 
            // ucPendingContracts
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvPendingContracts);
            Controls.Add(panelTop);
            Margin = new Padding(6, 6, 6, 6);
            Name = "ucPendingContracts";
            Size = new Size(2125, 1353);
            ((System.ComponentModel.ISupportInitialize)dgvPendingContracts).EndInit();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.DataGridView dgvPendingContracts;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panelTop;
    }
}
