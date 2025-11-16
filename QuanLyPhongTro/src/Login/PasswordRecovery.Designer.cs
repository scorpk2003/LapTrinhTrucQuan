namespace QuanLyPhongTro.src.Login
{
    partial class passwordrecovery
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
            tbEmail1 = new TextBox();
            lbforgotpass = new Label();
            lbghichu = new Label();
            lbnote = new Label();
            btConfirm = new Button();
            btBack = new Button();
            SuspendLayout();
            // 
            // tbEmail1
            // 
            tbEmail1.Location = new Point(90, 165);
            tbEmail1.Name = "tbEmail1";
            tbEmail1.Size = new Size(300, 27);
            tbEmail1.TabIndex = 0;
//            tbEmail1.TextChanged += tbEmail1_TextChanged;
            // 
            // lbforgotpass
            // 
            lbforgotpass.AutoSize = true;
            lbforgotpass.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbforgotpass.Location = new Point(228, 31);
            lbforgotpass.Name = "lbforgotpass";
            lbforgotpass.Size = new Size(387, 46);
            lbforgotpass.TabIndex = 2;
            lbforgotpass.Text = "Forgot your password?";
            // 
            // lbghichu
            // 
            lbghichu.AutoSize = true;
            lbghichu.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lbghichu.Location = new Point(90, 213);
            lbghichu.Name = "lbghichu";
            lbghichu.Size = new Size(541, 28);
            lbghichu.TabIndex = 3;
            lbghichu.Text = "Please enter the account that you want to reset the password";
            // 
            // lbnote
            // 
            lbnote.AutoSize = true;
            lbnote.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbnote.Location = new Point(90, 122);
            lbnote.Name = "lbnote";
            lbnote.Size = new Size(238, 28);
            lbnote.TabIndex = 4;
            lbnote.Text = "Phone Number or Email";
            // 
            // btConfirm
            // 
            btConfirm.BackColor = Color.FromArgb(255, 128, 0);
            btConfirm.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btConfirm.Location = new Point(581, 371);
            btConfirm.Name = "btConfirm";
            btConfirm.Size = new Size(130, 58);
            btConfirm.TabIndex = 5;
            btConfirm.Text = "Confirm";
            btConfirm.UseVisualStyleBackColor = false;
            btConfirm.Click += btConfirm_Click;
            // 
            // btBack
            // 
            btBack.BackColor = Color.FromArgb(255, 128, 0);
            btBack.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btBack.ForeColor = Color.Black;
            btBack.Location = new Point(114, 371);
            btBack.Name = "btBack";
            btBack.Size = new Size(130, 58);
            btBack.TabIndex = 5;
            btBack.Text = "Back";
            btBack.UseVisualStyleBackColor = false;
            // 
            // passwordrecovery
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            ClientSize = new Size(800, 450);
            Controls.Add(btConfirm);
            Controls.Add(btBack);
            Controls.Add(lbnote);
            Controls.Add(lbghichu);
            Controls.Add(lbforgotpass);
            Controls.Add(tbEmail1);
            Name = "passwordrecovery";
            Text = "Password Recovery";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbEmail1;
        private Label lbforgotpass;
        private Label lbghichu;
        private Label lbnote;
        private Button btConfirm;
        private Button btBack;
    }
}