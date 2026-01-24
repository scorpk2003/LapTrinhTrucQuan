namespace QuanLyPhongTro
{
    partial class FormManageListRoom
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
            dgvListRooms = new DataGridView();
            btnCreate = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnClose = new Button();
            lblTitle = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvListRooms).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvListRooms
            // 
            dgvListRooms.AllowUserToAddRows = false;
            dgvListRooms.AllowUserToDeleteRows = false;
            dgvListRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListRooms.BackgroundColor = Color.White;
            dgvListRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListRooms.Dock = DockStyle.Fill;
            dgvListRooms.Location = new Point(0, 164);
            dgvListRooms.Margin = new Padding(6, 6, 6, 6);
            dgvListRooms.MultiSelect = false;
            dgvListRooms.Name = "dgvListRooms";
            dgvListRooms.ReadOnly = true;
            dgvListRooms.RowHeadersWidth = 62;
            dgvListRooms.RowTemplate.Height = 28;
            dgvListRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListRooms.Size = new Size(1871, 979);
            dgvListRooms.TabIndex = 0;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.FromArgb(0, 123, 255);
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCreate.ForeColor = Color.White;
            btnCreate.Location = new Point(24, 50);
            btnCreate.Margin = new Padding(6, 6, 6, 6);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(283, 102);
            btnCreate.TabIndex = 1;
            btnCreate.Text = "➕ Tạo mới";
            btnCreate.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(255, 193, 7);
            btnEdit.Enabled = false;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(334, 56);
            btnEdit.Margin = new Padding(6, 6, 6, 6);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(283, 102);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "✏️ Chỉnh sửa";
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(220, 53, 69);
            btnDelete.Enabled = false;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(643, 50);
            btnDelete.Margin = new Padding(6, 6, 6, 6);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(283, 102);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "🗑️ Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(108, 117, 125);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(1582, 56);
            btnClose.Margin = new Padding(6, 6, 6, 6);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(283, 102);
            btnClose.TabIndex = 4;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(6, -11);
            lblTitle.Margin = new Padding(6, 0, 6, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(435, 72);
            lblTitle.TabIndex = 5;
            lblTitle.Text = "Quản lý Dãy Trọ";
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(lblTitle);
            panel1.Controls.Add(btnCreate);
            panel1.Controls.Add(btnClose);
            panel1.Controls.Add(btnEdit);
            panel1.Controls.Add(btnDelete);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(6, 6, 6, 6);
            panel1.Name = "panel1";
            panel1.Size = new Size(1871, 164);
            panel1.TabIndex = 6;
            // 
            // FormManageListRoom
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1871, 1143);
            Controls.Add(dgvListRooms);
            Controls.Add(panel1);
            Margin = new Padding(6, 6, 6, 6);
            MinimumSize = new Size(1483, 933);
            Name = "FormManageListRoom";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quản lý Dãy Trọ";
            ((System.ComponentModel.ISupportInitialize)dgvListRooms).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListRooms;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel1;
    }
}
