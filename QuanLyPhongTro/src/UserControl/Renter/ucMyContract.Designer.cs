namespace QuanLyPhongTro
{
    partial class ucMyContract
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
            this.grpContract = new System.Windows.Forms.GroupBox();
            this.lblDeposit = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.btnRequestTermination = new System.Windows.Forms.Button();
            this.btnRequestRenewal = new System.Windows.Forms.Button();
            this.grpContract.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hợp đồng của tôi";
            // 
            // grpContract
            // 
            this.grpContract.Controls.Add(this.lblDeposit);
            this.grpContract.Controls.Add(this.lblEndDate);
            this.grpContract.Controls.Add(this.lblStartDate);
            this.grpContract.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpContract.Location = new System.Drawing.Point(30, 80);
            this.grpContract.Name = "grpContract";
            this.grpContract.Size = new System.Drawing.Size(500, 200);
            this.grpContract.TabIndex = 3;
            this.grpContract.TabStop = false;
            this.grpContract.Text = "Thông tin Hợp đồng";
            // 
            // lblDeposit
            // 
            this.lblDeposit.AutoSize = true;
            this.lblDeposit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDeposit.Location = new System.Drawing.Point(20, 130);
            this.lblDeposit.Name = "lblDeposit";
            this.lblDeposit.Size = new System.Drawing.Size(100, 28);
            this.lblDeposit.TabIndex = 2;
            this.lblDeposit.Text = "Tiền cọc: ...";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEndDate.Location = new System.Drawing.Point(20, 85);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(142, 28);
            this.lblEndDate.TabIndex = 1;
            this.lblEndDate.Text = "Ngày kết thúc: ...";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStartDate.Location = new System.Drawing.Point(20, 40);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(139, 28);
            this.lblStartDate.TabIndex = 0;
            this.lblStartDate.Text = "Ngày bắt đầu: ...";
            // 
            // btnRequestTermination
            // 
            this.btnRequestTermination.BackColor = System.Drawing.Color.MistyRose;
            this.btnRequestTermination.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRequestTermination.Location = new System.Drawing.Point(30, 380);
            this.btnRequestTermination.Name = "btnRequestTermination";
            this.btnRequestTermination.Size = new System.Drawing.Size(500, 50);
            this.btnRequestTermination.TabIndex = 4;
            this.btnRequestTermination.Text = "Gửi yêu cầu Chấm dứt Hợp đồng";
            this.btnRequestTermination.UseVisualStyleBackColor = false;
            // 
            // btnRequestRenewal
            // 
            this.btnRequestRenewal.BackColor = System.Drawing.Color.AliceBlue;
            this.btnRequestRenewal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRequestRenewal.Location = new System.Drawing.Point(30, 310);
            this.btnRequestRenewal.Name = "btnRequestRenewal";
            this.btnRequestRenewal.Size = new System.Drawing.Size(500, 50);
            this.btnRequestRenewal.TabIndex = 5;
            this.btnRequestRenewal.Text = "Gửi yêu cầu Gia hạn Hợp đồng";
            this.btnRequestRenewal.UseVisualStyleBackColor = false;
            // 
            // ucMyContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnRequestRenewal);
            this.Controls.Add(this.btnRequestTermination);
            this.Controls.Add(this.grpContract);
            this.Controls.Add(this.label1);
            this.Name = "ucMyContract";
            this.Size = new System.Drawing.Size(1100, 800);
            this.grpContract.ResumeLayout(false);
            this.grpContract.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpContract;
        private System.Windows.Forms.Label lblDeposit;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Button btnRequestTermination;
        private System.Windows.Forms.Button btnRequestRenewal;
    }
}