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
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
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
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblName.Location = new System.Drawing.Point(30, 30);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(123, 28);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Tên phòng:";
            // 
            // txtRoomName
            // 
            this.txtRoomName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtRoomName.Location = new System.Drawing.Point(170, 27);
            this.txtRoomName.Name = "txtRoomName";
            this.txtRoomName.Size = new System.Drawing.Size(400, 34);
            this.txtRoomName.TabIndex = 0;
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAddress.Location = new System.Drawing.Point(170, 78);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(400, 70);
            this.txtAddress.TabIndex = 1;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAddress.Location = new System.Drawing.Point(30, 81);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(78, 28);
            this.lblAddress.TabIndex = 2;
            this.lblAddress.Text = "Ðịa chỉ:";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPrice.Location = new System.Drawing.Point(30, 168);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(95, 28);
            this.lblPrice.TabIndex = 4;
            this.lblPrice.Text = "Giá thuê:";
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblArea.Location = new System.Drawing.Point(30, 218);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(130, 28);
            this.lblArea.TabIndex = 6;
            this.lblArea.Text = "Diện tích (m²):";
            // 
            // numPrice
            // 
            this.numPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numPrice.Location = new System.Drawing.Point(170, 166);
            this.numPrice.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(400, 34);
            this.numPrice.TabIndex = 2;
            this.numPrice.ThousandsSeparator = true;
            // 
            // numArea
            // 
            this.numArea.DecimalPlaces = 1;
            this.numArea.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numArea.Location = new System.Drawing.Point(170, 216);
            this.numArea.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numArea.Name = "numArea";
            this.numArea.Size = new System.Drawing.Size(400, 34);
            this.numArea.TabIndex = 3;
            // 
            // lblImages
            // 
            this.lblImages.AutoSize = true;
            this.lblImages.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblImages.Location = new System.Drawing.Point(30, 320); // D?i xu?ng
            this.lblImages.Name = "lblImages";
            this.lblImages.Size = new System.Drawing.Size(95, 28);
            this.lblImages.TabIndex = 9;
            this.lblImages.Text = "Hình ảnh:";
            // 
            // btnAddImage
            // 
            this.btnAddImage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAddImage.Location = new System.Drawing.Point(170, 314); // D?i xu?ng
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(150, 40);
            this.btnAddImage.TabIndex = 4;
            this.btnAddImage.Text = "Thêm ảnh...";
            this.btnAddImage.UseVisualStyleBackColor = true;
            // 
            // lstImages
            // 
            this.lstImages.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstImages.FormattingEnabled = true;
            this.lstImages.ItemHeight = 25;
            this.lstImages.Location = new System.Drawing.Point(35, 370); // D?i xu?ng
            this.lstImages.Name = "lstImages";
            this.lstImages.Size = new System.Drawing.Size(285, 104);
            this.lstImages.TabIndex = 5;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.Location = new System.Drawing.Point(300, 500); // D?i xu?ng
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(130, 50);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCancel.Location = new System.Drawing.Point(440, 500); // D?i xu?ng
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 50);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
            this.openFileDialog.Multiselect = false; // Ch? cho ch?n 1 ?nh 1 l?n
            this.openFileDialog.Title = "Chọn hình ảnh";
            // 
            // picPreview
            // 
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreview.Location = new System.Drawing.Point(340, 314); // D?i xu?ng
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(230, 160);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreview.TabIndex = 14;
            this.picPreview.TabStop = false;
            // 
            // btnDeleteImage
            // 
            this.btnDeleteImage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteImage.Location = new System.Drawing.Point(245, 314); // D?i xu?ng
            this.btnDeleteImage.Name = "btnDeleteImage";
            this.btnDeleteImage.Size = new System.Drawing.Size(75, 40);
            this.btnDeleteImage.TabIndex = 15;
            this.btnDeleteImage.Text = "Xóa";
            this.btnDeleteImage.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStatus.Location = new System.Drawing.Point(30, 268);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(104, 28);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Trạng thái:";
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "Trống",
            "Ðã thuê",
            "Ðang sữa chữa"});
            this.cboStatus.Location = new System.Drawing.Point(170, 265);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(400, 36);
            this.cboStatus.TabIndex = 4;
            // 
            // FormEditRoom
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(603, 574); // Tang chi?u cao
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
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtRoomName);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chỉnh sửa phòng";
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtRoomName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
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
