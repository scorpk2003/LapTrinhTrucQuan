using QuanLyPhongTro.src.Models;
using QuanLyPhongTro.src.Services1;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTro.src.UserSession
{
    internal class UserSession
    {
        private static readonly Lazy<UserSession> _instance = new Lazy<UserSession>(() => new UserSession());
        public static UserSession Instance => _instance.Value;
        public Person? _user { get; set; }
        public bool IsAuthenticated { get; set; }
        private UserSession() {
            _user = new();
            IsAuthenticated = false;
        }

        public void Login(string Gmail, string pass)
        {
            PersonService personService = new PersonService();
            Person? user = personService.GetAccount(Gmail, pass);
            if(user != null)
            {
                _user = user;
                IsAuthenticated = true;
                System.Diagnostics.Debug.WriteLine($"Login successful {user.IdDetailNavigation.Name}");
            }
        }

        public void Logout()
        {
            _user = null;
            IsAuthenticated = false;
        }
    }
}
