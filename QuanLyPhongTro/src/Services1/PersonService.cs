using Microsoft.EntityFrameworkCore;
using QuanLyPhongTro.src.Models;
using System;
using System.Linq;

namespace QuanLyPhongTro.src.Services1
{
    public class PersonService
    {
        public Person? GetAccount(string username, string password)
        {
            using (var context = new AppContextDB())
            {
                try
                {
                
                    Person? person = context.People
                        .Include(p => p.IdDetailNavigation)
                        .FirstOrDefault(p => p.IdDetailNavigation!.Gmail == username && p.Password == password);
                    return person;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi GetAccount: {ex.Message}");
                    return null;
                }
            }
        }

        public Person GetById(Guid personId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return context.People.Find(personId); 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetById: {ex.Message}");
                return null;
            }
        }

        public bool SignUp(Person? person)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    context.People.Add(person!);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi SignUp (Outer): {ex.Message}");
                return false;
            }
        }

        public PersonDetail GetPersonDetail(Guid detailId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return context.PersonDetails.Find(detailId);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetPersonDetail: {ex.Message}");
                return null;
            }
        }

        public bool UpdatePersonDetail(PersonDetail detailData)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var existingDetail = context.PersonDetails.Find(detailData.Id); // Sửa
                    if (existingDetail == null) return false;
                    existingDetail = detailData;

                    if (detailData.Avatar != null && detailData.Avatar.Length > 0)
                    {
                        existingDetail.Avatar = detailData.Avatar;
                    }
                    if (detailData.CccdImage != null && detailData.CccdImage.Length > 0)
                    {
                        existingDetail.CccdImage = detailData.CccdImage;
                    }

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