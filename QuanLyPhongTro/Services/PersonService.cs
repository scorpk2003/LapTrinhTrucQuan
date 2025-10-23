using Microsoft.EntityFrameworkCore;
using QuanLyPhongTro.Data;
using QuanLyPhongTro.Model;
using System;
using System.Linq;

namespace QuanLyPhongTro.Services
{
    public class PersonService
    {
        // GetAccount(UserName, Password) -> idUser, Role
        /// <summary>
        /// Xác thực đăng nhập
        /// </summary>
        /// <param name="username">Tên đăng nhập</param>
        /// <param name="password">Mật khẩu</param>
        /// <returns>Trả về đối tượng Person nếu thành công, null nếu thất bại</returns>
        public Person GetAccount(string username, string password)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    // LƯU Ý: Đây là cách kiểm tra mật khẩu KHÔNG an toàn.
                    // Trong thực tế, bạn phải HASH mật khẩu khi đăng ký và so sánh HASH ở đây.
                    var person = context.Persons
                        .FirstOrDefault(p => p.Username == username && p.Password == password);

                    return person; // Sẽ là null nếu không tìm thấy
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetAccount: {ex.Message}");
                return null;
            }
        }

        // SignUp(Person) -> Add Person, Person Detail
        /// <summary>
        /// Đăng ký tài khoản mới. Tự động lưu Person và PersonDetail.
        /// </summary>
        /// <param name="person">Đối tượng Person (chứa Username, Password, Role)</param>
        /// <param name="personDetail">Đối tượng PersonDetailcs (chứa Name, CCCD, Phone)</param>
        /// <returns>True nếu đăng ký thành công</returns>
        public bool SignUp(Person person, PersonDetailcs personDetail)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    // Sử dụng Transaction để đảm bảo cả 2 đều được lưu hoặc không gì cả
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            // 1. Lưu PersonDetail trước để lấy ID
                            context.PersonDetails.Add(personDetail);
                            context.SaveChanges();

                            // 2. Gán ID của Detail cho Person
                            person.IdDetail = personDetail.Id;

                            // 3. Lưu Person
                            context.Persons.Add(person);
                            context.SaveChanges();

                            // 4. Hoàn tất
                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback(); // Hoàn tác nếu có lỗi
                            Console.WriteLine($"Lỗi SignUp (Transaction): {ex.Message}");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi SignUp: {ex.Message}");
                return false;
            }
        }

        // Information(idPerson) -> GetPersonDetail
        /// <summary>
        /// Lấy thông tin chi tiết của một người
        /// </summary>
        /// <param name="personId">ID của Person</param>
        /// <returns>Đối tượng PersonDetailcs</returns>
        public PersonDetailcs GetPersonDetail(Guid personId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    // Tìm Person, sau đó include (tham chiếu) đến PersonDetail
                    var person = context.Persons
                        .Include(p => p.PersonDetail) // Tải thông tin chi tiết
                        .FirstOrDefault(p => p.Id == personId);

                    return person?.PersonDetail; // Trả về chi tiết, có thể là null
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetPersonDetail: {ex.Message}");
                return null;
            }
        }
    }
}