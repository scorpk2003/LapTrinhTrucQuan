
using QuanLyPhongTro.Model;

namespace QuanLyPhongTro.src.Components
{
    partial class BillControl
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
            name_renter = new Label();
            dateTimePicker1 = new DateTimePicker();
            stat = new RadioButton();
            SuspendLayout();
            // 
            // name_room
            // 
            name_room.AutoSize = true;
            name_room.Font = new Font("Imprint MT Shadow", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            name_room.Location = new Point(40, 42);
            name_room.Name = "name_room";
            name_room.Size = new Size(62, 23);
            name_room.TabIndex = 0;
            name_room.Text = "label1";
            // 
            // name_renter
            // 
            name_renter.AutoSize = true;
            name_renter.Font = new Font("Nirmala UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            name_renter.Location = new Point(40, 99);
            name_renter.Name = "name_renter";
            name_renter.Size = new Size(52, 21);
            name_renter.TabIndex = 1;
            name_renter.Text = "label1";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Enabled = false;
            dateTimePicker1.Location = new Point(3, 155);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(194, 23);
            dateTimePicker1.TabIndex = 2;
            // 
            // stat
            // 
            stat.AutoSize = true;
            stat.Checked = true;
            stat.Enabled = false;
            stat.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            stat.Location = new Point(27, 202);
            stat.Name = "stat";
            stat.Size = new Size(140, 29);
            stat.TabIndex = 3;
            stat.TabStop = true;
            stat.Text = "radioButton1";
            stat.UseVisualStyleBackColor = true;
            stat.CheckedChanged += stat_CheckedChanged;
            // 
            // Bill
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(stat);
            Controls.Add(dateTimePicker1);
            Controls.Add(name_renter);
            Controls.Add(name_room);
            Name = "Bill";
            Size = new Size(200, 250);
            Load += Bill_Load;
            Click += Bill_Click;
            ResumeLayout(false);
            PerformLayout();
            _mediator.Register<Bill>(Name, GetBill);
        }

        private void Bill_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        #endregion

        private Label name_room;
        private Label name_renter;
        private DateTimePicker dateTimePicker1;
        private RadioButton stat;
    }
}
