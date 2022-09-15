using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tanchiki.Contoller;

namespace Tanchiki.View
{
    public partial class SingIn : Form
    {
        public SingIn()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AuthorizationController authorization = new AuthorizationController();
            authorization.Authorization(textBox1.Text, textBox2.Text);
            if (authorization.check_pass == true && authorization.check_login == true)
            {
                label4.Visible = false;
                label3.ForeColor = Color.Gray;
                label3.Text = "Account does not exist! Register?";
                label3.Enabled = true;

            }
            else
            {
                label3.Enabled = false;
                label3.ForeColor = Color.Red;
                if (authorization.check_login == true)
                {
                    label4.Visible = true;
                    label4.Text = "Incorrect login";
                }
                else
                {
                    label4.Visible = false;
                    label4.Text = "";
                }
                if (authorization.check_pass == true)
                {
                    label3.Text = "Incorrect password";
                }
                else
                {
                    label3.Text = "";
                }
            }
            if (authorization.check_pass == false)
            {
                MessageBox.Show("AUTH");

            }


        }
        string required_login = "login is a required field";
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
                }
                else
                {
                    label4.Text = "Invalid  format! please write login more 4 ";
                }
            }
            textBox1.LostFocus += TextBox1_LostFocus;
        }
        private void TextBox1_LostFocus(object sender, EventArgs e)
        {
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
                }
                else
                {
                    label4.Text = "Invalid  format! please write login more 4 ";
                }
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form1 singup = new Form1();
            singup.Show();
            singup.Focus();
            Close();
        }
    }
}
