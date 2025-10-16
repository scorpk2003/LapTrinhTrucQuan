namespace QuanLyPhongTro.src.Components
{
    partial class Notice
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            title_lb = new Label();
            stat_btn = new Button();
            SuspendLayout();
            // 
            // title_lb
            // 
            title_lb.AutoSize = true;
            title_lb.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            title_lb.Location = new Point(16, 14);
            title_lb.Name = "title_lb";
            title_lb.Size = new Size(61, 25);
            title_lb.TabIndex = 0;
            title_lb.Text = "label1";
            // 
            // stat_btn
            // 
            stat_btn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            stat_btn.Location = new Point(168, 7);
            stat_btn.Name = "stat_btn";
            stat_btn.Size = new Size(75, 35);
            stat_btn.TabIndex = 1;
            stat_btn.Text = "button1";
            stat_btn.UseVisualStyleBackColor = true;
            // 
            // Notice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(stat_btn);
            Controls.Add(title_lb);
            Name = "Notice";
            Size = new Size(250, 50);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label title_lb;
        private Button stat_btn;
    }
}
