using System;
using System.Collections.Generic;
using System.Linq;
using QuanLyPhongTro.src.Models;

namespace QuanLyPhongTro.src.Services
{
    public class PersonService
    {
        private readonly AppContextDB _context;

        public PersonService()
        {
            _context = new AppContextDB();
        }

        public IEnumerable<Person> GetAll()
        {
            return _context.People.ToList();
        }

        public Person GetById(Guid id)
        {
            return _context.People.FirstOrDefault(p => p.Id == id);
        }

        public Person Create(Person person)
        {
            _context.People.Add(person);
            _context.SaveChanges();
            return person;
        }

        public void Update(Person person)
        {
            _context.People.Update(person);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var person = _context.People.Find(id);
            if (person != null)
            {
                _context.People.Remove(person);
                _context.SaveChanges();
            }
        }
    }
}
