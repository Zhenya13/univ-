using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class UserList
    {
        private static List<User> userList;
        private static IStorageController storageController;
        public UserList(IStorageController controller)
        {
            storageController = controller;

            LoadListFromFile();

            if(userList == null)    
                SetDefaultList();
        }
        public List<User> GetUserList()
        {
            return userList;
        }
        public void AddUser(User user)
        {
            var userExists = userList.Find(u => u.Username == user.Username);
            if (userExists == null)
            {
                userList.Add(user);
            }
            UpdateFile();
        }
        public void UpdateUser(User oldUser, User newUser)
        {
            var user = userList.Find(cu => cu.Username == oldUser.Username);
            var index = userList.IndexOf(user);
            if (index > -1)
            {
                userList[index] = newUser.GetCopy();
                UpdateFile();
            }
        }
        private void SetUserList(List<User> users)
        {
            userList = users;
            UpdateFile();
        }
        private void SetDefaultList()
        {
            userList = new List<User>();
            userList.Add(new User("admin", true, false));
            SetUserList(userList);
        }
        private void LoadListFromFile()
        {
            userList = storageController.ReadData();
        }
        public void UpdateFile()
        {
            if (userList != null)
            {
                storageController.WriteData(userList);
            }
        }
    }
}
