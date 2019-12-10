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
    public partial class Form1 : Form
    {
        private int wrongLoginAttempt = 0;
        private int maxLoginAttempts = 3;
        private UserList userList;
        private User currentUser;
        public Form1()
        {
            userList = new UserList(new JsonFileController(new AdapterJson()));
            InitializeComponent();
        }
        private void EnteredWrongCredentials()
        {
            wrongLoginAttempt += 1;
            MessageBox.Show(Validation.GetIncorrectLoginAttemptMessage() + (maxLoginAttempts - wrongLoginAttempt));
            if (wrongLoginAttempt >= maxLoginAttempts)
            {
                this.Close();
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            var login = new Login();

            var testingUser = new User(textBox1.Text);

            var realUser = login.FindUser(testingUser, userList.GetUserList());

            if (realUser == null)
            {
                EnteredWrongCredentials();
                return;
            }

            testingUser.Password = textBox2.Text.CalculateHash();

            if (realUser.IsBlocked)
            {
                MessageBox.Show(Validation.GetAccountIsBlockedMessage());
            }
            else if(realUser.ShouldChangePassword)
            {
                LoadForm3(realUser);
            }
            else if (!login.VerifyUserPassword(testingUser, userList.GetUserList()))
            {
                EnteredWrongCredentials();
            }
            else
            {
                LoadForm2(realUser);
            }

            
        }
        private void ShowForm(Object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
        private void LoadForm2(User user)
        {
            this.Hide();

            var f = new Form2(user);
            f.FormClosed += new FormClosedEventHandler(ShowForm);
            f.Show();
        }
        private void LoadForm3(User user)
        {
            this.Hide();

            var f = new Form3(user);
            f.FormClosed += new FormClosedEventHandler(ShowForm);
            f.Show();
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Validation.GetAuthorRights());
        }
    }
}
