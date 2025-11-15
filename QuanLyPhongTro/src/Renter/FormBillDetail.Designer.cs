namespace QuanLyPhongTro
{
    partial class FormBillDetail
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblRoomName;
        private System.Windows.Forms.Label lblPaymentDate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DataGridView dgvBillDetails;
        private System.Windows.Forms.Label lblTotalMoney;
        private System.Windows.Forms.Button btnPayCash; // ĐỔI TÊN
        private System.Windows.Forms.Button btnPayQR;   // THÊM MỚI
        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblRoomName = new System.Windows.Forms.Label();
            this.lblPaymentDate = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.dgvBillDetails = new System.Windows.Forms.DataGridView();
            this.lblTotalMoney = new System.Windows.Forms.Label();
            this.btnPayCash = new System.Windows.Forms.Button();
            this.btnPayQR = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRoomName
            // 
            this.lblRoomName.AutoSize = true;
            this.lblRoomName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblRoomName.Location = new System.Drawing.Point(20, 20);
            this.lblRoomName.Name = "lblRoomName";
            this.lblRoomName.Size = new System.Drawing.Size(100, 21);
            this.lblRoomName.TabIndex = 0;
            this.lblRoomName.Text = "Phòng: ";
            // 
            // lblPaymentDate
            // 
            this.lblPaymentDate.AutoSize = true;
            this.lblPaymentDate.Location = new System.Drawing.Point(20, 50);
            this.lblPaymentDate.Name = "lblPaymentDate";
            this.lblPaymentDate.Size = new System.Drawing.Size(100, 15);
            this.lblPaymentDate.TabIndex = 1;
            this.lblPaymentDate.Text = "Ngày thanh toán: ";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(20, 75);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(70, 15);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Trạng thái: ";
            // 
            // dgvBillDetails
            // 
            this.dgvBillDetails.AllowUserToAddRows = false;
            this.dgvBillDetails.AllowUserToDeleteRows = false;
            this.dgvBillDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBillDetails.Location = new System.Drawing.Point(20, 110);
            this.dgvBillDetails.Name = "dgvBillDetails";
            this.dgvBillDetails.ReadOnly = true;
            this.dgvBillDetails.Size = new System.Drawing.Size(560, 200);
            this.dgvBillDetails.TabIndex = 3;
            // 
            // lblTotalMoney
            // 
            this.lblTotalMoney.AutoSize = true;
            this.lblTotalMoney.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalMoney.ForeColor = System.Drawing.Color.Red;
            this.lblTotalMoney.Location = new System.Drawing.Point(20, 325);
            this.lblTotalMoney.Name = "lblTotalMoney";
            this.lblTotalMoney.Size = new System.Drawing.Size(150, 25);
            this.lblTotalMoney.TabIndex = 4;
            this.lblTotalMoney.Text = "Tổng cộng: ";
            // 
            // btnPayCash
            // 
            this.btnPayCash.BackColor = System.Drawing.Color.Orange;
            this.btnPayCash.ForeColor = System.Drawing.Color.White;
            this.btnPayCash.Location = new System.Drawing.Point(230, 370);
            this.btnPayCash.Name = "btnPayCash";
            this.btnPayCash.Size = new System.Drawing.Size(110, 35);
            this.btnPayCash.TabIndex = 5;
            this.btnPayCash.Text = "Tiền mặt";
            this.btnPayCash.UseVisualStyleBackColor = false;
            // 
            // btnPayQR
            // 
            this.btnPayQR.BackColor = System.Drawing.Color.Green;
            this.btnPayQR.ForeColor = System.Drawing.Color.White;
            this.btnPayQR.Location = new System.Drawing.Point(350, 370);
            this.btnPayQR.Name = "btnPayQR";
            this.btnPayQR.Size = new System.Drawing.Size(110, 35);
            this.btnPayQR.TabIndex = 6;
            this.btnPayQR.Text = "QR Code";
            this.btnPayQR.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(470, 370);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 35);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // FormBillDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 420);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPayQR);
            this.Controls.Add(this.btnPayCash);
            this.Controls.Add(this.lblTotalMoney);
            this.Controls.Add(this.dgvBillDetails);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblPaymentDate);
            this.Controls.Add(this.lblRoomName);
            this.Name = "FormBillDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết hóa đơn";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}