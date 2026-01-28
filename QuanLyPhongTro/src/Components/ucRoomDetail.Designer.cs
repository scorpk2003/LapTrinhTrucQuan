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
            tbnuoc = new TextBox();
            tbdien = new TextBox();
            tbNameuser = new TextBox();
            lbnuoc = new Label();
            lbldien = new Label();
            lbnameuser = new Label();
            avatar_img = new PictureBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)avatar_img).BeginInit();
            SuspendLayout();
            // 
            // room_name
            // 
            room_name.AutoSize = true;
            room_name.Font = new Font("Rockwell", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            room_name.Location = new Point(126, 32);
            room_name.Name = "room_name";
            room_name.Size = new Size(69, 23);
            room_name.TabIndex = 0;
            room_name.Text = "label1";
            // 
            // role_opp
            // 
            role_opp.AutoSize = true;
            role_opp.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            role_opp.Location = new Point(18, 72);
            role_opp.Name = "role_opp";
            role_opp.Size = new Size(57, 21);
            role_opp.TabIndex = 1;
            role_opp.Text = "Owner";
            // 
            // name_opp
            // 
            name_opp.AutoSize = true;
            name_opp.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            name_opp.Location = new Point(115, 72);
            name_opp.Name = "name_opp";
            name_opp.Size = new Size(53, 21);
            name_opp.TabIndex = 2;
            name_opp.Text = "label1";
            name_opp.Click += label1_Click;
            // 
            // bt_chinhsua
            // 
            bt_chinhsua.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bt_chinhsua.Location = new Point(151, 499);
            bt_chinhsua.Name = "bt_chinhsua";
            bt_chinhsua.Size = new Size(116, 48);
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
            groupBox1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = SystemColors.ControlDarkDark;
            groupBox1.Location = new Point(18, 119);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(419, 361);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Phòng trọ";
            // 
            // tbnuoc
            // 
            tbnuoc.Location = new Point(164, 142);
            tbnuoc.Margin = new Padding(3, 2, 3, 2);
            tbnuoc.Name = "tbnuoc";
            tbnuoc.Size = new Size(161, 27);
            tbnuoc.TabIndex = 2;
            // 
            // tbdien
            // 
            tbdien.Location = new Point(164, 93);
            tbdien.Margin = new Padding(3, 2, 3, 2);
            tbdien.Name = "tbdien";
            tbdien.Size = new Size(161, 27);
            tbdien.TabIndex = 2;
            // 
            // tbNameuser
            // 
            tbNameuser.Location = new Point(164, 47);
            tbNameuser.Margin = new Padding(3, 2, 3, 2);
            tbNameuser.Name = "tbNameuser";
            tbNameuser.Size = new Size(161, 27);
            tbNameuser.TabIndex = 2;
            // 
            // lbnuoc
            // 
            lbnuoc.AutoSize = true;
            lbnuoc.Location = new Point(18, 148);
            lbnuoc.Name = "lbnuoc";
            lbnuoc.Size = new Size(43, 20);
            lbnuoc.TabIndex = 1;
            lbnuoc.Text = "nước";
            // 
            // lbldien
            // 
            lbldien.AutoSize = true;
            lbldien.Location = new Point(18, 93);
            lbldien.Name = "lbldien";
            lbldien.Size = new Size(41, 20);
            lbldien.TabIndex = 1;
            lbldien.Text = "Điện";
            // 
            // lbnameuser
            // 
            lbnameuser.AutoSize = true;
            lbnameuser.Location = new Point(18, 47);
            lbnameuser.Name = "lbnameuser";
            lbnameuser.Size = new Size(112, 20);
            lbnameuser.TabIndex = 1;
            lbnameuser.Text = "Tên người thuê";
            // 
            // avatar_img
            // 
            avatar_img.Location = new Point(375, 32);
            avatar_img.Name = "avatar_img";
            avatar_img.Size = new Size(62, 61);
            avatar_img.TabIndex = 5;
            avatar_img.TabStop = false;
            // 
            // ucRoomDetail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            Controls.Add(avatar_img);
            Controls.Add(groupBox1);
            Controls.Add(bt_chinhsua);
            Controls.Add(name_opp);
            Controls.Add(role_opp);
            Controls.Add(room_name);
            Name = "ucRoomDetail";
            Size = new Size(450, 550);
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
        private TextBox tbnuoc;
        private TextBox tbdien;
        private TextBox tbNameuser;
        private Label lbnuoc;
        private Label lbldien;
        private Label lbnameuser;
    }
}
