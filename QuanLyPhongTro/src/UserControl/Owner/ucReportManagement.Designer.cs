namespace QuanLyPhongTro
{
    partial class ucReportManagement
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.grpOccupancy = new System.Windows.Forms.GroupBox();
            this.occupancyChart = new ScottPlot.WinForms.FormsPlot();
            this.grpUnpaid = new System.Windows.Forms.GroupBox();
            this.dgvUnpaidBills = new System.Windows.Forms.DataGridView();
            this.panelUnpaidSummary = new System.Windows.Forms.Panel();
            this.lblUnpaidCount = new System.Windows.Forms.Label();
            this.lblUnpaidTotal = new System.Windows.Forms.Label();
            this.grpRevenue = new System.Windows.Forms.GroupBox();
            this.revenueChart = new ScottPlot.WinForms.FormsPlot();
            this.panelTop.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.grpOccupancy.SuspendLayout();
            this.grpUnpaid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnpaidBills)).BeginInit();
            this.panelUnpaidSummary.SuspendLayout();
            this.grpRevenue.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Controls.Add(this.cboYear);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.panelTop.Size = new System.Drawing.Size(1200, 80);
            this.panelTop.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(31, 97, 141);
            this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(360, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(150, 50);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // cboYear
            // 
            this.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYear.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(180, 20);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(160, 36);
            this.cboYear.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.label1.Location = new System.Drawing.Point(20, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "📅 Chọn năm:";
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel.Controls.Add(this.grpOccupancy, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.grpUnpaid, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.grpRevenue, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 80);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1200, 820);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // grpOccupancy
            // 
            this.grpOccupancy.Controls.Add(this.occupancyChart);
            this.grpOccupancy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOccupancy.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.grpOccupancy.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.grpOccupancy.Location = new System.Drawing.Point(727, 13);
            this.grpOccupancy.Name = "grpOccupancy";
            this.grpOccupancy.Padding = new System.Windows.Forms.Padding(10);
            this.grpOccupancy.Size = new System.Drawing.Size(460, 394);
            this.grpOccupancy.TabIndex = 1;
            this.grpOccupancy.TabStop = false;
            this.grpOccupancy.Text = "📊 Tỉ lệ lấp đầy";
            // 
            // occupancyChart
            // 
            this.occupancyChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.occupancyChart.Location = new System.Drawing.Point(10, 42);
            this.occupancyChart.Name = "occupancyChart";
            this.occupancyChart.Size = new System.Drawing.Size(440, 342);
            this.occupancyChart.TabIndex = 1;
            // 
            // grpUnpaid
            // 
            this.tableLayoutPanel.SetColumnSpan(this.grpUnpaid, 2);
            this.grpUnpaid.Controls.Add(this.dgvUnpaidBills);
            this.grpUnpaid.Controls.Add(this.panelUnpaidSummary);
            this.grpUnpaid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUnpaid.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.grpUnpaid.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.grpUnpaid.Location = new System.Drawing.Point(13, 413);
            this.grpUnpaid.Name = "grpUnpaid";
            this.grpUnpaid.Padding = new System.Windows.Forms.Padding(10);
            this.grpUnpaid.Size = new System.Drawing.Size(1174, 394);
            this.grpUnpaid.TabIndex = 2;
            this.grpUnpaid.TabStop = false;
            this.grpUnpaid.Text = "💰 Báo cáo nợ đọng (chưa thanh toán)";
            // 
            // dgvUnpaidBills
            // 
            this.dgvUnpaidBills.AllowUserToAddRows = false;
            this.dgvUnpaidBills.AllowUserToDeleteRows = false;
            this.dgvUnpaidBills.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUnpaidBills.BackgroundColor = System.Drawing.Color.White;
            this.dgvUnpaidBills.ColumnHeadersHeight = 45;
            this.dgvUnpaidBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUnpaidBills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUnpaidBills.EnableHeadersVisualStyles = false;
            this.dgvUnpaidBills.Location = new System.Drawing.Point(10, 96);
            this.dgvUnpaidBills.Name = "dgvUnpaidBills";
            this.dgvUnpaidBills.ReadOnly = true;
            this.dgvUnpaidBills.RowHeadersWidth = 62;
            this.dgvUnpaidBills.RowTemplate.Height = 40;
            this.dgvUnpaidBills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUnpaidBills.Size = new System.Drawing.Size(1154, 288);
            this.dgvUnpaidBills.TabIndex = 0;
            // 
            // panelUnpaidSummary
            // 
            this.panelUnpaidSummary.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.panelUnpaidSummary.Controls.Add(this.lblUnpaidTotal);
            this.panelUnpaidSummary.Controls.Add(this.lblUnpaidCount);
            this.panelUnpaidSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUnpaidSummary.Location = new System.Drawing.Point(10, 42);
            this.panelUnpaidSummary.Name = "panelUnpaidSummary";
            this.panelUnpaidSummary.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.panelUnpaidSummary.Size = new System.Drawing.Size(1154, 54);
            this.panelUnpaidSummary.TabIndex = 1;
            // 
            // lblUnpaidCount
            // 
            this.lblUnpaidCount.AutoSize = true;
            this.lblUnpaidCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
            this.lblUnpaidCount.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblUnpaidCount.Location = new System.Drawing.Point(12, 13);
            this.lblUnpaidCount.Name = "lblUnpaidCount";
            this.lblUnpaidCount.Size = new System.Drawing.Size(176, 28);
            this.lblUnpaidCount.TabIndex = 0;
            this.lblUnpaidCount.Text = "Số hóa đơn nợ: 0";
            // 
            // lblUnpaidTotal
            // 
            this.lblUnpaidTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUnpaidTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblUnpaidTotal.ForeColor = System.Drawing.Color.FromArgb(198, 40, 40);
            this.lblUnpaidTotal.Location = new System.Drawing.Point(650, 13);
            this.lblUnpaidTotal.Name = "lblUnpaidTotal";
            this.lblUnpaidTotal.Size = new System.Drawing.Size(492, 28);
            this.lblUnpaidTotal.TabIndex = 1;
            this.lblUnpaidTotal.Text = "Tổng nợ: 0 VND";
            this.lblUnpaidTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpRevenue
            // 
            this.grpRevenue.Controls.Add(this.revenueChart);
            this.grpRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRevenue.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.grpRevenue.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.grpRevenue.Location = new System.Drawing.Point(13, 13);
            this.grpRevenue.Name = "grpRevenue";
            this.grpRevenue.Padding = new System.Windows.Forms.Padding(10);
            this.grpRevenue.Size = new System.Drawing.Size(708, 394);
            this.grpRevenue.TabIndex = 3;
            this.grpRevenue.TabStop = false;
            this.grpRevenue.Text = "📈 Doanh thu theo tháng";
            // 
            // revenueChart
            // 
            this.revenueChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.revenueChart.Location = new System.Drawing.Point(10, 42);
            this.revenueChart.Name = "revenueChart";
            this.revenueChart.Size = new System.Drawing.Size(688, 342);
            this.revenueChart.TabIndex = 0;
            // 
            // ucReportManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.panelTop);
            this.Name = "ucReportManagement";
            this.Size = new System.Drawing.Size(1200, 900);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.grpOccupancy.ResumeLayout(false);
            this.grpUnpaid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnpaidBills)).EndInit();
            this.panelUnpaidSummary.ResumeLayout(false);
            this.panelUnpaidSummary.PerformLayout();
            this.grpRevenue.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private ScottPlot.WinForms.FormsPlot revenueChart;
        private System.Windows.Forms.GroupBox grpOccupancy;
        private ScottPlot.WinForms.FormsPlot occupancyChart;
        private System.Windows.Forms.GroupBox grpUnpaid;
        private System.Windows.Forms.DataGridView dgvUnpaidBills;
        private System.Windows.Forms.Panel panelUnpaidSummary;
        private System.Windows.Forms.Label lblUnpaidCount;
        private System.Windows.Forms.Label lblUnpaidTotal;
        private System.Windows.Forms.GroupBox grpRevenue;
    }
}
