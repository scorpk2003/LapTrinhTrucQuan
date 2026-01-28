using Microsoft.EntityFrameworkCore;
using QuanLyPhongTro.src.Test.Models; // <-- Sửa Namespace
using System;
using System.Linq;

namespace QuanLyPhongTro.Services
{
    public class PersonService
    {
        public Person GetAccount(string username, string password)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var person = context.People // Sửa
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

        public Person GetById(Guid personId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return context.People.Find(personId); // Sửa
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetById: {ex.Message}");
                return null;
            }
        }

        public bool SignUp(Person person, PersonDetail personDetail) // Sửa (Model mới)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            // 1. Thêm PersonDetail trước
                            context.PersonDetails.Add(personDetail); // Sửa
                            context.SaveChanges();

                            // 2. Gán ID của Detail cho Person
                            person.IdDetail = personDetail.Id;
                            context.People.Add(person); // Sửa
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

        public PersonDetail GetPersonDetail(Guid detailId) // Sửa (Tìm bằng detailId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return context.PersonDetails.Find(detailId); // Sửa
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetPersonDetail: {ex.Message}");
                return null;
            }
        }

        public bool UpdatePersonDetail(PersonDetail detailData) // Sửa (Model mới)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var existingDetail = context.PersonDetails.Find(detailData.Id); // Sửa
                    if (existingDetail == null) return false;

                    existingDetail.Name = detailData.Name;
                    existingDetail.Cccd = detailData.Cccd; // Sửa
                    existingDetail.Phone = detailData.Phone;
                    existingDetail.Gender = detailData.Gender; // Thêm
                    existingDetail.Gmail = detailData.Gmail; // Thêm

                    if (detailData.Avatar != null && detailData.Avatar.Length > 0)
                    {
                        existingDetail.Avatar = detailData.Avatar;
                    }
                    if (detailData.CccdImage != null && detailData.CccdImage.Length > 0)
                    {
                        existingDetail.CccdImage = detailData.CccdImage; // Thêm
                    }

                    context.PersonDetails.Update(existingDetail); // Sửa
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