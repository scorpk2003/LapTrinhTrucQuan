namespace QuanLyPhongTro
{
    partial class ucContractManagement
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPendingRequests = new System.Windows.Forms.TabPage();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.dgvRequests = new System.Windows.Forms.DataGridView();
            this.tabActiveContracts = new System.Windows.Forms.TabPage();
            this.btnEndContract = new System.Windows.Forms.Button();
            this.btnRenewContract = new System.Windows.Forms.Button();
            this.dgvContracts = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tabControlMain.SuspendLayout();
            this.tabPendingRequests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).BeginInit();
            this.tabActiveContracts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContracts)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPendingRequests);
            this.tabControlMain.Controls.Add(this.tabActiveContracts);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1200, 800);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPendingRequests
            // 
            this.tabPendingRequests.Controls.Add(this.btnRefresh);
            this.tabPendingRequests.Controls.Add(this.btnReject);
            this.tabPendingRequests.Controls.Add(this.btnApprove);
            this.tabPendingRequests.Controls.Add(this.dgvRequests);
            this.tabPendingRequests.Location = new System.Drawing.Point(4, 37);
            this.tabPendingRequests.Name = "tabPendingRequests";
            this.tabPendingRequests.Padding = new System.Windows.Forms.Padding(3);
            this.tabPendingRequests.Size = new System.Drawing.Size(1192, 759);
            this.tabPendingRequests.TabIndex = 0;
            this.tabPendingRequests.Text = "Yêu cầu đang chờ (0)";
            this.tabPendingRequests.UseVisualStyleBackColor = true;
            // 
            // btnReject
            // 
            this.btnReject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReject.BackColor = System.Drawing.Color.MistyRose;
            this.btnReject.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnReject.Location = new System.Drawing.Point(820, 690);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(150, 50);
            this.btnReject.TabIndex = 2;
            this.btnReject.Text = "Từ chối";
            this.btnReject.UseVisualStyleBackColor = false;
            // 
            // btnApprove
            // 
            this.btnApprove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApprove.BackColor = System.Drawing.Color.Honeydew;
            this.btnApprove.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnApprove.Location = new System.Drawing.Point(990, 690);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(180, 50);
            this.btnApprove.TabIndex = 1;
            this.btnApprove.Text = "Tạo hợp đồng";
            this.btnApprove.UseVisualStyleBackColor = false;
            // 
            // dgvRequests
            // 
            this.dgvRequests.AllowUserToAddRows = false;
            this.dgvRequests.AllowUserToDeleteRows = false;
            this.dgvRequests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRequests.Location = new System.Drawing.Point(6, 6);
            this.dgvRequests.MultiSelect = false;
            this.dgvRequests.Name = "dgvRequests";
            this.dgvRequests.ReadOnly = true;
            this.dgvRequests.RowHeadersWidth = 62;
            this.dgvRequests.RowTemplate.Height = 28;
            this.dgvRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRequests.Size = new System.Drawing.Size(1180, 670);
            this.dgvRequests.TabIndex = 0;
            // 
            // tabActiveContracts
            // 
            this.tabActiveContracts.Controls.Add(this.btnEndContract);
            this.tabActiveContracts.Controls.Add(this.btnRenewContract);
            this.tabActiveContracts.Controls.Add(this.dgvContracts);
            this.tabActiveContracts.Location = new System.Drawing.Point(4, 37);
            this.tabActiveContracts.Name = "tabActiveContracts";
            this.tabActiveContracts.Padding = new System.Windows.Forms.Padding(3);
            this.tabActiveContracts.Size = new System.Drawing.Size(1192, 759);
            this.tabActiveContracts.TabIndex = 1;
            this.tabActiveContracts.Text = "Hợp đồng đang hoạt động";
            this.tabActiveContracts.UseVisualStyleBackColor = true;
            // 
            // btnEndContract
            // 
            this.btnEndContract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEndContract.BackColor = System.Drawing.Color.MistyRose;
            this.btnEndContract.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEndContract.Location = new System.Drawing.Point(820, 690);
            this.btnEndContract.Name = "btnEndContract";
            this.btnEndContract.Size = new System.Drawing.Size(150, 50);
            this.btnEndContract.TabIndex = 4;
            this.btnEndContract.Text = "Thanh lý";
            this.btnEndContract.UseVisualStyleBackColor = false;
            // 
            // btnRenewContract
            // 
            this.btnRenewContract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRenewContract.BackColor = System.Drawing.Color.AliceBlue;
            this.btnRenewContract.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRenewContract.Location = new System.Drawing.Point(990, 690);
            this.btnRenewContract.Name = "btnRenewContract";
            this.btnRenewContract.Size = new System.Drawing.Size(180, 50);
            this.btnRenewContract.TabIndex = 3;
            this.btnRenewContract.Text = "Gia hạn hợp đồng";
            this.btnRenewContract.UseVisualStyleBackColor = false;
            // 
            // dgvContracts
            // 
            this.dgvContracts.AllowUserToAddRows = false;
            this.dgvContracts.AllowUserToDeleteRows = false;
            this.dgvContracts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvContracts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContracts.Location = new System.Drawing.Point(6, 6);
            this.dgvContracts.MultiSelect = false;
            this.dgvContracts.Name = "dgvContracts";
            this.dgvContracts.ReadOnly = true;
            this.dgvContracts.RowHeadersWidth = 62;
            this.dgvContracts.RowTemplate.Height = 28;
            this.dgvContracts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContracts.Size = new System.Drawing.Size(1180, 670);
            this.dgvContracts.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRefresh.Location = new System.Drawing.Point(20, 690);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(150, 50);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // ucContractManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlMain);
            this.Name = "ucContractManagement";
            this.Size = new System.Drawing.Size(1200, 800);
            this.tabControlMain.ResumeLayout(false);
            this.tabPendingRequests.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).EndInit();
            this.tabActiveContracts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContracts)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPendingRequests;
        private System.Windows.Forms.TabPage tabActiveContracts;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.DataGridView dgvRequests;
        private System.Windows.Forms.Button btnEndContract;
        private System.Windows.Forms.Button btnRenewContract;
        private System.Windows.Forms.DataGridView dgvContracts;
        private System.Windows.Forms.Button btnRefresh;
    }
}
