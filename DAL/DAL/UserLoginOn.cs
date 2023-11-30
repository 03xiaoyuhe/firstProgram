using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DAL
{


    public class UserRegistration
    {
        private readonly string connectionString = "SQpwdLoad";
        public bool CheckIfAccountExists(string username)
        {
            string query = "SELECT COUNT(*) FROM UserLogin WHERE Username = @Username";
            SqlParameter[] parameters = {
                new SqlParameter("@Username", SqlDbType.NVarChar) { Value = username }
            };

            object result = DBHelper.GetSingle(query, parameters, connectionString);//（）内的connectionString或许可以去掉。
            int count = Convert.ToInt32(result);

            return count > 0;
        }

        public bool RegisterUser(string username, string password, string phoneNumber)
        {
            if (CheckIfAccountExists(username))
            {
                throw new InvalidOperationException("该账号已存在，请重新注册。");
            }

            string query = "INSERT INTO UserLogin (Username, Password, PhoneNumber) VALUES (@Username, @Password, @PhoneNumber)";
            SqlParameter[] parameters = {
                new SqlParameter("@Username", SqlDbType.NVarChar) { Value = username },
                new SqlParameter("@Password", SqlDbType.NVarChar) { Value = password },
                new SqlParameter("@PhoneNumber", SqlDbType.NVarChar) { Value = phoneNumber }
            };

            int rowsAffected = DBHelper.ExecuteSql(query, parameters);

            return rowsAffected > 0;
        }
    }
}
