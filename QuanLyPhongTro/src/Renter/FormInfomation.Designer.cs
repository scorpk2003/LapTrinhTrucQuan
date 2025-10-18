namespace QuanLyPhongTro
{
    partial class FormInformation
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblCCCD;
        private System.Windows.Forms.Label lblSoDienThoai;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtCCCD;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnGoBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblHoTen = new Label();
            lblCCCD = new Label();
            lblSoDienThoai = new Label();
            lblEmail = new Label();
            lblDiaChi = new Label();
            txtHoTen = new TextBox();
            txtCCCD = new TextBox();
            txtSoDienThoai = new TextBox();
            txtEmail = new TextBox();
            txtDiaChi = new TextBox();
            btnUpdate = new Button();
            btnGoBack = new Button();
            SuspendLayout();
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Font = new Font("Segoe UI", 9.900001F);
            lblHoTen.Location = new Point(85, 87);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(171, 46);
            lblHoTen.TabIndex = 0;
            lblHoTen.Text = "Họ và tên:";
            // 
            // lblCCCD
            // 
            lblCCCD.AutoSize = true;
            lblCCCD.Font = new Font("Segoe UI", 9.900001F);
            lblCCCD.Location = new Point(150, 165);
            lblCCCD.Name = "lblCCCD";
            lblCCCD.Size = new Size(112, 46);
            lblCCCD.TabIndex = 2;
            lblCCCD.Text = "CCCD:";
            // 
            // lblSoDienThoai
            // 
            lblSoDienThoai.AutoSize = true;
            lblSoDienThoai.Font = new Font("Segoe UI", 9.900001F);
            lblSoDienThoai.Location = new Point(46, 239);
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.Size = new Size(224, 46);
            lblSoDienThoai.TabIndex = 4;
            lblSoDienThoai.Text = "Số điện thoại:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9.900001F);
            lblEmail.Location = new Point(150, 306);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(106, 46);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Email:";
            // 
            // lblDiaChi
            // 
            lblDiaChi.AutoSize = true;
            lblDiaChi.Font = new Font("Segoe UI", 9.900001F);
            lblDiaChi.Location = new Point(142, 372);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(128, 46);
            lblDiaChi.TabIndex = 8;
            lblDiaChi.Text = "Địa chỉ:";
            // 
            // txtHoTen
            // 
            txtHoTen.Font = new Font("Segoe UI", 9.900001F);
            txtHoTen.Location = new Point(334, 82);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(358, 51);
            txtHoTen.TabIndex = 1;
            // 
            // txtCCCD
            // 
            txtCCCD.Font = new Font("Segoe UI", 9.900001F);
            txtCCCD.Location = new Point(334, 162);
            txtCCCD.Name = "txtCCCD";
            txtCCCD.Size = new Size(358, 51);
            txtCCCD.TabIndex = 3;
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Font = new Font("Segoe UI", 9.900001F);
            txtSoDienThoai.Location = new Point(334, 234);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(358, 51);
            txtSoDienThoai.TabIndex = 5;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 9.900001F);
            txtEmail.Location = new Point(334, 303);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(358, 51);
            txtEmail.TabIndex = 7;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Font = new Font("Segoe UI", 9.900001F);
            txtDiaChi.Location = new Point(334, 372);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(358, 51);
            txtDiaChi.TabIndex = 9;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.MediumSeaGreen;
            btnUpdate.Font = new Font("Segoe UI", 9.900001F);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(150, 451);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(148, 71);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnGoBack
            // 
            btnGoBack.BackColor = Color.IndianRed;
            btnGoBack.Font = new Font("Segoe UI", 9.900001F);
            btnGoBack.ForeColor = Color.White;
            btnGoBack.Location = new Point(389, 451);
            btnGoBack.Name = "btnGoBack";
            btnGoBack.Size = new Size(161, 71);
            btnGoBack.TabIndex = 11;
            btnGoBack.Text = "Go Back";
            btnGoBack.UseVisualStyleBackColor = false;
            btnGoBack.Click += btnGoBack_Click;
            // 
            // FormInformation
            // 
            ClientSize = new Size(780, 568);
            Controls.Add(lblHoTen);
            Controls.Add(txtHoTen);
            Controls.Add(lblCCCD);
            Controls.Add(txtCCCD);
            Controls.Add(lblSoDienThoai);
            Controls.Add(txtSoDienThoai);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblDiaChi);
            Controls.Add(txtDiaChi);
            Controls.Add(btnUpdate);
            Controls.Add(btnGoBack);
            Name = "FormInformation";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thông tin người thuê";
            Load += FormInformation_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
