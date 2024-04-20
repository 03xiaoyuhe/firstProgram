using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Xml.Serialization.Configuration;

namespace DAL
{   
    public class ProjectCompletion
    {
        ///// <summary>
        ///// 查询小队id是否存在
        ///// </summary>
        ///// <param name="teateam_info_idm_id">小队id</param>
        ///// <returns></returns>
        //static public bool  CheckTeam_id(string teateam_info_idm_id)
        //{
        //    string query = "select TeamInfo.team_info_id from TeamInfo where team_info_id = @team_info_id";
        //    SqlParameter[] parameters =
        //    {
        //        new SqlParameter("@team_info_id",SqlDbType.Int ) { Value = teateam_info_idm_id },
        //    };

        //    object rowsAffected = DBHelper.GetSingle(query, parameters);
        //    int count = Convert.ToInt32(rowsAffected);

        //    return (count > 0);

        //}

        /// <summary>
        /// 像项目表插入所有信息
        /// </summary>
        /// <param name="user_phone">负责人电话号码</param>
        /// <param name="project_name">项目名称</param>
        /// <param name="project_level">项目评级</param>
        /// <param name="project_number">立项编号</param>
        /// <param name="project_category">项目类别</param>
        /// <param name="project_youth">是否符合青年项目申报条件</param>
        /// <param name="project_research">本项目国内外研究现状述评，选题意义与价值</param>
        /// <param name="project_view">本项目研究的主要观点、基本思路和方法、重点、难点以及创新之处</param>
        /// <param name="project_References">项目负责人和主要成员前期研究成果及主要参考文献</param>
        /// <param name="project_time">项目完成时间</param>
        /// <param name="project_form">成果形式</param>
        /// <returns>rowsAffected整型值</returns>
        static public bool ProjectInfor(
               string user_phone,
               string project_name,
               //string project_level,
               //string project_number,
               string project_category,
               string project_youth,
               string project_research,
               string project_view,
               string project_References,
               string project_time,
               string project_form
            )
        {
            
           // string query = "insert into ProjectApplications  (\r\nteam_id,\r\nproject_name,\r\nproject_level,\r\nproject_number,\r\nproject_category,\r\nproject_youth,\r\nproject_research,\r\nproject_view,\r\nproject_References,\r\nproject_time,\r\nproject_form\r\n) values (@team_id,\r\n@project_name,\r\n@project_level,\r\n@project_number,\r\n@project_category,\r\n@project_youth,\r\n@project_research,\r\n@project_view,\r\n@project_References,\r\n@project_time,\r\n@project_form );";
            string query = "insert into ProjectApplications  (\r\nuser_phone,\r\nproject_name,\r\nproject_category,\r\nproject_youth,\r\nproject_research,\r\nproject_view,\r\nproject_References,\r\nproject_time,\r\nproject_form\r\n) values (@user_phone,\r\n@project_name,\r\n@project_category,\r\n@project_youth,\r\n@project_research,\r\n@project_view,\r\n@project_References,\r\n@project_time,\r\n@project_form );";

            SqlParameter[] parameters = {   
                new SqlParameter("@user_phone", SqlDbType.NVarChar) { Value = user_phone },
                new SqlParameter("@project_name", SqlDbType.NVarChar) { Value = project_name },
                //new SqlParameter("@project_level", SqlDbType.NVarChar) { Value = project_level },
                //new SqlParameter("@project_number", SqlDbType.NVarChar) { Value = project_number },
                new SqlParameter("@project_category", SqlDbType.NVarChar) { Value = project_category },
                new SqlParameter("@project_youth", SqlDbType.NVarChar) { Value = project_youth },
                new SqlParameter("@project_research", SqlDbType.NVarChar) { Value = project_research },
                new SqlParameter("@project_view", SqlDbType.NVarChar) { Value = project_view },
                new SqlParameter("@project_References", SqlDbType.NVarChar) { Value = project_References },
                new SqlParameter("@project_time", SqlDbType.Date) { Value = project_time },
                new SqlParameter("@project_form", SqlDbType.NVarChar) { Value = project_form }
            };

            int rowsAffected = DBHelper.ExecuteSql(query, parameters);

            return rowsAffected > 0;
        }

