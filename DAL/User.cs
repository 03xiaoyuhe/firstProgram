using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace DAL
{
    public class User
    {

        /// <summary>
        /// 查询用户的账号密码是否在数据库中
        /// </summary>
        /// <param name="user_account">账号</param>
        /// <param name="user_psw">密码</param>
        /// <returns></returns>
        static public bool AuthenticateUser(string user_account, string user_psw)
        {
            string query = "SELECT user_account ,user_psw FROM UserInfor WHERE user_account = @user_account AND user_psw =@user_psw;";
            SqlParameter[] parameters = {
                new SqlParameter("@user_account", SqlDbType.NVarChar) { Value = user_account },
                new SqlParameter("@user_psw", SqlDbType.NVarChar) { Value = user_psw }
            };

            DataSet result = DBHelper.Query(query, parameters);

            DataTable dt = result.Tables[0];

            int count = Convert.ToInt32(dt.Rows[0]["count"]);

            return count > 0;
        }


        /// <summary>
        /// 查询账号是否存在
        /// </summary>
        /// <param name="username">账号</param>
        /// <returns></returns>
        static public bool CheckIfAccountExists(string user_account)
        {
            string query = "SELECT COUNT(*) FROM UserInfor WHERE user_account = @user_account";
            SqlParameter[] parameters = {
                new SqlParameter("@user_account", SqlDbType.NVarChar) { Value = user_account }
            };

            object result = DBHelper.GetSingle(query, parameters);
            int count = Convert.ToInt32(result);

            return count > 0;
        }

        /// <summary>
        /// 查询电话号码有没有被注册
        /// </summary>
        /// <param name="number">电话号码</param>
        /// <returns></returns>
        static public bool CheckIfUserNumberExists(string number)
        {
            string query = "select UserControl.control_number,UserInfor.user_number \r\nfrom UserControl, UserInfor \r\nwhere UserControl.control_number = @number or UserInfor.user_number = @number ";
            SqlParameter[] parameters =
            {
                new SqlParameter("@number", SqlDbType.Int) { Value = number }
            };

            int rowsAffected = DBHelper.ExecuteSql(query, parameters);

            return rowsAffected > 0;
        }


        /// <summary>
        /// 注册用户账号密码插入数据库
        /// </summary>
        /// <param name="user_account">账号</param>
        /// <param name="user_psw">密码</param>
        /// <param name="user_number">联系电话</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        static public bool InsertId(string user_account, string user_psw, string user_number)
        {
            if (CheckIfAccountExists(user_account))
            {
                throw new InvalidOperationException("该账号已存在，请重新注册。");
            }

            if (CheckIfUserNumberExists(user_number))
            {
                throw new InvalidOperationException("该电话号码已存在，请重新注册。");
            }

            string query = "INSERT INTO UserInfor (user_account, user_psw, user_number) VALUES (@user_account, @user_psw, @user_number);";
            SqlParameter[] parameters = {
                new SqlParameter("@user_account", SqlDbType.NVarChar) { Value = user_account },
                new SqlParameter("@user_psw", SqlDbType.NVarChar) { Value = user_psw },
                new SqlParameter("@user_number", SqlDbType.NVarChar) { Value = user_number }
            };

            int rowsAffected = DBHelper.ExecuteSql(query, parameters);

            return rowsAffected > 0;
        }

       


        /// <summary>
        /// 插入用户信息
        /// </summary>
        /// <param name="user_name">姓名</param>
        /// <param name="user_date">生日</param>
        /// <param name="user_sex">性别</param>
        /// <param name="user_position">职务</param>
        /// <param name="user_title">职称</param>
        /// <param name="user_speciality">专业</param>
        /// <param name="user_research">研究专长</param>
        /// <param name="user_research_now">现从事专业</param>
        /// <param name="user_workplace">工作单位</param>
        /// <param name="user_address">通信地址</param>
        /// <param name="user_office_number">办公电话</param>
        /// <param name="user_email">邮箱</param>
        /// <returns>整型</returns>
        static public bool Insert_Infor(
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
            string query = "insert into UserInfor (\r\nuser_name,\r\nuser_date, \r\nuser_sex,\r\nuser_position,\r\nuser_title,\r\nuser_speciality,\r\nuser_research,\r\nuser_research_now,\r\nuser_workplace,\r\nuser_address,\r\nuser_office_number,\r\nuser_number,\r\nuser_email\r\n) values (\r\n@user_name,\r\n@user_date, \r\n@user_sex,\r\n@user_position,\r\n@user_title,\r\n@user_speciality,\r\n@user_research,\r\n@user_research_now,\r\n@user_workplace,\r\n@user_address,\r\n@user_office_number,\r\n@user_number,\r\n@user_email\r\n);";
            SqlParameter[] parameters =
            {

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
        /// 通过user_id修改用户信息表中的用户信息。
        /// </summary>
        /// <param name="gender">性别</param>
        /// <param name="contact_number">身份证</param>
        /// <param name="email">邮箱</param>
        /// <param name="date_of_birth">出生日期</param>
        /// <param name="education_degree">学位</param>
        /// <param name="position">职务、职称</param>
        /// <param name="workplace">工作单位</param>
        /// <param name="user_id">用户id</param>
        /// <returns></returns>
        static public bool UpdataeUser(string user_name, string gender, string contact_number, string email, string date_of_birth, string education_degree, string position, string workplace, string user_id)
        {
            string query = "UPDATE UserInfo SET" +
                " gender = '@gender'," +
                "user_name='@user_name'," +
                "contact_number = '@contact_number'," +
                "email = '@email'," +
                "date_of_birth = '@date_of_birth'," +
                "education_degree = '@education_degree'," +
                "position = '@position'," +
                "workplace = '@workplace'" +
                "WHERE user_id = '@user_id';";
            SqlParameter[] parameters =
            {
                new SqlParameter("user_name",SqlDbType.NVarChar){Value = user_name},
                new SqlParameter ("@gender",SqlDbType.NVarChar){Value = gender},
                new SqlParameter ("@contact_number",SqlDbType.NVarChar){Value = contact_number},
                new SqlParameter ("@email",SqlDbType.NVarChar){Value = email},
                new SqlParameter ("@date_of_birth",SqlDbType.Date){Value = date_of_birth},
                new SqlParameter ("@education_degree",SqlDbType.NVarChar){Value = education_degree},
                new SqlParameter ("@position",SqlDbType.NVarChar){Value = position},
                new SqlParameter ("@workplace",SqlDbType.NVarChar){Value = workplace},
                new SqlParameter("@user_id",SqlDbType.Int){Value = user_id},
            };

            int rowsAffected = DBHelper.ExecuteSql(query, parameters);

            return rowsAffected > 0;


        }

        static public bool KindsInsert(
            string UseName,
            string UserDate,
            string UserSex,
            string UserPosition,
            string UserTitle,
            string UserSpeciality,
            string UserResearch,
            string UserResearch_now,
            string UserWorkplace,
            string UserAddress,
            string UserOfficeNumber,
            string UseNumber,
            string UserEmail
            )
        {
            string query = "insert into UserInfor ( \r\nUserName\r\nUserDate,\r\nUserSex,\r\nUserPosition,\r\nUserTitle,\r\nUserSpeciality,\r\nUserResearch,\r\nUserResearch_now,\r\nUserWorkplace,\r\nUserAddress,\r\nUserOfficeNumber,\r\nUseNumber,\r\nUserEmail\r\n) values ( \r\n@UseName,\r\n@UserDate,\r\n@UserSex,\r\n@UserPosition,\r\n@UserTitle,\r\n@UserSpeciality,\r\n@UserResearch,\r\n@UserResearch_now,\r\n@UserWorkplace,\r\n@UserAddress,\r\n@UserOfficeNumber,\r\n@UseNumber,\r\n@UserEmail\r\n); ";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter ("@UserName" ,SqlDbType.NVarChar) {Value = UseName},
                new SqlParameter ("@UserDate" ,SqlDbType.NVarChar) {Value = UserDate},
                new SqlParameter ("@UserSex" ,SqlDbType.NVarChar) {Value = UserSex},
                new SqlParameter ("@UserPosition" ,SqlDbType.NVarChar) {Value = UserPosition},
                new SqlParameter ("@UserTitle" ,SqlDbType.NVarChar) {Value = UserTitle},
                new SqlParameter ("@UserSpeciality" ,SqlDbType.NVarChar) {Value = UserSpeciality},
                new SqlParameter ("@UserResearch" ,SqlDbType.NVarChar) {Value = UserResearch},
                new SqlParameter ("@UserResearch_now" ,SqlDbType.NVarChar) {Value = UserResearch_now},
                new SqlParameter ("@UserWorkplace" ,SqlDbType.NVarChar) {Value = UserWorkplace},
                new SqlParameter ("@UserAddress" ,SqlDbType.NVarChar) {Value = UserAddress},
                new SqlParameter ("@UserOfficeNumber" ,SqlDbType.NVarChar) {Value = UserOfficeNumber},
                new SqlParameter ("@UseNumber" ,SqlDbType.NVarChar) {Value = UseNumber},
                new SqlParameter ("@UserEmail" ,SqlDbType.NVarChar) {Value = UserEmail},
            };

            int rowsAfforts = DBHelper.ExecuteSql(query, parameters);

            return rowsAfforts > 0;
        }


        /// <summary>
        /// 功能实现：绑定负责人信息时检查日期与项目，即 负责人不能在同一年负责两个项目。
        /// </summary>
        //void P()
        //{
        //    //利用字典存datatime 与 项目id     id为键，时间为值
        //    Dictionary<string, HashSet<string>> keyValuePairs = new Dictionary<string, HashSet<string>>();
        //    DataSet dataTable = DBHelper.Query("select project_id,project_time from ProjectApplications where  \r\nProjectApplications.project_id in  \r\n(select ProjectId from ProjectMember where IsLeader = 0) order by project_id asc;");
        //    DataTable dt = dataTable.Tables[0];
        //    foreach(DataRow row in dt.Rows)
        //    {
        //        HashSet<string> hashset = new HashSet<string>();
        //        hashset.Add (row[1].ToString());
        //        if (keyValuePairs.ContainsKey(row[0].ToString()))
        //        {
        //            keyValuePairs[row[0].ToString()] = hashset;
        //        }
        //        else
        //        {
        //            keyValuePairs.Add (row[0].ToString(), hashset);
        //        }
        //    }
        //}

    }
}


