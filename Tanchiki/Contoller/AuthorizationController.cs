using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanchiki.Model;

namespace Tanchiki.Contoller
{
    internal class AuthorizationController
    {
        public bool check_login { get; set; }
        public bool check_pass { get; set; }
        public AuthorizationController()
        {

        }

        public void Authorization(string auth_login, string auth_pass)
        {
            string connectionString = @"Data Source=SQL8004.site4now.net;Initial Catalog=db_a8bcfd_juzz;User Id=db_a8bcfd_juzz_admin;Password=JuzzikASP1";
            check_login = false;
            check_pass = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    var myEvent = connection.QueryFirst<Tanks_Users>(string.Format("SELECT * FROM User_data WHERE login = '{0}'", auth_login));

                    if (new Text_crypt().Verification(auth_pass, myEvent.password_hesh))
                    {
                        System.Windows.Forms.MessageBox.Show("if");
                        check_pass = false;
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("else");
                        check_pass = true;
                    }
                }
                catch
                {

                    check_login = true;
                }

            }
        }
    }
}
