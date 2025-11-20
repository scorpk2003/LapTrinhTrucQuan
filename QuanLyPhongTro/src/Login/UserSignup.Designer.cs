namespace QuanLyPhongTro.src.Login
{
    partial class UserSignup
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblSignup = new Label();
            tbEmailv = new TextBox();
            tbPass = new TextBox();
            tbPass1 = new TextBox();
            btsignup = new Button();
            checkshowpass = new CheckBox();
            llblogin = new LinkLabel();
            tbHovaten = new TextBox();
            lbHovaten = new Label();
            lbEmail = new Label();
            tbSđt = new TextBox();
            lbPhone = new Label();
            lbpassword = new Label();
            label1 = new Label();
            lbGioitinh = new Label();
            cbbGioitinh = new ComboBox();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            cbbRole = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblSignup
            // 
            lblSignup.AutoSize = true;
            lblSignup.BackColor = Color.RoyalBlue;
            lblSignup.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSignup.Location = new Point(878, 27);
            lblSignup.Name = "lblSignup";
            lblSignup.Size = new Size(146, 46);
            lblSignup.TabIndex = 1;
            lblSignup.Text = "Sign Up";
            lblSignup.Click += lblSignup_Click;
            // 
            // tbEmailv
            // 
            tbEmailv.Location = new Point(823, 193);
            tbEmailv.Name = "tbEmailv";
            tbEmailv.Size = new Size(279, 27);
            tbEmailv.TabIndex = 2;
            tbEmailv.TextChanged += tbEmailv_TextChanged;
            // 
            // tbPass
            // 
            tbPass.Location = new Point(823, 265);
            tbPass.Name = "tbPass";
            tbPass.Size = new Size(279, 27);
            tbPass.TabIndex = 4;
            tbPass.TextChanged += tbPass_TextChanged;
            // 
            // tbPass1
            // 
            tbPass1.Location = new Point(823, 327);
            tbPass1.Name = "tbPass1";
            tbPass1.Size = new Size(276, 27);
            tbPass1.TabIndex = 5;
            tbPass1.TextChanged += tbPass1_TextChanged;
            // 
            // btsignup
            // 
            btsignup.BackColor = Color.Lime;
            btsignup.Location = new Point(878, 579);
            btsignup.Name = "btsignup";
            btsignup.Size = new Size(183, 66);
            btsignup.TabIndex = 0;
            btsignup.Text = "Đăng kí";
            btsignup.UseVisualStyleBackColor = false;
            btsignup.Click += btsignup_Click;
            // 
            // checkshowpass
            // 
            checkshowpass.AutoSize = true;
            checkshowpass.BackColor = Color.White;
            checkshowpass.Location = new Point(823, 526);
            checkshowpass.Name = "checkshowpass";
            checkshowpass.Size = new Size(127, 24);
            checkshowpass.TabIndex = 6;
            checkshowpass.Text = "Hiện mật khẩu";
            checkshowpass.UseVisualStyleBackColor = false;
            checkshowpass.CheckedChanged += checkshowpass_CheckedChanged;
            // 
            // llblogin
            // 
            llblogin.AutoSize = true;
            llblogin.LinkColor = Color.Black;
            llblogin.Location = new Point(861, 661);
            llblogin.Name = "llblogin";
            llblogin.Size = new Size(224, 20);
            llblogin.TabIndex = 12;
            llblogin.TabStop = true;
            llblogin.Text = "Bạn đã có tài khoản? Đăng nhập";
            llblogin.LinkClicked += llblogin_LinkClicked;
            // 
            // tbHovaten
            // 
            tbHovaten.Location = new Point(823, 121);
            tbHovaten.Name = "tbHovaten";
            tbHovaten.Size = new Size(279, 27);
            tbHovaten.TabIndex = 13;
            tbHovaten.TextChanged += tbHovaten_TextChanged;
            // 
            // lbHovaten
            // 
            lbHovaten.AutoSize = true;
            lbHovaten.BackColor = SystemColors.ActiveBorder;
            lbHovaten.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbHovaten.Location = new Point(623, 121);
            lbHovaten.Name = "lbHovaten";
            lbHovaten.Size = new Size(101, 28);
            lbHovaten.TabIndex = 14;
            lbHovaten.Text = "Họ và Tên:";
            // 
            // lbEmail
            // 
            lbEmail.AutoSize = true;
            lbEmail.BackColor = SystemColors.ActiveBorder;
            lbEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbEmail.Location = new Point(623, 193);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(63, 28);
            lbEmail.TabIndex = 14;
            lbEmail.Text = "Email:";
            // 
            // tbSđt
            // 
            tbSđt.Location = new Point(823, 397);
            tbSđt.Name = "tbSđt";
            tbSđt.Size = new Size(279, 27);
            tbSđt.TabIndex = 15;
            tbSđt.TextChanged += tbSđt_TextChanged;
            // 
            // lbPhone
            // 
            lbPhone.AutoSize = true;
            lbPhone.BackColor = SystemColors.ActiveBorder;
            lbPhone.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbPhone.Location = new Point(623, 397);
            lbPhone.Name = "lbPhone";
            lbPhone.Size = new Size(132, 28);
            lbPhone.TabIndex = 14;
            lbPhone.Text = "Số điện thoại:";
            // 
            // lbpassword
            // 
            lbpassword.AutoSize = true;
            lbpassword.BackColor = SystemColors.ActiveBorder;
            lbpassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbpassword.Location = new Point(623, 265);
            lbpassword.Name = "lbpassword";
            lbpassword.Size = new Size(98, 28);
            lbpassword.TabIndex = 14;
            lbpassword.Text = "Mật khẩu:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveBorder;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(623, 327);
            label1.Name = "label1";
            label1.Size = new Size(175, 28);
            label1.TabIndex = 14;
            label1.Text = "Nhập lại mật khẩu:";
            // 
            // lbGioitinh
            // 
            lbGioitinh.AutoSize = true;
            lbGioitinh.BackColor = SystemColors.ActiveBorder;
            lbGioitinh.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbGioitinh.Location = new Point(623, 470);
            lbGioitinh.Name = "lbGioitinh";
            lbGioitinh.Size = new Size(91, 28);
            lbGioitinh.TabIndex = 14;
            lbGioitinh.Text = "Giới tính:";
            // 
            // cbbGioitinh
            // 
            cbbGioitinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbGioitinh.FormattingEnabled = true;
            cbbGioitinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            cbbGioitinh.Location = new Point(750, 470);
            cbbGioitinh.Name = "cbbGioitinh";
            cbbGioitinh.Size = new Size(119, 28);
            cbbGioitinh.TabIndex = 16;
            cbbGioitinh.SelectedIndexChanged += cbbGioitinh_SelectedIndexChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources._70e732608aac06f25fbd;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(579, 681);
            pictureBox1.TabIndex = 17;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ActiveBorder;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(906, 470);
            label2.Name = "label2";
            label2.Size = new Size(74, 28);
            label2.TabIndex = 14;
            label2.Text = "Vai Trò:";
            // 
            // cbbRole
            // 
            cbbRole.FormattingEnabled = true;
            cbbRole.Items.AddRange(new object[] { "User", "Admin" });
            cbbRole.Location = new Point(1023, 470);
            cbbRole.Name = "cbbRole";
            cbbRole.Size = new Size(115, 28);
            cbbRole.TabIndex = 18;
            cbbRole.SelectedIndexChanged += cbbRole_SelectedIndexChanged;
            // 
            // UserSignup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1175, 705);
            Controls.Add(cbbRole);
            Controls.Add(pictureBox1);
            Controls.Add(cbbGioitinh);
            Controls.Add(tbSđt);
            Controls.Add(label2);
            Controls.Add(lbGioitinh);
            Controls.Add(lbPhone);
            Controls.Add(label1);
            Controls.Add(lbpassword);
            Controls.Add(lbEmail);
            Controls.Add(lbHovaten);
            Controls.Add(tbHovaten);
            Controls.Add(llblogin);
            Controls.Add(checkshowpass);
            Controls.Add(btsignup);
            Controls.Add(tbPass1);
            Controls.Add(tbPass);
            Controls.Add(tbEmailv);
            Controls.Add(lblSignup);
            Name = "UserSignup";
            Text = "Signup";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblSignup;
        private TextBox tbEmailv;
        private TextBox tbPass;
        private TextBox tbPass1;
        private Button btsignup;
        private CheckBox checkshowpass;
        private LinkLabel llblogin;
        private TextBox tbHovaten;
        private Label lbHovaten;
        private Label lbEmail;
        private TextBox tbSđt;
        private Label lbPhone;
        private Label lbpassword;
        private Label label1;
        private Label lbGioitinh;
        private ComboBox cbbGioitinh;
        private PictureBox pictureBox1;
        private Label label2;
        private ComboBox cbbRole;
    }
}