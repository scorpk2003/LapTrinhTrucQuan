using Microsoft.EntityFrameworkCore;
using API_Server.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Server.src.DTO;


namespace API_Server.src.Services1
{
    public class ReportService
    {
        /// <summary>
        /// Tạo báo cáo mới
        /// </summary>
        public async Task<bool> CreateReportAsync(Report report)
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

                    await context.Reports.AddAsync(report); // ⭐ Add() → AddAsync()
                    await context.SaveChangesAsync(); // ⭐ SaveChanges() → SaveChangesAsync()
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi CreateReportAsync: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Lấy danh sách Notice của Owner
        /// </summary>
        public async Task<List<Notice>> GetNoticeAsync(Guid ownerId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.Notices // ⭐ Thêm await
                        .Include(p => p.IdreportNavigation)
                        .Include(p => p.IdreportNavigation!.IdReporterNavigation)
                        .Include(p => p.IdreportNavigation!.IdRoomNavigation)
                        .Where(p => p.IdreportNavigation!.IdRoomNavigation!.IdOwner == ownerId)
                        .ToListAsync(); // ⭐ ToList() → ToListAsync()
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetNoticeAsync: {ex.Message}");
                return new List<Notice>();
            }
        }

        /// <summary>
        /// Lấy Report theo Notice ID
        /// </summary>
        public async Task<Report?> GetReportAsync(Guid noticeId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.Reports // ⭐ Thêm await
                        .Where(p => p.Notice!.Id == noticeId)
                        .FirstOrDefaultAsync(); // ⭐ First() → FirstOrDefaultAsync() (tránh exception)
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetReportAsync: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Lấy danh sách Report theo Owner
        /// </summary>
        public async Task<List<Report>> GetReportsByOwnerAsync(Guid? ownerId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.Reports // ⭐ Thêm await
                        .Include(r => r.IdRoomNavigation)
                        .Include(r => r.IdReporterNavigation)
                        .Where(r => r.IdRoomNavigation.IdOwner == ownerId)
                        .OrderByDescending(r => r.DateCreated)
                        .ToListAsync(); // ⭐ ToList() → ToListAsync()
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetReportsByOwnerAsync: {ex.Message}");
                return new List<Report>();
            }
        }

        /// <summary>
        /// Cập nhật trạng thái Report
        /// </summary>
        public async Task<bool> UpdateReportStatusAsync(Guid reportId, string newStatus)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var report = await context.Reports.FindAsync(reportId); // ⭐ Find() → FindAsync()
                    if (report == null) return false;

