using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{

    //此类用于用户对于创建好的小队进行加入的各项操作

    public class UserTeamInformation
    {

        /// <summary>
        /// 利用用户表中的id与小队申请表中的id来插入小队成员表
        /// </summary>
        /// <param name="team_leader_id">使用负责人id查询小队id</param>
        /// <param name="contact_number">使用身份证查询用户id</param>
        /// <returns></returns>
        static public bool UserTeamInfor(string team_leader_id, string contact_number)
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
        /// 利用负责人的电话号码查询所在的小队的所有成员的信息
        /// </summary>
        /// <param name="useNamer">电话号码</param>
        /// <returns></returns>
        static public bool TeamVision(string useNamer)
        {
            string query = "select user_name ,gender , email,date_of_birth from  UserInfo where  " +
                "user_id in (select member_id FROM TeamMembers WHERE" +
                " team_id = " +
                "(select team_id from TeamInfo where" +
                " team_leader_id = " +
                "(select user_id from UserLogin where useNumber ='@useNumber'))) ;";
            SqlParameter[] parameters = {
            new SqlParameter("@useNamer",SqlDbType.NVarChar){Value = useNamer},
            };

            int rowsAffected = DBHelper.ExecuteSql(query, parameters);

            return rowsAffected > 0;


        }


        




    }
}
