//namespace QuanLyPhongTro
//{
//    partial class ucReportManagement
//    {
//        private System.ComponentModel.IContainer components = null;

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Component Designer generated code

//        private void InitializeComponent()
//        {
//            this.panelTop = new System.Windows.Forms.Panel();
//            this.btnRefresh = new System.Windows.Forms.Button();
//            this.cboYear = new System.Windows.Forms.ComboBox();
//            this.label1 = new System.Windows.Forms.Label();
//            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
//            this.revenueChart = new ScottPlot.WinForms.FormsPlot();
//            this.grpOccupancy = new System.Windows.Forms.GroupBox();
//            this.occupancyChart = new ScottPlot.WinForms.FormsPlot();
//            this.grpUnpaid = new System.Windows.Forms.GroupBox();
//            this.dgvUnpaidBills = new System.Windows.Forms.DataGridView();
//            this.grpRevenue = new System.Windows.Forms.GroupBox();
//            this.panelTop.SuspendLayout();
//            this.tableLayoutPanel.SuspendLayout();
//            this.grpOccupancy.SuspendLayout();
//            this.grpUnpaid.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.dgvUnpaidBills)).BeginInit();
//            this.grpRevenue.SuspendLayout();
//            this.SuspendLayout();
//            // 
//            // panelTop
//            // 
//            this.panelTop.BackColor = System.Drawing.Color.White;
//            this.panelTop.Controls.Add(this.btnRefresh);
//            this.panelTop.Controls.Add(this.cboYear);
//            this.panelTop.Controls.Add(this.label1);
//            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
//            this.panelTop.Location = new System.Drawing.Point(0, 0);
//            this.panelTop.Name = "panelTop";
//            this.panelTop.Size = new System.Drawing.Size(1200, 70);
//            this.panelTop.TabIndex = 0;
//            // 
//            // btnRefresh
//            // 
//            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F);
//            this.btnRefresh.Location = new System.Drawing.Point(300, 15);
//            this.btnRefresh.Name = "btnRefresh";
//            this.btnRefresh.Size = new System.Drawing.Size(120, 40);
//            this.btnRefresh.TabIndex = 2;
//            this.btnRefresh.Text = "Làm m?i";
//            this.btnRefresh.UseVisualStyleBackColor = true;
//            // 
//            // cboYear
//            // 
//            this.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
//            this.cboYear.Font = new System.Drawing.Font("Segoe UI", 10F);
//            this.cboYear.FormattingEnabled = true;
//            this.cboYear.Location = new System.Drawing.Point(140, 18);
//            this.cboYear.Name = "cboYear";
//            this.cboYear.Size = new System.Drawing.Size(140, 36);
//            this.cboYear.TabIndex = 1;
//            // 
//            // label1
//            // 
//            this.label1.AutoSize = true;
//            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
//            this.label1.Location = new System.Drawing.Point(20, 22);
//            this.label1.Name = "label1";
//            this.label1.Size = new System.Drawing.Size(103, 28);
//            this.label1.TabIndex = 0;
//            this.label1.Text = "Ch?n nam:";
//            // 
//            // tableLayoutPanel
//            // 
//            this.tableLayoutPanel.ColumnCount = 2;
//            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
//            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
//            this.tableLayoutPanel.Controls.Add(this.grpOccupancy, 1, 0);
//            this.tableLayoutPanel.Controls.Add(this.grpUnpaid, 0, 1);
//            this.tableLayoutPanel.Controls.Add(this.grpRevenue, 0, 0);
//            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 70);
//            this.tableLayoutPanel.Name = "tableLayoutPanel";
//            this.tableLayoutPanel.Padding = new System.Windows.Forms.Padding(10);
//            this.tableLayoutPanel.RowCount = 2;
//            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
//            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
//            this.tableLayoutPanel.Size = new System.Drawing.Size(1200, 830);
//            this.tableLayoutPanel.TabIndex = 1;
//            // 
//            // revenueChart
//            // 
//            this.revenueChart.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.revenueChart.Location = new System.Drawing.Point(10, 35);
//            this.revenueChart.Name = "revenueChart";
//            this.revenueChart.Size = new System.Drawing.Size(686, 350);
//            this.revenueChart.TabIndex = 0;
//            // 
//            // grpOccupancy
//            // 
//            this.grpOccupancy.Controls.Add(this.occupancyChart);
//            this.grpOccupancy.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.grpOccupancy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
//            this.grpOccupancy.Location = new System.Drawing.Point(727, 13);
//            this.grpOccupancy.Name = "grpOccupancy";
//            this.grpOccupancy.Padding = new System.Windows.Forms.Padding(10);
//            this.grpOccupancy.Size = new System.Drawing.Size(460, 399);
//            this.grpOccupancy.TabIndex = 1;
//            this.grpOccupancy.TabStop = false;
//            this.grpOccupancy.Text = "T? l? l?p d?y";
//            // 
//            // occupancyChart
//            // 
//            this.occupancyChart.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.occupancyChart.Location = new System.Drawing.Point(10, 35);
//            this.occupancyChart.Name = "occupancyChart";
//            this.occupancyChart.Size = new System.Drawing.Size(440, 354);
//            this.occupancyChart.TabIndex = 1;
//            // 
//            // grpUnpaid
//            // 
//            this.tableLayoutPanel.SetColumnSpan(this.grpUnpaid, 2);
//            this.grpUnpaid.Controls.Add(this.dgvUnpaidBills);
//            this.grpUnpaid.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.grpUnpaid.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
//            this.grpUnpaid.Location = new System.Drawing.Point(13, 418);
//            this.grpUnpaid.Name = "grpUnpaid";
//            this.grpUnpaid.Padding = new System.Windows.Forms.Padding(10);
//            this.grpUnpaid.Size = new System.Drawing.Size(1174, 399);
//            this.grpUnpaid.TabIndex = 2;
//            this.grpUnpaid.TabStop = false;
//            this.grpUnpaid.Text = "Báo cáo n? d?ng (chua thanh toán)";
//            // 
//            // dgvUnpaidBills
//            // 
//            this.dgvUnpaidBills.AllowUserToAddRows = false;
//            this.dgvUnpaidBills.AllowUserToDeleteRows = false;
//            this.dgvUnpaidBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
//            this.dgvUnpaidBills.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.dgvUnpaidBills.Location = new System.Drawing.Point(10, 35);
//            this.dgvUnpaidBills.Name = "dgvUnpaidBills";
//            this.dgvUnpaidBills.ReadOnly = true;
//            this.dgvUnpaidBills.RowHeadersWidth = 62;
//            this.dgvUnpaidBills.RowTemplate.Height = 28;
//            this.dgvUnpaidBills.Size = new System.Drawing.Size(1154, 354);
//            this.dgvUnpaidBills.TabIndex = 0;
//            // 
//            // grpRevenue
//            // 
//            this.grpRevenue.Controls.Add(this.revenueChart);
//            this.grpRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.grpRevenue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
//            this.grpRevenue.Location = new System.Drawing.Point(13, 13);
//            this.grpRevenue.Name = "grpRevenue";
//            this.grpRevenue.Padding = new System.Windows.Forms.Padding(10);
//            this.grpRevenue.Size = new System.Drawing.Size(708, 399);
//            this.grpRevenue.TabIndex = 3;
//            this.grpRevenue.TabStop = false;
//            this.grpRevenue.Text = "Doanh thu theo tháng";
//            // 
//            // ucReportManagement
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.Controls.Add(this.tableLayoutPanel);
//            this.Controls.Add(this.panelTop);
//            this.Name = "ucReportManagement";
//            this.Size = new System.Drawing.Size(1200, 900);
//            this.panelTop.ResumeLayout(false);
//            this.panelTop.PerformLayout();
//            this.tableLayoutPanel.ResumeLayout(false);
//            this.grpOccupancy.ResumeLayout(false);
//            this.grpUnpaid.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.dgvUnpaidBills)).EndInit();
//            this.grpRevenue.ResumeLayout(false);
//            this.ResumeLayout(false);
//        }

//        #endregion

//        private System.Windows.Forms.Panel panelTop;
//        private System.Windows.Forms.Button btnRefresh;
//        private System.Windows.Forms.ComboBox cboYear;
//        private System.Windows.Forms.Label label1;
//        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
//        private ScottPlot.WinForms.FormsPlot revenueChart;
//        private System.Windows.Forms.GroupBox grpOccupancy;
//        private ScottPlot.WinForms.FormsPlot occupancyChart;
//        private System.Windows.Forms.GroupBox grpUnpaid;
//        private System.Windows.Forms.DataGridView dgvUnpaidBills;
//        private System.Windows.Forms.GroupBox grpRevenue;
//    }
//}