                    report.Status = newStatus;
                    await context.SaveChangesAsync(); // ⭐ SaveChanges() → SaveChangesAsync()
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi UpdateReportStatusAsync: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Lấy danh sách Report theo Renter
        /// </summary>
        public async Task<List<Report>> GetReportsByRenterAsync(Guid? renterId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.Reports // ⭐ Thêm await
                        .Include(r => r.IdRoomNavigation)
                        .Where(r => r.IdReporter == renterId)
                        .OrderByDescending(r => r.DateCreated)
                        .ToListAsync(); // ⭐ ToList() → ToListAsync()
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetReportsByRenterAsync: {ex.Message}");
                return new List<Report>();
            }
        }

        /// <summary>
        /// Lấy chi tiết Report theo ID
        /// </summary>
        public async Task<Report?> GetReportByIdAsync(Guid reportId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.Reports
                        .Include(r => r.IdRoomNavigation)
                        .Include(r => r.IdReporterNavigation)
                            .ThenInclude(p => p.IdDetailNavigation)
                        .Include(r => r.Notice)
                        .FirstOrDefaultAsync(r => r.Id == reportId);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetReportByIdAsync: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Cập nhật thông tin Report
        /// </summary>
        public async Task<bool> UpdateReportAsync(Report report)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var exists = await context.Reports.AnyAsync(r => r.Id == report.Id);
                    if (!exists) return false;

                    context.Reports.Update(report);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi UpdateReportAsync: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Xóa Report
        /// </summary>
        public async Task<bool> DeleteReportAsync(Guid reportId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var report = await context.Reports
                        .Include(r => r.Notice) // Include Notice để xóa cascade
                        .FirstOrDefaultAsync(r => r.Id == reportId);

                    if (report == null) return false;

                    // Xóa Notice nếu có
                    if (report.Notice != null)
                    {
                        context.Notices.Remove(report.Notice);
                    }

                    context.Reports.Remove(report);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi DeleteReportAsync: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Lấy danh sách Report theo trạng thái
        /// </summary>
        public async Task<List<Report>> GetReportsByStatusAsync(Guid ownerId, string status)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.Reports
                        .Include(r => r.IdRoomNavigation)
                        .Include(r => r.IdReporterNavigation)
                        .Where(r => r.IdRoomNavigation.IdOwner == ownerId && r.Status == status)
                        .OrderByDescending(r => r.DateCreated)
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetReportsByStatusAsync: {ex.Message}");
                return new List<Report>();
            }
        }

        /// <summary>
        /// Lấy Report chưa xử lý (Pending)
        /// </summary>
        public async Task<List<Report>> GetPendingReportsAsync(Guid ownerId)
        {
            return await GetReportsByStatusAsync(ownerId, "Pending");
        }

        /// <summary>
        /// Lấy Report đang xử lý (In Progress)
        /// </summary>
        public async Task<List<Report>> GetInProgressReportsAsync(Guid ownerId)
        {
            return await GetReportsByStatusAsync(ownerId, "In Progress");
        }

        /// <summary>
        /// Lấy Report đã hoàn thành (Completed)
        /// </summary>
        public async Task<List<Report>> GetCompletedReportsAsync(Guid ownerId)
        {
            return await GetReportsByStatusAsync(ownerId, "Completed");
        }

        /// <summary>
        /// Đếm số Report theo trạng thái
        /// </summary>
        public async Task<int> CountReportsByStatusAsync(Guid ownerId, string status)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.Reports
                        .CountAsync(r => r.IdRoomNavigation.IdOwner == ownerId && r.Status == status);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi CountReportsByStatusAsync: {ex.Message}");
                return 0;
            }
        }

        /// <summary>
        /// Lấy thống kê Report
        /// </summary>
        public async Task<ReportStatistics> GetReportStatisticsAsync(Guid ownerId)
        {
            try
            {
                var pendingTask = CountReportsByStatusAsync(ownerId, "Pending");
                var inProgressTask = CountReportsByStatusAsync(ownerId, "In Progress");
                var completedTask = CountReportsByStatusAsync(ownerId, "Completed");

                await Task.WhenAll(pendingTask, inProgressTask, completedTask);

                return new ReportStatistics
                {
                    PendingCount = await pendingTask,
                    InProgressCount = await inProgressTask,
                    CompletedCount = await completedTask,
                    TotalCount = await pendingTask + await inProgressTask + await completedTask
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetReportStatisticsAsync: {ex.Message}");
                return new ReportStatistics();
            }
        }

        /// <summary>
        /// Tìm kiếm Report theo từ khóa
        /// </summary>
        public async Task<List<Report>> SearchReportsAsync(Guid ownerId, string keyword)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.Reports
                        .Include(r => r.IdRoomNavigation)
                        .Include(r => r.IdReporterNavigation)
                        .Where(r => r.IdRoomNavigation.IdOwner == ownerId &&
                                   (r.Title.Contains(keyword) ||
                                    (r.Description != null && r.Description.Contains(keyword))))
                        .OrderByDescending(r => r.DateCreated)
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi SearchReportsAsync: {ex.Message}");
                return new List<Report>();
            }
        }

        /// <summary>
        /// Lấy Report theo phòng
        /// </summary>
        public async Task<List<Report>> GetReportsByRoomAsync(Guid roomId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.Reports
                        .Include(r => r.IdReporterNavigation)
                        .Where(r => r.IdRoom == roomId)
                        .OrderByDescending(r => r.DateCreated)
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetReportsByRoomAsync: {ex.Message}");
                return new List<Report>();
            }
        }

        /// <summary>
        /// Lấy Report trong khoảng thời gian
        /// </summary>
        public async Task<List<Report>> GetReportsByDateRangeAsync(
            Guid ownerId,
            DateTime fromDate,
            DateTime toDate)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.Reports
                        .Include(r => r.IdRoomNavigation)
                        .Include(r => r.IdReporterNavigation)
                        .Where(r => r.IdRoomNavigation.IdOwner == ownerId &&
                                   r.DateCreated.HasValue &&
                                   r.DateCreated.Value >= fromDate &&
                                   r.DateCreated.Value <= toDate)
                        .OrderByDescending(r => r.DateCreated)
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetReportsByDateRangeAsync: {ex.Message}");
                return new List<Report>();
            }
        }

        /// <summary>
        /// Đánh dấu Report là đã xem
        /// </summary>
        public async Task<bool> MarkAsReadAsync(Guid reportId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var report = await context.Reports.FindAsync(reportId);
                    if (report == null) return false;

                    // Nếu có thêm trường IsRead trong model
                    // report.IsRead = true;

                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi MarkAsReadAsync: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Tạo Report với Notice
        /// </summary>
        public async Task<bool> CreateReportWithNoticeAsync(Report report, Notice notice)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    using (var transaction = await context.Database.BeginTransactionAsync())
                    {
                        try
                        {
                            // Tạo Report
                            report.DateCreated = DateTime.Now;
                            if (string.IsNullOrEmpty(report.Status))
                            {
                                report.Status = "Pending";
                            }

                            await context.Reports.AddAsync(report);
                            await context.SaveChangesAsync();

                            // Tạo Notice
                            notice.Idreport = report.Id;
                            notice.CreatedAt = DateTime.Now;
                            await context.Notices.AddAsync(notice);
                            await context.SaveChangesAsync();

                            await transaction.CommitAsync();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            await transaction.RollbackAsync();
                            Console.WriteLine($"Lỗi CreateReportWithNoticeAsync (Transaction): {ex.Message}");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi CreateReportWithNoticeAsync: {ex.Message}");
                return false;
            }
        }
    }
}
    
    