using System;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class FormCreateRoom : Form
    {
        private InfoRoom room;

        public FormCreateRoom()
        {
            InitializeComponent();
            room = new InfoRoom();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu nhập vào
                if (string.IsNullOrWhiteSpace(txtRoomName.Text) ||
                    string.IsNullOrWhiteSpace(txtArea.Text) ||
                    string.IsNullOrWhiteSpace(txtPrice.Text) ||
                    cboStatus.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Parse dữ liệu
                if (!double.TryParse(txtArea.Text, out double area))
                {
                    MessageBox.Show("Diện tích phải là số!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(txtPrice.Text, out decimal price))
                {
                    MessageBox.Show("Giá thuê phải là số!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lưu thông tin
                room.Name = txtRoomName.Text.Trim();
                room.Area = area;
                room.Price = price;
                room.Status = cboStatus.SelectedItem.ToString();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public InfoRoom GetRoom() => room;

        private void FormCreateRoom_Load(object sender, EventArgs e)
        {

        }
    }

    // Class chứa thông tin phòng
    public class InfoRoom
    {
        public string Name { get; set; }
        public double Area { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
    }
}
