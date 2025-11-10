namespace QuanLyPhongTro.src.Signup
{
    partial class CreateAccout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateAccout));
            imagelogin = new PictureBox();
            lblCreateaccout = new Label();
            tbUsername = new TextBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            btCreat = new Button();
            ((System.ComponentModel.ISupportInitialize)imagelogin).BeginInit();
            SuspendLayout();
            // 
            // imagelogin
            // 
            imagelogin.BackColor = Color.FromArgb(255, 224, 192);
            imagelogin.BorderStyle = BorderStyle.FixedSingle;
            imagelogin.Image = (Image)resources.GetObject("imagelogin.Image");
            imagelogin.Location = new Point(-5, 1);
            imagelogin.Name = "imagelogin";
            imagelogin.Size = new Size(359, 450);
            imagelogin.SizeMode = PictureBoxSizeMode.Zoom;
            imagelogin.TabIndex = 1;
            imagelogin.TabStop = false;
            // 
            // lblCreateaccout
            // 
            lblCreateaccout.AutoSize = true;
            lblCreateaccout.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCreateaccout.ForeColor = Color.Maroon;
            lblCreateaccout.Location = new Point(496, 41);
            lblCreateaccout.Name = "lblCreateaccout";
            lblCreateaccout.Size = new Size(177, 31);
            lblCreateaccout.TabIndex = 2;
            lblCreateaccout.Text = "Create Account";
            // 
            // tbUsername
            // 
            tbUsername.Location = new Point(470, 103);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(260, 27);
            tbUsername.TabIndex = 3;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(470, 169);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(260, 27);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(470, 234);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(260, 27);
            textBox2.TabIndex = 3;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(470, 304);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(260, 27);
            textBox3.TabIndex = 3;
            // 
            // btCreat
            // 
            btCreat.BackColor = Color.Lime;
            btCreat.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btCreat.ForeColor = Color.Black;
            btCreat.Location = new Point(545, 358);
            btCreat.Name = "btCreat";
            btCreat.Size = new Size(128, 68);
            btCreat.TabIndex = 4;
            btCreat.Text = "Create";
            btCreat.UseVisualStyleBackColor = false;
            // 
            // CreateAccout
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btCreat);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(tbUsername);
            Controls.Add(lblCreateaccout);
            Controls.Add(imagelogin);
            Name = "CreateAccout";
            Text = "Create Account";
            Load += CreateAccout_Load;
            ((System.ComponentModel.ISupportInitialize)imagelogin).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox imagelogin;
        private Label lblCreateaccout;
        private TextBox tbUsername;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button btCreat;
    }
}