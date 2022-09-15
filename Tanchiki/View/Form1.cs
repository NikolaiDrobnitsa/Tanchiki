using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tanchiki.Contoller;
using Tanchiki.View;

namespace Tanchiki
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool check_login = false;
        bool check_pass = false;
        string required_login = "login is a required field";
        string required_pass = "Password is a required field";
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                label4.Text = required_login;
            }
            else
            {
                if (textBox1.Text.Length > 4)
                {
                    label4.Visible = false;
                    check_login = true;
                }
                else
                {
                    label4.Text = "Invalid email format! please write login more 4";
                }
            }
            textBox1.LostFocus += TextBox1_LostFocus;
        }

        private void TextBox1_LostFocus(object sender, EventArgs e)
        {
            check_login = false;
            label4.Visible = true;
            if (textBox1.Text == "")
            {
                label4.Text = required_login;
            }
            else
            {
                if (textBox1.Text.Length > 4)
                {
                    label4.Visible = false;
                    check_login = true;
                }
                else
                {
                    label4.Text = "Invalid email format! please write login more 4";
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Regex rgx = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d\[\]\(\),\.!@\$\^~\|=\-_\{\}#*%]{8,16}$");
            if (textBox2.Text == "")
            {
                label3.Text = required_pass;
            }
            else
            {
                if (textBox2.Text.Length < 8 || textBox2.Text.Length > 16)
                {
                    label3.Visible = true;
                    check_pass = false;
                    label3.Text = "Password Must be 8 - 16 characters long";
                }
                else
                {
                    if (rgx.IsMatch(textBox2.Text))
                    {
                        label3.Visible = false;
                        check_pass = true;
                    }
                    else
                    {
                        label3.Text = "Minimum 8 characters at least 1 Alphabet and 1 Number.The only allowed characters are all alphanumerics(A - Z, a - z, 0 - 9) and symbols[]()!$^,.~|= -_{ }#";
                    }
                }
            }


        }
        private void open_authorization_window()
        {
            const string message =
        "Successful registration ✔\nSing In?";
            const string caption = "Registration";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                SingIn sing_forms = new SingIn();
                sing_forms.Show();
                Close();
            }
            if (result == DialogResult.No)
            {
                Begin_form begin_Form = new Begin_form();
                begin_Form.Focus();
                this.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            RegestrationController new_user = new RegestrationController();

            if (check_login == true && check_pass == true)
            {
                new_user.CanUserEdit(textBox1.Text);
                if (new_user.checkUniEmail == true)
                {
                    new_user.Regestration(textBox1.Text, textBox2.Text);
                    open_authorization_window();
                }
                else
                {
                    label4.Visible = true;
                    label4.Text = "Такой login существует придумайте другой!";
                }

            }
            else
            {
                if (check_login == false)
                {
                    textBox1.Focus();
                    if (textBox1.Text == "")
                    {
                        label4.Text = required_login;
                    }

                }
                if (check_pass == false)
                {
                    textBox2.Focus();
                    if (textBox2.Text == "")
                    {
                        label3.Text = required_pass;
                    }

                }
            }

        }
    }
}
