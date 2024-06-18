using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

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
            string query = "select * from view_project_infor  order by " + project_id + ";";

            int reslut = DBHelper.ExecuteSql(query);

            return reslut > 0;

        }

        /// <summary>
        /// 对下面两个操作开启事务
        /// 将表添加结项表中，即进行“结项”操作。
        /// 并将申请表中的该项目删除掉。
        /// </summary>
        /// <param name="project_id">项目申请时的id</param>
        /// <returns></returns>
        static public bool ProjectCom(string project_id)
        {
            string query = "begin transaction " +
                "\r\ndeclare @number int \r\nset @number  = 0 \r\n" +
                "\r\ninsert into ProjectComplete\r\n" +
                "(\r\nproject_id," +
                "\r\nuser_number," +
                "\r\nproject_name," +
                "\r\nproject_level," +
                "\r\nproject_number," +
                "\r\nproject_category," +
                "\r\nproject_youth," +
                "\r\nproject_research_," +
                "\r\nproject_view," +
                "\r\nproject_References," +
                "\r\nproject_time," +
                "\r\nproject_form," +
                "\r\nproject_opinion," +
                "\r\nproject_expert_view ," +
                "\r\nproject_approval_view\r\n) select *from ProjectApplications " +
                "where project_id = @project_id\r\n\r\n" +
                "set @number = @number + @@error " +
                "\r\n\r\nDELETE FROM ProjectApplications " +
                "where project_id = @project_id_dele \r\n\r\n" +
                "set @number = @number + @@error\r\n\r\n" +
                "if @number <>0\r\n" +
                "begin \r\nRollback transaction\r\nend\r\n" +
                "else\r\nbegin\r\ncommit transaction\r\nend;";
            SqlParameter[] parameters =
            {
                new SqlParameter("@project_id",SqlDbType.Int) {Value = project_id},
                new SqlParameter("@project_id_dele",SqlDbType.Int) {Value = project_id },
            };

            int rowsAffected = DBHelper.ExecuteSql(query, parameters);

            return (rowsAffected > 0);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="user_phone"></param>
        /// <param name="project_name"></param>
        /// <param name="project_category"></param>
        /// <param name="project_youth"></param>
        /// <param name="project_research"></param>
        /// <param name="project_view"></param>
        /// <param name="project_References"></param>
        /// <param name="project_time"></param>
        /// <param name="project_form"></param>
        /// <param name="user_name"></param>
        /// <param name="user_date"></param>
        /// <param name="user_sex"></param>
        /// <param name="user_position"></param>
        /// <param name="user_title"></param>
        /// <param name="user_speciality"></param>
        /// <param name="user_research"></param>
        /// <param name="user_research_now"></param>
        /// <param name="user_workplace"></param>
        /// <param name="user_address"></param>
        /// <param name="user_office_number"></param>
        /// <param name="user_number"></param>
        /// <param name="user_email"></param>
        /// <returns></returns>
        static public bool ProjectInfor_Test(
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
        string project_form,
        string user_name,
        string user_date,
        string user_sex,
        string user_position,
        string user_title,
        string user_speciality,
        string user_research,
        string user_research_now,
        string user_workplace,
        string user_address,
        string user_office_number,
        string user_number,
        string user_email
     )
        {


            // string query = "insert into ProjectApplications  (\r\nteam_id,\r\nproject_name,\r\nproject_level,\r\nproject_number,\r\nproject_category,\r\nproject_youth,\r\nproject_research,\r\nproject_view,\r\nproject_References,\r\nproject_time,\r\nproject_form\r\n) values (@team_id,\r\n@project_name,\r\n@project_level,\r\n@project_number,\r\n@project_category,\r\n@project_youth,\r\n@project_research,\r\n@project_view,\r\n@project_References,\r\n@project_time,\r\n@project_form );";
            string query =
            "begin transaction " +
            "declare @Number int " +
            "set @Number = 0" +

            "insert into ProjectApplications " +
            "(user_phone,project_name,project_category,project_youth,project_research," +
            "project_view,project_References,project_time,project_form) " +
            "values (@user_phone,@project_name,@project_category,@project_youth,@project_research," +
            "@project_view,@project_References,@project_time,@project_form )" +

            "set @Number = @Number + @@error  " +

            "insert into UserInfor " +
            "(user_name,user_date, user_sex,user_position,user_title,user_speciality,user_research," +
            "user_research_now,user_workplace,user_address,user_office_number,user_number,user_email) " +
            "values (@user_name,@user_date, @user_sex,@user_position,@user_title,@user_speciality,@user_research," +
            "@user_research_now,@user_workplace,@user_address,@user_office_number,@user_number,@user_email)" +

            "set @Number = @Number + @@error " +

            "if @Number<>0" +
            "begin " +
            "Rollback transaction " +
            "end " +
            "else " +
            " begin " +
            " commit transaction " +
            " end;";

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
                new SqlParameter("@project_form", SqlDbType.NVarChar) { Value = project_form },
                new SqlParameter("@user_name",SqlDbType.NVarChar) { Value = user_name },
                new SqlParameter("@user_date",SqlDbType.Date) { Value = user_date },
                new SqlParameter("@user_sex",SqlDbType.NVarChar) { Value = user_sex },
                new SqlParameter("@user_position",SqlDbType.NVarChar) { Value = user_position },
                new SqlParameter("@user_title",SqlDbType.NVarChar) { Value = user_title },
                new SqlParameter("@user_speciality",SqlDbType.NVarChar) { Value = user_speciality },
                new SqlParameter("@user_research",SqlDbType.NVarChar) { Value = user_research },
                new SqlParameter("@user_research_now",SqlDbType.NVarChar) { Value = user_research_now },
                new SqlParameter("@user_workplace",SqlDbType.NVarChar) { Value = user_workplace },
                new SqlParameter("@user_address",SqlDbType.NVarChar) { Value = user_address },
                new SqlParameter("@user_office_number",SqlDbType.NVarChar) { Value = user_office_number },
                new SqlParameter("@user_number",SqlDbType.NVarChar) { Value = user_number},
                new SqlParameter("@user_email",SqlDbType.NVarChar) { Value = user_email },
            };

            int rowsAffected = DBHelper.ExecuteSql(query, parameters);

            return rowsAffected > 0;
        }

        /// <summary>
        /// 通过立项编号删除数据
        /// </summary>
        /// <param name="project_id"></param>
        /// <returns></returns>
        public static bool DeleteInfor(string project_id)
        {
            string query = "delete from ProjectApplications where project_id = @project_id";
            SqlParameter[] parameters =
            {
                new SqlParameter("@project_id",SqlDbType.Int) { Value = project_id },
            };
            int rowAfforts = DBHelper.ExecuteSql(query, parameters);

            return rowAfforts > 0;
        }



        /// <summary>
        /// 插入项目表
        /// </summary>
        /// <param name="project_leader"></param>
        /// <param name="project_name"></param>
        /// <param name="project_level"></param>
        /// <param name="project_number"></param>
        /// <param name="project_category"></param>
        /// <param name="project_youth"></param>
        /// <param name="project_research"></param>
        /// <param name="project_view"></param>
        /// <param name="project_References"></param>
        /// <param name="project_time"></param>
        /// <param name="project_form"></param>
        /// <param name="project_opinion"></param>
        /// <param name="project_expert_view"></param>
        /// <param name="project_approval_view"></param>
        /// <returns></returns>
        static public bool KindsInsert(
               string project_leader,
               string project_name,
               string project_level,
               string project_number,
               string project_category,
               string project_youth,
               string project_research,
               string project_view,
               string project_References,
               string project_time,
               string project_form,
               string project_opinion,
               string project_expert_view,
               string project_approval_view
            )
        {
            //project_time = (DateTime.Parse(project_time)).ToString("d");
            //string query = " insert into ProjectApplications ( project_leader,under_research ,\r\nproject_name ,\r\nproject_level ,\r\nproject_number,\r\nproject_category,\r\nproject_youth, \r\nproject_research,\r\nproject_view ,\r\nproject_References,\r\nproject_time ,\r\nproject_form ,\r\nproject_opinion ,\r\nproject_expert_view ,\r\nproject_approval_view) values \r\n( @project_leader ,'True',@project_name,\r\n@project_level ,\r\n@project_number,\r\n@project_category,\r\n@project_youth, \r\n@project_research,\r\n@project_view ,\r\n@project_References,\r\n@project_time ,\r\n@project_form ,\r\n@project_opinion ,\r\n@project_expert_view ,\r\n@project_approval_view); \r\n";
            string query = "\r\nbegin transaction\r\ndeclare @num int\r\nset @num = 0\r\n\r\n insert into ProjectApplications (\r\n project_leader,under_research ,\r\nproject_name ,\r\nproject_level ,\r\nproject_number,\r\nproject_category,\r\nproject_youth,\r\nproject_research,\r\nproject_view ,\r\nproject_References,\r\nproject_time ,\r\nproject_form,\r\nproject_opinion ,\r\nproject_expert_view ,\r\nproject_approval_view)\r\nvalues \r\n( @project_leader ,'True',@project_name,@project_level ,@project_number,@project_category,@project_youth, @project_research,@project_view ,@project_References,@project_time ,@project_form ,@project_opinion ,@project_expert_view ,@project_approval_view)\r\nset @num = @num + @@error\r\nif @num = 0\r\nbegin\r\ninsert into ProjectMember (ProjectId,UserId,IsLeader) values ((select project_id from ProjectApplications where project_number = '" + project_number + "')," + project_leader + ",1)\r\nset @num = @num + @@error\r\nif @num = 0\r\nbegin \r\ncommit transaction\r\nend\r\nelse\r\nbegin\r\nRollback transaction\r\nend\r\nend\r\nelse\r\nbegin\r\nRollback transaction\r\nend";
            SqlParameter[] parameters = {
                new SqlParameter("@project_leader", SqlDbType.NVarChar) { Value = project_leader },
                new SqlParameter("@project_name", SqlDbType.NVarChar) { Value = project_name },
                new SqlParameter("@project_level", SqlDbType.NVarChar) { Value = project_level },
                new SqlParameter("@project_number", SqlDbType.NVarChar) { Value = project_number },
                new SqlParameter("@project_category", SqlDbType.NVarChar) { Value = project_category },
                new SqlParameter("@project_youth", SqlDbType.NVarChar) { Value = project_youth },
                new SqlParameter("@project_research", SqlDbType.NVarChar) { Value = project_research },
                new SqlParameter("@project_view", SqlDbType.NVarChar) { Value = project_view },
                new SqlParameter("@project_References", SqlDbType.NVarChar) { Value = project_References },
                new SqlParameter("@project_time", SqlDbType.Date) { Value = project_time },
                new SqlParameter("@project_form", SqlDbType.NVarChar) { Value = project_form },
                new SqlParameter("@project_opinion", SqlDbType.NVarChar) { Value = project_opinion },
                new SqlParameter("@project_expert_view", SqlDbType.NVarChar) { Value = project_expert_view },
                new SqlParameter("@project_approval_view", SqlDbType.NVarChar) { Value = project_approval_view },
            };

            int rowsAffected = DBHelper.ExecuteSql(query, parameters);

            return rowsAffected > 0;

        }
        /// <summary>
        /// 检查是否只有汉字
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsChineseCh(string input)
        {
            Regex regex = new Regex("^[\u4e00-\u9fa5]+$");
            return regex.IsMatch(input);
        }

        static public bool KidsInfor(
               string project_leader,
               string project_name,
               string project_level,
               string project_number,
               string project_category,
               string project_youth,
               string project_research,
               string project_view,
               string project_References,
               string project_time,
               string project_form,
               string project_opinion,
               string project_expert_view,
               string project_approval_view,
               List<string> UserName  //队员姓名               
            )
        {
            if (UserName.Count == 0)
            {
                return KindsInsert(
                project_leader,
                project_name,
                project_level,
                project_number,
                project_category,
                project_youth,
                project_research,
                project_view,
                project_References,
                project_time,
                project_form,
                project_opinion,
                project_expert_view,
                project_approval_view);

            }
            else
            {
                string query1 = "begin transaction\r\ndeclare @error int\r\nset @error = 0\r\ninsert into ProjectApplications \r\n( project_leader,\r\nunder_research ,\r\nproject_name ,\r\nproject_level ,\r\nproject_number,\r\nproject_category,\r\nproject_youth,\r\nproject_research,\r\nproject_view ,\r\nproject_References,\r\nproject_time ,project_form ,project_opinion ,project_expert_view ,project_approval_view) \r\nvalues\r\n( @project_leader ,'True',@project_name,@project_level ,@project_number,@project_category,@project_youth, @project_research,@project_view ,@project_References,@project_time ,@project_form ,@project_opinion ,@project_expert_view ,@project_approval_view); \r\nset @error = @@error + @error\r\n\r\nif(@error=0)\r\nbegin\r\nset @error = 0";
                string query3 = "set @error = @@error + @error \r\nif(@error=0)\r\nbegin \r\ncommit transaction\r\nend\r\nelse\r\nbegin\r\nRollback transaction\r\nend\r\nend\r\nelse\r\nbegin\r\nRollback transaction\r\nend";

                string query2 = "insert into ProjectMember (ProjectId,UserId) values \r\n((select project_id from ProjectApplications where project_number = @project_number),";

                List<SqlParameter> parameters = new List<SqlParameter>();
                int count = UserName.Count;

                for (int i = 0; i < count; i++)
                {
                    if (IsChineseCh(UserName[i]))
                    {
                        query2 += (i == 0 ? "" : ",") + $"(select Id from UserInfor where UseName = @UseName{i})";
                        parameters.Add(new SqlParameter($"@UseName{i}", SqlDbType.NVarChar) { Value = UserName[i] });
                    }
                    else
                    {
                        query2 += (i == 0 ? "" : ",") + $"(select Id from UserInfor where Id = @UseName{i})";
                        parameters.Add(new SqlParameter($"@UseName{i}", SqlDbType.NVarChar) { Value = UserName[i] });
                    }


                }

                query2 += ")";

                query1 = query1 + query2 + query3;

                parameters.Add(new SqlParameter("@project_leader", SqlDbType.NVarChar) { Value = project_leader });
                parameters.Add(new SqlParameter("@project_opinion", SqlDbType.NVarChar) { Value = project_opinion });
                parameters.Add(new SqlParameter("@project_name", SqlDbType.NVarChar) { Value = project_name });
                parameters.Add(new SqlParameter("@project_level", SqlDbType.NVarChar) { Value = project_level });
                parameters.Add(new SqlParameter("@project_number", SqlDbType.NVarChar) { Value = project_number });
                parameters.Add(new SqlParameter("@project_category", SqlDbType.NVarChar) { Value = project_category });
                parameters.Add(new SqlParameter("@project_youth", SqlDbType.NVarChar) { Value = project_youth });
                parameters.Add(new SqlParameter("@project_research", SqlDbType.NVarChar) { Value = project_research });
                parameters.Add(new SqlParameter("@project_view", SqlDbType.NVarChar) { Value = project_view });
                parameters.Add(new SqlParameter("@project_References", SqlDbType.NVarChar) { Value = project_References });
                parameters.Add(new SqlParameter("@project_time", SqlDbType.Date) { Value = project_time });
                parameters.Add(new SqlParameter("@project_form", SqlDbType.NVarChar) { Value = project_form });
                parameters.Add(new SqlParameter("@project_expert_view", SqlDbType.NVarChar) { Value = project_expert_view });
                parameters.Add(new SqlParameter("@project_approval_view", SqlDbType.NVarChar) { Value = project_approval_view });

                int rowsAffected = DBHelper.ExecuteSql(query1, parameters);

                return rowsAffected > 0;
            }

        }


    }
}
