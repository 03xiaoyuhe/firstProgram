using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{

    public class UserTeamInformation
    {

        /// <summary>
        /// 利用用户表中的id与小队申请表中的id来插入小队成员表
        /// </summary>
        /// <param name="team_leader_id">使用负责人id查询小队id</param>
        /// <param name="contact_number">使用身份证查询用户id</param>
        /// <returns></returns>
        public bool UserTeamInfor(string team_leader_id, string contact_number)
        {

            string query = "INSERT INTO TeamMembers (team_id,member_id) VALUES" +
                "(" +
                "(select team_id from TeamInfo where team_leader_id='@team_leader_id')," +
                "(select user_id from UserInfo where contact_number='@contact_number')" +
                ")";
            SqlParameter[] parameters = {
                new SqlParameter("@team_leader_id", SqlDbType.NVarChar) { Value = team_leader_id },
                new SqlParameter("@contact_number", SqlDbType.NVarChar) { Value = contact_number },
            };

            int rowsAffected = DBHelper.ExecuteSql(query, parameters);

            return rowsAffected > 0;
        }



        /// <summary>
        /// 利用原队伍id修改为现在的队伍id
        /// </summary>
        /// <param name="team_idBefore">原队伍id</param>
        /// <param name="team_id">现在的队伍id</param>
        /// <returns></returns>
        public bool UpdataTeamInfor(string team_idBefore, string team_id )
        {
            string query = "UPDATE TeamMembers SET team_id = '@team_id ' WHERE  team_id='@team_idBefore'";

            SqlParameter[] parameters = {
                new SqlParameter("@team_idBefore", SqlDbType.NVarChar) { Value = team_idBefore },
                new SqlParameter("@team_id", SqlDbType.NVarChar) { Value = team_id },

                        };


            int rowsAffected = DBHelper.ExecuteSql(query, parameters);

            return rowsAffected > 0;
        }




    }
}
