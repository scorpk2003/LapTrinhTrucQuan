using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QuanLyPhongTro.src.Models;

namespace QuanLyPhongTro.src.Services1
{
    public class PersonDetailServices
    {
        /// <summary>
        /// L?y chi ti?t ngu?i dùng theo Id
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
                System.Diagnostics.Debug.WriteLine($"L?i GetPersonDetailById: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Thêm chi ti?t ngu?i dùng m?i
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
                Console.WriteLine($"L?i AddPersonDetail: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// C?p nh?t chi ti?t ngu?i dùng
        /// </summary>
        public bool UpdatePersonDetail(PersonDetail detail)
        {
            try
            {
                using var context = new AppContextDB(); 
                context.PersonDetails.Update(detail);
                Person? people = context.People.Find(detail.Person!.Id);
                people!.Username = detail.Name!;
                context.People.Update(people);

                context.SaveChanges();
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
                System.Diagnostics.Debug.WriteLine($"L?i DeletePersonDetail: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// L?y t?t c? chi ti?t ngu?i dùng
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
                System.Diagnostics.Debug.WriteLine($"L?i GetAllPersonDetails: {ex.Message}");
                return new List<PersonDetail>();
            }
        }
    }
}
