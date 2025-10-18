namespace QuanLyPhongTro
{
    partial class FormCreateRoom
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
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
            lblTitle = new Label();
            lblRoomName = new Label();
            txtRoomName = new TextBox();
            lblArea = new Label();
            txtArea = new TextBox();
            lblPrice = new Label();
            txtPrice = new TextBox();
            lblStatus = new Label();
            cboStatus = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(234, 41);
            lblTitle.Margin = new Padding(6, 0, 6, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(453, 62);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "THÊM PHÒNG TRỌ";
            // 
            // lblRoomName
            // 
            lblRoomName.AutoSize = true;
            lblRoomName.Location = new Point(85, 164);
            lblRoomName.Margin = new Padding(6, 0, 6, 0);
            lblRoomName.Name = "lblRoomName";
            lblRoomName.Size = new Size(167, 41);
            lblRoomName.TabIndex = 1;
            lblRoomName.Text = "Tên phòng:";
            // 
            // txtRoomName
            // 
            txtRoomName.Location = new Point(340, 158);
            txtRoomName.Margin = new Padding(6, 6, 6, 6);
            txtRoomName.Name = "txtRoomName";
            txtRoomName.Size = new Size(463, 47);
            txtRoomName.TabIndex = 2;
            // 
            // lblArea
            // 
            lblArea.AutoSize = true;
            lblArea.Location = new Point(85, 246);
            lblArea.Margin = new Padding(6, 0, 6, 0);
            lblArea.Name = "lblArea";
            lblArea.Size = new Size(205, 41);
            lblArea.TabIndex = 3;
            lblArea.Text = "Diện tích (m²):";
            // 
            // txtArea
            // 
            txtArea.Location = new Point(340, 240);
            txtArea.Margin = new Padding(6, 6, 6, 6);
            txtArea.Name = "txtArea";
            txtArea.Size = new Size(463, 47);
            txtArea.TabIndex = 4;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(85, 328);
            lblPrice.Margin = new Padding(6, 0, 6, 0);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(224, 41);
            lblPrice.TabIndex = 5;
            lblPrice.Text = "Giá thuê (VNĐ):";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(340, 322);
            txtPrice.Margin = new Padding(6, 6, 6, 6);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(463, 47);
            txtPrice.TabIndex = 6;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(85, 410);
            lblStatus.Margin = new Padding(6, 0, 6, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(160, 41);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "Tình trạng:";
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.FormattingEnabled = true;
            cboStatus.Items.AddRange(new object[] { "Trống", "Đã thuê" });
            cboStatus.Location = new Point(340, 404);
            cboStatus.Margin = new Padding(6, 6, 6, 6);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(463, 49);
            cboStatus.TabIndex = 8;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.MediumSeaGreen;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(340, 512);
            btnSave.Margin = new Padding(6, 6, 6, 6);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(191, 72);
            btnSave.TabIndex = 9;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.IndianRed;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(616, 512);
            btnCancel.Margin = new Padding(6, 6, 6, 6);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(191, 72);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // FormCreateRoom
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(956, 656);
            Controls.Add(lblTitle);
            Controls.Add(lblRoomName);
            Controls.Add(txtRoomName);
            Controls.Add(lblArea);
            Controls.Add(txtArea);
            Controls.Add(lblPrice);
            Controls.Add(txtPrice);
            Controls.Add(lblStatus);
            Controls.Add(cboStatus);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Margin = new Padding(6, 6, 6, 6);
            Name = "FormCreateRoom";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thêm phòng trọ";
            Load += FormCreateRoom_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRoomName;
        private System.Windows.Forms.TextBox txtRoomName;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
