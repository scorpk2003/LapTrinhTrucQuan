using QuanLyPhongTro.src.Login;
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
            RegisterFactory();
            Application.Run(new Loginmain());
        }

        static void RegisterFactory()
        {
            Mediator.Instance.RegisterFactory("UcBillManagement", () => new ucBillManagement());
            Mediator.Instance.RegisterFactory("UcContractManagement", () => new ucContractManagement());
            Mediator.Instance.RegisterFactory("UcIncidentManagement", () => new ucIncidentManagement());
            Mediator.Instance.RegisterFactory("ucBill", () => new ucBill());
            Mediator.Instance.RegisterFactory("ucBillDetail", () => new ucBillDetail());
        }
    }
}