using QuanLyPhongTro.src.Login;
using QuanLyPhongTro.src.Mediator;
using QuanLyPhongTro.src.Components;
using QuanLyPhongTro.src;

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
            Mediator.Instance.RegisterFactory("ucListRoom", () => new ucListRoom());
            Mediator.Instance.RegisterFactory("ucNotice", () => new ucNotice());
            Mediator.Instance.RegisterFactory("ucReport", () => new ucReport());
            Mediator.Instance.RegisterFactory("ucRoom", () => new ucRoom());
            Mediator.Instance.RegisterFactory("ucRoomDetail", () => new ucRoomDetail());
            Mediator.Instance.RegisterFactory("ucUser", () => new ucUser());
        }
    }
}