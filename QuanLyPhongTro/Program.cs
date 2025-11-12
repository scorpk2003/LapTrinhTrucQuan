using QuanLyPhongTro.src.Mediator;
using QuanLyPhongTro.src.Test;
using System;
using System.Globalization;
using System.Windows.Forms;
using System.Threading;
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
            var culture = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            Mediator.Instance.RegisterFactory("UcBillManagement", () => new ucBillManagement());
            Mediator.Instance.RegisterFactory("UcContractManagement", () => new ucContractManagement());
            Mediator.Instance.RegisterFactory("UcReportManagement", () => new ucReportManagement());
            Mediator.Instance.RegisterFactory("UcIncidentManagement", () => new ucIncidentManagement());

            Mediator.Instance.RegisterFactory("UcMyRoom", () => new ucMyRoom());
            Mediator.Instance.RegisterFactory("UcMyBills", () => new ucMyBills());
            Mediator.Instance.RegisterFactory("UcMyContract", () => new ucMyContract());
            Mediator.Instance.RegisterFactory("UcMyReports", () => new ucMyReports());

            QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;
            ApplicationConfiguration.Initialize();

            // Chạy Form Auth (Form này sẽ tự xử lý việc đăng nhập)
            Application.Run(new AuthForm());
        }
    }
}