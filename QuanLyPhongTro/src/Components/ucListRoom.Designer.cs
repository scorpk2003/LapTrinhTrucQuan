using QuanLyPhongTro.src.Components;

namespace QuanLyPhongTro.src
{
    partial class ucListRoom
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
            name_lr = new Label();
            name_owr = new Label();
            name_add = new Label();
            stat = new RadioButton();
            SuspendLayout();
            // 
            // name_lr
            // 
            name_lr.AutoSize = true;
            name_lr.Font = new Font("Imprint MT Shadow", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            name_lr.Location = new Point(15, 33);
            name_lr.Name = "name_lr";
            name_lr.Size = new Size(147, 23);
            name_lr.TabIndex = 0;
            name_lr.Text = "name list room";
            // 
            // name_owr
            // 
            name_owr.AutoSize = true;
            name_owr.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            name_owr.Location = new Point(26, 90);
            name_owr.Name = "name_owr";
            name_owr.Size = new Size(52, 20);
            name_owr.TabIndex = 1;
            name_owr.Text = "Owner";
            // 
            // name_add
            // 
            name_add.AutoSize = true;
            name_add.Font = new Font("Segoe UI", 11.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            name_add.Location = new Point(30, 150);
            name_add.MaximumSize = new Size(150, 0);
            name_add.Name = "name_add";
            name_add.Size = new Size(48, 20);
            name_add.TabIndex = 2;
            name_add.Text = "label1";
            // 
            // stat
            // 
            stat.AutoCheck = false;
            stat.AutoSize = true;
            stat.Checked = true;
            stat.Enabled = false;
            stat.Font = new Font("Yu Gothic Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            stat.Location = new Point(26, 202);
            stat.Name = "stat";
            stat.Size = new Size(136, 25);
            stat.TabIndex = 3;
            stat.TabStop = true;
            stat.Text = "radioButton1";
            stat.UseVisualStyleBackColor = true;
            // 
            // ucListRoom
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(217, 245, 240);
            Controls.Add(stat);
            Controls.Add(name_add);
            Controls.Add(name_owr);
            Controls.Add(name_lr);
            Name = "ucListRoom";
            Size = new Size(200, 250);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label name_lr;
        private Label name_owr;
        private Label name_add;
        private RadioButton stat;
    }
}
