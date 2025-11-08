namespace QuanLyPhongTro
{
    partial class AuthForm
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            // XÓA DÒNG NÀY: this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0); // Đặt ở góc
            this.panelMain.Name = "panelMain";

            // THÊM 2 DÒNG NÀY:
            this.panelMain.AutoSize = true;
            this.panelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            // 
            // AuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            // THÊM 2 DÒNG NÀY (để chắc chắn)
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;

            // XÓA DÒNG NÀY: this.ClientSize = ... (Không cần vì đã AutoSize)
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AuthForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập / Đăng ký";
            this.ResumeLayout(false);

            // THÊM DÒNG NÀY:
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
    }
}