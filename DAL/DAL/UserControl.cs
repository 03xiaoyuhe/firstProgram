using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserControl
    {
        private readonly string connectionString = "SQpwdLoad";


        /// <summary>
        /// 查询账号是否存在
        /// </summary>
        /// <param name="contol_name">账号</param>
        /// <returns></returns>
        public bool CheckControlIfAccountExists(string contol_name)
        {
            string query = "SELECT COUNT(*) FROM UserContol WHERE contol_name = @contol_name";
            SqlParameter[] parameters = {
                new SqlParameter("@contol_name", SqlDbType.NVarChar) { Value = contol_name }
            };

            object result = DBHelper.GetSingle(query, parameters);//（）内的connectionString或许可以去掉。
            int count = Convert.ToInt32(result);

            return count > 0;
        }



        /// <summary>
        /// 注册账号密码插入数据库
        /// </summary>
        /// <param name="contol_name">账号</param>
        /// <param name="contol_paw">密码</param>
        /// <param name="contol_number">联系电话</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public bool RegisterUserConrrol(string contol_name, string contol_paw, string contol_number)
        {
            if (CheckControlIfAccountExists(contol_name))
            {
                throw new InvalidOperationException("该账号已存在，请重新注册。");
            }

            string query = "INSERT INTO UserContol (contol_name, contol_paw, contol_number) VALUES (@contol_name, @contol_paw, @contol_number)";
            SqlParameter[] parameters = {
                new SqlParameter("@contol_name", SqlDbType.NVarChar) { Value = contol_name },
                new SqlParameter("@contol_paw", SqlDbType.NVarChar) { Value = contol_paw },
                new SqlParameter("@contol_number", SqlDbType.NVarChar) { Value = contol_number }
            };

            int rowsAffected = DBHelper.ExecuteSql(query, parameters);

            return rowsAffected > 0;
        }



        /// <summary>
        /// 查询账号密码是否在数据库中,判断能否能成功登录
        /// </summary>
        /// <param name="contol_name">账号</param>
        /// <param name="contol_paw">密码</param>
        /// <returns></returns>
        public bool AuthenticateUserContol(string contol_name, string contol_paw)
        {
            string query = "SELECT COUNT(*)\"count\" FROM UserContol WHERE contol_name = @contol_name AND contol_paw =@contol_paw;";
            SqlParameter[] parameters = {
                new SqlParameter("@contol_name", SqlDbType.NVarChar) { Value = contol_name },
                new SqlParameter("@contol_paw", SqlDbType.NVarChar) { Value = contol_paw }
            };

            DataSet result = DBHelper.Query(query, parameters);
            DataTable dt = result.Tables[0];
            int count = Convert.ToInt32(dt.Rows[0]["count"]);

            return count > 0;
        }





    }
}
