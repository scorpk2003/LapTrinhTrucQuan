using Microsoft.EntityFrameworkCore;
using QuanLyPhongTro.src.Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
                    report.DateCreated = DateTime.Now;
                    if (string.IsNullOrEmpty(report.Status))
                    {
                        report.Status = "Pending";
                    }
                    context.Reports.Add(report);
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

        public List<Report> GetReportsByOwner(Guid ownerId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return context.Reports
                        .Include(r => r.IdRoomNavigation)
                        .Include(r => r.IdReporterNavigation)
                        .Where(r => r.IdRoomNavigation.IdOwner == ownerId)
                        .OrderByDescending(r => r.DateCreated)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetReportsByOwner: {ex.Message}");
                return new List<Report>();
            }
        }

        public bool UpdateReportStatus(Guid reportId, string newStatus)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var report = context.Reports.Find(reportId); 
                    if (report == null) return false;

                    report.Status = newStatus;
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi UpdateReportStatus: {ex.Message}");
                return false;
            }
        }

        public List<Report> GetReportsByRenter(Guid renterId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return context.Reports 
                        .Include(r => r.IdRoomNavigation)
                        .Where(r => r.IdReporter == renterId)
                        .OrderByDescending(r => r.DateCreated)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetReportsByRenter: {ex.Message}");
                return new List<Report>();
            }
        }
    }
}