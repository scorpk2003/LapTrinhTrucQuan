using Microsoft.EntityFrameworkCore;
using QuanLyPhongTro.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyPhongTro.src.Services1
{
    public class ServiceServices
    {
        /// <summary>
        /// L?y t?t c? d?ch v?
        /// </summary>
        public List<Service> GetAllServices()
        {
            try
            {
                using var context = new AppContextDB();
                return context.Services.AsNoTracking().OrderBy(s => s.Name).ToList();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi GetAllServices: {ex.Message}");
                return new List<Service>();
            }
        }

        /// <summary>
        /// L?y d?ch v? theo Id
        /// </summary>
        public Service? GetServiceById(Guid id)
        {
            try
            {
                using var context = new AppContextDB();
                return context.Services.AsNoTracking().FirstOrDefault(s => s.Id == id);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi GetServiceById: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Thêm d?ch v?
        /// </summary>
        public bool AddService(Service service)
        {
            try
            {
                using var context = new AppContextDB();
                service.Id = Guid.NewGuid();
                context.Services.Add(service);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi AddService: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// C?p nh?t d?ch v?
        /// </summary>
        public bool UpdateService(Service service)
        {
            try
            {
                using var context = new AppContextDB();
                var existing = context.Services.FirstOrDefault(s => s.Id == service.Id);
                if (existing == null) return false;

                existing.Name = service.Name;
                existing.Unit = service.Unit;
                existing.PricePerUnit = service.PricePerUnit;

                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi UpdateService: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Xóa d?ch v? theo Id
        /// </summary>
        public bool DeleteService(Guid serviceId)
        {
            try
            {
                using var context = new AppContextDB();
                var service = context.Services.FirstOrDefault(s => s.Id == serviceId);
                if (service == null) return false;

                context.Services.Remove(service);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi DeleteService: {ex.Message}");
                return false;
            }
        }
    }
}
