
using QuanLyPhongTro.Model;

namespace QuanLyPhongTro.src.Components
{
    partial class ucBill
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
            name_room = new Label();
            name_opp = new Label();
            date_create = new DateTimePicker();
            stat = new RadioButton();
            role_lb = new Label();
            SuspendLayout();
            // 
            // name_room
            // 
            name_room.AutoSize = true;
            name_room.Font = new Font("Imprint MT Shadow", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            name_room.Location = new Point(40, 42);
            name_room.Name = "name_room";
            name_room.Size = new Size(58, 23);
            name_room.TabIndex = 0;
            name_room.Text = "room";
            // 
            // name_opp
            // 
            name_opp.AutoSize = true;
            name_opp.Font = new Font("Nirmala UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            name_opp.Location = new Point(62, 102);
            name_opp.Name = "name_opp";
            name_opp.Size = new Size(138, 17);
            name_opp.TabIndex = 1;
            name_opp.Text = "Cao Hoang Gia Khang";
            // 
            // date_create
            // 
            date_create.Enabled = false;
            date_create.Location = new Point(19, 160);
            date_create.Name = "date_create";
            date_create.Size = new Size(181, 23);
            date_create.TabIndex = 2;
            // 
            // stat
            // 
            stat.AutoSize = true;
            stat.BackColor = Color.FromArgb(234, 64, 77);
            stat.Checked = true;
            stat.Enabled = false;
            stat.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            stat.ForeColor = SystemColors.ControlLightLight;
            stat.Location = new Point(19, 207);
            stat.Name = "stat";
            stat.Padding = new Padding(5);
            stat.Size = new Size(165, 35);
            stat.TabIndex = 3;
            stat.TabStop = true;
            stat.Text = "Chưa Thanh Toán";
            stat.UseVisualStyleBackColor = false;
            // 
            // role_lb
            // 
            role_lb.AutoSize = true;
            role_lb.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            role_lb.Location = new Point(3, 99);
            role_lb.Name = "role_lb";
            role_lb.Size = new Size(36, 20);
            role_lb.TabIndex = 4;
            role_lb.Text = "role";
            // 
            // ucBill
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(217, 245, 240);
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(role_lb);
            Controls.Add(stat);
            Controls.Add(date_create);
            Controls.Add(name_opp);
            Controls.Add(name_room);
            Name = "ucBill";
            Size = new Size(224, 261);
            Load += Bill_Load;
            Click += Bill_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        private void Bill_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        #endregion

        private Label name_room;
        private Label name_opp;
        private DateTimePicker date_create;
        private RadioButton stat;
        private Label role_lb;
    }
}
