namespace QuanLyPhongTro
{
    partial class Owner_TrangChu
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
            panelTop = new Panel();
            lblTitle = new Label();
            lblOwnerName = new Label();
            panelMenu = new Panel();
            btnLogout = new Button();
            btnReport = new Button();
            btnBill = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnCreate = new Button();
            flowPanelRooms = new FlowLayoutPanel();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            panelTop.SuspendLayout();
            panelMenu.SuspendLayout();
            flowPanelRooms.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(25, 42, 86);
            panelTop.Controls.Add(lblTitle);
            panelTop.Controls.Add(lblOwnerName);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(6, 6, 6, 6);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(3844, 205);
            panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(64, 57);
            lblTitle.Margin = new Padding(6, 0, 6, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(632, 81);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🏠 Owner Dashboard";
            // 
            // lblOwnerName
            // 
            lblOwnerName.Anchor = AnchorStyles.Right;
            lblOwnerName.AutoSize = true;
            lblOwnerName.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            lblOwnerName.ForeColor = Color.WhiteSmoke;
            lblOwnerName.Location = new Point(2952, 72);
            lblOwnerName.Margin = new Padding(6, 0, 6, 0);
            lblOwnerName.Name = "lblOwnerName";
            lblOwnerName.Size = new Size(454, 54);
            lblOwnerName.TabIndex = 1;
            lblOwnerName.Text = "Welcome, [Owner Name]";
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(41, 128, 185);
            panelMenu.Controls.Add(btnLogout);
            panelMenu.Controls.Add(btnReport);
            panelMenu.Controls.Add(btnBill);
            panelMenu.Controls.Add(btnDelete);
            panelMenu.Controls.Add(btnEdit);
            panelMenu.Controls.Add(btnCreate);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 205);
            panelMenu.Margin = new Padding(6, 6, 6, 6);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(595, 1804);
            panelMenu.TabIndex = 1;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(53, 1640);
            btnLogout.Margin = new Padding(6, 6, 6, 6);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(489, 113);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnReport
            // 
            btnReport.Location = new Point(53, 943);
            btnReport.Margin = new Padding(6, 6, 6, 6);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(489, 113);
            btnReport.TabIndex = 4;
            btnReport.Text = "Report";
            btnReport.UseVisualStyleBackColor = true;
            // 
            // btnBill
            // 
            btnBill.Location = new Point(53, 800);
            btnBill.Margin = new Padding(6, 6, 6, 6);
            btnBill.Name = "btnBill";
            btnBill.Size = new Size(489, 113);
            btnBill.TabIndex = 3;
            btnBill.Text = "Bill Management";
            btnBill.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(53, 656);
            btnDelete.Margin = new Padding(6, 6, 6, 6);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(489, 113);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete Room";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(53, 512);
            btnEdit.Margin = new Padding(6, 6, 6, 6);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(489, 113);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Edit Room";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(53, 369);
            btnCreate.Margin = new Padding(6, 6, 6, 6);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(489, 113);
            btnCreate.TabIndex = 0;
            btnCreate.Text = "Create Room";
            btnCreate.UseVisualStyleBackColor = true;
            // 
            // flowPanelRooms
            // 
            flowPanelRooms.AutoScroll = true;
            flowPanelRooms.BackColor = Color.WhiteSmoke;
            flowPanelRooms.Controls.Add(button1);
            flowPanelRooms.Controls.Add(button2);
            flowPanelRooms.Controls.Add(button3);
            flowPanelRooms.Controls.Add(button4);
            flowPanelRooms.Controls.Add(button5);
            flowPanelRooms.Controls.Add(button6);
            flowPanelRooms.Controls.Add(button7);
            flowPanelRooms.Dock = DockStyle.Fill;
            flowPanelRooms.Location = new Point(595, 205);
            flowPanelRooms.Margin = new Padding(6, 6, 6, 6);
            flowPanelRooms.Name = "flowPanelRooms";
            flowPanelRooms.Padding = new Padding(42, 41, 42, 41);
            flowPanelRooms.Size = new Size(3249, 1804);
            flowPanelRooms.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(45, 44);
            button1.Name = "button1";
            button1.Size = new Size(450, 494);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(501, 44);
            button2.Name = "button2";
            button2.Size = new Size(450, 494);
            button2.TabIndex = 0;
            button2.Text = "button1";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(957, 44);
            button3.Name = "button3";
            button3.Size = new Size(450, 494);
            button3.TabIndex = 0;
            button3.Text = "button1";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(1413, 44);
            button4.Name = "button4";
            button4.Size = new Size(450, 494);
            button4.TabIndex = 0;
            button4.Text = "button1";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(1869, 44);
            button5.Name = "button5";
            button5.Size = new Size(450, 494);
            button5.TabIndex = 0;
            button5.Text = "button1";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(2325, 44);
            button6.Name = "button6";
            button6.Size = new Size(450, 494);
            button6.TabIndex = 0;
            button6.Text = "button1";
            button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Location = new Point(45, 544);
            button7.Name = "button7";
            button7.Size = new Size(450, 494);
            button7.TabIndex = 0;
            button7.Text = "button1";
            button7.UseVisualStyleBackColor = true;
            // 
            // Owner_TrangChu
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(3844, 2009);
            Controls.Add(flowPanelRooms);
            Controls.Add(panelMenu);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(6, 6, 6, 6);
            Name = "Owner_TrangChu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Owner Dashboard";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelMenu.ResumeLayout(false);
            flowPanelRooms.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblOwnerName;
        private System.Windows.Forms.Panel panelMenu;
        public System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnBill;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnLogout;
        public System.Windows.Forms.FlowLayoutPanel flowPanelRooms;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
    }
}
