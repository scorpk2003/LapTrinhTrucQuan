using Microsoft.VisualBasic.Logging;
using QuanLyPhongTro.src.Test.Models;
using QuanLyPhongTro.src.Login;
using QuanLyPhongTro.src.Signup;
using ScottPlot.Plottables;
using System;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class AuthForm : Form
    {
        Login loginControl;
        Signup signupControl;

        public AuthForm()
        {
            InitializeComponent();

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            ShowLoginControl();
        }

        private void ShowLoginControl()
        {
            panelMain.Controls.Clear();
            loginControl = new Login();

            loginControl.LoginSuccess += LoginControl_LoginSuccess;
            loginControl.GoToSignup += (s, e) => ShowSignupControl();

            panelMain.Controls.Add(loginControl);
        }

        private void ShowSignupControl()
        {
            panelMain.Controls.Clear();
            signupControl = new Signup();

            signupControl.GoToLogin += (s, e) => ShowLoginControl();

            panelMain.Controls.Add(signupControl);
        }

        private void LoginControl_LoginSuccess(Person person)
        {
            if (person.Role == "Owner")
            {
                Owner_TrangChu mainForm = new Owner_TrangChu(person);
                mainForm.Show();

                this.Hide();
                mainForm.FormClosed += (s, e) => this.Close();
            }
            if (person.Role == "Renter")
            {
                Renter_TrangChu mainForm = new Renter_TrangChu(person);
                mainForm.Show();

                this.Hide();
                mainForm.FormClosed += (s, e) => this.Close();
            }
            else if (person.Role == "")
            {
                MessageBox.Show("Ðang nh?p Renter thành công! (Chua có Form Renter)");
            }
        }
    }
}
