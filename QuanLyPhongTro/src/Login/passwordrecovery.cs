using QuanLyPhongTro.src.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace QuanLyPhongTro.src.Login;

public partial class passwordrecovery : Form
{
    private Label lblError;
    public passwordrecovery()
    {
        InitializeComponent();
        tbEmail1.Text = "Nhập email đã đăng ký...";
        tbEmail1.ForeColor = Color.Gray;

        tbEmail1.Enter += (s, e) =>
        {
            if (tbEmail1.Text == "Nhập email đã đăng ký...")
            {
                tbEmail1.Text = "";
                tbEmail1.ForeColor = Color.Black;
            }
        };

        tbEmail1.Leave += (s, e) =>
        {
            if (string.IsNullOrWhiteSpace(tbEmail1.Text))
            {
                tbEmail1.Text = "Nhập email đã đăng ký...";
                tbEmail1.ForeColor = Color.Gray;
            }
        };

        // Tạo label lỗi dưới textbox
        lblError = new Label();
        lblError.ForeColor = Color.FromArgb(255, 60, 60);
        lblError.AutoSize = true;
        lblError.Font = new Font("Segoe UI", 8.5f);
        lblError.Location = new Point(tbEmail1.Left, tbEmail1.Bottom + 2);
        lblError.Text = "";
        this.Controls.Add(lblError);

        // Realtime validate khi nhập
        tbEmail1.TextChanged += TbEmail1_TextChanged;
        tbEmail1.Leave += TbEmail1_Leave;
    }

    private bool IsValidEmail(string email)
    {
        string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, pattern);
    }

    private bool IsValidPhone(string phone)
    {
        string pattern = @"^0\d{9,10}$"; // SĐT VN
        return Regex.IsMatch(phone, pattern);
    }

    private bool IsValidEmailOrPhone(string text)
    {
        return IsValidEmail(text) || IsValidPhone(text);
    }

    private void TbEmail1_TextChanged(object sender, EventArgs e)
    {
        this.BeginInvoke((Action)(() =>
        {
            string input = tbEmail1.Text.Trim();
            if (string.IsNullOrEmpty(input) || input == "Nhập email đã đăng ký...")
                lblError.Text = "";
            else if (!IsValidEmailOrPhone(input))
                lblError.Text = "Sai định dạng email hoặc số điện thoại";
            else
                lblError.Text = "";
        }));
    }

    private void TbEmail1_Leave(object sender, EventArgs e)
    {
        if (!IsValidEmailOrPhone(tbEmail1.Text))
            lblError.Text = "Sai định dạng email hoặc số điện thoại";
    }

    private void btConfirm_Click(object sender, EventArgs e)
    {
        if (!IsValidEmailOrPhone(tbEmail1.Text))
        {
            lblError.Text = "Sai định dạng email hoặc số điện thoại";
            return;
        }

        lblError.Text = "";

        OTP MaOtp = new OTP();
        this.Hide();
        MaOtp.ShowDialog();
        this.Show();
    }
}


