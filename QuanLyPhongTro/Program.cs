using QuanLyPhongTro.src;
using QuanLyPhongTro.src.Components;
using QuanLyPhongTro.src.Login;
using QuanLyPhongTro.src.Mediator;
using System.Globalization;

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
            // Owner UserControls
            Mediator.Instance.RegisterFactory("UcBillManagement", () => new ucBillManagement());
            Mediator.Instance.RegisterFactory("UcContractManagement", () => new ucContractManagement());
            Mediator.Instance.RegisterFactory("UcReportManagement", () => new ucReportManagement());
            Mediator.Instance.RegisterFactory("UcIncidentManagement", () => new ucIncidentManagement());

            // Renter UserControls
            Mediator.Instance.RegisterFactory("UcMyRoom", () => new ucMyRoom());
            Mediator.Instance.RegisterFactory("UcMyBills", () => new ucMyBills());
            Mediator.Instance.RegisterFactory("UcMyContract", () => new ucMyContract());
            Mediator.Instance.RegisterFactory("UcMyReports", () => new ucMyReports());
            Mediator.Instance.RegisterFactory("UcPendingContracts", () => new ucPendingContracts());

            // Component UserControls (legacy)
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