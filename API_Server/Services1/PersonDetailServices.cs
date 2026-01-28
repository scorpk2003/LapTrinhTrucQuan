using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using API_Server.src.Models;
using System.Threading.Tasks;

namespace API_Server.src.Services1
{
    public class PersonDetailServices
    {
        /// <summary>
        /// L?y chi ti?t ngu?i dùng theo Id
        /// </summary>
        public async Task<PersonDetail> GetPersonDetailByIdAsync(Guid id)
        {
            try
            {
                using var context = new AppContextDB();
                return await context.PersonDetails
                              .AsNoTracking()
                              .FirstOrDefaultAsync(pd => pd.Id == id);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"L?i GetPersonDetailById: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Thêm chi ti?t ngu?i dùng m?i
        /// </summary>
        public async Task<bool> AddPersonDetailAsync(PersonDetail detail)
        {
            try
            {
                using var context = new AppContextDB();
                await context.PersonDetails.AddAsync(detail);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"L?i AddPersonDetail: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// C?p nh?t chi ti?t ngu?i dùng
        /// </summary>
        public async Task<bool> UpdatePersonDetailAsync(PersonDetail detail)
        {
            try
            {
                using var context = new AppContextDB();
                context.PersonDetails.Update(detail);
                Person? people = await context.People.FindAsync(detail.Person!.Id);
                people!.Username = detail.Name!;
                context.People.Update(people);

                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"L?i UpdatePersonDetail: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Xóa chi ti?t ngu?i dùng theo Id
        /// </summary>
        public async Task<bool> DeletePersonDetailAsync(Guid id)
        {
            try
            {
                using var context = new AppContextDB();
                var detail = await context.PersonDetails.FindAsync(id);
                if (detail == null) return false;

                context.PersonDetails.Remove(detail);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"L?i DeletePersonDetail: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// L?y t?t c? chi ti?t ngu?i dùng
        /// </summary>
        public async Task<List<PersonDetail>> GetAllPersonDetailsAsync()
        {
            try
            {
                using var context = new AppContextDB();
                return await context.PersonDetails.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"L?i GetAllPersonDetails: {ex.Message}");
                return new List<PersonDetail>();
            }
        }

        /// <summary>
        /// Tìm kiếm chi tiết người dùng theo CCCD
        /// </summary>
        public async Task<PersonDetail> GetByCardIdAsync(string cccd)
        {
            try
            {
                using var context = new AppContextDB();
                return await context.PersonDetails
                    .AsNoTracking()
                    .FirstOrDefaultAsync(pd => pd.Cccd == cccd);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi GetByCardIdAsync: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Tìm kiếm chi tiết người dùng theo số điện thoại
        /// </summary>
        public async Task<PersonDetail> GetByPhoneAsync(string phone)
        {
            try
            {
                using var context = new AppContextDB();
                return await context.PersonDetails
                    .AsNoTracking()
                    .FirstOrDefaultAsync(pd => pd.Phone == phone);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi GetByPhoneAsync: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Tìm kiếm chi tiết người dùng theo email
        /// </summary>
        public async Task<PersonDetail> GetByEmailAsync(string email)
        {
            try
            {
                using var context = new AppContextDB();
                return await context.PersonDetails
                    .AsNoTracking()
                    .FirstOrDefaultAsync(pd => pd.Gmail == email);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi GetByEmailAsync: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Tìm kiếm chi tiết người dùng theo tên (tìm kiếm gần đúng)
        /// </summary>
        public async Task<List<PersonDetail>> SearchByNameAsync(string keyword)
        {
            try
            {
                using var context = new AppContextDB();
                return await context.PersonDetails
                    .AsNoTracking()
                    .Where(pd => pd.Name != null && pd.Name.Contains(keyword))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi SearchByNameAsync: {ex.Message}");
                return new List<PersonDetail>();
            }
        }

        /// <summary>
        /// Kiểm tra CCCD đã tồn tại chưa
        /// </summary>
        public async Task<bool> IsCccdExistsAsync(string cccd, Guid? excludeId = null)
        {
            try
            {
                using var context = new AppContextDB();

                var query = context.PersonDetails.Where(pd => pd.Cccd == cccd);

                // Loại trừ ID hiện tại khi update
                if (excludeId.HasValue)
                {
                    query = query.Where(pd => pd.Id != excludeId.Value);
                }

                return await query.AnyAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi IsCccdExistsAsync: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra số điện thoại đã tồn tại chưa
        /// </summary>
        public async Task<bool> IsPhoneExistsAsync(string phone, Guid? excludeId = null)
        {
            try
            {
                using var context = new AppContextDB();

                var query = context.PersonDetails.Where(pd => pd.Phone == phone);

                if (excludeId.HasValue)
                {
                    query = query.Where(pd => pd.Id != excludeId.Value);
                }

                return await query.AnyAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi IsPhoneExistsAsync: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra email đã tồn tại chưa
        /// </summary>
        public async Task<bool> IsEmailExistsAsync(string email, Guid? excludeId = null)
        {
            try
            {
                using var context = new AppContextDB();

                var query = context.PersonDetails.Where(pd => pd.Gmail == email);

                if (excludeId.HasValue)
                {
                    query = query.Where(pd => pd.Id != excludeId.Value);
                }

                return await query.AnyAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi IsEmailExistsAsync: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Lấy danh sách người dùng theo giới tính
        /// </summary>
        public async Task<List<PersonDetail>> GetByGenderAsync(string gender)
        {
            try
            {
                using var context = new AppContextDB();
                return await context.PersonDetails
                    .AsNoTracking()
                    .Where(pd => pd.Gender == gender)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi GetByGenderAsync: {ex.Message}");
                return new List<PersonDetail>();
            }
        }

        /// <summary>
        /// Đếm tổng số người dùng
        /// </summary>
        public async Task<int> CountAllAsync()
        {
            try
            {
                using var context = new AppContextDB();
                return await context.PersonDetails.CountAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi CountAllAsync: {ex.Message}");
                return 0;
            }
        }

        /// <summary>
        /// Cập nhật avatar người dùng
        /// </summary>
        public async Task<bool> UpdateAvatarAsync(Guid id, byte[] avatarData)
        {
            try
            {
                using var context = new AppContextDB();
                var detail = await context.PersonDetails.FindAsync(id);
                if (detail == null) return false;

                detail.Avatar = avatarData;
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi UpdateAvatarAsync: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Cập nhật ảnh CCCD người dùng
        /// </summary>
        public async Task<bool> UpdateCccdImageAsync(Guid id, byte[] cccdImageData)
        {
            try
            {
                using var context = new AppContextDB();
                var detail = await context.PersonDetails.FindAsync(id);
                if (detail == null) return false;

                detail.CccdImage = cccdImageData;
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi UpdateCccdImageAsync: {ex.Message}");
                return false;
            }

        }
        /// <summary>
        /// Lấy chi tiết người dùng kèm thông tin Person
        /// </summary>
        public async Task<PersonDetail> GetPersonDetailWithPersonAsync(Guid id)
        {
            try
            {
                using var context = new AppContextDB();
                return await context.PersonDetails
                    .Include(pd => pd.Person) // Load thông tin Person
                    .FirstOrDefaultAsync(pd => pd.Id == id);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi GetPersonDetailWithPersonAsync: {ex.Message}");
                return null;
            }
        }
    }
        }
