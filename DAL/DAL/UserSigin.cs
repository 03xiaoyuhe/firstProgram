using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace DAL
{
    public class UserLogin
    {
        private readonly string connectionString = "SQpwdLoad"; // Replace with your actual connection string

        public bool AuthenticateUser(string username, string password)
        {
            string query = "SELECT COUNT(*) FROM UserLogin WHERE Username = @Username AND Password = @Password";
            SqlParameter[] parameters = {
                new SqlParameter("@Username", SqlDbType.NVarChar) { Value = username },
                new SqlParameter("@Password", SqlDbType.NVarChar) { Value = password }
            };

            object result = DBHelper.GetSingle(query, parameters, connectionString);
            int count = Convert.ToInt32(result);

            return count > 0;
        }
    }
}


