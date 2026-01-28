using Microsoft.EntityFrameworkCore;
using API_Server.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Server.src.DTO;

namespace API_Server.src.Services1
{
    public class ServiceServices
    {
        /// <summary>
        /// Lấy tất cả dịch vụ
        /// </summary>
        public async Task<List<Service>> GetAllServicesAsync()
        {
            try
            {
                using var context = new AppContextDB();
                return await context.Services // ⭐ Thêm await
                    .AsNoTracking()
                    .OrderBy(s => s.Name)
                    .ToListAsync(); // ⭐ ToList() → ToListAsync()
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi GetAllServicesAsync: {ex.Message}");
                return new List<Service>();
            }
        }

        /// <summary>
        /// Lấy dịch vụ theo Id
        /// </summary>
        public async Task<Service?> GetServiceByIdAsync(Guid id)
        {
            try
            {
                using var context = new AppContextDB();
                return await context.Services // ⭐ Thêm await
                    .AsNoTracking()
                    .FirstOrDefaultAsync(s => s.Id == id); // ⭐ FirstOrDefault() → FirstOrDefaultAsync()
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi GetServiceByIdAsync: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Thêm dịch vụ
        /// </summary>
        public async Task<bool> AddServiceAsync(Service service)
        {
            try
            {
                using var context = new AppContextDB();
                service.Id = Guid.NewGuid();
                await context.Services.AddAsync(service); // ⭐ Add() → AddAsync()
                await context.SaveChangesAsync(); // ⭐ SaveChanges() → SaveChangesAsync()
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi AddServiceAsync: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Cập nhật dịch vụ
        /// </summary>
        public async Task<bool> UpdateServiceAsync(Service service)
        {
            try
            {
                using var context = new AppContextDB();
                var existing = await context.Services.FirstOrDefaultAsync(s => s.Id == service.Id); // ⭐ FirstOrDefault() → FirstOrDefaultAsync()
                if (existing == null) return false;

                existing.Name = service.Name;
                existing.Unit = service.Unit;
                existing.PricePerUnit = service.PricePerUnit;

                await context.SaveChangesAsync(); // ⭐ SaveChanges() → SaveChangesAsync()
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi UpdateServiceAsync: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Xóa dịch vụ theo Id
        /// </summary>
        public async Task<bool> DeleteServiceAsync(Guid serviceId)
        {
            try
            {
                using var context = new AppContextDB();
                var service = await context.Services.FirstOrDefaultAsync(s => s.Id == serviceId); // ⭐ FirstOrDefault() → FirstOrDefaultAsync()
                if (service == null) return false;

                context.Services.Remove(service);
                await context.SaveChangesAsync(); // ⭐ SaveChanges() → SaveChangesAsync()
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi DeleteServiceAsync: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Tìm kiếm dịch vụ theo tên
        /// </summary>
        public async Task<List<Service>> SearchServicesAsync(string keyword)
        {
            try
            {
                using var context = new AppContextDB();
                return await context.Services
                    .AsNoTracking()
                    .Where(s => s.Name.Contains(keyword))
                    .OrderBy(s => s.Name)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi SearchServicesAsync: {ex.Message}");
                return new List<Service>();
            }
        }

        /// <summary>
        /// Lấy dịch vụ theo đơn vị
        /// </summary>
        public async Task<List<Service>> GetServicesByUnitAsync(string unit)
        {
            try
            {
                using var context = new AppContextDB();
                return await context.Services
                    .AsNoTracking()
                    .Where(s => s.Unit == unit)
                    .OrderBy(s => s.Name)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi GetServicesByUnitAsync: {ex.Message}");
                return new List<Service>();
            }
        }

        /// <summary>
        /// Lấy dịch vụ theo khoảng giá
        /// </summary>
        public async Task<List<Service>> GetServicesByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            try
            {
                using var context = new AppContextDB();
                return await context.Services
                    .AsNoTracking()
                    .Where(s => s.PricePerUnit >= minPrice && s.PricePerUnit <= maxPrice)
                    .OrderBy(s => s.PricePerUnit)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi GetServicesByPriceRangeAsync: {ex.Message}");
                return new List<Service>();
            }
        }

        /// <summary>
        /// Kiểm tra tên dịch vụ đã tồn tại chưa
        /// </summary>
        public async Task<bool> IsServiceNameExistsAsync(string name, Guid? excludeId = null)
        {
            try
            {
                using var context = new AppContextDB();

                var query = context.Services.Where(s => s.Name == name);

                // Loại trừ ID hiện tại khi update
                if (excludeId.HasValue)
                {
                    query = query.Where(s => s.Id != excludeId.Value);
                }

                return await query.AnyAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi IsServiceNameExistsAsync: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Đếm tổng số dịch vụ
        /// </summary>
        public async Task<int> CountServicesAsync()
        {
            try
            {
                using var context = new AppContextDB();
                return await context.Services.CountAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi CountServicesAsync: {ex.Message}");
                return 0;
            }
        }

        /// <summary>
        /// Lấy thống kê dịch vụ
        /// </summary>
        public async Task<ServiceStatistics> GetServiceStatisticsAsync()
        {
            try
            {
                using var context = new AppContextDB();
                var services = await context.Services.ToListAsync();

                if (!services.Any())
                {
                    return new ServiceStatistics();
                }

                return new ServiceStatistics
                {
                    TotalServices = services.Count,
                    AveragePrice = services.Average(s => s.PricePerUnit ?? 0),
                    MinPrice = services.Min(s => s.PricePerUnit ?? 0),
                    MaxPrice = services.Max(s => s.PricePerUnit ?? 0),
                    TotalRevenue = await GetTotalServiceRevenueAsync()
                };
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi GetServiceStatisticsAsync: {ex.Message}");
                return new ServiceStatistics();
            }
        }

        /// <summary>
        /// Tính tổng doanh thu từ dịch vụ
        /// </summary>
        private async Task<decimal> GetTotalServiceRevenueAsync()
        {
            try
            {
                using var context = new AppContextDB();
                return await context.BillDetails
                    .SumAsync(bd => bd.Total ?? 0);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi GetTotalServiceRevenueAsync: {ex.Message}");
                return 0;
            }
        }




        /// <summary>
        /// Kiểm tra dịch vụ có đang được sử dụng không
        /// </summary>
        public async Task<bool> IsServiceInUseAsync(Guid serviceId)
        {
            try
            {
                using var context = new AppContextDB();
                return await context.BillDetails
                    .AnyAsync(bd => bd.IdService == serviceId);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi IsServiceInUseAsync: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Lấy danh sách đơn vị duy nhất
        /// </summary>
        public async Task<List<string>> GetDistinctUnitsAsync()
        {
            try
            {
                using var context = new AppContextDB();
                return await context.Services
                    .Where(s => !string.IsNullOrEmpty(s.Unit))
                    .Select(s => s.Unit)
                    .Distinct()
                    .OrderBy(u => u)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi GetDistinctUnitsAsync: {ex.Message}");
                return new List<string>();
            }
        }

        /// <summary>
        /// Cập nhật giá dịch vụ hàng loạt
        /// </summary>
        public async Task<bool> BulkUpdatePriceAsync(List<Guid> serviceIds, decimal newPrice)
        {
            try
            {
                using var context = new AppContextDB();
                var services = await context.Services
                    .Where(s => serviceIds.Contains(s.Id))
                    .ToListAsync();

                foreach (var service in services)
                {
                    service.PricePerUnit = newPrice;
                }

                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi BulkUpdatePriceAsync: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Tăng/giảm giá theo phần trăm
        /// </summary>
        public async Task<bool> AdjustPriceByPercentageAsync(Guid serviceId, decimal percentage)
        {
            try
            {
                using var context = new AppContextDB();
                var service = await context.Services.FindAsync(serviceId);
                if (service == null) return false;

                var currentPrice = service.PricePerUnit ?? 0;
                service.PricePerUnit = currentPrice * (1 + percentage / 100);

                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi AdjustPriceByPercentageAsync: {ex.Message}");
                return false;
            }
        }
    }
}