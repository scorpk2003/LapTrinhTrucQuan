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
            back_btn = new Button();
            groupBox1 = new GroupBox();
            sign_btn = new Button();
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
            role_opp.Size = new Size(52, 21);
            role_opp.TabIndex = 1;
            role_opp.Text = "label1";
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
            // back_btn
            // 
            back_btn.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            back_btn.Location = new Point(160, 486);
            back_btn.Name = "back_btn";
            back_btn.Size = new Size(116, 48);
            back_btn.TabIndex = 3;
            back_btn.Text = "Go Back";
            back_btn.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.PaleGreen;
            groupBox1.Controls.Add(sign_btn);
            groupBox1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = SystemColors.ControlDarkDark;
            groupBox1.Location = new Point(18, 119);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(419, 361);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Phòng trọ";
            // 
            // sign_btn
            // 
            sign_btn.Location = new Point(163, 301);
            sign_btn.Name = "sign_btn";
            sign_btn.Size = new Size(75, 30);
            sign_btn.TabIndex = 0;
            sign_btn.Text = "Sign";
            sign_btn.UseVisualStyleBackColor = true;
            // 
            // avatar_img
            // 
            avatar_img.Location = new Point(375, 32);
            avatar_img.Name = "avatar_img";
            avatar_img.Size = new Size(62, 61);
            avatar_img.TabIndex = 5;
            avatar_img.TabStop = false;
            // 
            // RoomDetail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            Controls.Add(avatar_img);
            Controls.Add(groupBox1);
            Controls.Add(back_btn);
            Controls.Add(name_opp);
            Controls.Add(role_opp);
            Controls.Add(room_name);
            Name = "RoomDetail";
            Size = new Size(450, 550);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)avatar_img).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label room_name;
        private Label role_opp;
        private Label name_opp;
        private Button back_btn;
        private GroupBox groupBox1;
        private PictureBox avatar_img;
        private Button sign_btn;
    }
}
