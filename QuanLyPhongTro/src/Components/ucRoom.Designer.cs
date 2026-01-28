namespace QuanLyPhongTro.src.Components
{
    partial class ucRoom
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
            room_name = new Label();
            state_radio = new RadioButton();
            btSign = new Button();
            SuspendLayout();
            // 
            // room_name
            // 
            room_name.AutoSize = true;
            room_name.Font = new Font("Brush Script MT", 24F, FontStyle.Italic, GraphicsUnit.Point, 0);
            room_name.ForeColor = Color.CornflowerBlue;
            room_name.Location = new Point(17, 67);
            room_name.Name = "room_name";
            room_name.Size = new Size(92, 50);
            room_name.TabIndex = 0;
            room_name.Text = "label1";
            // 
            // state_radio
            // 
            state_radio.AutoCheck = false;
            state_radio.AutoSize = true;
            state_radio.BackColor = SystemColors.ButtonHighlight;
            state_radio.CheckAlign = ContentAlignment.TopCenter;
            state_radio.Checked = true;
            state_radio.Enabled = false;
            state_radio.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            state_radio.ImageAlign = ContentAlignment.TopRight;
            state_radio.Location = new Point(34, 180);
            state_radio.Margin = new Padding(6, 7, 6, 7);
            state_radio.Name = "state_radio";
            state_radio.Size = new Size(147, 48);
            state_radio.TabIndex = 1;
            state_radio.TabStop = true;
            state_radio.Text = "radioButton1";
            state_radio.UseVisualStyleBackColor = false;
//            state_radio.CheckedChanged += state_radio_CheckedChanged;
            // 
            // btSign
            // 
            btSign.BackColor = Color.FromArgb(255, 255, 128);
            btSign.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btSign.ForeColor = SystemColors.ActiveCaptionText;
            btSign.Location = new Point(0, 258);
            btSign.Name = "btSign";
            btSign.Size = new Size(213, 46);
            btSign.TabIndex = 2;
            btSign.Text = "Kí hợp đồng";
            btSign.UseVisualStyleBackColor = false;
       //     btSign.Click += btSign_Click;
            // 
            // ucRoom
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(btSign);
            Controls.Add(state_radio);
            Controls.Add(room_name);
            ForeColor = SystemColors.ActiveCaption;
            Margin = new Padding(3, 4, 3, 4);
            Name = "ucRoom";
            Size = new Size(213, 319);
      //      Load += Room_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label room_name;
        private RadioButton state_radio;
        private Button btSign;
    }
}
