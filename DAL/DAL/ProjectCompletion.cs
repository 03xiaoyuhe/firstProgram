using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DAL
{   
    public class ProjectCompletion
    {

        /// <summary>
        /// 检查team_id是否存在
        /// </summary>
        /// <param name="useNumber">负责人电话号码</param>
        /// <returns></returns>
        static public bool CheckTeam_id(string useNumber)
        {
            string query = "select team_id from TeamInfo where team_leader_id=(" +
                "select user_id from UserLogin where useNumber=@useNumber)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@useNumber",SqlDbType.NVarChar) {Value = useNumber},
            };

            object rowsAffected = DBHelper.GetSingle(query, parameters);
            int count = Convert.ToInt32(rowsAffected);

            return (count > 0);
        }

        /// <summary>
        /// 向项目信息表中插入所有的信息
        /// </summary>
        /// <param name="proposal_number">立项编号</param>
        /// <param name="project_title">项目名称</param>
        /// <param name="project_description">项目描述</param>
        /// <param name="useNumber">负责人电话号码</param>
        /// <param name="achievement_form">成果形式</param>
        /// <param name="achievement_brief">项目成果简介</param>
        /// <returns></returns>
        static public bool ProjectInfor(string proposal_number, string project_title, string project_description,string useNumber, string achievement_form,string achievement_brief)
        {
            
            string query = "INSERT INTO ProjectApplications (proposal_number, project_title, " +
                "project_description,team_id,achievement_form,achievement_brief) " +
                "VALUES (@proposal_number, @project_title, @project_description," +
                "(select team_id from TeamInfo where team_leader_id=(select user_id from UserLogin where useNumber=@useNumber))" +
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

        /// <summary>
        /// 利用project_id修改表中的各值
        /// </summary>
        /// <param name="project_id">项目id</param>
        /// <param name="proposal_number">立项编号</param>
        /// <param name="project_title">项目名称</param>
        /// <param name="project_description">项目描述</param>
        /// <param name="useNumber">负责人电话号码</param>
        /// <param name="achievement_form">成果形式</param>
        /// <param name="achievement_brief">项目成果简介</param>
        /// <returns></returns>
        static public bool UpdatePrroject(string project_id, string proposal_number, string project_title, string project_description, string useNumber, string achievement_form, string achievement_brief)
        {
            string query = "UPDATE ProjectApplications SET " +
                "proposal_number = '@proposal_number'," +
                "project_title = '@project_title'," +
                "project_description = '@project_description'," +
                "team_id = (select user_id from UserLogin where useNumber=@userNumber))," +
                "achievement_form = '@achievement_form'," +
                "achievement_brief = '@achievement_brief'" +
                "WHERE project_id = '@project_id';";
            SqlParameter[] parameters =
            {
                new SqlParameter("@proposal_number",SqlDbType.NVarChar) { Value = proposal_number },
                new SqlParameter("@project_title",SqlDbType.NVarChar){Value = project_title },
                new SqlParameter("@project_description",SqlDbType.NVarChar) { Value = project_description },
                new SqlParameter("@useNumber", SqlDbType.NVarChar) { Value = useNumber },
                new SqlParameter("@achievement_form",SqlDbType.NVarChar){Value=achievement_form },
                new SqlParameter("@achievement_brief",SqlDbType.NVarChar){Value=achievement_brief },
                new SqlParameter("@project_id",SqlDbType.NVarChar) {Value = project_id},
            };

            int rowsAffected = DBHelper.ExecuteSql(query, parameters);

            return rowsAffected > 0;

        }

        /// <summary>
        /// 利用立项编号对申请的项目进行删除
        /// </summary>
        /// <param name="proposal_number"></param>
        /// <returns></returns>
        static public bool DeleteProject(string proposal_number)
        {
            string query = "DELETE FROM ProjectApplications WHERE proposal_number = '@proposal_number';";
            SqlParameter[] parameters =
            {
                new SqlParameter("@proposal_number",SqlDbType.NVarChar) {Value = proposal_number},
            };

            int rowsAffecteed = DBHelper.ExecuteSql(query, parameters);

            return rowsAffecteed > 0;
        }

        /// <summary>
        /// 显示表中的所有信息
        /// </summary>
        /// <returns></returns>
        static public DataSet  ProjectVision()
        {
            string query = "select * from ProjectApplications;";
            DataSet result = DBHelper.Query(query);

            //DataTable dt = result.Tables[0];

            //int count = Convert.ToInt32(dt.Rows[0]["count"]);

            return result;

        }

        /// <summary>
        /// 通过立项编号进行查询
        /// </summary>
        /// <param name="proposal_number">立项编号</param>
        /// <returns></returns>
        static public bool ProjectNumberVision(string proposal_number)
        {
            string query = "select *from ProjectApplications where proposal_number = '@proposal_number';";
            SqlParameter[] parameters = {
                new SqlParameter("@proposal_number",SqlDbType.NVarChar){Value = proposal_number},
            };
            object rowsAffected = DBHelper.GetSingle(query, parameters);
            int count = Convert.ToInt32(rowsAffected);

            return count > 0;

        }


        /// <summary>
        /// 利用立项编号对应删除表中的该项目信息
        /// </summary>
        /// <param name="project_id">项目id</param>
        /// <returns></returns>
        static public bool ProjectDeteleVision(string project_id)
        {
            string query = "DELETE FROM ProjectApplications WHERE project_id=@project_id;";
            SqlParameter[] parameters =
            {
                new SqlParameter("@project_id",SqlDbType.Int) {Value = project_id},
            };

            int rowsAffecteed = DBHelper.ExecuteSql(query, parameters);

            return (rowsAffecteed > 0);
        }

    }
}
