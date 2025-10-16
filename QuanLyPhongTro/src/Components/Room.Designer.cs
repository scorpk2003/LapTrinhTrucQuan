namespace QuanLyPhongTro.src.Components
{
    partial class Room
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
            SuspendLayout();
            // 
            // room_name
            // 
            room_name.AutoSize = true;
            room_name.Font = new Font("Brush Script MT", 24F, FontStyle.Italic, GraphicsUnit.Point, 0);
            room_name.ForeColor = Color.CornflowerBlue;
            room_name.Location = new Point(15, 50);
            room_name.Name = "room_name";
            room_name.Size = new Size(72, 39);
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
            state_radio.Location = new Point(15, 137);
            state_radio.Margin = new Padding(5);
            state_radio.Name = "state_radio";
            state_radio.Size = new Size(118, 38);
            state_radio.TabIndex = 1;
            state_radio.TabStop = true;
            state_radio.Text = "radioButton1";
            state_radio.UseVisualStyleBackColor = false;
            state_radio.CheckedChanged += state_radio_CheckedChanged;
            // 
            // Room
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(state_radio);
            Controls.Add(room_name);
            ForeColor = SystemColors.ActiveCaption;
            Name = "Room";
            Size = new Size(150, 200);
            Load += Room_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label room_name;
        private RadioButton state_radio;
    }
}
