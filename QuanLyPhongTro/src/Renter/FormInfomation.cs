using System;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class FormInformation : Form
    {
        public FormInformation()
        {
            InitializeComponent();
        }

        private void FormInformation_Load(object sender, EventArgs e)
        {
            // Giả lập dữ liệu người thuê (trong thực tế sẽ lấy từ database)
            txtHoTen.Text = "Nguyễn Văn A";
            txtCCCD.Text = "079123456789";
            txtSoDienThoai.Text = "0909123456";
            txtEmail.Text = "nguyenvana@gmail.com";
            txtDiaChi.Text = "123 Nguyễn Trãi, Q.5, TP.HCM";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Cập nhật thông tin (sau này có thể lưu vào DB)
            MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
