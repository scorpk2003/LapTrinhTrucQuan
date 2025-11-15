using Microsoft.EntityFrameworkCore;

using QuanLyPhongTro.Models;
using System;

namespace QuanLyPhongTro.Services
{
    public class ReportService
    {
        //Done
        public bool CreateReport(Report report)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    System.Diagnostics.Debug.WriteLine($"\n\n\n\t{context.Database.GetConnectionString}\n\n\n");
                    context.Reports.Add(report);
                    context.SaveChanges();
                    System.Diagnostics.Debug.WriteLine("Tạo báo cáo thành công.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi CreateReport: {ex.InnerException?.Message ?? ex.Message}");
                return false;
            }
        }
    }
}