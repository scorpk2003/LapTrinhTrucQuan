namespace QuanLyPhongTro.src.Components
{
    partial class ucRoomDetail
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
            room_name = new Label();
            role_opp = new Label();
            name_opp = new Label();
            bt_chinhsua = new Button();
            groupBox1 = new GroupBox();
            sign_btn = new Button();
            avatar_img = new PictureBox();
            lbnameuser = new Label();
            lbldien = new Label();
            lbnuoc = new Label();
            tbNameuser = new TextBox();
            tbdien = new TextBox();
            tbnuoc = new TextBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)avatar_img).BeginInit();
            SuspendLayout();
            // 
            // room_name
            // 
            room_name.AutoSize = true;
            room_name.Font = new Font("Rockwell", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            room_name.Location = new Point(144, 43);
            room_name.Name = "room_name";
            room_name.Size = new Size(91, 31);
            room_name.TabIndex = 0;
            room_name.Text = "label1";
            // 
            // role_opp
            // 
            role_opp.AutoSize = true;
            role_opp.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            role_opp.Location = new Point(21, 96);
            role_opp.Name = "role_opp";
            role_opp.Size = new Size(69, 28);
            role_opp.TabIndex = 1;
            role_opp.Text = "Owner";
            // 
            // name_opp
            // 
            name_opp.AutoSize = true;
            name_opp.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            name_opp.Location = new Point(131, 96);
            name_opp.Name = "name_opp";
            name_opp.Size = new Size(65, 28);
            name_opp.TabIndex = 2;
            name_opp.Text = "label1";
            name_opp.Click += label1_Click;
            // 
            // bt_chinhsua
            // 
            bt_chinhsua.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bt_chinhsua.Location = new Point(173, 665);
            bt_chinhsua.Margin = new Padding(3, 4, 3, 4);
            bt_chinhsua.Name = "bt_chinhsua";
            bt_chinhsua.Size = new Size(133, 64);
            bt_chinhsua.TabIndex = 3;
            bt_chinhsua.Text = "Chỉnh sửa";
            bt_chinhsua.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.PaleGreen;
            groupBox1.Controls.Add(tbnuoc);
            groupBox1.Controls.Add(tbdien);
            groupBox1.Controls.Add(tbNameuser);
            groupBox1.Controls.Add(lbnuoc);
            groupBox1.Controls.Add(lbldien);
            groupBox1.Controls.Add(lbnameuser);
            groupBox1.Controls.Add(sign_btn);
            groupBox1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = SystemColors.ControlDarkDark;
            groupBox1.Location = new Point(21, 159);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(479, 481);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Phòng trọ";
            // 
            // sign_btn
            // 
            sign_btn.Location = new Point(387, 20);
            sign_btn.Margin = new Padding(3, 4, 3, 4);
            sign_btn.Name = "sign_btn";
            sign_btn.Size = new Size(86, 40);
            sign_btn.TabIndex = 0;
            sign_btn.Text = "Sign";
            sign_btn.UseVisualStyleBackColor = true;
            // 
            // avatar_img
            // 
            avatar_img.Location = new Point(429, 43);
            avatar_img.Margin = new Padding(3, 4, 3, 4);
            avatar_img.Name = "avatar_img";
            avatar_img.Size = new Size(71, 81);
            avatar_img.TabIndex = 5;
            avatar_img.TabStop = false;
            // 
            // lbnameuser
            // 
            lbnameuser.AutoSize = true;
            lbnameuser.Location = new Point(20, 63);
            lbnameuser.Name = "lbnameuser";
            lbnameuser.Size = new Size(141, 25);
            lbnameuser.TabIndex = 1;
            lbnameuser.Text = "Tên người thuê";
            // 
            // lbldien
            // 
            lbldien.AutoSize = true;
            lbldien.Location = new Point(20, 124);
            lbldien.Name = "lbldien";
            lbldien.Size = new Size(52, 25);
            lbldien.TabIndex = 1;
            lbldien.Text = "Điện";
            // 
            // lbnuoc
            // 
            lbnuoc.AutoSize = true;
            lbnuoc.Location = new Point(20, 197);
            lbnuoc.Name = "lbnuoc";
            lbnuoc.Size = new Size(56, 25);
            lbnuoc.TabIndex = 1;
            lbnuoc.Text = "nước";
            // 
            // tbNameuser
            // 
            tbNameuser.Location = new Point(187, 63);
            tbNameuser.Name = "tbNameuser";
            tbNameuser.Size = new Size(183, 32);
            tbNameuser.TabIndex = 2;
            // 
            // tbdien
            // 
            tbdien.Location = new Point(187, 124);
            tbdien.Name = "tbdien";
            tbdien.Size = new Size(183, 32);
            tbdien.TabIndex = 2;
            // 
            // tbnuoc
            // 
            tbnuoc.Location = new Point(187, 190);
            tbnuoc.Name = "tbnuoc";
            tbnuoc.Size = new Size(183, 32);
            tbnuoc.TabIndex = 2;
            // 
            // ucRoomDetail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            Controls.Add(avatar_img);
            Controls.Add(groupBox1);
            Controls.Add(bt_chinhsua);
            Controls.Add(name_opp);
            Controls.Add(role_opp);
            Controls.Add(room_name);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ucRoomDetail";
            Size = new Size(514, 733);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)avatar_img).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label room_name;
        private Label role_opp;
        private Label name_opp;
        private Button bt_chinhsua;
        private GroupBox groupBox1;
        private PictureBox avatar_img;
        private Button sign_btn;
        private TextBox tbnuoc;
        private TextBox tbdien;
        private TextBox tbNameuser;
        private Label lbnuoc;
        private Label lbldien;
        private Label lbnameuser;
    }
}
