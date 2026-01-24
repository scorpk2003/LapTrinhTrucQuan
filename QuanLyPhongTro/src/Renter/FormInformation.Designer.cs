using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    partial class FormInformation
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            panelTop = new Panel();
            lblHeader = new Label();
            btnCloseTop = new Button();

            splitContainer = new SplitContainer();

            panelAvatar = new Panel();
            grpAvatar = new GroupBox();
            picAvatar = new PictureBox();
            btnChonAnh = new Button();
            lblHint = new Label();

            panelRight = new Panel();
            grpInfo = new GroupBox();
            tableFields = new TableLayoutPanel();

            lblUsername = new Label();
            txtUsername = new TextBox();

            lblName = new Label();
            txtName = new TextBox();

            lblCCCD = new Label();
            txtCCCD = new TextBox();

            lblPhone = new Label();
            txtPhone = new TextBox();

            panelBottom = new Panel();
            btnEditSave = new Button();
            btnClose = new Button();

            openFileDialog = new OpenFileDialog();

            // ====== TOP ======
            panelTop.SuspendLayout();

            // ====== SPLIT INIT (QUAN TRỌNG: BeginInit đúng chuẩn) ======
            ((System.ComponentModel.ISupportInitialize)(splitContainer)).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();

            // ====== LEFT INIT ======
            panelAvatar.SuspendLayout();
            grpAvatar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(picAvatar)).BeginInit();

            // ====== RIGHT INIT ======
            panelRight.SuspendLayout();
            grpInfo.SuspendLayout();
            tableFields.SuspendLayout();
            panelBottom.SuspendLayout();

            SuspendLayout();

            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(240, 244, 248);
            panelTop.Dock = DockStyle.Top;
            panelTop.Padding = new Padding(32, 20, 32, 20);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(2550, 110);
            panelTop.TabIndex = 0;
            panelTop.Controls.Add(lblHeader);
            panelTop.Controls.Add(btnCloseTop);

            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeader.ForeColor = Color.FromArgb(41, 128, 185);
            lblHeader.Location = new Point(32, 28);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(345, 81);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Thông tin cá nhân";

            // 
            // btnCloseTop
            // 
            btnCloseTop.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCloseTop.BackColor = Color.White;
            btnCloseTop.FlatStyle = FlatStyle.Flat;
            btnCloseTop.FlatAppearance.BorderColor = Color.FromArgb(220, 225, 230);
            btnCloseTop.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCloseTop.ForeColor = Color.FromArgb(80, 80, 80);
            btnCloseTop.Location = new Point(2390, 24);
            btnCloseTop.Name = "btnCloseTop";
            btnCloseTop.Size = new Size(128, 62);
            btnCloseTop.TabIndex = 1;
            btnCloseTop.Text = "Đóng";
            btnCloseTop.UseVisualStyleBackColor = false;
            btnCloseTop.DialogResult = DialogResult.Cancel;

            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.FixedPanel = FixedPanel.Panel1;
            splitContainer.Location = new Point(0, 110);
            splitContainer.Name = "splitContainer";
            splitContainer.Size = new Size(2550, 1325);
            splitContainer.SplitterWidth = 12;
            splitContainer.SplitterDistance = 720;
            splitContainer.TabIndex = 1;
            splitContainer.Panel1MinSize = 650;
            splitContainer.Panel2MinSize = 850;

            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(panelAvatar);

            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(panelRight);

            // 
            // panelAvatar
            // 
            panelAvatar.BackColor = Color.White;
            panelAvatar.Dock = DockStyle.Fill;
            panelAvatar.Padding = new Padding(32, 24, 16, 24);
            panelAvatar.Name = "panelAvatar";
            panelAvatar.TabIndex = 0;
            panelAvatar.Controls.Add(grpAvatar);

            // 
            // grpAvatar
            // 
            grpAvatar.Dock = DockStyle.Fill;
            grpAvatar.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            grpAvatar.Name = "grpAvatar";
            grpAvatar.Padding = new Padding(32, 28, 32, 28);
            grpAvatar.TabIndex = 0;
            grpAvatar.TabStop = false;
            grpAvatar.Text = "Ảnh đại diện";
            grpAvatar.Controls.Add(picAvatar);
            grpAvatar.Controls.Add(btnChonAnh);
            grpAvatar.Controls.Add(lblHint);

            // 
            // picAvatar
            // 
            picAvatar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            picAvatar.BackColor = Color.White;
            picAvatar.BorderStyle = BorderStyle.FixedSingle;
            picAvatar.Location = new Point(64, 78);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(560, 560);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 0;
            picAvatar.TabStop = false;

            // 
            // btnChonAnh
            // 
            btnChonAnh.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnChonAnh.BackColor = Color.FromArgb(41, 128, 185);
            btnChonAnh.FlatStyle = FlatStyle.Flat;
            btnChonAnh.FlatAppearance.BorderSize = 0;
            btnChonAnh.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnChonAnh.ForeColor = Color.White;
            btnChonAnh.Location = new Point(64, 670);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new Size(560, 84);
            btnChonAnh.TabIndex = 1;
            btnChonAnh.Text = "Đổi ảnh";
            btnChonAnh.UseVisualStyleBackColor = false;

            // 
            // lblHint
            // 
            lblHint.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblHint.Font = new Font("Segoe UI", 11F);
            lblHint.ForeColor = Color.DimGray;
            lblHint.Location = new Point(64, 770);
            lblHint.Name = "lblHint";
            lblHint.Size = new Size(560, 90);
            lblHint.TabIndex = 2;
            lblHint.Text = "Gợi ý: dùng ảnh rõ mặt, tỷ lệ vuông để hiển thị đẹp nhất.";
            lblHint.TextAlign = ContentAlignment.TopLeft;

            // 
            // panelRight
            // 
            panelRight.BackColor = Color.White;
            panelRight.Dock = DockStyle.Fill;
            panelRight.Padding = new Padding(16, 24, 32, 24);
            panelRight.Name = "panelRight";
            panelRight.TabIndex = 0;
            panelRight.Controls.Add(grpInfo);
            panelRight.Controls.Add(panelBottom);

            // 
            // grpInfo
            // 
            grpInfo.Dock = DockStyle.Fill;
            grpInfo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            grpInfo.Name = "grpInfo";
            grpInfo.Padding = new Padding(32, 28, 32, 28);
            grpInfo.TabIndex = 0;
            grpInfo.TabStop = false;
            grpInfo.Text = "Thông tin";
            grpInfo.Controls.Add(tableFields);

            // 
            // tableFields
            // 
            tableFields.AutoSize = true;
            tableFields.ColumnCount = 2;
            tableFields.RowCount = 4;
            tableFields.Dock = DockStyle.Top;
            tableFields.Name = "tableFields";
            tableFields.Padding = new Padding(0, 10, 0, 10);
            tableFields.TabIndex = 0;

            tableFields.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 320F));
            tableFields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableFields.RowStyles.Add(new RowStyle(SizeType.Absolute, 110F));
            tableFields.RowStyles.Add(new RowStyle(SizeType.Absolute, 110F));
            tableFields.RowStyles.Add(new RowStyle(SizeType.Absolute, 110F));
            tableFields.RowStyles.Add(new RowStyle(SizeType.Absolute, 110F));

            tableFields.Controls.Add(lblUsername, 0, 0);
            tableFields.Controls.Add(txtUsername, 1, 0);
            tableFields.Controls.Add(lblName, 0, 1);
            tableFields.Controls.Add(txtName, 1, 1);
            tableFields.Controls.Add(lblCCCD, 0, 2);
            tableFields.Controls.Add(txtCCCD, 1, 2);
            tableFields.Controls.Add(lblPhone, 0, 3);
            tableFields.Controls.Add(txtPhone, 1, 3);

            // 
            // lblUsername
            // 
            lblUsername.Anchor = AnchorStyles.Left;
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 13F);
            lblUsername.ForeColor = Color.FromArgb(50, 50, 50);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(284, 60);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Tên đăng nhập";

            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtUsername.Font = new Font("Segoe UI", 13F);
            txtUsername.ReadOnly = true;
            txtUsername.BackColor = Color.FromArgb(245, 247, 250);
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(1460, 65);
            txtUsername.TabIndex = 1;

            // 
            // lblName
            // 
            lblName.Anchor = AnchorStyles.Left;
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 13F);
            lblName.ForeColor = Color.FromArgb(50, 50, 50);
            lblName.Name = "lblName";
            lblName.Size = new Size(171, 60);
            lblName.TabIndex = 2;
            lblName.Text = "Họ và tên";

            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtName.Font = new Font("Segoe UI", 13F);
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Name = "txtName";
            txtName.Size = new Size(1460, 65);
            txtName.TabIndex = 3;

            // 
            // lblCCCD
            // 
            lblCCCD.Anchor = AnchorStyles.Left;
            lblCCCD.AutoSize = true;
            lblCCCD.Font = new Font("Segoe UI", 13F);
            lblCCCD.ForeColor = Color.FromArgb(50, 50, 50);
            lblCCCD.Name = "lblCCCD";
            lblCCCD.Size = new Size(95, 60);
            lblCCCD.TabIndex = 4;
            lblCCCD.Text = "CCCD";

            // 
            // txtCCCD
            // 
            txtCCCD.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtCCCD.Font = new Font("Segoe UI", 13F);
            txtCCCD.BorderStyle = BorderStyle.FixedSingle;
            txtCCCD.Name = "txtCCCD";
            txtCCCD.Size = new Size(1460, 65);
            txtCCCD.TabIndex = 5;

            // 
            // lblPhone
            // 
            lblPhone.Anchor = AnchorStyles.Left;
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 13F);
            lblPhone.ForeColor = Color.FromArgb(50, 50, 50);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(214, 60);
            lblPhone.TabIndex = 6;
            lblPhone.Text = "Số điện thoại";

            // 
            // txtPhone
            // 
            txtPhone.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtPhone.Font = new Font("Segoe UI", 13F);
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(1460, 65);
            txtPhone.TabIndex = 7;

            // 
            // panelBottom
            // 
            panelBottom.BackColor = Color.White;
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Height = 140;
            panelBottom.Padding = new Padding(0, 20, 0, 0);
            panelBottom.Name = "panelBottom";
            panelBottom.TabIndex = 1;
            panelBottom.Controls.Add(btnEditSave);
            panelBottom.Controls.Add(btnClose);

            // 
            // btnEditSave
            // 
            btnEditSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditSave.BackColor = Color.Orange;
            btnEditSave.FlatStyle = FlatStyle.Flat;
            btnEditSave.FlatAppearance.BorderSize = 0;
            btnEditSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnEditSave.ForeColor = Color.White;
            btnEditSave.Location = new Point(900, 25);
            btnEditSave.Name = "btnEditSave";
            btnEditSave.Size = new Size(320, 90);
            btnEditSave.TabIndex = 0;
            btnEditSave.Text = "Sửa";
            btnEditSave.UseVisualStyleBackColor = false;

            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(39, 174, 96);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(1240, 25);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(320, 90);
            btnClose.TabIndex = 1;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.DialogResult = DialogResult.Cancel;

            // 
            // openFileDialog
            // 
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            // 
            // FormInformation
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnClose;
            ClientSize = new Size(2550, 1435);
            Controls.Add(splitContainer);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormInformation";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thông tin cá nhân";

            // ====== RESUME/ENDINIT ĐÚNG THỨ TỰ ======
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();

            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(splitContainer)).EndInit();
            splitContainer.ResumeLayout(false);

            panelAvatar.ResumeLayout(false);
            grpAvatar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(picAvatar)).EndInit();

            panelRight.ResumeLayout(false);
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            tableFields.ResumeLayout(false);
            tableFields.PerformLayout();

            panelBottom.ResumeLayout(false);

            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblHeader;
        private Button btnCloseTop;

        private SplitContainer splitContainer;

        private Panel panelAvatar;
        private GroupBox grpAvatar;
        private PictureBox picAvatar;
        private Button btnChonAnh;
        private Label lblHint;

        private Panel panelRight;
        private GroupBox grpInfo;
        private TableLayoutPanel tableFields;

        private Label lblUsername;
        private TextBox txtUsername;

        private Label lblName;
        private TextBox txtName;

        private Label lblCCCD;
        private TextBox txtCCCD;

        private Label lblPhone;
        private TextBox txtPhone;

        private Panel panelBottom;
        private Button btnEditSave;
        private Button btnClose;

        private OpenFileDialog openFileDialog;
    }
}
