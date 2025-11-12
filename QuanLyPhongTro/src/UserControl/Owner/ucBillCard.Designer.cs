namespace QuanLyPhongTro
{
    partial class ucBillCard
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.grpOtherCosts = new System.Windows.Forms.GroupBox();
            this.lstOtherCosts = new System.Windows.Forms.ListBox();
            this.lblWater = new System.Windows.Forms.Label();
            this.lblElectricity = new System.Windows.Forms.Label();
            this.lblRenterName = new System.Windows.Forms.Label();
            this.lblRoomName = new System.Windows.Forms.Label();
            this.btnExportPDF = new System.Windows.Forms.Button();
            this.btnSendBill = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.grpOtherCosts.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.lblStatus);
            this.panelMain.Controls.Add(this.lblTotal);
            this.panelMain.Controls.Add(this.grpOtherCosts);
            this.panelMain.Controls.Add(this.lblWater);
            this.panelMain.Controls.Add(this.lblElectricity);
            this.panelMain.Controls.Add(this.lblRenterName);
            this.panelMain.Controls.Add(this.lblRoomName);
            this.panelMain.Controls.Add(this.btnExportPDF);
            this.panelMain.Controls.Add(this.btnSendBill);
            this.panelMain.Location = new System.Drawing.Point(5, 5);
            this.panelMain.Margin = new System.Windows.Forms.Padding(10);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(420, 440);
            this.panelMain.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblStatus.Location = new System.Drawing.Point(20, 85);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(111, 28);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "(Trạng thái)";
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTotal.Location = new System.Drawing.Point(15, 330);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(385, 45);
            this.lblTotal.TabIndex = 7;
            this.lblTotal.Text = "TỔNG: 0 VND";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpOtherCosts
            // 
            this.grpOtherCosts.Controls.Add(this.lstOtherCosts);
            this.grpOtherCosts.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpOtherCosts.Location = new System.Drawing.Point(20, 195);
            this.grpOtherCosts.Name = "grpOtherCosts";
            this.grpOtherCosts.Size = new System.Drawing.Size(380, 130);
            this.grpOtherCosts.TabIndex = 6;
            this.grpOtherCosts.TabStop = false;
            this.grpOtherCosts.Text = "Chi phí phát sinh";
            // 
            // lstOtherCosts
            // 
            this.lstOtherCosts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstOtherCosts.FormattingEnabled = true;
            this.lstOtherCosts.ItemHeight = 25;
            this.lstOtherCosts.Location = new System.Drawing.Point(3, 27);
            this.lstOtherCosts.Name = "lstOtherCosts";
            this.lstOtherCosts.Size = new System.Drawing.Size(374, 100);
            this.lstOtherCosts.TabIndex = 0;
            // 
            // lblWater
            // 
            this.lblWater.AutoSize = true;
            this.lblWater.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblWater.Location = new System.Drawing.Point(20, 155);
            this.lblWater.Name = "lblWater";
            this.lblWater.Size = new System.Drawing.Size(117, 28);
            this.lblWater.TabIndex = 5;
            this.lblWater.Text = "Tiền nước: ...";
            // 
            // lblElectricity
            // 
            this.lblElectricity.AutoSize = true;
            this.lblElectricity.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblElectricity.Location = new System.Drawing.Point(20, 120);
            this.lblElectricity.Name = "lblElectricity";
            this.lblElectricity.Size = new System.Drawing.Size(107, 28);
            this.lblElectricity.TabIndex = 4;
            this.lblElectricity.Text = "Tiền điện: ...";
            // 
            // lblRenterName
            // 
            this.lblRenterName.AutoSize = true;
            this.lblRenterName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblRenterName.Location = new System.Drawing.Point(20, 55);
            this.lblRenterName.Name = "lblRenterName";
            this.lblRenterName.Size = new System.Drawing.Size(133, 28);
            this.lblRenterName.TabIndex = 3;
            this.lblRenterName.Text = "(Người thuê...)";
            // 
            // lblRoomName
            // 
            this.lblRoomName.AutoSize = true;
            this.lblRoomName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblRoomName.Location = new System.Drawing.Point(15, 15);
            this.lblRoomName.Name = "lblRoomName";
            this.lblRoomName.Size = new System.Drawing.Size(183, 38);
            this.lblRoomName.TabIndex = 2;
            this.lblRoomName.Text = "(Tên phòng)";
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnExportPDF.Location = new System.Drawing.Point(20, 385);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(120, 40);
            this.btnExportPDF.TabIndex = 1;
            this.btnExportPDF.Text = "Xuất PDF";
            this.btnExportPDF.UseVisualStyleBackColor = true;
            // 
            // btnSendBill
            // 
            this.btnSendBill.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSendBill.Location = new System.Drawing.Point(250, 385);
            this.btnSendBill.Name = "btnSendBill";
            this.btnSendBill.Size = new System.Drawing.Size(150, 40);
            this.btnSendBill.TabIndex = 0;
            this.btnSendBill.Text = "Gửi Hóa đơn";
            this.btnSendBill.UseVisualStyleBackColor = true;
            // 
            // ucBillCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "ucBillCard";
            this.Size = new System.Drawing.Size(430, 450);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.grpOtherCosts.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button btnExportPDF;
        private System.Windows.Forms.Button btnSendBill;
        private System.Windows.Forms.Label lblRoomName;
        private System.Windows.Forms.Label lblRenterName;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.GroupBox grpOtherCosts;
        private System.Windows.Forms.ListBox lstOtherCosts;
        private System.Windows.Forms.Label lblWater;
        private System.Windows.Forms.Label lblElectricity;
        private System.Windows.Forms.Label lblStatus;
    }
}