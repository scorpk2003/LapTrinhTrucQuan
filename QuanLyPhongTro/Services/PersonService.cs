using Microsoft.EntityFrameworkCore;
using QuanLyPhongTro.Data;
using QuanLyPhongTro.Model;
using System;
using System.Linq;

namespace QuanLyPhongTro.Services
{
    public class PersonService
    {
        // Hàm này đã có: Xác thực đăng nhập
        public Person GetAccount(string username, string password)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    // LƯU Ý: Vẫn là cách kiểm tra mật khẩu KHÔNG an toàn.
                    var person = context.Persons
                        // .Include(p => p.PersonDetail) // Thêm Include để tải chi tiết
                        .FirstOrDefault(p => p.Username == username && p.Password == password);

                    return person;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetAccount: {ex.Message}");
                return null;
            }
        }

        // Hàm này đã có: Đăng ký (với Transaction)
        public bool SignUp(Person person, PersonDetailcs personDetail)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            context.PersonDetails.Add(personDetail);
                            context.SaveChanges();

                            person.IdDetail = personDetail.Id;

                            context.Persons.Add(person);
                            context.SaveChanges();

                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            Console.WriteLine($"Lỗi SignUp: {ex.Message}");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi SignUp (Outer): {ex.Message}");
                return false;
            }
        }

        // Hàm này đã có: Lấy chi tiết
        public PersonDetailcs GetPersonDetail(Guid personId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var person = context.Persons
                        .Include(p => p.PersonDetail) // Tải thông tin chi tiết
                        .FirstOrDefault(p => p.Id == personId);

                    return person?.PersonDetail; // Trả về chi tiết
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetPersonDetail: {ex.Message}");
                return null;
            }
        }

        // --- HÀM MỚI ---
        /// <summary>
        /// Cập nhật thông tin chi tiết (Tên, CCCD, SĐT, Avatar)
        /// </summary>
        /// <param name="detailData">Đối tượng PersonDetailcs đã được cập nhật</param>
        /// <returns>True nếu thành công</returns>
        public bool UpdatePersonDetail(PersonDetailcs detailData)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var existingDetail = context.PersonDetails.Find(detailData.Id);
                    if (existingDetail == null)
                    {
                        return false; // Không tìm thấy
                    }

                    // Cập nhật các trường
                    existingDetail.Name = detailData.Name;
                    existingDetail.CCCD = detailData.CCCD;
                    existingDetail.Phone = detailData.Phone;
                    existingDetail.Avatar = detailData.Avatar;

                    context.PersonDetails.Update(existingDetail);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi UpdatePersonDetail: {ex.Message}");
                return false;
            }
        }
    }
}