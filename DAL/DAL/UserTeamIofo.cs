using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserTeamIofo
    {

        /// <summary>
        ///小队申请表，需要两个参数进行对表中数据的插入。
        /// </summary>
        /// <param name="teamName">小队名</param>
        /// <param name="contactNumber">负责人的身份证号</param>
        /// <returns></returns>
        public bool UserTeamSign(string teamName, string contactNumber)
        {

            string query = "INSERT INTO TeamInfo (team_leader_id,team_name) VALUES ((select user_id from UserInfo where contact_number='@contactNumber'),'@teamName')";
            SqlParameter[] parameters = {
                new SqlParameter("@teamName", SqlDbType.NVarChar) { Value = teamName },
                new SqlParameter("@contactNumber", SqlDbType.NVarChar) { Value = contactNumber },
            };

            int rowsAffected = DBHelper.ExecuteSql(query, parameters);

            return rowsAffected > 0;
        }


    }
}
