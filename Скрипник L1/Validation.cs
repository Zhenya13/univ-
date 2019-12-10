using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lab1
{
    public static class Validation
    {
        public static bool ValidatePassword(string password, bool utilityCheck)
        {
            if (utilityCheck)
            {
            List<string> patterns = new List<string>();
            patterns.Add(@"[0-9]+");
            patterns.Add(@"[\+\-\*\/]+");
            //patterns.Add(@"[А-Яа-я]+");


                foreach(var pattern in patterns)
                {
                    var match = Regex.Match(password, pattern);
                    if(!match.Success)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        
        public static string GetAuthorRights()
        {
            return "Made by Roma";
        }
        public static string GetNotValidPasswordMessage()
        {
            return "You should include at least one number and one arithmetic symbol in new password";
        }
        public static string GetAccountIsBlockedMessage()
        {
            return "Your account have been blocked. Talk to administrator.";
        }
        public static string GetWrongPasswordMessage()
        {
            return "Wrong password";
        }
        public static string GetPasswordsDoNotMatchMessage()
        {
            return "Passwords do not match";
        }
        public static string GetPasswordIsChangedMessage()
        {
            return "Password is changed";
        }
        public static string GetIncorrectLoginAttemptMessage()
        {
            return "Login or password is incorrect.You have attempts to login: ";
        }
    }
}
