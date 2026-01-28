using API_Server.src.Services1;
using API_Server.src.Models;
using API_Server.src.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Server.src.Controllers
{
    public class ReportController
    {
        private readonly ReportService _reportService;

        public ReportController()
        {
            _reportService = new ReportService();
        }

        public Task<bool> CreateReportAsync(Report report)
        {
            return _reportService.CreateReportAsync(report);
        }

        public Task<List<Report>> GetReportsByOwnerAsync(Guid ownerId)
        {
            return _reportService.GetReportsByOwnerAsync(ownerId);
        }

        public Task<List<Report>> GetReportsByRenterAsync(Guid renterId)
        {
            return _reportService.GetReportsByRenterAsync(renterId);
        }

        public Task<Report?> GetReportByIdAsync(Guid reportId)
        {
            return _reportService.GetReportByIdAsync(reportId);
        }

        public Task<bool> UpdateReportStatusAsync(Guid reportId, string status)
        {
            return _reportService.UpdateReportStatusAsync(reportId, status);
        }

        public Task<ReportStatistics> GetReportStatisticsAsync(Guid ownerId)
        {
            return _reportService.GetReportStatisticsAsync(ownerId);
        }
    }
}
