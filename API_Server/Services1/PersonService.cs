using Microsoft.EntityFrameworkCore;
using API_Server.src.Models;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace API_Server.src.Services1
{
    public class PersonService
    {
        public async Task< Person?> GetAccountAsync(string username, string password)
        {
            using (var context = new AppContextDB())
            {
                try
                {
                
                    Person? person = await context.People
                        .Include(p => p.IdDetailNavigation)
                        .FirstOrDefaultAsync(p => p.IdDetailNavigation!.Gmail == username && p.Password == password);
                    return person;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi GetAccount: {ex.Message}");
                    return null;
                }
            }
        }

        public async Task <Person> GetByIdAsync(Guid personId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.People.FindAsync(personId); 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetById: {ex.Message}");
                return null;
            }
        }

        public async Task <bool> SignUpAsync(Person? person)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                  await  context.People.AddAsync(person!);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi SignUp (Outer): {ex.Message}");
                return false;
            }
        }

        public async Task <PersonDetail> GetPersonDetailAsync(Guid detailId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.PersonDetails.FindAsync(detailId);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetPersonDetail: {ex.Message}");
                return null;
            }
        }

        public async Task < bool> UpdatePersonDetailAsync(PersonDetail detailData)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var existingDetail = await context.PersonDetails.FindAsync(detailData.Id); // Sửa
                    if (existingDetail == null) return false;
                    existingDetail.Name = detailData.Name;
                    existingDetail.Cccd = detailData.Cccd;
                    existingDetail.Phone = detailData.Phone;
                    existingDetail.Gender = detailData.Gender;
                    existingDetail.Gmail = detailData.Gmail;

                    if (detailData.Avatar != null && detailData.Avatar.Length > 0)
                    {
                        existingDetail.Avatar = detailData.Avatar;
                    }
                    if (detailData.CccdImage != null && detailData.CccdImage.Length > 0)
                    {
                        existingDetail.CccdImage = detailData.CccdImage;
                    }

                    context.PersonDetails.Update(existingDetail);
                     await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi UpdatePersonDetail: {ex.Message}");
                return false;
            }
        }
        /// <summary>
        /// Lấy Person kèm PersonDetail
        /// </summary>
        public async Task<Person?> GetPersonWithDetailAsync(Guid personId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.People
                        .Include(p => p.IdDetailNavigation)
                        .FirstOrDefaultAsync(p => p.Id == personId);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetPersonWithDetailAsync: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Kiểm tra email đã tồn tại chưa
        /// </summary>
        public async Task<bool> IsEmailExistsAsync(string email)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.PersonDetails
                        .AnyAsync(pd => pd.Gmail == email);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi IsEmailExistsAsync: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra username đã tồn tại chưa
        /// </summary>
        public async Task<bool> IsUsernameExistsAsync(string username)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.People
                        .AnyAsync(p => p.Username == username);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi IsUsernameExistsAsync: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Đổi mật khẩu
        /// </summary>
        public async Task<bool> ChangePasswordAsync(Guid personId, string oldPassword, string newPassword)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var person = await context.People.FindAsync(personId);
                    if (person == null) return false;

                    // Kiểm tra mật khẩu cũ
                    if (person.Password != oldPassword)
                        return false;

                    // Cập nhật mật khẩu mới
                    person.Password = newPassword;
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ChangePasswordAsync: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Cập nhật thông tin Person
        /// </summary>
        public async Task<bool> UpdatePersonAsync(Person person)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var exists = await context.People.AnyAsync(p => p.Id == person.Id);
                    if (!exists) return false;

                    context.People.Update(person);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi UpdatePersonAsync: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Xóa Person (và PersonDetail nếu có)
        /// </summary>
        public async Task<bool> DeletePersonAsync(Guid personId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    using (var transaction = await context.Database.BeginTransactionAsync())
                    {
                        try
                        {
                            var person = await context.People
                                .Include(p => p.IdDetailNavigation)
                                .FirstOrDefaultAsync(p => p.Id == personId);

                            if (person == null) return false;

                            // Xóa PersonDetail nếu có
                            if (person.IdDetailNavigation != null)
                            {
                                context.PersonDetails.Remove(person.IdDetailNavigation);
                            }

                            // Xóa Person
                            context.People.Remove(person);

                            await context.SaveChangesAsync();
                            await transaction.CommitAsync();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            await transaction.RollbackAsync();
                            Console.WriteLine($"Lỗi DeletePersonAsync (Transaction): {ex.Message}");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi DeletePersonAsync: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Lấy tất cả Person theo Role
        /// </summary>
        public async Task<List<Person>> GetPeopleByRoleAsync(string role)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.People
                        .Include(p => p.IdDetailNavigation)
                        .Where(p => p.Role == role)
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetPeopleByRoleAsync: {ex.Message}");
                return new List<Person>();
            }
        }

        /// <summary>
        /// Lấy tất cả Owner
        /// </summary>
        public async Task<List<Person>> GetAllOwnersAsync()
        {
            return await GetPeopleByRoleAsync("Owner");
        }

        /// <summary>
        /// Lấy tất cả Renter
        /// </summary>
        public async Task<List<Person>> GetAllRentersAsync()
        {
            return await GetPeopleByRoleAsync("Renter");
        }

        /// <summary>
        /// Tìm kiếm người dùng theo tên hoặc email
        /// </summary>
        public async Task<List<Person>> SearchPeopleAsync(string keyword)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.People
                        .Include(p => p.IdDetailNavigation)
                        .Where(p => p.Username.Contains(keyword) ||
                                   (p.IdDetailNavigation != null &&
                                    (p.IdDetailNavigation.Name!.Contains(keyword) ||
                                     p.IdDetailNavigation.Gmail!.Contains(keyword))))
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi SearchPeopleAsync: {ex.Message}");
                return new List<Person>();
            }
        }

        /// <summary>
        /// Đếm số lượng người dùng theo Role
        /// </summary>
        public async Task<int> CountByRoleAsync(string role)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.People
                        .CountAsync(p => p.Role == role);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi CountByRoleAsync: {ex.Message}");
                return 0;
            }
        }

        /// <summary>
        /// Lấy tất cả người dùng
        /// </summary>
        public async Task<List<Person>> GetAllPeopleAsync()
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.People
                        .Include(p => p.IdDetailNavigation)
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetAllPeopleAsync: {ex.Message}");
                return new List<Person>();
            }
        }

        /// <summary>
        /// Đăng ký tài khoản với PersonDetail
        /// </summary>
        public async Task<bool> SignUpWithDetailAsync(Person person, PersonDetail detail)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    using (var transaction = await context.Database.BeginTransactionAsync())
                    {
                        try
                        {
                            // Tạo PersonDetail trước
                            detail.Id = Guid.NewGuid();
                            await context.PersonDetails.AddAsync(detail);
                            await context.SaveChangesAsync();

                            // Tạo Person và liên kết với PersonDetail
                            person.IdDetail = detail.Id;
                            await context.People.AddAsync(person);
                            await context.SaveChangesAsync();

                            await transaction.CommitAsync();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            await transaction.RollbackAsync();
                            Console.WriteLine($"Lỗi SignUpWithDetailAsync (Transaction): {ex.Message}");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi SignUpWithDetailAsync: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Reset mật khẩu (dành cho admin)
        /// </summary>
        public async Task<bool> ResetPasswordAsync(Guid personId, string newPassword)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var person = await context.People.FindAsync(personId);
                    if (person == null) return false;

                    person.Password = newPassword;
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ResetPasswordAsync: {ex.Message}");
                return false;
            }
        }
    }
}