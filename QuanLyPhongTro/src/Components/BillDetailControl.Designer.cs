namespace QuanLyPhongTro.src.Components
{
    partial class BillDetailControl
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
            name_lb = new Label();
            groupBox1 = new GroupBox();
            pay_btn = new Button();
            SuspendLayout();
            // 
            // name_lb
            // 
            name_lb.AutoSize = true;
            name_lb.Font = new Font("Rockwell", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            name_lb.Location = new Point(136, 51);
            name_lb.Name = "name_lb";
            name_lb.Size = new Size(69, 23);
            name_lb.TabIndex = 0;
            name_lb.Text = "label1";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = AppColors.SubBackground;
            groupBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(22, 119);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(404, 361);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Chi tiết hoá đơn";
            // 
            // pay_btn
            // 
            pay_btn.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pay_btn.Location = new Point(163, 486);
            pay_btn.Name = "pay_btn";
            pay_btn.Size = new Size(99, 46);
            pay_btn.TabIndex = 2;
            pay_btn.Text = "button1";
            pay_btn.UseVisualStyleBackColor = true;
            pay_btn.Click += pay_btn_Click;
            // 
            // BillDetailControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = AppColors.Background;
            Controls.Add(pay_btn);
            Controls.Add(groupBox1);
            Controls.Add(name_lb);
            Name = "BillDetailControl";
            Size = new Size(450, 550);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label name_lb;
        private GroupBox groupBox1;
        private Button pay_btn;
    }
}
