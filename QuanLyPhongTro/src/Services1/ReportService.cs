using Microsoft.EntityFrameworkCore;
using QuanLyPhongTro.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyPhongTro.src.Services1
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

        public List<Notice> GetNotice(Guid ownerID)
        {
            List<Notice> notices = new List<Notice>();
            try
            {
                using (var context = new AppContextDB())
                {
                    return context.Notices
                        .Include(p => p.IdreportNavigation)
                        .Include(p => p.IdreportNavigation!.IdReporterNavigation)
                        .Include(p => p.IdreportNavigation!.IdRoomNavigation)
                        .Where(p => p.IdreportNavigation!.IdRoomNavigation!.IdOwner == ownerID)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Get Notice: {ex.Message}");
            }
        }

        public Report? GetReport(Guid nocticeID)
        {
            Report rp = new();
            try
            {
                using (var context = new AppContextDB())
                {
                    return context.Reports
                        .Where(p => p.Notice!.Id == nocticeID)
                        .First();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Get Report: {ex.Message}");
            }
        }

        public List<Report> GetReportsByOwner(Guid? ownerId)
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

        public List<Report> GetReportsByRenter(Guid? renterId)
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