using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserResearch
    {

        private readonly string connectionString = "SQpwdLoad";


        /// <summary>
        /// 查询账号是否存在
        /// </summary>
        /// <param name="Research_name">账号</param>
        /// <returns></returns>
        public bool CheckResearchIfAccountExists(string Research_name)
        {
            string query = "SELECT COUNT(*) FROM UserResearch WHERE Research_name = @Research_name";
            SqlParameter[] parameters = {
                new SqlParameter("@Research_name", SqlDbType.NVarChar) { Value = Research_name }
            };

            object result = DBHelper.GetSingle(query, parameters);//（）内的connectionString或许可以去掉。
            int count = Convert.ToInt32(result);

            return count > 0;
        }



        /// <summary>
        /// 注册账号密码插入数据库
        /// </summary>
        /// <param name="Research_name">账号</param>
        /// <param name="Research_paw">密码</param>
        /// <param name="Research_number">联系电话</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public bool RegisterResearchUser(string Research_name, string Research_paw, string Research_number)
        {
            if (CheckResearchIfAccountExists(Research_name))
            {
                throw new InvalidOperationException("该账号已存在，请重新注册。");
            }

            string query = "INSERT INTO UserResearch (Research_name, Research_paw, Research_number) VALUES (@Research_name, @Research_paw, @Research_number)";
            SqlParameter[] parameters = {
                new SqlParameter("@Research_name", SqlDbType.NVarChar) { Value = Research_name },
                new SqlParameter("@Research_paw", SqlDbType.NVarChar) { Value = Research_paw },
                new SqlParameter("@Research_number", SqlDbType.NVarChar) { Value = Research_number }
            };

            int rowsAffected = DBHelper.ExecuteSql(query, parameters);

            return rowsAffected > 0;
        }


        /// <summary>
        /// 查询账号密码是否在数据库中,判断能否能成功登录
        /// </summary>
        /// <param name="Research_name">账号</param>
        /// <param name="Research_paw">密码</param>
        /// <returns></returns>
        public bool AuthenticateUserResearch(string Research_name, string Research_paw)
        {
            string query = "SELECT COUNT(*)\"count\" FROM UserResearch WHERE Research_name = @Research_name AND Research_paw =@Research_paw;";
            SqlParameter[] parameters = {
                new SqlParameter("@Research_name", SqlDbType.NVarChar) { Value = Research_name },
                new SqlParameter("@Research_paw", SqlDbType.NVarChar) { Value = Research_paw }
            };

            DataSet result = DBHelper.Query(query, parameters);
            DataTable dt = result.Tables[0];
            int count = Convert.ToInt32(dt.Rows[0]["count"]);

            return count > 0;
        }


    }
}
