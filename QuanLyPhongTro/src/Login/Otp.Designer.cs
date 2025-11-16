namespace QuanLyPhongTro.src.Login
{
    partial class OTP
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
            lbNhapma = new Label();
            lbMaxacminh = new Label();
            mtOTP = new MaskedTextBox();
            lbnote = new Label();
            linklbguilaima = new LinkLabel();
            SuspendLayout();
            // 
            // lbNhapma
            // 
            lbNhapma.AutoSize = true;
            lbNhapma.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbNhapma.Location = new Point(246, 37);
            lbNhapma.Name = "lbNhapma";
            lbNhapma.Size = new Size(315, 46);
            lbNhapma.TabIndex = 0;
            lbNhapma.Text = "Nhập mã xác nhận";
            // 
            // lbMaxacminh
            // 
            lbMaxacminh.AutoSize = true;
            lbMaxacminh.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbMaxacminh.Location = new Point(246, 115);
            lbMaxacminh.Name = "lbMaxacminh";
            lbMaxacminh.Size = new Size(323, 28);
            lbMaxacminh.TabIndex = 1;
            lbMaxacminh.Text = "Mã xác minh đã được gửi đến Email";
            // 
            // mtOTP
            // 
            mtOTP.BackColor = SystemColors.Menu;
            mtOTP.BorderStyle = BorderStyle.None;
            mtOTP.Font = new Font("Segoe UI", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mtOTP.Location = new Point(313, 177);
            mtOTP.Mask = "0 0 0 0 0 0";
            mtOTP.Name = "mtOTP";
            mtOTP.Size = new Size(192, 63);
            mtOTP.TabIndex = 2;
            // 
            // lbnote
            // 
            lbnote.AutoSize = true;
            lbnote.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbnote.Location = new Point(246, 307);
            lbnote.Name = "lbnote";
            lbnote.Size = new Size(230, 28);
            lbnote.TabIndex = 3;
            lbnote.Text = "Bạn chưa nhận được mã?";
            // 
            // linklbguilaima
            // 
            linklbguilaima.AutoSize = true;
            linklbguilaima.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linklbguilaima.LinkColor = Color.Red;
            linklbguilaima.Location = new Point(473, 310);
            linklbguilaima.Name = "linklbguilaima";
            linklbguilaima.Size = new Size(61, 25);
            linklbguilaima.TabIndex = 4;
            linklbguilaima.TabStop = true;
            linklbguilaima.Text = "Gửi lại";
            linklbguilaima.UseMnemonic = false;
            linklbguilaima.LinkClicked += linklbguilaima_LinkClicked;
            // 
            // OTP
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(linklbguilaima);
            Controls.Add(lbnote);
            Controls.Add(mtOTP);
            Controls.Add(lbMaxacminh);
            Controls.Add(lbNhapma);
            Name = "OTP";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbNhapma;
        private Label lbMaxacminh;
        private MaskedTextBox mtOTP;
        private Label lbnote;
        private LinkLabel linklbguilaima;
    }
}