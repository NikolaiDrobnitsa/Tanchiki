using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanchiki.Model;

namespace Tanchiki.Contoller
{
    internal class RegestrationController
    {
        public bool checkUniEmail { get; set; }
        private int outresult { get; set; }
        public void Regestration(string _login, string _pass)
        {
            string connectionString = @"Data Source=SQL8004.site4now.net;Initial Catalog=db_a8bcfd_juzz;User Id=db_a8bcfd_juzz_admin;Password=JuzzikASP1";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Tanks_Users regestration = new Tanks_Users() { login = _login, password_hesh = new Text_crypt().Generate(_pass) };
                connection.Execute("INSERT INTO User_data (login, password_hesh) VALUES(@login,@password_hesh)", regestration);
            }


        }
        public void CanUserEdit(string userName)
        {
            string connectionString = @"Data Source=SQL8004.site4now.net;Initial Catalog=db_a8bcfd_juzz;User Id=db_a8bcfd_juzz_admin;Password=JuzzikASP1";

            string sqlExpression = "CheckUniEmail";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter nameLogin = new SqlParameter
                {
                    ParameterName = "@check_login",
                    Value = userName
                };
                command.Parameters.Add(nameLogin);


                SqlParameter Count_login = new SqlParameter
                {
                    ParameterName = "@count_check",
                    SqlDbType = SqlDbType.Int
                };

                Count_login.Direction = ParameterDirection.Output;
                command.Parameters.Add(Count_login);



                command.ExecuteNonQuery();
                //System.Windows.Forms.MessageBox.Show(command.Parameters["@count_check"].Value.ToString());
                outresult = Convert.ToInt32(command.Parameters["@count_check"].Value);

                if (outresult >= 1)
                {
                    checkUniEmail = false;
                }
                else
                {
                    checkUniEmail = true;
                }
            }
        }
    }
}
