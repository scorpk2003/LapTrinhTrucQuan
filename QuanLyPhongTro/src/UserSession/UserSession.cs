using QuanLyPhongTro.src.Models;
using System;
using System.Collections.Generic;
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
            AppContextDB appContextDB = new AppContextDB();
            Person? user = appContextDB.People
                .FirstOrDefault(u => u.IdDetailNavigation!.Gmail == Gmail && u.Password == pass);
            if (user != null)
            {
                System.Diagnostics.Debug.WriteLine("\n\n\tLogin successful for user: " + user + "\n\n");
                _user = user;
                IsAuthenticated = true;
            }
        }

        public void Logout()
        {
            _user = null;
            IsAuthenticated = false;
        }
    }
}
