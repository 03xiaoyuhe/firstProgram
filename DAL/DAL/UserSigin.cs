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
        private string connectionString = "Data Source=.;Initial Catalog=Social Philosophy Project;User Id=sa;Password=0.0.00.0;"; 


        /// <summary>
        /// 查询账号密码是否在数据库中
        /// </summary>
        /// <param name="username">账号</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public bool AuthenticateUser(string username, string password)
        {
            string query = "SELECT COUNT(*)\"count\" FROM UserLogin WHERE username = @Username AND password =@Password;";
            SqlParameter[] parameters = {
                new SqlParameter("@Username", SqlDbType.NVarChar) { Value = username },
                new SqlParameter("@Password", SqlDbType.NVarChar) { Value = password }
            };

            DataSet result = DBHelper.Query(query, parameters);
            DataTable dt = result.Tables[0];
            int count = Convert.ToInt32(dt.Rows[0]["count"]);

            return count > 0;
        }
    }
}


