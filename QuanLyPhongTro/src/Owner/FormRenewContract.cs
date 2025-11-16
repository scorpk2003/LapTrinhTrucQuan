using System;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class FormRenewContract : Form
    {
        // Public property d? l?y giá tr?
        public int MonthsToAdd { get; private set; }

        /// <summary>
        /// Form xác nh?n s? tháng
        /// </summary>
        /// <param name="defaultMonths">S? tháng hi?n th? m?c d?nh</param>
        /// <param name="title">Tiêu d? c?a Form</param>
        public FormRenewContract(int defaultMonths = 6, string title = "Xác nh?n Gia h?n")
        {
            InitializeComponent();

            // Gán giá tr? m?c d?nh
            this.Text = title;
            if (defaultMonths > 0)
            {
                numMonths.Value = defaultMonths;
            }

            this.btnConfirm.Click += BtnConfirm_Click;
            this.btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            // L?y giá tr? t? ô s?
            this.MonthsToAdd = (int)numMonths.Value;

            // Ðóng form và báo OK
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
