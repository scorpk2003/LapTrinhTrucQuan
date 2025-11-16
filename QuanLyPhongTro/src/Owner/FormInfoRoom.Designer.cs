namespace QuanLyPhongTro
{
    partial class FormInfoRoom
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
            this.lblRoomName = new System.Windows.Forms.Label();
            this.grpContractInfo = new System.Windows.Forms.GroupBox();
            this.lblRenterName = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpRoomInfo = new System.Windows.Forms.GroupBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.grpImages = new System.Windows.Forms.GroupBox();
            this.lblImageCounter = new System.Windows.Forms.Label();
            this.btnNextImage = new System.Windows.Forms.Button();
            this.btnPrevImage = new System.Windows.Forms.Button();
            this.picRoomPreview = new System.Windows.Forms.PictureBox();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnBook = new System.Windows.Forms.Button();
            this.grpContractInfo.SuspendLayout();
            this.grpRoomInfo.SuspendLayout();
            this.grpImages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRoomPreview)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRoomName
            // 
            this.lblRoomName.AutoSize = true;
            this.lblRoomName.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblRoomName.Location = new System.Drawing.Point(15, 10);
            this.lblRoomName.Name = "lblRoomName";
            this.lblRoomName.Size = new System.Drawing.Size(199, 45);
            this.lblRoomName.TabIndex = 1;
            this.lblRoomName.Text = "Tên Phòng...";
            // 
            // grpContractInfo
            // 
            this.grpContractInfo.Controls.Add(this.lblRenterName);
            this.grpContractInfo.Controls.Add(this.lblEndDate);
            this.grpContractInfo.Controls.Add(this.lblStartDate);
            this.grpContractInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpContractInfo.Location = new System.Drawing.Point(450, 90);
            this.grpContractInfo.Name = "grpContractInfo";
            this.grpContractInfo.Size = new System.Drawing.Size(400, 200);
            this.grpContractInfo.TabIndex = 5;
            this.grpContractInfo.TabStop = false;
            this.grpContractInfo.Text = "Thông tin hợp d?ng";
            // 
            // lblRenterName
            // 
            this.lblRenterName.AutoSize = true;
            this.lblRenterName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRenterName.Location = new System.Drawing.Point(15, 45);
            this.lblRenterName.Name = "lblRenterName";
            this.lblRenterName.Size = new System.Drawing.Size(133, 28);
            this.lblRenterName.TabIndex = 2;
            this.lblRenterName.Text = "Nguời thuê: ...";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEndDate.Location = new System.Drawing.Point(15, 125);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(142, 28);
            this.lblEndDate.TabIndex = 1;
            this.lblEndDate.Text = "Ngày kết thúc: ...";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStartDate.Location = new System.Drawing.Point(15, 85);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(139, 28);
            this.lblStartDate.TabIndex = 0;
            this.lblStartDate.Text = "Ngày bắt đầu: ...";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(17, 60);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(158, 32);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Trạng thái: ...";
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnEdit.Location = new System.Drawing.Point(440, 640);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(120, 50);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.MistyRose;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnDelete.ForeColor = System.Drawing.Color.DarkRed;
            this.btnDelete.Location = new System.Drawing.Point(580, 640);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 50);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnClose.Location = new System.Drawing.Point(720, 640);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 50);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Ðóng";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // grpRoomInfo
            // 
            this.grpRoomInfo.Controls.Add(this.lblAddress);
            this.grpRoomInfo.Controls.Add(this.lblArea);
            this.grpRoomInfo.Controls.Add(this.lblPrice);
            this.grpRoomInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpRoomInfo.Location = new System.Drawing.Point(25, 90);
            this.grpRoomInfo.Name = "grpRoomInfo";
            this.grpRoomInfo.Size = new System.Drawing.Size(400, 200);
            this.grpRoomInfo.TabIndex = 10;
            this.grpRoomInfo.TabStop = false;
            this.grpRoomInfo.Text = "Thông tin phòng";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblAddress.Location = new System.Drawing.Point(15, 125);
            this.lblAddress.MaximumSize = new System.Drawing.Size(380, 0); 
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(102, 30);
            this.lblAddress.TabIndex = 7;
            this.lblAddress.Text = "Ðịa chỉ: ...";
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblArea.Location = new System.Drawing.Point(15, 85);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(147, 30);
            this.lblArea.TabIndex = 6;
            this.lblArea.Text = "Diện tích: ... m²";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblPrice.ForeColor = System.Drawing.Color.DarkRed;
            this.lblPrice.Location = new System.Drawing.Point(15, 45);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(120, 30);
            this.lblPrice.TabIndex = 5;
            this.lblPrice.Text = "Giá: ... VND";
            // 
            // grpImages
            // 
            this.grpImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpImages.Controls.Add(this.lblImageCounter);
            this.grpImages.Controls.Add(this.btnNextImage);
            this.grpImages.Controls.Add(this.btnPrevImage);
            this.grpImages.Controls.Add(this.picRoomPreview);
            this.grpImages.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpImages.Location = new System.Drawing.Point(25, 300);
            this.grpImages.Name = "grpImages";
            this.grpImages.Padding = new System.Windows.Forms.Padding(10);
            this.grpImages.Size = new System.Drawing.Size(825, 320);
            this.grpImages.TabIndex = 11;
            this.grpImages.TabStop = false;
            this.grpImages.Text = "Hình ảnh phòng";
            // 
            // lblImageCounter
            // 
            this.lblImageCounter.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblImageCounter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblImageCounter.Location = new System.Drawing.Point(360, 280);
            this.lblImageCounter.Name = "lblImageCounter";
            this.lblImageCounter.Size = new System.Drawing.Size(100, 30);
            this.lblImageCounter.TabIndex = 3;
            this.lblImageCounter.Text = "0 / 0";
            this.lblImageCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNextImage
            // 
            this.btnNextImage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnNextImage.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnNextImage.Location = new System.Drawing.Point(750, 140);
            this.btnNextImage.Name = "btnNextImage";
            this.btnNextImage.Size = new System.Drawing.Size(60, 60);
            this.btnNextImage.TabIndex = 2;
            this.btnNextImage.Text = ">";
            this.btnNextImage.UseVisualStyleBackColor = true;
            // 
            // btnPrevImage
            // 
            this.btnPrevImage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnPrevImage.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnPrevImage.Location = new System.Drawing.Point(15, 140);
            this.btnPrevImage.Name = "btnPrevImage";
            this.btnPrevImage.Size = new System.Drawing.Size(60, 60);
            this.btnPrevImage.TabIndex = 1;
            this.btnPrevImage.Text = "<";
            this.btnPrevImage.UseVisualStyleBackColor = true;
            // 
            // picRoomPreview
            // 
            this.picRoomPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picRoomPreview.BackColor = System.Drawing.Color.Gainsboro;
            this.picRoomPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picRoomPreview.Location = new System.Drawing.Point(90, 40);
            this.picRoomPreview.Name = "picRoomPreview";
            this.picRoomPreview.Size = new System.Drawing.Size(645, 230);
            this.picRoomPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picRoomPreview.TabIndex = 0;
            this.picRoomPreview.TabStop = false;
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.lblRoomName);
            this.panelHeader.Controls.Add(this.lblStatus);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(878, 100);
            this.panelHeader.TabIndex = 12;
            // 
            // btnBook
            // 
            this.btnBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnBook.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnBook.ForeColor = System.Drawing.Color.White;
            this.btnBook.Location = new System.Drawing.Point(440, 640);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(260, 50);
            this.btnBook.TabIndex = 13;
            this.btnBook.Text = "Gửi yêu cầu thuê";
            this.btnBook.UseVisualStyleBackColor = false;
            // 
            // FormInfoRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(878, 714);
            this.Controls.Add(this.grpImages);
            this.Controls.Add(this.grpRoomInfo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.grpContractInfo);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.btnBook);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormInfoRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết phòng";
            this.grpContractInfo.ResumeLayout(false);
            this.grpContractInfo.PerformLayout();
            this.grpRoomInfo.ResumeLayout(false);
            this.grpRoomInfo.PerformLayout();
            this.grpImages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picRoomPreview)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Label lblRoomName;
        private System.Windows.Forms.GroupBox grpContractInfo;
        private System.Windows.Forms.Label lblRenterName;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grpRoomInfo;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.GroupBox grpImages;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox picRoomPreview;
        private System.Windows.Forms.Label lblImageCounter;
        private System.Windows.Forms.Button btnNextImage;
        private System.Windows.Forms.Button btnPrevImage;
        private System.Windows.Forms.Button btnBook;
    }
}
