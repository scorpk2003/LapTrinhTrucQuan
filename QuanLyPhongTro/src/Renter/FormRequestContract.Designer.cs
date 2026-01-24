namespace QuanLyPhongTro
{
    partial class FormRequestContract
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            lblRoomName = new Label();
            label3 = new Label();
            lblRenterName = new Label();
            label5 = new Label();
            dtpStartDate = new DateTimePicker();
            label6 = new Label();
            label7 = new Label();
            txtNote = new TextBox();
            btnSend = new Button();
            btnCancel = new Button();
            numDuration = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numDuration).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(57, 62);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(239, 54);
            label1.TabIndex = 0;
            label1.Text = "Phòng thuê:";
            // 
            // lblRoomName
            // 
            lblRoomName.AutoSize = true;
            lblRoomName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblRoomName.Location = new Point(416, 62);
            lblRoomName.Margin = new Padding(6, 0, 6, 0);
            lblRoomName.Name = "lblRoomName";
            lblRoomName.Size = new Size(251, 54);
            lblRoomName.TabIndex = 1;
            lblRoomName.Text = "(Tên phòng)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(57, 164);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(211, 54);
            label3.TabIndex = 2;
            label3.Text = "Nguời gủi:";
            // 
            // lblRenterName
            // 
            lblRenterName.AutoSize = true;
            lblRenterName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblRenterName.Location = new Point(416, 164);
            lblRenterName.Margin = new Padding(6, 0, 6, 0);
            lblRenterName.Name = "lblRenterName";
            lblRenterName.Size = new Size(335, 54);
            lblRenterName.TabIndex = 3;
            lblRenterName.Text = "(Tên nguời thuê)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(57, 266);
            label5.Margin = new Padding(6, 0, 6, 0);
            label5.Name = "label5";
            label5.Size = new Size(386, 54);
            label5.TabIndex = 4;
            label5.Text = "Ngày muốn bắt đầu:";
            // 
            // dtpStartDate
            // 
            dtpStartDate.Font = new Font("Segoe UI", 12F);
            dtpStartDate.Location = new Point(441, 266);
            dtpStartDate.Margin = new Padding(6, 6, 6, 6);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(658, 61);
            dtpStartDate.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(57, 369);
            label6.Margin = new Padding(6, 0, 6, 0);
            label6.Name = "label6";
            label6.Size = new Size(326, 54);
            label6.TabIndex = 6;
            label6.Text = "Thời hạn (tháng):";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(57, 472);
            label7.Margin = new Padding(6, 0, 6, 0);
            label7.Name = "label7";
            label7.Size = new Size(167, 54);
            label7.TabIndex = 8;
            label7.Text = "Ghi chú:";
            // 
            // txtNote
            // 
            txtNote.Font = new Font("Segoe UI", 13F);
            txtNote.Location = new Point(66, 533);
            txtNote.Margin = new Padding(6, 6, 6, 6);
            txtNote.Multiline = true;
            txtNote.Name = "txtNote";
            txtNote.Size = new Size(1016, 242);
            txtNote.TabIndex = 2;
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.FromArgb(41, 128, 185);
            btnSend.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(822, 820);
            btnSend.Margin = new Padding(6, 6, 6, 6);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(264, 102);
            btnSend.TabIndex = 3;
            btnSend.Text = "Gửi";
            btnSend.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 13F);
            btnCancel.Location = new Point(529, 820);
            btnCancel.Margin = new Padding(6, 6, 6, 6);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(264, 102);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // numDuration
            // 
            numDuration.Font = new Font("Segoe UI", 12F);
            numDuration.Location = new Point(400, 362);
            numDuration.Margin = new Padding(11, 12, 11, 12);
            numDuration.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            numDuration.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDuration.Name = "numDuration";
            numDuration.Size = new Size(429, 61);
            numDuration.TabIndex = 1;
            numDuration.Value = new decimal(new int[] { 12, 0, 0, 0 });
            // 
            // FormRequestContract
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1148, 972);
            Controls.Add(numDuration);
            Controls.Add(btnCancel);
            Controls.Add(btnSend);
            Controls.Add(txtNote);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(dtpStartDate);
            Controls.Add(label5);
            Controls.Add(lblRenterName);
            Controls.Add(label3);
            Controls.Add(lblRoomName);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(6, 6, 6, 6);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormRequestContract";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gửi yêu cầu thuê phòng";
            ((System.ComponentModel.ISupportInitialize)numDuration).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRoomName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRenterName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown numDuration;
    }
}
