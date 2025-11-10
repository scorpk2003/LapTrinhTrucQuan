using Microsoft.EntityFrameworkCore;
using QuanLyPhongTro.Data;
using QuanLyPhongTro.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyPhongTro.Services
{
    public class ReportService
    {
        /// <summary>
        /// (Hàm cũ) Dùng cho Người thuê gửi
        /// </summary>
        public bool CreateReport(Report report)
        {
            try
            {
                using (var context = new AppContextDB())
                {
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

        // Cho Chủ trọ
        /// <summary>
        /// Lấy tất cả báo cáo/yêu cầu liên quan đến các phòng của chủ trọ
        /// </summary>
        public List<Report> GetReportsByOwner(Guid ownerId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return context.Reports
                        .Include(r => r.Room)   // Lấy tên phòng
                        .Include(r => r.Reporter) // Lấy tên người báo cáo
                        .Where(r => r.Room.IdOwner == ownerId)
                        .OrderByDescending(r => r.DateCreated) // Mới nhất lên đầu
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetReportsByOwner: {ex.Message}");
                return new List<Report>();
            }
        }

        // Cho Chủ trọ
        /// <summary>
        /// Cập nhật trạng thái (Pending, InProgress, Resolved)
        /// </summary>
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
    }
}