using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using QuanLyPhongTro.Models;

namespace QuanLyPhongTro.Services
{
    public class PersonDetailServices
    {
        /// <summary>
        /// Lấy chi tiết người dùng theo Id
        /// </summary>
        public PersonDetail GetPersonDetailById(Guid id)
        {
            try
            {
                using var context = new AppContextDB();
                return context.PersonDetails
                              .AsNoTracking()
                              .FirstOrDefault(pd => pd.Id == id);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi GetPersonDetailById: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Thêm chi tiết người dùng mới
        /// </summary>
        public bool AddPersonDetail(PersonDetail detail)
        {
            try
            {
                using var context = new AppContextDB();
                context.PersonDetails.Add(detail);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi AddPersonDetail: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Cập nhật chi tiết người dùng
        /// </summary>
        public bool UpdatePersonDetail(PersonDetail detail)
        {
            try
            {
                using var context = new AppContextDB(); context.PersonDetails.Update(detail);
                var existing = context.PersonDetails.Find(detail.Id);
                if (existing == null) return false;

                existing.Name = detail.Name;
                existing.Cccd = detail.Cccd;
                existing.Phone = detail.Phone;
                existing.Avatar = detail.Avatar;

                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi UpdatePersonDetail: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Xóa chi tiết người dùng theo Id
        /// </summary>
        public bool DeletePersonDetail(Guid id)
        {
            try
            {
                using var context = new AppContextDB();
                var detail = context.PersonDetails.Find(id);
                if (detail == null) return false;

                context.PersonDetails.Remove(detail);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi DeletePersonDetail: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Lấy tất cả chi tiết người dùng
        /// </summary>
        public List<PersonDetail> GetAllPersonDetails()
        {
            try
            {
                using var context = new AppContextDB();
                return context.PersonDetails.AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi GetAllPersonDetails: {ex.Message}");
                return new List<PersonDetail>();
            }
        }
    }
}