        /// <summary>
        /// 更新表中的数据，通过项目id
        /// </summary>
        /// <param name="project_id">项目id</param>
        /// <param name="team_id">小队id</param>
        /// <param name="project_name">项目名称</param>
        /// <param name="project_level">项目评级</param>
        /// <param name="project_number">立项编号</param>
        /// <param name="project_category">项目类别</param>
        /// <param name="project_youth">是否符合青年项目申报条件</param>
        /// <param name="project_research">本项目国内外研究现状述评，选题意义与价值</param>
        /// <param name="project_view">本项目研究的主要观点、基本思路和方法、重点、难点以及创新之处</param>
        /// <param name="project_References">项目负责人和主要成员前期研究成果及主要参考文献</param>
        /// <param name="project_time">项目完成时间</param>
        /// <param name="project_form">成果形式</param>
        /// <returns>整型</returns>
        static public bool UpdatePrroject(
               string project_id,
               //string team_id,
               string project_name,
               //string project_level,
               //string project_number,
               string project_category,
               string project_youth,
               string project_research,
               string project_view,
               string project_References,
               string project_time,
               string project_form
            )
        {
            //string query = "update ProjectApplications set \r\nteam_id = @team_id, \r\nproject_name = @project_name, \r\nproject_level = @project_level, \r\nproject_number = @project_number, \r\nproject_category = @project_category, \r\nproject_youth = @project_youth, \r\nproject_research = @project_research, \r\nproject_view = @project_view, \r\nproject_References = @project_References, \r\nproject_time = @project_time, \r\nproject_form = @project_form, \r\nwhere project_id = @project_id;";
            string query = "update ProjectApplications set   \r\nproject_number = @project_number, \r\nproject_category = @project_category, \r\nproject_youth = @project_youth, \r\nproject_research = @project_research, \r\nproject_view = @project_view, \r\nproject_References = @project_References, \r\nproject_time = @project_time, \r\nproject_form = @project_form, \r\nwhere project_id = @project_id;";

            SqlParameter[] parameters =
            {
                new SqlParameter("@project_id",SqlDbType.Int) { Value = project_id},
                //new SqlParameter("@team_id",SqlDbType.Int) { Value = team_id},
                new SqlParameter("@project_name",SqlDbType.Int) { Value = project_name},
                //new SqlParameter("@project_level",SqlDbType.Int) { Value = project_level},
                //new SqlParameter("@project_number",SqlDbType.Int) { Value = project_number},
                new SqlParameter("@project_category",SqlDbType.Int) { Value = project_category},
                new SqlParameter("@project_youth",SqlDbType.Int) { Value = project_youth},
                new SqlParameter("@project_research",SqlDbType.Int) { Value = project_research},
                new SqlParameter("@project_view",SqlDbType.Int) { Value = project_view},
                new SqlParameter("@project_References",SqlDbType.Int) { Value = project_References},
                new SqlParameter("@project_time",SqlDbType.Int) { Value = project_time},
                new SqlParameter("@project_form",SqlDbType.Int) { Value = project_form},
            };
            int rowsAffected = DBHelper.ExecuteSql(query, parameters);

            return rowsAffected > 0;
        }
        /// <summary>
        /// 显示所有项目信息并通过项目id升序排列
        /// </summary>
        /// <param name="project_id">项目id</param>
        /// <returns></returns>
        static public bool ProjectDeteleVision(string project_id)
        {
            string query = "select * from view_project_infor  order by "+ project_id + ";";

            int reslut = DBHelper.ExecuteSql(query);

            return reslut>0;

        }



    }
}
