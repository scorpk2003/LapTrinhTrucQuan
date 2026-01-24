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
            label1 = new Label();
            grpContract = new GroupBox();
            lblDeposit = new Label();
            lblEndDate = new Label();
            lblStartDate = new Label();
            btnRequestTermination = new Button();
            btnRequestRenewal = new Button();
            grpContractImage = new GroupBox();
            picContractImage = new PictureBox();
            lblNoImage = new Label();
            grpContract.SuspendLayout();
            grpContractImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picContractImage).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            label1.Location = new Point(38, 41);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(500, 76);
            label1.TabIndex = 0;
            label1.Text = "Hợp đồng của tôi";
            // 
            // grpContract
            // 
            grpContract.Controls.Add(lblDeposit);
            grpContract.Controls.Add(lblEndDate);
            grpContract.Controls.Add(lblStartDate);
            grpContract.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            grpContract.Location = new Point(57, 164);
            grpContract.Margin = new Padding(6, 6, 6, 6);
            grpContract.Name = "grpContract";
            grpContract.Padding = new Padding(6, 6, 6, 6);
            grpContract.Size = new Size(944, 410);
            grpContract.TabIndex = 3;
            grpContract.TabStop = false;
            grpContract.Text = "Thông tin Hợp đồng";
            // 
            // lblDeposit
            // 
            lblDeposit.AutoSize = true;
            lblDeposit.Font = new Font("Segoe UI", 13F);
            lblDeposit.Location = new Point(38, 266);
            lblDeposit.Margin = new Padding(6, 0, 6, 0);
            lblDeposit.Name = "lblDeposit";
            lblDeposit.Size = new Size(237, 60);
            lblDeposit.TabIndex = 2;
            lblDeposit.Text = "Tiền cọc: ...";
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Font = new Font("Segoe UI", 13F);
            lblEndDate.Location = new Point(38, 174);
            lblEndDate.Margin = new Padding(6, 0, 6, 0);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(348, 60);
            lblEndDate.TabIndex = 1;
            lblEndDate.Text = "Ngày kết thúc: ...";
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Font = new Font("Segoe UI", 13F);
            lblStartDate.Location = new Point(38, 82);
            lblStartDate.Margin = new Padding(6, 0, 6, 0);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(339, 60);
            lblStartDate.TabIndex = 0;
            lblStartDate.Text = "Ngày bắt đầu: ...";
            // 
            // btnRequestTermination
            // 
            btnRequestTermination.BackColor = Color.MistyRose;
            btnRequestTermination.Font = new Font("Segoe UI", 13F);
            btnRequestTermination.Location = new Point(57, 779);
            btnRequestTermination.Margin = new Padding(6, 6, 6, 6);
            btnRequestTermination.Name = "btnRequestTermination";
            btnRequestTermination.Size = new Size(944, 102);
            btnRequestTermination.TabIndex = 4;
            btnRequestTermination.Text = "Gửi yêu cầu chấm dứt hợp đồng";
            btnRequestTermination.UseVisualStyleBackColor = false;
            // 
            // btnRequestRenewal
            // 
            btnRequestRenewal.BackColor = Color.AliceBlue;
            btnRequestRenewal.Font = new Font("Segoe UI", 13F);
            btnRequestRenewal.Location = new Point(57, 636);
            btnRequestRenewal.Margin = new Padding(6, 6, 6, 6);
            btnRequestRenewal.Name = "btnRequestRenewal";
            btnRequestRenewal.Size = new Size(944, 102);
            btnRequestRenewal.TabIndex = 5;
            btnRequestRenewal.Text = "Gửi yêu cầu gia hạn hợp đồng";
            btnRequestRenewal.UseVisualStyleBackColor = false;
            // 
            // grpContractImage
            // 
            grpContractImage.Controls.Add(picContractImage);
            grpContractImage.Controls.Add(lblNoImage);
            grpContractImage.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            grpContractImage.Location = new Point(1077, 164);
            grpContractImage.Margin = new Padding(6, 6, 6, 6);
            grpContractImage.Name = "grpContractImage";
            grpContractImage.Padding = new Padding(6, 6, 6, 6);
            grpContractImage.Size = new Size(907, 1230);
            grpContractImage.TabIndex = 6;
            grpContractImage.TabStop = false;
            grpContractImage.Text = "Ảnh Hợp đồng";
            // 
            // picContractImage
            // 
            picContractImage.BorderStyle = BorderStyle.FixedSingle;
            picContractImage.Cursor = Cursors.Hand;
            picContractImage.Location = new Point(38, 82);
            picContractImage.Margin = new Padding(6, 6, 6, 6);
            picContractImage.Name = "picContractImage";
            picContractImage.Size = new Size(829, 1105);
            picContractImage.SizeMode = PictureBoxSizeMode.Zoom;
            picContractImage.TabIndex = 0;
            picContractImage.TabStop = false;
            // 
            // lblNoImage
            // 
            lblNoImage.AutoSize = true;
            lblNoImage.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblNoImage.ForeColor = Color.Gray;
            lblNoImage.Location = new Point(227, 574);
            lblNoImage.Margin = new Padding(6, 0, 6, 0);
            lblNoImage.Name = "lblNoImage";
            lblNoImage.Size = new Size(353, 46);
            lblNoImage.TabIndex = 1;
            lblNoImage.Text = "Chưa có ảnh hợp đồng";
            lblNoImage.TextAlign = ContentAlignment.MiddleCenter;
            lblNoImage.Visible = false;
            // 
            // ucMyContract
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.White;
            Controls.Add(grpContractImage);
            Controls.Add(btnRequestRenewal);
            Controls.Add(btnRequestTermination);
            Controls.Add(grpContract);
            Controls.Add(label1);
            Margin = new Padding(6, 6, 6, 6);
            Name = "ucMyContract";
            Size = new Size(2078, 1640);
            grpContract.ResumeLayout(false);
            grpContract.PerformLayout();
            grpContractImage.ResumeLayout(false);
            grpContractImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picContractImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpContract;
        private System.Windows.Forms.Label lblDeposit;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Button btnRequestTermination;
        private System.Windows.Forms.Button btnRequestRenewal;
        private System.Windows.Forms.GroupBox grpContractImage;
        private System.Windows.Forms.PictureBox picContractImage;
        private System.Windows.Forms.Label lblNoImage;
    }
}
