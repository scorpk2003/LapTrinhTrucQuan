
using QuanLyPhongTro.src.Models;

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
            name_room.Location = new Point(46, 56);
            name_room.Name = "name_room";
            name_room.Size = new Size(70, 28);
            name_room.TabIndex = 0;
            name_room.Text = "room";
            // 
            // name_opp
            // 
            name_opp.AutoSize = true;
            name_opp.Font = new Font("Nirmala UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            name_opp.Location = new Point(71, 136);
            name_opp.Name = "name_opp";
            name_opp.Size = new Size(180, 23);
            name_opp.TabIndex = 1;
            name_opp.Text = "Cao Hoang Gia Khang";
            // 
            // date_create
            // 
            date_create.Enabled = false;
            date_create.Location = new Point(22, 213);
            date_create.Margin = new Padding(3, 4, 3, 4);
            date_create.Name = "date_create";
            date_create.Size = new Size(206, 27);
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
            stat.Location = new Point(22, 276);
            stat.Margin = new Padding(3, 4, 3, 4);
            stat.Name = "stat";
            stat.Padding = new Padding(6, 7, 6, 7);
            stat.Size = new Size(206, 46);
            stat.TabIndex = 3;
            stat.TabStop = true;
            stat.Text = "Chưa Thanh Toán";
            stat.UseVisualStyleBackColor = false;
            // 
            // role_lb
            // 
            role_lb.AutoSize = true;
            role_lb.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            role_lb.Location = new Point(3, 132);
            role_lb.Name = "role_lb";
            role_lb.Size = new Size(45, 25);
            role_lb.TabIndex = 4;
            role_lb.Text = "role";
            // 
            // ucBill
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(217, 245, 240);
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(role_lb);
            Controls.Add(stat);
            Controls.Add(date_create);
            Controls.Add(name_opp);
            Controls.Add(name_room);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ucBill";
            Size = new Size(260, 348);
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
