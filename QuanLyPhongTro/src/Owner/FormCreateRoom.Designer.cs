namespace QuanLyPhongTro
{
    partial class FormCreateRoom
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
            this.btnNewListRoom = new System.Windows.Forms.Button();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.numArea = new System.Windows.Forms.NumericUpDown();
            this.lblImages = new System.Windows.Forms.Label();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.lstImages = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.btnDeleteImage = new System.Windows.Forms.Button();
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
            // lblListRoom
            // 
            this.lblListRoom.AutoSize = true;
            this.lblListRoom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblListRoom.Location = new System.Drawing.Point(30, 81);
            this.lblListRoom.Name = "lblListRoom";
            this.lblListRoom.Size = new System.Drawing.Size(95, 28);
            this.lblListRoom.TabIndex = 2;
            this.lblListRoom.Text = "Dãy trọ:";
            // 
            // cboListRoom
            // 
            this.cboListRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboListRoom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboListRoom.FormattingEnabled = true;
            this.cboListRoom.Location = new System.Drawing.Point(170, 78);
            this.cboListRoom.Name = "cboListRoom";
            this.cboListRoom.Size = new System.Drawing.Size(300, 36);
            this.cboListRoom.TabIndex = 1;
            // 
            // btnNewListRoom
            // 
            this.btnNewListRoom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNewListRoom.Location = new System.Drawing.Point(480, 78);
            this.btnNewListRoom.Name = "btnNewListRoom";
            this.btnNewListRoom.Size = new System.Drawing.Size(90, 36);
            this.btnNewListRoom.TabIndex = 2;
            this.btnNewListRoom.Text = "Tạo mới";
            this.btnNewListRoom.UseVisualStyleBackColor = true;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPrice.Location = new System.Drawing.Point(30, 138);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(95, 28);
            this.lblPrice.TabIndex = 4;
            this.lblPrice.Text = "Giá thuê:";
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblArea.Location = new System.Drawing.Point(30, 188);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(130, 28);
            this.lblArea.TabIndex = 6;
            this.lblArea.Text = "Diện tích (m²):";
            // 
            // numPrice
            // 
            this.numPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numPrice.Location = new System.Drawing.Point(170, 136);
            this.numPrice.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(400, 34);
            this.numPrice.TabIndex = 3;
            this.numPrice.ThousandsSeparator = true;
            // 
            // numArea
            // 
            this.numArea.DecimalPlaces = 1;
            this.numArea.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numArea.Location = new System.Drawing.Point(170, 186);
            this.numArea.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numArea.Minimum = new decimal(new int[] { 1, 0, 0, 0 }); // ✅ Thêm giá trị tối thiểu
            this.numArea.Name = "numArea";
            this.numArea.Size = new System.Drawing.Size(400, 34);
            this.numArea.TabIndex = 4;
            this.numArea.Value = new decimal(new int[] { 20, 0, 0, 0 }); // ✅ Giá trị mặc định 20m²
            // 
            // lblImages
            // 
            this.lblImages.AutoSize = true;
            this.lblImages.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblImages.Location = new System.Drawing.Point(30, 240);
            this.lblImages.Name = "lblImages";
            this.lblImages.Size = new System.Drawing.Size(95, 28);
            this.lblImages.TabIndex = 9;
            this.lblImages.Text = "Hình ảnh:";
            // 
            // btnAddImage
            // 
            this.btnAddImage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAddImage.Location = new System.Drawing.Point(170, 234);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(150, 40);
            this.btnAddImage.TabIndex = 5;
            this.btnAddImage.Text = "Thêm ảnh...";
            this.btnAddImage.UseVisualStyleBackColor = true;
            // 
            // lstImages
            // 
            this.lstImages.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstImages.FormattingEnabled = true;
            this.lstImages.ItemHeight = 25;
            this.lstImages.Location = new System.Drawing.Point(35, 290);
            this.lstImages.Name = "lstImages";
            this.lstImages.Size = new System.Drawing.Size(285, 104);
            this.lstImages.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(300, 420);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 50);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCancel.Location = new System.Drawing.Point(440, 420);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 50);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.Title = "Chọn hình ảnh";
            // 
            // picPreview
            // 
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreview.Location = new System.Drawing.Point(340, 234);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(230, 160);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreview.TabIndex = 14;
            this.picPreview.TabStop = false;
            // 
            // btnDeleteImage
            // 
            this.btnDeleteImage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteImage.Location = new System.Drawing.Point(245, 234);
            this.btnDeleteImage.Name = "btnDeleteImage";
            this.btnDeleteImage.Size = new System.Drawing.Size(75, 40);
            this.btnDeleteImage.TabIndex = 15;
            this.btnDeleteImage.Text = "Xóa";
            this.btnDeleteImage.UseVisualStyleBackColor = true;
            // 
            // FormCreateRoom
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(603, 494);
            this.Controls.Add(this.btnDeleteImage);
            this.Controls.Add(this.picPreview);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lstImages);
            this.Controls.Add(this.btnAddImage);
            this.Controls.Add(this.lblImages);
            this.Controls.Add(this.numArea);
            this.Controls.Add(this.numPrice);
            this.Controls.Add(this.lblArea);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.btnNewListRoom);
            this.Controls.Add(this.cboListRoom);
            this.Controls.Add(this.lblListRoom);
            this.Controls.Add(this.txtRoomName);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCreateRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tạo phòng mới";
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
        private System.Windows.Forms.Button btnNewListRoom;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.NumericUpDown numArea;
        private System.Windows.Forms.Label lblImages;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.ListBox lstImages;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Button btnDeleteImage;
    }
}
