namespace QuanLyPhongTro
{
    partial class FormEditRoom
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtRoomName = new System.Windows.Forms.TextBox();
            this.lblListRoom = new System.Windows.Forms.Label();
            this.cboListRoom = new System.Windows.Forms.ComboBox();
            this.btnEditListRoom = new System.Windows.Forms.Button();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.numArea = new System.Windows.Forms.NumericUpDown();
            this.lblImages = new System.Windows.Forms.Label();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.lstImages = new System.Windows.Forms.ListBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.btnDeleteImage = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblName.Location = new System.Drawing.Point(30, 30);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(129, 30);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Tên phòng:";
            // 
            // txtRoomName
            // 
            this.txtRoomName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtRoomName.Location = new System.Drawing.Point(180, 26);
            this.txtRoomName.Name = "txtRoomName";
            this.txtRoomName.Size = new System.Drawing.Size(660, 39);
            this.txtRoomName.TabIndex = 0;
            // 
            // lblListRoom
            // 
            this.lblListRoom.AutoSize = true;
            this.lblListRoom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblListRoom.Location = new System.Drawing.Point(30, 95);
            this.lblListRoom.Name = "lblListRoom";
            this.lblListRoom.Size = new System.Drawing.Size(84, 28);
            this.lblListRoom.TabIndex = 2;
            this.lblListRoom.Text = "Dãy trọ:";
            // 
            // cboListRoom
            // 
            this.cboListRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboListRoom.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboListRoom.FormattingEnabled = true;
            this.cboListRoom.Location = new System.Drawing.Point(180, 91);
            this.cboListRoom.Name = "cboListRoom";
            this.cboListRoom.Size = new System.Drawing.Size(540, 38);
            this.cboListRoom.TabIndex = 1;
            // 
            // btnEditListRoom
            // 
            this.btnEditListRoom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEditListRoom.Location = new System.Drawing.Point(730, 90);
            this.btnEditListRoom.Name = "btnEditListRoom";
            this.btnEditListRoom.Size = new System.Drawing.Size(110, 40);
            this.btnEditListRoom.TabIndex = 2;
            this.btnEditListRoom.Text = "Quản lý";
            this.btnEditListRoom.UseVisualStyleBackColor = true;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPrice.Location = new System.Drawing.Point(30, 160);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(91, 28);
            this.lblPrice.TabIndex = 4;
            this.lblPrice.Text = "Giá thuê:";
            // 
            // numPrice
            // 
            this.numPrice.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.numPrice.Location = new System.Drawing.Point(180, 156);
            this.numPrice.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(230, 37);
            this.numPrice.TabIndex = 3;
            this.numPrice.ThousandsSeparator = true;
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblArea.Location = new System.Drawing.Point(450, 160);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(130, 28);
            this.lblArea.TabIndex = 6;
            this.lblArea.Text = "Diện tích (m²):";
            // 
            // numArea
            // 
            this.numArea.DecimalPlaces = 1;
            this.numArea.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.numArea.Location = new System.Drawing.Point(610, 156);
            this.numArea.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numArea.Name = "numArea";
            this.numArea.Size = new System.Drawing.Size(230, 37);
            this.numArea.TabIndex = 4;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStatus.Location = new System.Drawing.Point(30, 225);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(102, 28);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Trạng thái:";
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] { "Trống", "Đã thuê", "Đang sửa chữa" });
            this.cboStatus.Location = new System.Drawing.Point(180, 221);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(660, 38);
            this.cboStatus.TabIndex = 5;
            // 
            // lblImages
            // 
            this.lblImages.AutoSize = true;
            this.lblImages.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblImages.Location = new System.Drawing.Point(30, 290);
            this.lblImages.Name = "lblImages";
            this.lblImages.Size = new System.Drawing.Size(185, 30);
            this.lblImages.TabIndex = 9;
            this.lblImages.Text = "Quản lý hình ảnh";
            // 
            // lstImages
            // 
            this.lstImages.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstImages.FormattingEnabled = true;
            this.lstImages.ItemHeight = 25;
            this.lstImages.Location = new System.Drawing.Point(35, 335);
            this.lstImages.Name = "lstImages";
            this.lstImages.Size = new System.Drawing.Size(375, 254);
            this.lstImages.TabIndex = 7;
            // 
            // btnAddImage
            // 
            this.btnAddImage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAddImage.Location = new System.Drawing.Point(35, 600);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(180, 45);
            this.btnAddImage.TabIndex = 6;
            this.btnAddImage.Text = "➕ Thêm ảnh";
            this.btnAddImage.UseVisualStyleBackColor = true;
            // 
            // btnDeleteImage
            // 
            this.btnDeleteImage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDeleteImage.ForeColor = System.Drawing.Color.DarkRed;
            this.btnDeleteImage.Location = new System.Drawing.Point(230, 600);
            this.btnDeleteImage.Name = "btnDeleteImage";
            this.btnDeleteImage.Size = new System.Drawing.Size(180, 45);
            this.btnDeleteImage.TabIndex = 15;
            this.btnDeleteImage.Text = "🗑️ Xóa ảnh chọn";
            this.btnDeleteImage.UseVisualStyleBackColor = true;
            // 
            // picPreview
            // 
            this.picPreview.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreview.Location = new System.Drawing.Point(440, 335);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(400, 310);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreview.TabIndex = 14;
            this.picPreview.TabStop = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(540, 652);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(150, 50);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Lưu thay đổi";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCancel.Location = new System.Drawing.Point(700, 652);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 50);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FormEditRoom
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(878, 714);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnDeleteImage);
            this.Controls.Add(this.picPreview);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lstImages);
            this.Controls.Add(this.btnAddImage);
            this.Controls.Add(this.lblImages);
            this.Controls.Add(this.numArea);
            this.Controls.Add(this.numPrice);
            this.Controls.Add(this.lblArea);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.btnEditListRoom);
            this.Controls.Add(this.cboListRoom);
            this.Controls.Add(this.lblListRoom);
            this.Controls.Add(this.txtRoomName);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chỉnh sửa thông tin phòng";
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtRoomName;
        private System.Windows.Forms.Label lblListRoom;
        private System.Windows.Forms.ComboBox cboListRoom;
        private System.Windows.Forms.Button btnEditListRoom;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.NumericUpDown numArea;
        private System.Windows.Forms.Label lblImages;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.ListBox lstImages;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Button btnDeleteImage;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cboStatus;
    }
}