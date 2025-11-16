namespace QuanLyPhongTro.src.Login
{
    partial class Loginmain
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
            TbUsernameuser = new TextBox();
            lbluserlogin = new Label();
            lblUsername = new Label();
            tbPassworduser = new TextBox();
            lblPassworduser = new Label();
            btLoginuser = new Button();
            LbForgetpass = new LinkLabel();
            btCreateaccount = new Button();
            cbRememberpass = new CheckBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // TbUsernameuser
            // 
            TbUsernameuser.Location = new Point(592, 133);
            TbUsernameuser.Name = "TbUsernameuser";
            TbUsernameuser.Size = new Size(251, 27);
            TbUsernameuser.TabIndex = 2;
            TbUsernameuser.TextChanged += TbUsernameuser_TextChanged;
            // 
            // lbluserlogin
            // 
            lbluserlogin.AutoSize = true;
            lbluserlogin.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lbluserlogin.Location = new Point(654, 49);
            lbluserlogin.Name = "lbluserlogin";
            lbluserlogin.Size = new Size(129, 31);
            lbluserlogin.TabIndex = 0;
            lbluserlogin.Text = "User Login";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 12F);
            lblUsername.Location = new Point(475, 132);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(63, 28);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Email:";
            // 
            // tbPassworduser
            // 
            tbPassworduser.Location = new Point(592, 190);
            tbPassworduser.Name = "tbPassworduser";
            tbPassworduser.Size = new Size(251, 27);
            tbPassworduser.TabIndex = 4;
            tbPassworduser.TextChanged += tbPassworduser_TextChanged;
            // 
            // lblPassworduser
            // 
            lblPassworduser.AutoSize = true;
            lblPassworduser.Font = new Font("Segoe UI", 12F);
            lblPassworduser.Location = new Point(475, 186);
            lblPassworduser.Name = "lblPassworduser";
            lblPassworduser.Size = new Size(97, 28);
            lblPassworduser.TabIndex = 3;
            lblPassworduser.Text = "Password:";
            // 
            // btLoginuser
            // 
            btLoginuser.BackColor = Color.FromArgb(0, 192, 192);
            btLoginuser.Font = new Font("Segoe UI", 12F);
            btLoginuser.Location = new Point(592, 284);
            btLoginuser.Name = "btLoginuser";
            btLoginuser.Size = new Size(114, 52);
            btLoginuser.TabIndex = 5;
            btLoginuser.Text = "Login";
            btLoginuser.UseVisualStyleBackColor = false;
            btLoginuser.Click += btLoginuser_Click;
            // 
            // LbForgetpass
            // 
            LbForgetpass.AutoSize = true;
            LbForgetpass.Font = new Font("Segoe UI", 10.2F);
            LbForgetpass.LinkColor = Color.Gray;
            LbForgetpass.Location = new Point(736, 301);
            LbForgetpass.Name = "LbForgetpass";
            LbForgetpass.Size = new Size(143, 23);
            LbForgetpass.TabIndex = 7;
            LbForgetpass.TabStop = true;
            LbForgetpass.Text = "Forgot Password?";
            LbForgetpass.LinkClicked += LbForgetpass_LinkClicked;
            // 
            // btCreateaccount
            // 
            btCreateaccount.BackColor = Color.Lime;
            btCreateaccount.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btCreateaccount.Location = new Point(592, 371);
            btCreateaccount.Name = "btCreateaccount";
            btCreateaccount.Size = new Size(278, 66);
            btCreateaccount.TabIndex = 6;
            btCreateaccount.Text = "Tạo tài khoản mới";
            btCreateaccount.UseVisualStyleBackColor = false;
            btCreateaccount.Click += btCreateaccount_Click;
            // 
            // cbRememberpass
            // 
            cbRememberpass.AutoSize = true;
            cbRememberpass.Location = new Point(592, 239);
            cbRememberpass.Name = "cbRememberpass";
            cbRememberpass.Size = new Size(124, 24);
            cbRememberpass.TabIndex = 11;
            cbRememberpass.Text = "Nhớ mật khẩu";
            cbRememberpass.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources._70e732608aac06f25fbd;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(6, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(463, 509);
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // Loginmain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(912, 515);
            Controls.Add(pictureBox1);
            Controls.Add(cbRememberpass);
            Controls.Add(btCreateaccount);
            Controls.Add(LbForgetpass);
            Controls.Add(btLoginuser);
            Controls.Add(lblPassworduser);
            Controls.Add(lblUsername);
            Controls.Add(lbluserlogin);
            Controls.Add(tbPassworduser);
            Controls.Add(TbUsernameuser);
            Name = "Loginmain";
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox TbUsernameuser;
        private Label lbluserlogin;
        private Label lblUsername;
        private TextBox tbPassworduser;
        private Label lblPassworduser;
        private Button btLoginuser;
        private LinkLabel LbForgetpass;
        private Button btCreateaccount;
        private CheckBox cbRememberpass;
        private PictureBox pictureBox1;
    }
}