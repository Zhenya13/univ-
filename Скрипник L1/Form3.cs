using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form3 : Form
    {
        User user;
        UserList userList;
        public Form3(User user)
        {
            InitializeComponent();

            this.userList = new UserList(new JsonFileController(new AdapterJson()));
            this.user = user;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var newPassword = textBox1.Text;
            if(!Validation.ValidatePassword(newPassword, user.Utility))
            {
                MessageBox.Show(Validation.GetNotValidPasswordMessage());
            }
            else if(textBox1.Text != textBox2.Text)
            {
                MessageBox.Show(Validation.GetPasswordsDoNotMatchMessage());
            }
            else
            {
                var newUser = user.GetCopy();
                newUser.Password = newPassword.CalculateHash();
                newUser.ShouldChangePassword = false;

                userList.UpdateUser(user, newUser);

                this.Close();
            }
            
        }
    }
}
