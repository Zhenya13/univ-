using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    class PasswordTextBox: TextBox
    {
        public PasswordTextBox()
        {
            this.TextChanged += ChangeToStars;
        }
        private void ChangeToStars(object sender, EventArgs e)
        {
            this.PasswordChar = '*';
        }
    }
}
