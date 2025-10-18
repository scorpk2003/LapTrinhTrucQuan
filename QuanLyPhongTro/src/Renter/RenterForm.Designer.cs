using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QuanLyPhongTro
{
    partial class RenterForm
    {
        private System.ComponentModel.IContainer components = null;

        // Khai báo các Controls m?i
        private Button btnViewBill;
        private Button btnViewContract;
        private Button btnEndOfContract;

        // Tái s? d?ng các Controls dã có, d?i tên bi?n n?u c?n
        private Panel panelTop;
        private Label lblTitle;
        private Label lblRenterName;
        private Panel panelMenu;
        private Button btnLogout;
        private Button btnReport;
        private Button btnInfo;
        public FlowLayoutPanel flowPanelContent; // Ð?i tên t? flowPanelRooms

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelTop = new Panel();
            btnReport = new Button();
            lblTitle = new Label();
            lblRenterName = new Label();
            btnLogout = new Button();
            panelMenu = new Panel();
            btnEndOfContract = new Button();
            btnViewContract = new Button();
            btnViewBill = new Button();
            btnInfo = new Button();
            flowPanelContent = new FlowLayoutPanel();
            panelTop.SuspendLayout();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(25, 42, 86);
            panelTop.Controls.Add(btnLogout);
            panelTop.Controls.Add(btnReport);
            panelTop.Controls.Add(lblTitle);
            panelTop.Controls.Add(lblRenterName);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(6);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(3400, 246);
            panelTop.TabIndex = 0;
            // 
            // btnReport (Nút Tròn)
            // 
            btnReport.Anchor = AnchorStyles.Right;
            btnReport.BackColor = Color.FromArgb(231, 76, 60); // Màu d? cho báo cáo
            btnReport.FlatAppearance.BorderSize = 0;
            btnReport.FlatStyle = FlatStyle.Flat;
            btnReport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnReport.ForeColor = Color.White;
            btnReport.Location = new Point(2800, 60); // V? trí m?u g?n góc trên bên ph?i
            btnReport.Margin = new Padding(6);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(160, 160);
            btnReport.TabIndex = 3;
            btnReport.Text = "Report";
            btnReport.UseVisualStyleBackColor = false;
            btnReport.BringToFront(); // Ð?m b?o nút n?m trên cùng
            // T?o hi?u ?ng bo tròn
            // Luu ý: C?n thêm code v? hình tròn b?ng Graphics/Region d? th?t s? tròn.
            // ? dây ch? dùng kích thu?c vuông l?n.
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(57, 72);
            lblTitle.Margin = new Padding(6, 0, 6, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(640, 81);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "?? Renter Main Menu";
            // 
            // lblRenterName
            // 
            lblRenterName.Anchor = AnchorStyles.Right;
            lblRenterName.AutoSize = true;
            lblRenterName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            lblRenterName.ForeColor = Color.WhiteSmoke;
            lblRenterName.Location = new Point(2300, 92);
            lblRenterName.Margin = new Padding(6, 0, 6, 0);
            lblRenterName.Name = "lblRenterName";
            lblRenterName.Size = new Size(450, 54);
            lblRenterName.TabIndex = 1;
            lblRenterName.Text = "Welcome, [Renter Name]";
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Right;
            btnLogout.Font = new System.Drawing.Font("Segoe UI", 12F);
            btnLogout.Location = new Point(3000, 80); // V? trí m?u g?n góc trên bên ph?i
            btnLogout.Margin = new Padding(6);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(300, 80);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(41, 128, 185);
            panelMenu.Controls.Add(btnEndOfContract);
            panelMenu.Controls.Add(btnViewContract);
            panelMenu.Controls.Add(btnViewBill);
            panelMenu.Controls.Add(btnInfo);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 246);
            panelMenu.Margin = new Padding(6);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(472, 1435);
            panelMenu.TabIndex = 1;
            // 
            // btnInfo (Information)
            // 
            btnInfo.Font = new System.Drawing.Font("Segoe UI", 12F);
            btnInfo.Location = new Point(57, 102);
            btnInfo.Margin = new Padding(6);
            btnInfo.Name = "btnInfo";
            btnInfo.Size = new Size(340, 123);
            btnInfo.TabIndex = 0;
            btnInfo.Text = "Information";
            btnInfo.UseVisualStyleBackColor = true;
            // 
            // btnViewBill (View Bill)
            // 
            btnViewBill.Font = new System.Drawing.Font("Segoe UI", 12F);
            btnViewBill.Location = new Point(57, 266);
            btnViewBill.Margin = new Padding(6);
            btnViewBill.Name = "btnViewBill";
            btnViewBill.Size = new Size(340, 123);
            btnViewBill.TabIndex = 1;
            btnViewBill.Text = "View Bill";
            btnViewBill.UseVisualStyleBackColor = true;
            // 
            // btnViewContract (View Contract)
            // 
            btnViewContract.Font = new System.Drawing.Font("Segoe UI", 12F);
            btnViewContract.Location = new Point(57, 430);
            btnViewContract.Margin = new Padding(6);
            btnViewContract.Name = "btnViewContract";
            btnViewContract.Size = new Size(340, 123);
            btnViewContract.TabIndex = 2;
            btnViewContract.Text = "View Contract";
            btnViewContract.UseVisualStyleBackColor = true;
            // 
            // btnEndOfContract (End of Contract)
            // 
            btnEndOfContract.Font = new System.Drawing.Font("Segoe UI", 12F);
            btnEndOfContract.Location = new Point(57, 594);
            btnEndOfContract.Margin = new Padding(6);
            btnEndOfContract.Name = "btnEndOfContract";
            btnEndOfContract.Size = new Size(340, 123);
            btnEndOfContract.TabIndex = 3;
            btnEndOfContract.Text = "End of Contract";
            btnEndOfContract.UseVisualStyleBackColor = true;
            // 
            // flowPanelContent
            // 
            flowPanelContent.AutoScroll = true;
            flowPanelContent.BackColor = Color.WhiteSmoke;
            flowPanelContent.Dock = DockStyle.Fill;
            flowPanelContent.Location = new Point(472, 246);
            flowPanelContent.Margin = new Padding(6);
            flowPanelContent.Name = "flowPanelContent";
            flowPanelContent.Padding = new Padding(38, 41, 38, 41);
            flowPanelContent.Size = new Size(2928, 1435);
            flowPanelContent.TabIndex = 2;
            // 
            // Renter_MainMenu
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(3400, 1681);
            Controls.Add(flowPanelContent);
            Controls.Add(panelMenu);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(6);
            Name = "Renter_MainMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Renter Main Menu";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

    }
}