namespace QuanLyPhongTro
{
    partial class FormUploadContractImage
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblContractInfo = new Label();
            picPreview = new PictureBox();
            btnChooseImage = new Button();
            btnUpload = new Button();
            btnCancel = new Button();
            lblFileName = new Label();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)picPreview).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lblContractInfo
            // 
            lblContractInfo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblContractInfo.Location = new Point(42, 41);
            lblContractInfo.Margin = new Padding(6, 0, 6, 0);
            lblContractInfo.Name = "lblContractInfo";
            lblContractInfo.Size = new Size(1190, 164);
            lblContractInfo.TabIndex = 0;
            lblContractInfo.Text = "Thông tin hợp đồng...";
            // 
            // picPreview
            // 
            picPreview.BorderStyle = BorderStyle.FixedSingle;
            picPreview.Location = new Point(42, 62);
            picPreview.Margin = new Padding(6, 6, 6, 6);
            picPreview.Name = "picPreview";
            picPreview.Size = new Size(1103, 613);
            picPreview.SizeMode = PictureBoxSizeMode.Zoom;
            picPreview.TabIndex = 1;
            picPreview.TabStop = false;
            // 
            // btnChooseImage
            // 
            btnChooseImage.BackColor = Color.DodgerBlue;
            btnChooseImage.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnChooseImage.ForeColor = Color.White;
            btnChooseImage.Location = new Point(42, 697);
            btnChooseImage.Margin = new Padding(6, 6, 6, 6);
            btnChooseImage.Name = "btnChooseImage";
            btnChooseImage.Size = new Size(319, 92);
            btnChooseImage.TabIndex = 2;
            btnChooseImage.Text = "Chọn ảnh";
            btnChooseImage.UseVisualStyleBackColor = false;
            // 
            // btnUpload
            // 
            btnUpload.BackColor = Color.Green;
            btnUpload.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnUpload.ForeColor = Color.White;
            btnUpload.Location = new Point(680, 1107);
            btnUpload.Margin = new Padding(6, 6, 6, 6);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(255, 92);
            btnUpload.TabIndex = 3;
            btnUpload.Text = "Đăng tải";
            btnUpload.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Gray;
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(978, 1107);
            btnCancel.Margin = new Padding(6, 6, 6, 6);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(255, 92);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // lblFileName
            // 
            lblFileName.AutoSize = true;
            lblFileName.Font = new Font("Segoe UI", 12F);
            lblFileName.ForeColor = Color.DarkGreen;
            lblFileName.Location = new Point(382, 722);
            lblFileName.Margin = new Padding(6, 0, 6, 0);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new Size(278, 54);
            lblFileName.TabIndex = 5;
            lblFileName.Text = "Chưa chọn file";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(picPreview);
            groupBox1.Controls.Add(btnChooseImage);
            groupBox1.Controls.Add(lblFileName);
            groupBox1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            groupBox1.Location = new Point(42, 226);
            groupBox1.Margin = new Padding(6, 6, 6, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(6, 6, 6, 6);
            groupBox1.Size = new Size(1190, 840);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ảnh hợp đồng";
            // 
            // FormUploadContractImage
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1275, 1230);
            Controls.Add(groupBox1);
            Controls.Add(btnCancel);
            Controls.Add(btnUpload);
            Controls.Add(lblContractInfo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(6, 6, 6, 6);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormUploadContractImage";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Đăng tải ảnh hợp đồng";
            ((System.ComponentModel.ISupportInitialize)picPreview).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblContractInfo;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Button btnChooseImage;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
