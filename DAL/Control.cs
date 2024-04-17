using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Control
    {
        /// <summary>
        /// 查询用户的账号密码是否在数据库中
        /// </summary>
        /// <param name="control_account">账号</param>
        /// <param name="control_psw">密码</param>
        /// <returns></returns>
        static public bool AuthenticateUser(string control_account, string control_psw)
        {
            string query = "SELECT control_id FROM UserControl WHERE control_account = @control_account AND control_psw =@control_psw;";
            SqlParameter[] parameters = {
                new SqlParameter("@control_account", SqlDbType.NVarChar) { Value = control_account },
                new SqlParameter("@control_psw", SqlDbType.NVarChar) { Value = control_psw }
            };

            DataSet result = DBHelper.Query(query, parameters);

            DataTable dt = result.Tables[0];

            int count = Convert.ToInt32(dt.Rows[0]["control_id"]);

            return count > 0;

        }

        /// <summary>
        /// 注册时查询账号是否存在
        /// </summary>
        /// <param name="control_account">账号</param>
        /// <returns></returns>
        static public bool CheckIfAccountExists(string control_account)
        {
            string query = "SELECT COUNT(*) FROM UserControl WHERE control_account = @control_account";
            SqlParameter[] parameters = {
                new SqlParameter("@control_account", SqlDbType.NVarChar) { Value = control_account }
            };

            object result = DBHelper.GetSingle(query, parameters);
            int count = Convert.ToInt32(result);

            return count > 0;
        }


        /// <summary>
        /// 注册时查询电话号码有没有被注册
        /// </summary>
        /// <param name="control_number">电话号码</param>
        /// <returns></returns>
        static public bool CheckIfUserNumberExists(string control_number)
        {
            string query = "SELECT control_id FROM UserControl WHERE control_number = '@control_number' ";
            SqlParameter[] parameters =
            {
                new SqlParameter("@control_number", SqlDbType.NVarChar) { Value = control_number }
            };

            int rowAfforts = DBHelper.ExecuteSql(query, parameters);
            

            return rowAfforts > 0;

        }

        /// <summary>
        /// 向管理员表中插入数据
        /// </summary>
        /// <param name="control_account">账号</param>
        /// <param name="control_psw">密码</param>
        /// <param name="control_number">电话号码</param>
        /// <returns></returns>
        static public bool InsertId(string control_account, string control_psw, string control_number)
        {
            if (CheckIfAccountExists(control_account))
            {
                throw new InvalidOperationException("该账号已存在，请重新注册。");
            }

            if (CheckIfUserNumberExists(control_number))
            {
                throw new InvalidOperationException("该电话号码已存在，请重新注册。");
            }

            string query = "INSERT INTO UserControl (control_account, control_psw, control_number) VALUES (@control_account, @control_psw, @control_number)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@control_account",SqlDbType.NVarChar) { Value = control_account },
                new SqlParameter("@control_psw",SqlDbType.NVarChar) { Value = control_psw },
                new SqlParameter("@control_number",SqlDbType.NVarChar) { Value = control_number },

            };

            int rowAfforts = DBHelper.ExecuteSql(query, parameters);

            return rowAfforts > 0;

        }


    }
}
