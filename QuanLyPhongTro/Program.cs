
using QuanLyPhongTro.src.Login;
using QuanLyPhongTro.src.Mediator;

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
            RegisterFactory();
            Application.Run(new Loginmain());
        }

        static void RegisterFactory()
        {
            Mediator.Instance.RegisterFactory("UcBillManagement", () => new ucBillManagement());
            Mediator.Instance.RegisterFactory("UcContractManagement", () => new ucContractManagement());
            Mediator.Instance.RegisterFactory("UcIncidentManagement", () => new ucIncidentManagement());
        }
    }
}