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
    public partial class Form2 : Form
    {
        private User currentUser;
        private UserList userList;
        public Form2(User user)
        {
            InitializeComponent();

            this.currentUser = user;
            userList = new UserList(new JsonFileController(new AdapterJson()));

            if (!user.IsAdmin)
            {
                panel1.Visible = false;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ChangePassword();
        }
        private void ChangePassword()
        {
            var login = new Login();

            var realUser = login.FindUser(currentUser, userList.GetUserList());

            var testingUser = realUser.GetCopy();

            testingUser.Password = textBox1.Text.CalculateHash();

            var passwordIsCorrect = login.VerifyUserPassword(testingUser, userList.GetUserList());

            var newPassword = textBox2.Text;

            if (!passwordIsCorrect)
            {
                MessageBox.Show(Validation.GetWrongPasswordMessage());
            }
            else if (!Validation.ValidatePassword(newPassword, testingUser.Utility))
            {
                MessageBox.Show(Validation.GetNotValidPasswordMessage());
            }
            else if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show(Validation.GetPasswordsDoNotMatchMessage());
            }
            else
            {
                var newUser = currentUser.GetCopy();
                newUser.Password = newPassword.CalculateHash();

                userList.UpdateUser(currentUser, newUser);
                MessageBox.Show(Validation.GetPasswordIsChangedMessage());
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            RefreshGridData();
        }


        private void RefreshGridData()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = userList.GetUserList();
            dataGridView1.Columns["Username"].ReadOnly = true;
            dataGridView1.Columns["IsAdmin"].ReadOnly = true;
            dataGridView1.Columns["Password"].Visible = false;
            dataGridView1.Columns["ShouldChangePassword"].Visible = false;
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            userList.UpdateFile();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var user = new User(textBox4.Text);

            userList.AddUser(user);

            RefreshGridData();
        }
    }

}
