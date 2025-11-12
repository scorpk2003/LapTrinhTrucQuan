using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QuanLyPhongTro.Data;
using QuanLyPhongTro.Model;

namespace QuanLyPhongTro.Services
{
    public class ReportServices
    {
        /// <summary>
        /// Thêm báo cáo mới
        /// </summary>
        public bool AddReport(Report report)
        {
            try
            {
                using var context = new AppContextDB();
                context.Report.Add(report);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi AddReport: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Lấy tất cả báo cáo
        /// </summary>
        public List<Report> GetReports()
        {
            try
            {
                using var context = new AppContextDB();
                return context.Report
                              .Include(r => r.Reporter)
                              .Include(r => r.Room)
                              .AsNoTracking()
                              .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetReports: {ex.Message}");
                return new List<Report>();
            }
        }

        /// <summary>
        /// Lấy báo cáo theo Id
        /// </summary>
        public Report GetReportById(Guid id)
        {
            try
            {
                using var context = new AppContextDB();
                return context.Report
                              .Include(r => r.Reporter)
                              .Include(r => r.Room)
                              .AsNoTracking()
                              .FirstOrDefault(r => r.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetReportById: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Cập nhật trạng thái báo cáo
        /// </summary>
        public bool UpdateReportStatus(Guid id, string status)
        {
            try
            {
                using var context = new AppContextDB();
                var report = context.Report.Find(id);
                if (report == null) return false;

                report.Status = status;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi UpdateReportStatus: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Xóa báo cáo theo Id
        /// </summary>
        public bool DeleteReport(Guid id)
        {
            try
            {
                using var context = new AppContextDB();
                var report = context.Report.Find(id);
                if (report == null) return false;

                context.Report.Remove(report);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi DeleteReport: {ex.Message}");
                return false;
            }
        }
    }
}
