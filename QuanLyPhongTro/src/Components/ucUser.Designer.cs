namespace QuanLyPhongTro.src.Components
{
    partial class ucUser
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbInfomation = new Label();
            ptb_avatar = new PictureBox();
            lb_tên = new Label();
            lbCCCD = new Label();
            lbGioitinh = new Label();
            lbPhone = new Label();
            lbgmail = new Label();
            ptFrontCCCD = new PictureBox();
            ptbAfterCCCD = new PictureBox();
            btEdit = new Button();
            tbName = new TextBox();
            tbCCCD = new TextBox();
            tbGender = new TextBox();
            tbPhone = new TextBox();
            tbEmail = new TextBox();
            ((System.ComponentModel.ISupportInitialize)ptb_avatar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ptFrontCCCD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ptbAfterCCCD).BeginInit();
            SuspendLayout();
            // 
            // lbInfomation
            // 
            lbInfomation.AutoSize = true;
            lbInfomation.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbInfomation.Location = new Point(128, 28);
            lbInfomation.Name = "lbInfomation";
            lbInfomation.Size = new Size(244, 31);
            lbInfomation.TabIndex = 0;
            lbInfomation.Text = "Thông tin người thuê";
            // 
            // ptb_avatar
            // 
            ptb_avatar.Location = new Point(16, 92);
            ptb_avatar.Name = "ptb_avatar";
            ptb_avatar.Size = new Size(155, 188);
            ptb_avatar.TabIndex = 1;
            ptb_avatar.TabStop = false;
            // 
            // lb_tên
            // 
            lb_tên.AutoSize = true;
            lb_tên.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lb_tên.Location = new Point(191, 92);
            lb_tên.Name = "lb_tên";
            lb_tên.Size = new Size(93, 25);
            lb_tên.TabIndex = 2;
            lb_tên.Text = "Họ và tên:";
            // 
            // lbCCCD
            // 
            lbCCCD.AutoSize = true;
            lbCCCD.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbCCCD.Location = new Point(191, 132);
            lbCCCD.Name = "lbCCCD";
            lbCCCD.Size = new Size(62, 25);
            lbCCCD.TabIndex = 2;
            lbCCCD.Text = "CCCD:";
            // 
            // lbGioitinh
            // 
            lbGioitinh.AutoSize = true;
            lbGioitinh.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbGioitinh.Location = new Point(191, 175);
            lbGioitinh.Name = "lbGioitinh";
            lbGioitinh.Size = new Size(82, 25);
            lbGioitinh.TabIndex = 2;
            lbGioitinh.Text = "Giới tính:";
            // 
            // lbPhone
            // 
            lbPhone.AutoSize = true;
            lbPhone.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbPhone.Location = new Point(191, 218);
            lbPhone.Name = "lbPhone";
            lbPhone.Size = new Size(121, 25);
            lbPhone.TabIndex = 2;
            lbPhone.Text = "Số điện thoại:";
            // 
            // lbgmail
            // 
            lbgmail.AutoSize = true;
            lbgmail.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbgmail.Location = new Point(191, 255);
            lbgmail.Name = "lbgmail";
            lbgmail.Size = new Size(58, 25);
            lbgmail.TabIndex = 2;
            lbgmail.Text = "Email:";
            // 
            // ptFrontCCCD
            // 
            ptFrontCCCD.Location = new Point(53, 302);
            ptFrontCCCD.Name = "ptFrontCCCD";
            ptFrontCCCD.Size = new Size(396, 168);
            ptFrontCCCD.TabIndex = 3;
            ptFrontCCCD.TabStop = false;
            // 
            // ptbAfterCCCD
            // 
            ptbAfterCCCD.Location = new Point(53, 501);
            ptbAfterCCCD.Name = "ptbAfterCCCD";
            ptbAfterCCCD.Size = new Size(396, 184);
            ptbAfterCCCD.TabIndex = 3;
            ptbAfterCCCD.TabStop = false;
            ptbAfterCCCD.Click += ptbAfterCCCD_Click;
            // 
            // btEdit
            // 
            btEdit.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btEdit.Location = new Point(334, 702);
            btEdit.Name = "btEdit";
            btEdit.Size = new Size(178, 38);
            btEdit.TabIndex = 4;
            btEdit.Text = "Chỉnh sửa";
            btEdit.UseVisualStyleBackColor = true;
//            btEdit.Click += btEdit_Click_1;
            // 
            // tbName
            // 
            tbName.Location = new Point(334, 92);
            tbName.Name = "tbName";
            tbName.Size = new Size(195, 27);
            tbName.TabIndex = 5;
            // 
            // tbCCCD
            // 
            tbCCCD.Location = new Point(334, 130);
            tbCCCD.Name = "tbCCCD";
            tbCCCD.Size = new Size(195, 27);
            tbCCCD.TabIndex = 5;
            // 
            // tbGender
            // 
            tbGender.Location = new Point(334, 176);
            tbGender.Name = "tbGender";
            tbGender.Size = new Size(195, 27);
            tbGender.TabIndex = 5;
            // 
            // tbPhone
            // 
            tbPhone.Location = new Point(334, 216);
            tbPhone.Name = "tbPhone";
            tbPhone.Size = new Size(195, 27);
            tbPhone.TabIndex = 5;
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(334, 256);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(195, 27);
            tbEmail.TabIndex = 5;
            // 
            // ucUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tbEmail);
            Controls.Add(tbPhone);
            Controls.Add(tbGender);
            Controls.Add(tbCCCD);
            Controls.Add(tbName);
            Controls.Add(btEdit);
            Controls.Add(ptbAfterCCCD);
            Controls.Add(ptFrontCCCD);
            Controls.Add(lbgmail);
            Controls.Add(lbPhone);
            Controls.Add(lbGioitinh);
            Controls.Add(lbCCCD);
            Controls.Add(lb_tên);
            Controls.Add(ptb_avatar);
            Controls.Add(lbInfomation);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ucUser";
            Size = new Size(544, 754);
            ((System.ComponentModel.ISupportInitialize)ptb_avatar).EndInit();
            ((System.ComponentModel.ISupportInitialize)ptFrontCCCD).EndInit();
            ((System.ComponentModel.ISupportInitialize)ptbAfterCCCD).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbInfomation;
        private PictureBox ptb_avatar;
        private Label lb_tên;
        private Label lbCCCD;
        private Label lbGioitinh;
        private Label lbPhone;
        private Label lbgmail;
        private PictureBox ptFrontCCCD;
        private PictureBox ptbAfterCCCD;
        private Button btEdit;
        private TextBox tbName;
        private TextBox tbCCCD;
        private TextBox tbGender;
        private TextBox tbPhone;
        private TextBox tbEmail;
    }
}
