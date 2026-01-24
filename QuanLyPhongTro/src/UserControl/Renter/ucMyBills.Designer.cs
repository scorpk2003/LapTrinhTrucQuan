namespace QuanLyPhongTro
{
    partial class ucMyBills
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
            dgvBills = new DataGridView();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBills).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.White;
            panelTop.Controls.Add(label1);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(6, 6, 6, 6);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(2078, 144);
            panelTop.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            label1.Location = new Point(38, 31);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(536, 76);
            label1.TabIndex = 0;
            label1.Text = "Lịch sử Thanh toán";
            // 
            // dgvBills
            // 
            dgvBills.AllowUserToAddRows = false;
            dgvBills.AllowUserToDeleteRows = false;
            dgvBills.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBills.Dock = DockStyle.Fill;
            dgvBills.Location = new Point(0, 144);
            dgvBills.Margin = new Padding(6, 6, 6, 6);
            dgvBills.Name = "dgvBills";
            dgvBills.ReadOnly = true;
            dgvBills.RowHeadersWidth = 62;
            dgvBills.RowTemplate.Height = 28;
            dgvBills.Size = new Size(2078, 1496);
            dgvBills.TabIndex = 1;
            // 
            // ucMyBills
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvBills);
            Controls.Add(panelTop);
            Margin = new Padding(6, 6, 6, 6);
            Name = "ucMyBills";
            Size = new Size(2078, 1640);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBills).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvBills;
    }
}
