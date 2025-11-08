using QuanLyPhongTro.Data;
using QuanLyPhongTro.Model;
using System;

namespace QuanLyPhongTro.Services
{
    public class ReportService
    {
        public bool CreateReport(Report report)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    //context.Reports.Add(report);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi CreateReport: {ex.Message}");
                return false;
            }
        }
    }
}