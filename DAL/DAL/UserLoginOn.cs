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


        /// <summary>
        /// 查询账号是否存在
        /// </summary>
        /// <param name="username">账号</param>
        /// <returns></returns>
        static public bool CheckIfAccountExists(string username)
        {
            string query = "SELECT COUNT(*) FROM UserLogin WHERE Username = @Username";
            SqlParameter[] parameters = {
                new SqlParameter("@Username", SqlDbType.NVarChar) { Value = username }
            };

            object result = DBHelper.GetSingle(query, parameters);//（）内的connectionString或许可以去掉。
            int count = Convert.ToInt32(result);

            return count > 0;
        }


        static public bool CheckIfUserNumberExists(string useNumber)
        {
            string query = "SELECT COUNT(*) FROM UserLogin WHERE useNumber = @useNumber";
            SqlParameter[] parameters = {
                new SqlParameter("@useNumber", SqlDbType.NVarChar) { Value = useNumber }
            };

            object result = DBHelper.GetSingle(query, parameters);//（）内的connectionString或许可以去掉。
            int count = Convert.ToInt32(result);

            return count > 0;
        }



        /// <summary>
        /// 注册账号密码插入数据库
        /// </summary>
        /// <param name="username">账号</param>
        /// <param name="password">密码</param>
        /// <param name="userNumber">联系电话</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        static public bool RegisterUser(string username, string password, string userNumber)
        {
            if (CheckIfAccountExists(username))
            {
                throw new InvalidOperationException("该账号已存在，请重新注册。");
            }

            string query = "INSERT INTO UserLogin (Username, Password, useNumber) VALUES (@Username, @Password, @PhoneNumber)";
            SqlParameter[] parameters = {
                new SqlParameter("@Username", SqlDbType.NVarChar) { Value = username },
                new SqlParameter("@Password", SqlDbType.NVarChar) { Value = password },
                new SqlParameter("@PhoneNumber", SqlDbType.NVarChar) { Value = userNumber }
            };

            int rowsAffected = DBHelper.ExecuteSql(query, parameters);

            return rowsAffected > 0;
        }

    

    }
}
