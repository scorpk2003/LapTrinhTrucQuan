using Microsoft.VisualBasic.Logging;
using QuanLyPhongTro.src.Models;
using QuanLyPhongTro.src.Services1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro.src.Login
{
    public partial class UserSignup : Form
    {
        private Label? lblErrHovaten;
        private Label? lblErrSdt;
        private Label? lblErrGioitinh;
        // Label báo lỗi
        private Label? lblErrEmail;
        private Label? lblErrUser;
        private Label? lblErrPass;
        private Label? lblErrRePass;
        private Label? lblErrRole;
        public UserSignup()
        {
            InitializeComponent(
                );

            // Ẩn password lúc đầu
            tbPass.UseSystemPasswordChar = true;
            tbPass1.UseSystemPasswordChar = true;
            CreateErrorLabels();
        }



        // Tạo label lỗi
        private void CreateErrorLabels()
        {
            if (lblErrEmail != null) return;

            lblErrEmail = NewErrorLabelUnder(tbEmailv);

            lblErrPass = NewErrorLabelUnder(tbPass);
            lblErrRePass = NewErrorLabelUnder(tbPass1);

            this.Controls.Add(lblErrEmail);
            this.Controls.Add(lblErrUser);
            this.Controls.Add(lblErrPass);
            this.Controls.Add(lblErrRePass);
            lblErrHovaten = NewErrorLabelUnder(tbHovaten);
            lblErrSdt = NewErrorLabelUnder(tbSđt);
            lblErrGioitinh = NewErrorLabelUnder(cbbGioitinh);

            this.Controls.Add(lblErrHovaten);
            this.Controls.Add(lblErrSdt);
            this.Controls.Add(lblErrGioitinh);
            lblErrRole = NewErrorLabelUnder(cbbRole);
            this.Controls.Add(lblErrRole);
        }

        private Label NewErrorLabelUnder(Control ctrl)
        {
            Label lbl = new Label();
            lbl.ForeColor = Color.FromArgb(255, 60, 60); // màu đỏ
            lbl.Font = new Font("Segoe UI", 8.5f, FontStyle.Regular);
            lbl.AutoSize = true;
            lbl.Text = "";
            lbl.Location = new Point(ctrl.Left, ctrl.Bottom + 2);
            return lbl;
        }

        // Kiểm tra Email hợp lệ
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        // Kiểm tra số điện thoại hợp lệ (VN)
        private bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return false;
            string pattern = @"^(0|\+84)[0-9]{9}$"; // 10 số bắt đầu 0 hoặc +84
            return Regex.IsMatch(phone, pattern);
        }

        // Nút đăng ký
        private void btsignup_Click(object sender, EventArgs e)
        {
            bool ok = true;

            // Họ và tên
            if (string.IsNullOrWhiteSpace(tbHovaten.Text) || !Regex.IsMatch(tbHovaten.Text, @"^[a-zA-ZÀ-ỹ\s]+$"))
            {
                lblErrHovaten!.Text = "Họ và tên không hợp lệ.";
                ok = false;
            }
            else lblErrHovaten!.Text = "";

            // Email 
            if (!IsValidEmail(tbEmailv.Text))
            {
                lblErrEmail!.Text = "Email không hợp lệ.";
                ok = false;
            }
            else
            {
                lblErrEmail!.Text = "";
            }

            // Số điện thoại (riêng)
            if (string.IsNullOrWhiteSpace(tbSđt.Text) || !Regex.IsMatch(tbSđt.Text, @"^(0|\+84)[0-9]{9}$"))
            {
                lblErrSdt!.Text = "Số điện thoại không hợp lệ.";
                ok = false;
            }
            else lblErrSdt!.Text = "";

            // Giới tính
            if (cbbGioitinh.SelectedIndex == -1)
            {
                lblErrGioitinh!.Text = "Vui lòng chọn giới tính.";
                ok = false;
            }
            else lblErrGioitinh!.Text = "";

            // Password
            if (tbPass.Text.Length < 6)
            {
                lblErrPass!.Text = "Mật khẩu phải ≥ 6 ký tự.";
                ok = false;
            }
            else lblErrPass!.Text = "";

            if (tbPass1.Text != tbPass.Text)
            {
                lblErrRePass!.Text = "Mật khẩu nhập lại không khớp.";
                ok = false;
            }
            else lblErrRePass!.Text = "";
            if (cbbRole.SelectedIndex == -1)
            {
                lblErrRole!.Text = "Vui lòng chọn vai trò.";
                ok = false;
            }
            else
            {
                lblErrRole!.Text = "";
            }

            // Lấy giá trị Role
            string selectedRole = cbbRole.SelectedItem?.ToString() ?? "";
            if (!ok) return;
            MessageBox.Show("Đăng ký thành công!", "Thành công");

            Person people = new Person
            {
                Username = tbHovaten.Text.Trim(),
                Password = tbPass.Text.Trim(),
                Role = selectedRole,
                IdDetailNavigation = new PersonDetail
                {
                    Name = tbHovaten.Text.Trim(),
                    Gmail = tbEmailv.Text.Trim(),
                    Phone = tbSđt.Text.Trim(),
                }
            };
            PersonService personService = new PersonService();
            Person? exist = personService.GetAccount(people.IdDetailNavigation.Gmail, people.Password);
            if(exist != null)
            {
                MessageBox.Show("Tài khoản đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                personService.SignUp(people);
            }
                // Hiển thị lại form login gốc

            Loginmain loginmain = new Loginmain();
            loginmain.Show();
            this.Close();

        }

        // Kiểm tra Email hoặc SĐT
        private bool IsValidEmailOrPhone(string text)
        {
            bool isPhone = Regex.IsMatch(text, @"^(0|\+84)[0-9]{9}$");
            bool isEmail = Regex.IsMatch(text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return isPhone || isEmail;
        }



        // Realtime email
        private void tbEmailv_TextChanged(object sender, EventArgs e)
        {
            this.BeginInvoke((Action)(() =>
            {
                if (string.IsNullOrWhiteSpace(tbEmailv.Text))
                    lblErrEmail!.Text = "Không được để trống.";
                else if (!IsValidEmail(tbEmailv.Text))
                    lblErrEmail!.Text = "Email không hợp lệ.";
                else
                    lblErrEmail!.Text = "";
            }));
        }

        private void tbEmailv_Leave(object sender, EventArgs e)
        {
            if (!IsValidEmail(tbEmailv.Text))
                lblErrEmail!.Text = "Email không hợp lệ.";
            else
                lblErrEmail!.Text = "";
        }



        // Realtime mật khẩu
        private void tbPass_TextChanged(object sender, EventArgs e)
        {
            if (tbPass.Text.Length < 6)
                lblErrPass!.Text = "Mật khẩu phải ≥ 6 ký tự.";
            else
                lblErrPass!.Text = "";
        }

        private void tbPass_Leave(object sender, EventArgs e)
        {
            if (tbPass.Text.Length < 6)
                lblErrPass!.Text = "Mật khẩu phải ≥ 6 ký tự.";
        }

        // Realtime nhập lại mật khẩu
        private void tbPass1_TextChanged(object sender, EventArgs e)
        {
            if (tbPass1.Text != tbPass.Text)
                lblErrRePass!.Text = "Mật khẩu nhập lại không khớp.";
            else
                lblErrRePass!.Text = "";
        }

        private void tbPass1_Leave(object sender, EventArgs e)
        {
            if (tbPass1.Text != tbPass.Text)
                lblErrRePass!.Text = "Mật khẩu nhập lại không khớp.";
        }

        private void checkshowpass_CheckedChanged(object sender, EventArgs e)
        {
            tbPass.UseSystemPasswordChar = !checkshowpass.Checked;
            tbPass1.UseSystemPasswordChar = !checkshowpass.Checked;
        }



        private void llblogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Loginmain loginmain = new Loginmain(); // hiện lại form login hiện tại
            this.Close();      // đóng form signup
            loginmain.Show();
        }

        private void tbHovaten_TextChanged(object sender, EventArgs e)
        {
            string name = tbHovaten.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
                lblErrHovaten!.Text = "Họ và tên không được để trống.";
            else if (!Regex.IsMatch(name, @"^[a-zA-ZÀ-ỹ\s]+$"))
                lblErrHovaten!.Text = "Họ và tên chỉ chứa chữ cái.";
            else
                lblErrHovaten!.Text = "";
        }

        private void tbSđt_TextChanged(object sender, EventArgs e)
        {
            string phone = tbSđt.Text.Trim();
            if (string.IsNullOrWhiteSpace(phone))
                lblErrSdt!.Text = "Số điện thoại không được để trống.";
            else if (!Regex.IsMatch(phone, @"^(0|\+84)[0-9]{9}$"))
                lblErrSdt!.Text = "Số điện thoại không hợp lệ.";
            else
                lblErrSdt!.Text = "";
        }

        private void cbbGioitinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbGioitinh.SelectedIndex == -1)
                lblErrGioitinh!.Text = "Vui lòng chọn giới tính.";
            else
                lblErrGioitinh!.Text = "";
        }

        private void lblSignup_Click(object sender, EventArgs e)
        {

        }

        private void cbbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbRole.SelectedIndex != -1)
                lblErrRole!.Text = "";
        }
    }
}
