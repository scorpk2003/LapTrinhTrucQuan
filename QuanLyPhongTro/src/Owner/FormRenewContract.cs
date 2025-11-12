using System;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class FormRenewContract : Form
    {
        // Public property để lấy giá trị
        public int MonthsToAdd { get; private set; }

        /// <summary>
        /// Form xác nhận số tháng
        /// </summary>
        /// <param name="defaultMonths">Số tháng hiển thị mặc định</param>
        /// <param name="title">Tiêu đề của Form</param>
        public FormRenewContract(int defaultMonths = 6, string title = "Xác nhận Gia hạn")
        {
            InitializeComponent();

            // Gán giá trị mặc định
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
            // Lấy giá trị từ ô số
            this.MonthsToAdd = (int)numMonths.Value;

            // Đóng form và báo OK
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}