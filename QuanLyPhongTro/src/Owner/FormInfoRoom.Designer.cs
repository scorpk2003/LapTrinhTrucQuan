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
            this.picRoom = new System.Windows.Forms.PictureBox();
            this.lblRoomName = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.grpContractInfo = new System.Windows.Forms.GroupBox();
            this.lblRenterName = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picRoom)).BeginInit();
            this.grpContractInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // picRoom
            // 
            this.picRoom.BackColor = System.Drawing.Color.Gainsboro;
            this.picRoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picRoom.Location = new System.Drawing.Point(25, 25);
            this.picRoom.Name = "picRoom";
            this.picRoom.Size = new System.Drawing.Size(400, 200);
            this.picRoom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picRoom.TabIndex = 0;
            this.picRoom.TabStop = false;
            // 
            // lblRoomName
            // 
            this.lblRoomName.AutoSize = true;
            this.lblRoomName.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblRoomName.Location = new System.Drawing.Point(20, 240);
            this.lblRoomName.Name = "lblRoomName";
            this.lblRoomName.Size = new System.Drawing.Size(199, 45);
            this.lblRoomName.TabIndex = 1;
            this.lblRoomName.Text = "Tên Phòng...";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblPrice.ForeColor = System.Drawing.Color.DarkRed;
            this.lblPrice.Location = new System.Drawing.Point(22, 290);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(120, 30);
            this.lblPrice.TabIndex = 2;
            this.lblPrice.Text = "Giá: ... VND";
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblArea.Location = new System.Drawing.Point(22, 325);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(147, 30);
            this.lblArea.TabIndex = 3;
            this.lblArea.Text = "Diện tích: ... m²";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblAddress.Location = new System.Drawing.Point(22, 360);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(102, 30);
            this.lblAddress.TabIndex = 4;
            this.lblAddress.Text = "Địa chỉ: ...";
            // 
            // grpContractInfo
            // 
            this.grpContractInfo.Controls.Add(this.lblRenterName);
            this.grpContractInfo.Controls.Add(this.lblEndDate);
            this.grpContractInfo.Controls.Add(this.lblStartDate);
            this.grpContractInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpContractInfo.Location = new System.Drawing.Point(25, 450);
            this.grpContractInfo.Name = "grpContractInfo";
            this.grpContractInfo.Size = new System.Drawing.Size(400, 150);
            this.grpContractInfo.TabIndex = 5;
            this.grpContractInfo.TabStop = false;
            this.grpContractInfo.Text = "Thông tin hợp đồng";
            // 
            // lblRenterName
            // 
            this.lblRenterName.AutoSize = true;
            this.lblRenterName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRenterName.Location = new System.Drawing.Point(15, 35);
            this.lblRenterName.Name = "lblRenterName";
            this.lblRenterName.Size = new System.Drawing.Size(133, 28);
            this.lblRenterName.TabIndex = 2;
            this.lblRenterName.Text = "Người thuê: ...";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEndDate.Location = new System.Drawing.Point(15, 105);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(142, 28);
            this.lblEndDate.TabIndex = 1;
            this.lblEndDate.Text = "Ngày kết thúc: ...";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStartDate.Location = new System.Drawing.Point(15, 70);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(139, 28);
            this.lblStartDate.TabIndex = 0;
            this.lblStartDate.Text = "Ngày bắt đầu: ...";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(21, 400);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(158, 32);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Trạng thái: ...";
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnEdit.Location = new System.Drawing.Point(25, 620);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(120, 50);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.MistyRose;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnDelete.ForeColor = System.Drawing.Color.DarkRed;
            this.btnDelete.Location = new System.Drawing.Point(165, 620);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 50);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnClose.Location = new System.Drawing.Point(305, 620);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 50);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // FormInfoRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(450, 695);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.grpContractInfo);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblArea);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblRoomName);
            this.Controls.Add(this.picRoom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormInfoRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết phòng";
            ((System.ComponentModel.ISupportInitialize)(this.picRoom)).EndInit();
            this.grpContractInfo.ResumeLayout(false);
            this.grpContractInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox picRoom;
        private System.Windows.Forms.Label lblRoomName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.GroupBox grpContractInfo;
        private System.Windows.Forms.Label lblRenterName;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
    }
}