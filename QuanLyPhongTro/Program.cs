using QuanLyPhongTro.src.Mediator;
using QuanLyPhongTro.src.UserSession;
using QuanLyPhongTro.src.Components;

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
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Mediator.Instance.RegisterFactory("BillControl", () => new BillControl());
            Mediator.Instance.RegisterFactory("BillDetailControl", () => new BillDetailControl());
            Application.Run(new MainForm());
        }
    }
}