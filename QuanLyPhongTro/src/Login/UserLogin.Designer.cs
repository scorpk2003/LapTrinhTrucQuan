namespace QuanLyPhongTro.src.Login
{
    partial class UserLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserLogin));
            imagelogin = new PictureBox();
            TbUsernameuser = new TextBox();
            lbluserlogin = new Label();
            lblUsername = new Label();
            tbPassworduser = new TextBox();
            lblPassworduser = new Label();
            btLoginuser = new Button();
            LbForgetpass = new LinkLabel();
            btCreateaccount = new Button();
            ((System.ComponentModel.ISupportInitialize)imagelogin).BeginInit();
            SuspendLayout();
            // 
            // imagelogin
            // 
            imagelogin.BackColor = Color.FromArgb(255, 224, 192);
            imagelogin.BorderStyle = BorderStyle.FixedSingle;
            imagelogin.Image = (Image)resources.GetObject("imagelogin.Image");
            imagelogin.Location = new Point(-5, 0);
            imagelogin.Name = "imagelogin";
            imagelogin.Size = new Size(359, 450);
            imagelogin.SizeMode = PictureBoxSizeMode.Zoom;
            imagelogin.TabIndex = 0;
            imagelogin.TabStop = false;
            // 
            // TbUsernameuser
            // 
            TbUsernameuser.Location = new Point(502, 133);
            TbUsernameuser.Name = "TbUsernameuser";
            TbUsernameuser.Size = new Size(251, 27);
            TbUsernameuser.TabIndex = 1;
            // 
            // lbluserlogin
            // 
            lbluserlogin.AutoSize = true;
            lbluserlogin.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbluserlogin.Location = new Point(534, 48);
            lbluserlogin.Name = "lbluserlogin";
            lbluserlogin.Size = new Size(129, 31);
            lbluserlogin.TabIndex = 2;
            lbluserlogin.Text = "User Login";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsername.Location = new Point(384, 133);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(103, 28);
            lblUsername.TabIndex = 3;
            lblUsername.Text = "Username:";
            // 
            // tbPassworduser
            // 
            tbPassworduser.Location = new Point(502, 189);
            tbPassworduser.Name = "tbPassworduser";
            tbPassworduser.Size = new Size(251, 27);
            tbPassworduser.TabIndex = 1;
            // 
            // lblPassworduser
            // 
            lblPassworduser.AutoSize = true;
            lblPassworduser.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPassworduser.Location = new Point(390, 189);
            lblPassworduser.Name = "lblPassworduser";
            lblPassworduser.Size = new Size(97, 28);
            lblPassworduser.TabIndex = 3;
            lblPassworduser.Text = "Password:";
            // 
            // btLoginuser
            // 
            btLoginuser.BackColor = Color.FromArgb(0, 192, 192);
            btLoginuser.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btLoginuser.Location = new Point(502, 249);
            btLoginuser.Name = "btLoginuser";
            btLoginuser.Size = new Size(114, 52);
            btLoginuser.TabIndex = 4;
            btLoginuser.Text = "Login";
            btLoginuser.UseVisualStyleBackColor = false;
            // 
            // LbForgetpass
            // 
            LbForgetpass.AutoSize = true;
            LbForgetpass.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LbForgetpass.LinkColor = Color.Gray;
            LbForgetpass.Location = new Point(635, 266);
            LbForgetpass.Name = "LbForgetpass";
            LbForgetpass.Size = new Size(143, 23);
            LbForgetpass.TabIndex = 5;
            LbForgetpass.TabStop = true;
            LbForgetpass.Text = "Forgot Password?";
            // 
            // btCreateaccount
            // 
            btCreateaccount.BackColor = Color.Lime;
            btCreateaccount.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btCreateaccount.Location = new Point(462, 329);
            btCreateaccount.Name = "btCreateaccount";
            btCreateaccount.Size = new Size(278, 66);
            btCreateaccount.TabIndex = 9;
            btCreateaccount.Text = "Tạo tài khoản mới";
            btCreateaccount.UseVisualStyleBackColor = false;
            btCreateaccount.Click += btCreateaccount_Click;
            // 
            // UserLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btCreateaccount);
            Controls.Add(LbForgetpass);
            Controls.Add(btLoginuser);
            Controls.Add(lblPassworduser);
            Controls.Add(lblUsername);
            Controls.Add(lbluserlogin);
            Controls.Add(tbPassworduser);
            Controls.Add(TbUsernameuser);
            Controls.Add(imagelogin);
            Name = "UserLogin";
            Text = "UserLogin";
            ((System.ComponentModel.ISupportInitialize)imagelogin).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox imagelogin;
        private TextBox TbUsernameuser;
        private Label lbluserlogin;
        private Label lblUsername;
        private TextBox tbPassworduser;
        private Label lblPassworduser;
        private Button btLoginuser;
        private LinkLabel LbForgetpass;
        private Button btCreateaccount;
    }
}