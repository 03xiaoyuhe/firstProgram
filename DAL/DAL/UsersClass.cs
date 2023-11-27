using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserClass
    {
        private static string formName = "UserLogin";

        #region 字段名
        /// <summary>
        /// 字段名指代为密码
        /// </summary>
        private static string fieldPwd = "password";

        private static string fieldId = "username";



        #endregion

        // formValues.add()

        //用户登录的方法
        /// <summary>
        /// 用来检测输入的用户名与密码是否在数据库中
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="psw">密码</param>
        /// <returns>返回值为DataSet，内容为对应的信息，若没有就返回值为Null(返回值待验证)</returns>
        public DataSet checkId(string name)
        {
            string strsql = "select * from " + formName + " where " + fieldId + " = '" + name;
            return DBHelper.Query(strsql);
        }


        /// <summary>
        /// 向数据库中插入用户名和密码
        /// </summary>
        /// <param name="name">用户输入的用户名</param>
        /// <param name="psw">用户输入的密码</param>
        /// <returns>返回影响的条数</returns>
        public int insertId(string name, string psw)
        {
            
            string strsql = "insert into" + formName + "(" + fieldId + "," + fieldPwd + ") values("+ "'"+ name + " '"+ "," + "'" + psw + " '" + ")";
            return DBHelper.ExecuteSql(strsql);
        }

        ///<summary>
        ///
        ///</summary>
        public int deleteId(string name, string psw)
        {

            string strsql = "delete from" + formName + "where" +"("+ fieldId+ " = " + " name "+"and" + fieldPwd + " = " +"'"+ psw + "'";
            return DBHelper.ExecuteSql(strsql);
        }



    }



}
