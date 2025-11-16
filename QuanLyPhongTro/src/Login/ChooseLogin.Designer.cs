namespace QuanLyPhongTro.src.Login
{
    partial class ChooseLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseLogin));
            btnAdmin = new Button();
            btnUser = new Button();
            lblSignin = new Label();
            lblTitle = new Label();
            SuspendLayout();
            // 
            // btnAdmin
            // 
            btnAdmin.BackColor = Color.FromArgb(255, 128, 0);
            btnAdmin.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdmin.ForeColor = Color.Blue;
            btnAdmin.Image = (Image)resources.GetObject("btnAdmin.Image");
            btnAdmin.ImageAlign = ContentAlignment.TopCenter;
            btnAdmin.Location = new Point(456, 275);
            btnAdmin.Name = "btnAdmin";
            btnAdmin.Size = new Size(200, 93);
            btnAdmin.TabIndex = 8;
            btnAdmin.Text = "Admin";
            btnAdmin.TextAlign = ContentAlignment.BottomCenter;
            btnAdmin.UseVisualStyleBackColor = false;
            btnAdmin.Click += btnAdmin_Click;
            // 
            // btnUser
            // 
            btnUser.BackColor = Color.FromArgb(255, 128, 0);
            btnUser.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUser.ForeColor = Color.Blue;
            btnUser.Image = (Image)resources.GetObject("btnUser.Image");
            btnUser.ImageAlign = ContentAlignment.TopCenter;
            btnUser.Location = new Point(158, 275);
            btnUser.Name = "btnUser";
            btnUser.Size = new Size(200, 93);
            btnUser.TabIndex = 7;
            btnUser.Text = "User";
            btnUser.TextAlign = ContentAlignment.BottomCenter;
            btnUser.UseVisualStyleBackColor = false;
            btnUser.Click += btnUser_Click;
            // 
            // lblSignin
            // 
            lblSignin.AutoSize = true;
            lblSignin.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSignin.Location = new Point(327, 186);
            lblSignin.Name = "lblSignin";
            lblSignin.Size = new Size(151, 38);
            lblSignin.TabIndex = 6;
            lblSignin.Text = "Sign in as:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe Script", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(32, 83);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(736, 78);
            lblTitle.TabIndex = 5;
            lblTitle.Text = "Room management software";
            // 
            // ChooseLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 192, 192);
            BackgroundImage = Properties.Resources._1;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 490);
            Controls.Add(btnAdmin);
            Controls.Add(btnUser);
            Controls.Add(lblSignin);
            Controls.Add(lblTitle);
            Name = "ChooseLogin";
            Text = "ChooseLogin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdmin;
        private Button btnUser;
        private Label lblSignin;
        private Label lblTitle;
    }
}