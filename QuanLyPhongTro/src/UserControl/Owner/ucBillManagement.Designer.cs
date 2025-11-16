namespace QuanLyPhongTro
{
    partial class ucBillManagement
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnConfirmPayment = new System.Windows.Forms.Button();
            this.btnGenerateBills = new System.Windows.Forms.Button();
            this.btnShowUnpaid = new System.Windows.Forms.Button();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowPanelBills = new System.Windows.Forms.FlowLayoutPanel();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.btnConfirmPayment);
            this.panelTop.Controls.Add(this.btnGenerateBills);
            this.panelTop.Controls.Add(this.btnShowUnpaid);
            this.panelTop.Controls.Add(this.cboYear);
            this.panelTop.Controls.Add(this.cboMonth);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1200, 70);
            this.panelTop.TabIndex = 0;
            // 
            // btnConfirmPayment
            // 
            this.btnConfirmPayment.BackColor = System.Drawing.Color.Green;
            this.btnConfirmPayment.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnConfirmPayment.ForeColor = System.Drawing.Color.White;
            this.btnConfirmPayment.Location = new System.Drawing.Point(770, 15);
            this.btnConfirmPayment.Name = "btnConfirmPayment";
            this.btnConfirmPayment.Size = new System.Drawing.Size(170, 40);
            this.btnConfirmPayment.TabIndex = 5;
            this.btnConfirmPayment.Text = "Xác nhận thanh toán";
            this.btnConfirmPayment.UseVisualStyleBackColor = false;
            // 
            // btnGenerateBills
            // 
            this.btnGenerateBills.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGenerateBills.Location = new System.Drawing.Point(950, 15);
            this.btnGenerateBills.Name = "btnGenerateBills";
            this.btnGenerateBills.Size = new System.Drawing.Size(220, 40);
            this.btnGenerateBills.TabIndex = 4;
            this.btnGenerateBills.Text = "Tạo HÐ tháng này";
            this.btnGenerateBills.UseVisualStyleBackColor = true;
            // 
            // btnShowUnpaid
            // 
            this.btnShowUnpaid.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnShowUnpaid.Location = new System.Drawing.Point(500, 15);
            this.btnShowUnpaid.Name = "btnShowUnpaid";
            this.btnShowUnpaid.Size = new System.Drawing.Size(250, 40);
            this.btnShowUnpaid.TabIndex = 3;
            this.btnShowUnpaid.Text = "Hiển thị tất cả hóa đơn";
            this.btnShowUnpaid.UseVisualStyleBackColor = true;
            // 
            // cboYear
            // 
            this.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(350, 18);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(121, 36);
            this.cboYear.TabIndex = 2;
            // 
            // cboMonth
            // 
            this.cboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonth.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Location = new System.Drawing.Point(190, 18);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(140, 36);
            this.cboMonth.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.Location = new System.Drawing.Point(20, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lọc theo tháng:";
            // 
            // flowPanelBills
            // 
            this.flowPanelBills.AutoScroll = true;
            this.flowPanelBills.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowPanelBills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelBills.Location = new System.Drawing.Point(0, 70);
            this.flowPanelBills.Name = "flowPanelBills";
            this.flowPanelBills.Padding = new System.Windows.Forms.Padding(10);
            this.flowPanelBills.Size = new System.Drawing.Size(1200, 830);
            this.flowPanelBills.TabIndex = 1;
            // 
            // ucBillManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowPanelBills);
            this.Controls.Add(this.panelTop);
            this.Name = "ucBillManagement";
            this.Size = new System.Drawing.Size(1200, 900);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.FlowLayoutPanel flowPanelBills;
        private System.Windows.Forms.Button btnShowUnpaid;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenerateBills;
        private System.Windows.Forms.Button btnConfirmPayment;
    }
}
