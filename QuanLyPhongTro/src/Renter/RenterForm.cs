using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyPhongTro.Model;

namespace QuanLyPhongTro
{
    // Ð?i tên class d? phù h?p v?i ch?c nang ngu?i dã thuê phòng
    public partial class RenterForm : Form
    {
        private readonly Person? _currentPerson;

        // Constructor dùng lúc ch?y th?c t? sau dang nh?p
        public RenterForm(Person currentPerson)
        {
            _currentPerson = currentPerson;
            InitializeComponent();
            HookEvents();
        }

        // Constructor m?c d?nh d? Designer ho?t d?ng (không nên dùng khi ch?y th?t)
        public RenterForm() : this(null!) { }

        private void HookEvents()
        {
            Load += Renter_MainMenu_Load;
            btnInfo.Click += BtnInfo_Click;
            btnViewBill.Click += BtnViewBill_Click;
            btnViewContract.Click += BtnViewContract_Click;
            btnEndOfContract.Click += BtnEndOfContract_Click;
            btnReport.Click += BtnReport_Click;
            btnLogout.Click += BtnLogout_Click;

            // C?p nh?t tiêu d?
            lblTitle.Text = "Renter Main Menu";
            lblRenterName.Text = _currentPerson != null ? $"Welcome, {_currentPerson.Username}" : "Welcome, [Guest]";
        }

        private void Renter_MainMenu_Load(object sender, EventArgs e)
        {
            LoadDefaultView();
        }

        private void LoadDefaultView()
        {
            flowPanelContent.Controls.Clear();

            Panel infoPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(30, 40, 30, 40),
                BackColor = Color.White
            };

            Label lblWelcome = new Label
            {
                Text = "Chào mừng bạn đã đến với ?ng d?n v?i trang qu?n lý phòng dã thuê.\nPhòng c?a b?n: P101",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Padding = new Padding(20),
                Height = 180
            };
            infoPanel.Controls.Add(lblWelcome);

            Label lblNotice = new Label
            {
                Text = "S? d?ng menu bên trái d? xem Hóa don, H?p d?ng ho?c Báo cáo s? c?.",
                Font = new Font("Segoe UI", 14F, FontStyle.Italic),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Padding = new Padding(20, 10, 20, 10)
            };
            infoPanel.Controls.Add(lblNotice);

            flowPanelContent.Controls.Add(infoPanel);
        }

        // === Event Handlers cho Menu bên trái ===
        private void BtnInfo_Click(object sender, EventArgs e)
        {
            if (_currentPerson == null)
            {
                MessageBox.Show("Chua có thông tin ngu?i dùng (null). Hãy dang nh?p tru?c.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using var formInfo = new FormInformation(_currentPerson);
            formInfo.ShowDialog(this);
        }

        private void BtnViewBill_Click(object sender, EventArgs e)
        {
            MessageBox.Show("M? Form xem Danh sách Hóa don (View Bill).", "Ch?c nang", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnViewContract_Click(object sender, EventArgs e)
        {
            MessageBox.Show("M? Form xem H?p d?ng (View Contract).", "Ch?c nang", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnEndOfContract_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("B?n có ch?c ch?n mu?n g?i Yêu c?u Ch?m d?t H?p d?ng?\nÐi?u này có th? yêu c?u thông báo tru?c.",
                                                 "Xác nh?n Ch?m d?t H?p d?ng",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Yêu c?u ch?m d?t h?p d?ng dã du?c g?i. Vui lòng ch? xác nh?n t? Ch? tr?.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // === Event Handlers cho Menu trên cùng ===
        private void BtnReport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("M? Form Báo cáo s? c? ho?c Ph?n h?i (Report).", "Ch?c nang", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("B?n có ch?c mu?n dang xu?t?",
                                                 "Ðang xu?t", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}