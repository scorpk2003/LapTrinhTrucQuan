namespace QuanLyPhongTro
{
    partial class ucMyRoom
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
            this.label1 = new System.Windows.Forms.Label();
            this.grpRoomInfo = new System.Windows.Forms.GroupBox();
            this.lblRoomAddress = new System.Windows.Forms.Label();
            this.lblRoomArea = new System.Windows.Forms.Label();
            this.lblRoomPrice = new System.Windows.Forms.Label();
            this.lblRoomName = new System.Windows.Forms.Label();
            this.grpContract = new System.Windows.Forms.GroupBox();
            this.lblDeposit = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.grpBill = new System.Windows.Forms.GroupBox();
            this.btnPay = new System.Windows.Forms.Button();
            this.lblBillStatus = new System.Windows.Forms.Label();
            this.lblBillTotal = new System.Windows.Forms.Label();
            this.lblBillTitle = new System.Windows.Forms.Label();
            this.grpSpending = new System.Windows.Forms.GroupBox();
            this.spendingChart = new ScottPlot.WinForms.FormsPlot();
            this.grpRoomInfo.SuspendLayout();
            this.grpContract.SuspendLayout();
            this.grpBill.SuspendLayout();
            this.grpSpending.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(361, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tổng quan Phòng thuê";
            // 
            // grpRoomInfo
            // 
            this.grpRoomInfo.Controls.Add(this.lblRoomAddress);
            this.grpRoomInfo.Controls.Add(this.lblRoomArea);
            this.grpRoomInfo.Controls.Add(this.lblRoomPrice);
            this.grpRoomInfo.Controls.Add(this.lblRoomName);
            this.grpRoomInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpRoomInfo.Location = new System.Drawing.Point(30, 80);
            this.grpRoomInfo.Name = "grpRoomInfo";
            this.grpRoomInfo.Size = new System.Drawing.Size(350, 250);
            this.grpRoomInfo.TabIndex = 1;
            this.grpRoomInfo.TabStop = false;
            this.grpRoomInfo.Text = "Phòng của tôi";
            // 
            // lblRoomAddress
            // 
            this.lblRoomAddress.AutoSize = true;
            this.lblRoomAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRoomAddress.Location = new System.Drawing.Point(20, 150);
            this.lblRoomAddress.Name = "lblRoomAddress";
            this.lblRoomAddress.Size = new System.Drawing.Size(91, 28);
            this.lblRoomAddress.TabIndex = 3;
            this.lblRoomAddress.Text = "Địa chỉ: ...";
            // 
            // lblRoomArea
            // 
            this.lblRoomArea.AutoSize = true;
            this.lblRoomArea.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRoomArea.Location = new System.Drawing.Point(20, 110);
            this.lblRoomArea.Name = "lblRoomArea";
            this.lblRoomArea.Size = new System.Drawing.Size(107, 28);
            this.lblRoomArea.TabIndex = 2;
            this.lblRoomArea.Text = "Diện tích: ...";
            // 
            // lblRoomPrice
            // 
            this.lblRoomPrice.AutoSize = true;
            this.lblRoomPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRoomPrice.Location = new System.Drawing.Point(20, 70);
            this.lblRoomPrice.Name = "lblRoomPrice";
            this.lblRoomPrice.Size = new System.Drawing.Size(103, 28);
            this.lblRoomPrice.TabIndex = 1;
            this.lblRoomPrice.Text = "Giá thuê: ...";
            // 
            // lblRoomName
            // 
            this.lblRoomName.AutoSize = true;
            this.lblRoomName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRoomName.Location = new System.Drawing.Point(20, 30);
            this.lblRoomName.Name = "lblRoomName";
            this.lblRoomName.Size = new System.Drawing.Size(147, 30);
            this.lblRoomName.TabIndex = 0;
            this.lblRoomName.Text = "(Tên phòng)";
            // 
            // grpContract
            // 
            this.grpContract.Controls.Add(this.lblDeposit);
            this.grpContract.Controls.Add(this.lblEndDate);
            this.grpContract.Controls.Add(this.lblStartDate);
            this.grpContract.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpContract.Location = new System.Drawing.Point(400, 80);
            this.grpContract.Name = "grpContract";
            this.grpContract.Size = new System.Drawing.Size(350, 250);
            this.grpContract.TabIndex = 2;
            this.grpContract.TabStop = false;
            this.grpContract.Text = "Hợp đồng";
            // 
            // lblDeposit
            // 
            this.lblDeposit.AutoSize = true;
            this.lblDeposit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDeposit.Location = new System.Drawing.Point(20, 110);
            this.lblDeposit.Name = "lblDeposit";
            this.lblDeposit.Size = new System.Drawing.Size(100, 28);
            this.lblDeposit.TabIndex = 2;
            this.lblDeposit.Text = "Tiền cọc: ...";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEndDate.Location = new System.Drawing.Point(20, 70);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(142, 28);
            this.lblEndDate.TabIndex = 1;
            this.lblEndDate.Text = "Ngày kết thúc: ...";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStartDate.Location = new System.Drawing.Point(20, 30);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(139, 28);
            this.lblStartDate.TabIndex = 0;
            this.lblStartDate.Text = "Ngày bắt đầu: ...";
            // 
            // grpBill
            // 
            this.grpBill.Controls.Add(this.btnPay);
            this.grpBill.Controls.Add(this.lblBillStatus);
            this.grpBill.Controls.Add(this.lblBillTotal);
            this.grpBill.Controls.Add(this.lblBillTitle);
            this.grpBill.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpBill.Location = new System.Drawing.Point(770, 80);
            this.grpBill.Name = "grpBill";
            this.grpBill.Size = new System.Drawing.Size(350, 250);
            this.grpBill.TabIndex = 3;
            this.grpBill.TabStop = false;
            this.grpBill.Text = "Hóa đơn tháng này";
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.Location = new System.Drawing.Point(25, 180);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(300, 50);
            this.btnPay.TabIndex = 3;
            this.btnPay.Text = "Thanh toán (Demo)";
            this.btnPay.UseVisualStyleBackColor = false;
            // 
            // lblBillStatus
            // 
            this.lblBillStatus.AutoSize = true;
            this.lblBillStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblBillStatus.Location = new System.Drawing.Point(20, 70);
            this.lblBillStatus.Name = "lblBillStatus";
            this.lblBillStatus.Size = new System.Drawing.Size(111, 28);
            this.lblBillStatus.TabIndex = 2;
            this.lblBillStatus.Text = "(Trạng thái)";
            // 
            // lblBillTotal
            // 
            this.lblBillTotal.AutoSize = true;
            this.lblBillTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBillTotal.ForeColor = System.Drawing.Color.DarkRed;
            this.lblBillTotal.Location = new System.Drawing.Point(20, 110);
            this.lblBillTotal.Name = "lblBillTotal";
            this.lblBillTotal.Size = new System.Drawing.Size(109, 32);
            this.lblBillTotal.TabIndex = 1;
            this.lblBillTotal.Text = "Tổng: ...";
            // 
            // lblBillTitle
            // 
            this.lblBillTitle.AutoSize = true;
            this.lblBillTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBillTitle.Location = new System.Drawing.Point(20, 30);
            this.lblBillTitle.Name = "lblBillTitle";
            this.lblBillTitle.Size = new System.Drawing.Size(193, 28);
            this.lblBillTitle.TabIndex = 0;
            this.lblBillTitle.Text = "Hóa đơn tháng .../...";
            // 
            // grpSpending
            // 
            this.grpSpending.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSpending.Controls.Add(this.spendingChart);
            this.grpSpending.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpSpending.Location = new System.Drawing.Point(30, 350);
            this.grpSpending.Name = "grpSpending";
            this.grpSpending.Padding = new System.Windows.Forms.Padding(10);
            this.grpSpending.Size = new System.Drawing.Size(1090, 500);
            this.grpSpending.TabIndex = 4;
            this.grpSpending.TabStop = false;
            this.grpSpending.Text = "Biểu đồ chi tiêu 12 tháng qua";
            // 
            // spendingChart
            // 
            this.spendingChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spendingChart.Location = new System.Drawing.Point(10, 35);
            this.spendingChart.Name = "spendingChart";
            this.spendingChart.Size = new System.Drawing.Size(1070, 455);
            this.spendingChart.TabIndex = 0;
            // 
            // ucMyRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.grpSpending);
            this.Controls.Add(this.grpBill);
            this.Controls.Add(this.grpContract);
            this.Controls.Add(this.grpRoomInfo);
            this.Controls.Add(this.label1);
            this.Name = "ucMyRoom";
            this.Size = new System.Drawing.Size(1150, 880);
            this.grpRoomInfo.ResumeLayout(false);
            this.grpRoomInfo.PerformLayout();
            this.grpContract.ResumeLayout(false);
            this.grpContract.PerformLayout();
            this.grpBill.ResumeLayout(false);
            this.grpBill.PerformLayout();
            this.grpSpending.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpRoomInfo;
        private System.Windows.Forms.Label lblRoomAddress;
        private System.Windows.Forms.Label lblRoomArea;
        private System.Windows.Forms.Label lblRoomPrice;
        private System.Windows.Forms.Label lblRoomName;
        private System.Windows.Forms.GroupBox grpContract;
        private System.Windows.Forms.Label lblDeposit;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.GroupBox grpBill;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Label lblBillStatus;
        private System.Windows.Forms.Label lblBillTotal;
        private System.Windows.Forms.Label lblBillTitle;
        private System.Windows.Forms.GroupBox grpSpending;
        private ScottPlot.WinForms.FormsPlot spendingChart;
    }
}