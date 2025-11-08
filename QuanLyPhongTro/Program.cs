using QuanLyPhongTro.Model; // Vẫn cần
using System;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Chạy Form Auth (Form này sẽ tự xử lý việc đăng nhập)
            Application.Run(new AuthForm());
        }
    }
}