using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class UserInformations
    {
        private readonly string connectionString = "SQpwdLoad";//获取连接数据的字符串。


        /// <summary>
        /// 对Social Philosophy Project数据库中的UserInfo表进行插入操作
        /// </summary>
        /// <param name="gender">性别</param>
        /// <param name="contact_number">身份证号</param>
        /// <param name="email">邮箱</param>
        /// <param name="date_of_birth">出生日期</param>
        /// <param name="education_degree">学历</param>
        /// <param name="position">职业</param>
        /// <param name="workplace">工作地点</param>
        /// <returns></returns>
        public bool RegisterUser(string gender, string contact_number, string email, string date_of_birth, string education_degree, string position, string workplace)
        {
            string query = "INSERT INTO UserInfo (gender, contact_number, email,date_of_birth,education_degree,position,workplace) VALUES (@gender, @contact_number, @email,@email,@date_of_birth,@education_degree,@position,@workplace)";
            SqlParameter[] parameters = {
                new SqlParameter("@gender", SqlDbType.NVarChar) { Value = gender },
                new SqlParameter("@contact_number", SqlDbType.NVarChar) { Value = contact_number },
                new SqlParameter("@email", SqlDbType.NVarChar) { Value = email },
                new SqlParameter("@date_of_birth", SqlDbType.NVarChar) { Value = date_of_birth },
                new SqlParameter("@education_degree", SqlDbType.NVarChar) { Value = education_degree },
                new SqlParameter("@position", SqlDbType.NVarChar) { Value = position },
                new SqlParameter("@workplace", SqlDbType.NVarChar) { Value = workplace },
            };


            int rowsAffected = DBHelper.ExecuteSql(query, parameters);

            return rowsAffected > 0;
        }


        /// <summary>
        /// 通过原值修改为现有的值，针对性别
        /// </summary>      
        /// <param name="useNumber">电话号码</param>
        /// <param name="gender">正确的修改为的值</param>
        /// <returns></returns>
        public bool UpdataRegisterGender(string useNumber, string gender)
        {
            string query = "UPDATE UserInfo SET gender='@gender' " +
                "WHERE " +
                " user_id=" +
                "(select user_idfrom UserInfo where " +
                "user_id=(select user_id from UserLogin where useNumber='@useNumber'))";

            SqlParameter[] parameters = {
                new SqlParameter("@gender", SqlDbType.NVarChar) { Value = gender },
                new SqlParameter("@useNumber", SqlDbType.NVarChar) { Value = useNumber },

                        };


            int rowsAffected = DBHelper.ExecuteSql(query, parameters);

            return rowsAffected > 0;
        }


        /// <summary>
        /// 通过原值修改为现有的值，针对身份证号
        /// </summary>
        /// <param name="useNumber">电话号码</param>
        /// <param name="contact_number">现身份证号</param>
        /// <returns></returns>
        public bool UpdataRegisterContact(string useNumber, string contact_number)
        {
            string query = "UPDATE UserInfo SET " +
                "contact_number='@contact_number' WHERE " +
                " user_id=(select user_id from UserInfo where " +
                "user_id=(select user_id from UserLogin where useNumber='@useNumber'))";

            SqlParameter[] parameters = {
                new SqlParameter("@contact_number", SqlDbType.NVarChar) { Value = contact_number },
                new SqlParameter("@useNumber", SqlDbType.NVarChar) { Value = useNumber },

                        };


            int rowsAffected = DBHelper.ExecuteSql(query, parameters);

            return rowsAffected > 0;
        }


        /// <summary>
        /// 通过原值修改为现有的值,针对邮箱
        /// </summary>
        /// <param name="useNumber">电话号码</param>
        /// <param name="email">现邮箱</param>
        /// <returns></returns>
        public bool UpdataRegisterEmail(string useNumber, string email)
        {
            string query = "UPDATE UserInfo SET email='@email'" +
                " WHERE  user_id=(select user_id from UserInfo where" +
                " user_id=(select user_id from UserLogin where useNumber='@useNumber'));";

            SqlParameter[] parameters = {
                new SqlParameter("@email", SqlDbType.NVarChar) { Value = email },
                new SqlParameter("@useNumber", SqlDbType.NVarChar) { Value = useNumber },

                        };


            int rowsAffected = DBHelper.ExecuteSql(query, parameters);

            return rowsAffected > 0;
        }



        /// <summary>
        /// 通过原值修改为现有的值,针对出生日期
        /// </summary>
        /// <param name="useNumber">电话号码</param>
        /// <param name="brith">现生日</param>
        /// <returns></returns>
        public bool UpdataRegisterBrith(string useNumber, string brith)
        {
            string query = "UPDATE UserInfo SET date_of_birth='@brith' WHERE " +
                " user_id=(select user_id from UserInfo where " +
                "user_id=(select user_id from UserLogin where useNumber='@useNumber'));";

            SqlParameter[] parameters = {
                new SqlParameter("@brith", SqlDbType.NVarChar) { Value = brith },
                new SqlParameter("@useNumber", SqlDbType.NVarChar) { Value = useNumber },

                        };


            int rowsAffected = DBHelper.ExecuteSql(query, parameters);

            return rowsAffected > 0;
        }



        /// <summary>
        /// 通过原值修改为现有的值，针对学历
        /// </summary>
        /// <param name="useNumber">电话号码</param>
        /// <param name="Education">现学历</param>
        /// <returns></returns>
        public bool UpdataRegisterEducation(string useNumber, string Education)
        {
            string query = "UPDATE UserInfo SET education_degree='@Education' " +
                "WHERE  user_id=(select user_id from UserInfo where" +
                " user_id=(select user_id from UserLogin where useNumber='@useNumber'));";

            SqlParameter[] parameters = {
                new SqlParameter("@Education", SqlDbType.NVarChar) { Value = Education },
                new SqlParameter("@useNumber", SqlDbType.NVarChar) { Value = useNumber },

                        };


            int rowsAffected = DBHelper.ExecuteSql(query, parameters);

            return rowsAffected > 0;
        }


        /// <summary>
        /// 通过原值修改为现有的值，针对职业
        /// </summary>
        /// <param name="useNumber">电话号码</param>
        /// <param name="position">现职业</param>
        /// <returns></returns>
        public bool UpdataRegisterPosition(string useNumber, string position)
        {
            string query = "UPDATE UserInfo SET position='@position' " +
                "WHERE  user_id=(select user_id from UserInfo " +
                "where user_id=(select user_id from UserLogin where useNumber='@useNumber'));";

            SqlParameter[] parameters = {
            
                new SqlParameter("@position", SqlDbType.NVarChar) { Value = position },
                new SqlParameter("@useNumber", SqlDbType.NVarChar) { Value = useNumber },

                        };


            int rowsAffected = DBHelper.ExecuteSql(query, parameters);

            return rowsAffected > 0;
        }


        /// <summary>
        /// 通过原值修改为现有的值，针对工作地点
        /// </summary>
        /// <param name="useNumber">原工作地点</param>
        /// <param name="work">现工作地点</param>
        /// <returns></returns>
        public bool UpdataRegisterWork(string useNumber, string work)
        {
            string query = "UPDATE UserInfo SET workplace='@workplace' " +
                "WHERE  user_id=(select user_id from UserInfo where " +
                "user_id=(select user_id from UserLogin where useNumber='@useNumber'));";

            SqlParameter[] parameters = {
                new SqlParameter("@work", SqlDbType.NVarChar) { Value = work },
                new SqlParameter("@useNumber", SqlDbType.NVarChar) { Value = useNumber },

                        };


            int rowsAffected = DBHelper.ExecuteSql(query, parameters);

            return rowsAffected > 0;
        }





    }
}
  

