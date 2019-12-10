using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Login
    {

        public Login()
        {
        }
        
        public User FindUser(User user, List<User> users)
        {
            
            var theUser = users.Find(cu => cu.Username == user.Username);

            return theUser;
        }
        public bool VerifyUserPassword(User user, List<User> users)
        {
            var theUser = users.Find(cu =>cu.Username == user.Username && cu.Password == user.Password);

            return theUser == null ? false : true;
        }
    }
}
