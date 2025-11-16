namespace QuanLyPhongTro.src.Login
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            lbnote = new Label();
            lbnote1 = new Label();
            textBox1 = new TextBox();
            lbnote2 = new Label();
            lbnote3 = new Label();
            lbnote4 = new Label();
            lbnote5 = new Label();
            btnext = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // lbnote
            // 
            lbnote.AutoSize = true;
            lbnote.Font = new Font("Segoe UI Emoji", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbnote.Location = new Point(280, 38);
            lbnote.Name = "lbnote";
            lbnote.Size = new Size(330, 46);
            lbnote.TabIndex = 0;
            lbnote.Text = "Thiết lập mật khẩu";
            // 
            // lbnote1
            // 
            lbnote1.AutoSize = true;
            lbnote1.Font = new Font("Segoe UI Light", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbnote1.Location = new Point(361, 113);
            lbnote1.Name = "lbnote1";
            lbnote1.Size = new Size(162, 28);
            lbnote1.TabIndex = 1;
            lbnote1.Text = "Tạo mật khẩu mới";
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(298, 172);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(308, 24);
            textBox1.TabIndex = 2;
            // 
            // lbnote2
            // 
            lbnote2.AutoSize = true;
            lbnote2.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbnote2.Location = new Point(298, 221);
            lbnote2.Name = "lbnote2";
            lbnote2.Size = new Size(182, 20);
            lbnote2.TabIndex = 3;
            lbnote2.Text = "Ít nhất một kí tự viết thường.";
            // 
            // lbnote3
            // 
            lbnote3.AutoSize = true;
            lbnote3.Font = new Font("Segoe UI Light", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbnote3.Location = new Point(298, 253);
            lbnote3.Name = "lbnote3";
            lbnote3.Size = new Size(190, 23);
            lbnote3.TabIndex = 3;
            lbnote3.Text = "Ít nhất một kí tự viết hoa.";
            lbnote3.Click += label2_Click;
            // 
            // lbnote4
            // 
            lbnote4.AutoSize = true;
            lbnote4.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbnote4.Location = new Point(298, 289);
            lbnote4.Name = "lbnote4";
            lbnote4.Size = new Size(66, 20);
            lbnote4.TabIndex = 3;
            lbnote4.Text = "8-16 kí tự";
            // 
            // lbnote5
            // 
            lbnote5.AutoSize = true;
            lbnote5.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbnote5.Location = new Point(298, 319);
            lbnote5.Name = "lbnote5";
            lbnote5.Size = new Size(393, 20);
            lbnote5.TabIndex = 3;
            lbnote5.Text = "Chỉ các chữ cái, số và ký tự phổ biến mới có thể được sử dụng";
            // 
            // btnext
            // 
            btnext.BackColor = Color.FromArgb(255, 128, 0);
            btnext.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnext.Location = new Point(298, 362);
            btnext.Name = "btnext";
            btnext.Size = new Size(308, 76);
            btnext.TabIndex = 4;
            btnext.Text = "Tiếp theo";
            btnext.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(48, 12);
            button1.Name = "button1";
            button1.Size = new Size(63, 57);
            button1.TabIndex = 5;
            button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 450);
            Controls.Add(button1);
            Controls.Add(btnext);
            Controls.Add(lbnote5);
            Controls.Add(lbnote4);
            Controls.Add(lbnote3);
            Controls.Add(lbnote2);
            Controls.Add(textBox1);
            Controls.Add(lbnote1);
            Controls.Add(lbnote);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbnote;
        private Label lbnote1;
        private TextBox textBox1;
        private Label lbnote2;
        private Label lbnote3;
        private Label lbnote4;
        private Label lbnote5;
        private Button btnext;
        private Button button1;
    }
}