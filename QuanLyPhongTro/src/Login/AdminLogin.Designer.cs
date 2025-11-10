namespace QuanLyPhongTro.src.Login
{
    partial class AdminLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminLogin));
            imagelogin = new PictureBox();
            TbUsernameuser = new TextBox();
            textBox1 = new TextBox();
            lblUsername = new Label();
            lblPassword = new Label();
            lblAdminlogin = new Label();
            btLoginadmin = new Button();
            LbForgetpass = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)imagelogin).BeginInit();
            SuspendLayout();
            // 
            // imagelogin
            // 
            imagelogin.BackColor = Color.FromArgb(255, 224, 192);
            imagelogin.BorderStyle = BorderStyle.FixedSingle;
            imagelogin.Image = (Image)resources.GetObject("imagelogin.Image");
            imagelogin.Location = new Point(-10, 0);
            imagelogin.Name = "imagelogin";
            imagelogin.Size = new Size(359, 450);
            imagelogin.SizeMode = PictureBoxSizeMode.Zoom;
            imagelogin.TabIndex = 1;
            imagelogin.TabStop = false;
            // 
            // TbUsernameuser
            // 
            TbUsernameuser.Location = new Point(497, 127);
            TbUsernameuser.Name = "TbUsernameuser";
            TbUsernameuser.Size = new Size(251, 27);
            TbUsernameuser.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(497, 194);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(251, 27);
            textBox1.TabIndex = 2;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsername.Location = new Point(373, 127);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(103, 28);
            lblUsername.TabIndex = 4;
            lblUsername.Text = "Username:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(379, 193);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(97, 28);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Password:";
            // 
            // lblAdminlogin
            // 
            lblAdminlogin.AutoSize = true;
            lblAdminlogin.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAdminlogin.Location = new Point(532, 62);
            lblAdminlogin.Name = "lblAdminlogin";
            lblAdminlogin.Size = new Size(153, 31);
            lblAdminlogin.TabIndex = 5;
            lblAdminlogin.Text = "Admin Login";
            // 
            // btLoginadmin
            // 
            btLoginadmin.BackColor = Color.FromArgb(0, 192, 192);
            btLoginadmin.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btLoginadmin.Location = new Point(497, 265);
            btLoginadmin.Name = "btLoginadmin";
            btLoginadmin.Size = new Size(114, 52);
            btLoginadmin.TabIndex = 6;
            btLoginadmin.Text = "Login";
            btLoginadmin.UseVisualStyleBackColor = false;
            // 
            // LbForgetpass
            // 
            LbForgetpass.AutoSize = true;
            LbForgetpass.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LbForgetpass.LinkColor = Color.Gray;
            LbForgetpass.Location = new Point(621, 277);
            LbForgetpass.Name = "LbForgetpass";
            LbForgetpass.Size = new Size(143, 23);
            LbForgetpass.TabIndex = 7;
            LbForgetpass.TabStop = true;
            LbForgetpass.Text = "Forgot Password?";
            // 
            // AdminLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(LbForgetpass);
            Controls.Add(btLoginadmin);
            Controls.Add(lblAdminlogin);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(textBox1);
            Controls.Add(TbUsernameuser);
            Controls.Add(imagelogin);
            Name = "AdminLogin";
            Text = "Login Admin";
            ((System.ComponentModel.ISupportInitialize)imagelogin).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox imagelogin;
        private TextBox TbUsernameuser;
        private TextBox textBox1;
        private Label lblUsername;
        private Label lblPassword;
        private Label lblAdminlogin;
        private Button btLoginadmin;
        private LinkLabel LbForgetpass;
    }
}