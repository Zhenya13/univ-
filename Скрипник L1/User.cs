using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lab1
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsBlocked { get; set; }
        public bool Utility { get; set; }
        public bool ShouldChangePassword { get; set; }

        public User(string username): 
            this(username, true) { }

        public User(string username, bool utility):
            this(username, "", false, false, utility, true) { }

        public User(string username, bool isAdmin, bool utility):
            this(username, "", isAdmin, false, utility, true) { }

        [JsonConstructor]
        public User(string username, string password, bool isAdmin, bool isBlocked, bool utility, bool scp)
        {
            this.Username = username;
            this.Password = password;
            this.IsAdmin = isAdmin;
            this.IsBlocked = isBlocked;
            this.Utility = utility;
            this.ShouldChangePassword = scp;
        }

        public User GetCopy()
        {
            return new User(Username, Password, IsAdmin, IsBlocked, Utility, ShouldChangePassword);
        }
        
    }
}
