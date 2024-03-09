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
        ///小队创建表，需要两个参数进行对表中数据的插入,向里插入负责人id与队伍名字。
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

        /// <summary>
        /// 利用电话号码修改现在的队伍id
        /// </summary>
        /// <param name="useNumber">电话号码</param>
        /// <param name="team_id">现在的队伍id</param>
        /// <returns></returns>
        public bool UpdataTeamInfor(string useNumber, string team_id)
        {
            string query = "UPDATE TeamMembers SET team_id = '@team_id' " +
                "WHERE  member_id=(select user_id from UserInfo where " +
                "user_id=(select user_id from UserLogin where useNumber='@useNumber'));";

            SqlParameter[] parameters = {
                new SqlParameter("@useNumber", SqlDbType.NVarChar) { Value = useNumber },
                new SqlParameter("@team_id", SqlDbType.NVarChar) { Value = team_id },

            };


            int rowsAffected = DBHelper.ExecuteSql(query, parameters);

            return rowsAffected > 0;
        }



    }
}
