using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProjectCompletion
    {

        /// <summary>
        /// 向项目信息表中插入所有的信息
        /// </summary>
        /// <param name="proposal_number">立项编号</param>
        /// <param name="project_title">项目名称</param>
        /// <param name="project_description">项目描述</param>
        /// <param name="useNumber">点话号码</param>
        /// <param name="achievement_form">成果形式</param>
        /// <param name="achievement_brief">项目成果简介</param>
        /// <returns></returns>
        public bool ProjectInfor(string proposal_number, string project_title, string project_description,string useNumber, string achievement_form,string achievement_brief)
        {
            
            string query = "INSERT INTO UserLogin (proposal_number, project_title, " +
                "project_description,team_id,achievement_form,achievement_brief) " +
                "VALUES (@proposal_number, @project_title, @project_description," +
                "(select team_id from TeamInfo where team_leader_id=(select user_id from UserLogin where useNumber='@useNumber'))" +
                ",@achievement_form,@achievement_brief)";
            SqlParameter[] parameters = {
                new SqlParameter("@proposal_number", SqlDbType.NVarChar) { Value = proposal_number },
                new SqlParameter("@project_title", SqlDbType.NVarChar) { Value = project_title },
                new SqlParameter("@project_description", SqlDbType.NVarChar) { Value = project_description },
                new SqlParameter("@useNumber", SqlDbType.NVarChar) { Value = useNumber },
                new SqlParameter("@achievement_form", SqlDbType.NVarChar) { Value = achievement_form },
                new SqlParameter("@achievement_brief", SqlDbType.NVarChar) { Value = achievement_brief }

            };

            int rowsAffected = DBHelper.ExecuteSql(query, parameters);

            return rowsAffected > 0;
        }







    }
}
