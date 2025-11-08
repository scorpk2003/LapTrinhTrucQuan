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
        public string UserId { get; set; }
        public string Role { get; set; }
        public bool IsAuthenticated { get; set; }
        private UserSession() {
            UserId = "";
            Role = "";
            IsAuthenticated = false;
        }

        public void Login(string userID, string role)
        {
            UserId = userID;
            Role = role;
            IsAuthenticated = true;
        }

        public void Logout()
        {
            UserId = "";
            Role = "";
            IsAuthenticated = false;
        }
    }
}
