namespace QuanLyPhongTro.src.Components
{
    partial class ucReport
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
            label1 = new Label();
            name_room = new Label();
            name_usr = new Label();
            des_rtxt = new RichTextBox();
            send_btn = new Button();
            lbReport = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 135);
            label1.Name = "label1";
            label1.Size = new Size(78, 25);
            label1.TabIndex = 0;
            label1.Text = "Gửi đến";
            // 
            // name_room
            // 
            name_room.AutoSize = true;
            name_room.Font = new Font("Rockwell", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            name_room.ForeColor = SystemColors.ActiveCaption;
            name_room.Location = new Point(129, 64);
            name_room.Name = "name_room";
            name_room.Size = new Size(82, 27);
            name_room.TabIndex = 1;
            name_room.Text = "label2";
            // 
            // name_usr
            // 
            name_usr.AutoSize = true;
            name_usr.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            name_usr.Location = new Point(102, 135);
            name_usr.Name = "name_usr";
            name_usr.Size = new Size(63, 25);
            name_usr.TabIndex = 2;
            name_usr.Text = "label2";
            // 
            // des_rtxt
            // 
            des_rtxt.Location = new Point(14, 165);
            des_rtxt.Margin = new Padding(3, 4, 3, 4);
            des_rtxt.Name = "des_rtxt";
            des_rtxt.Size = new Size(297, 183);
            des_rtxt.TabIndex = 3;
            des_rtxt.Text = "";
            // 
            // send_btn
            // 
            send_btn.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            send_btn.Location = new Point(120, 357);
            send_btn.Margin = new Padding(3, 4, 3, 4);
            send_btn.Name = "send_btn";
            send_btn.Size = new Size(91, 47);
            send_btn.TabIndex = 4;
            send_btn.Text = "Send";
            send_btn.UseVisualStyleBackColor = true;
            // 
            // lbReport
            // 
            lbReport.AutoSize = true;
            lbReport.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbReport.Location = new Point(120, 9);
            lbReport.Name = "lbReport";
            lbReport.Size = new Size(113, 41);
            lbReport.TabIndex = 5;
            lbReport.Text = "RePort";
            // 
            // ucReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbReport);
            Controls.Add(send_btn);
            Controls.Add(des_rtxt);
            Controls.Add(name_usr);
            Controls.Add(name_room);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ucReport";
            Size = new Size(325, 415);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label name_room;
        private Label name_usr;
        private RichTextBox des_rtxt;
        private Button send_btn;
        private Label lbReport;
    }
}