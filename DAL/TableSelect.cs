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
    public class TableSelect
    {
        
        /// <summary>
        /// 对所有的表都适合的查询单行操作
        /// 其中函数需要三个变量
        /// 分别为 “表名” “字段名” “字段名对应的值”
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="CellId">字段名</param>
        /// <param name="Id">字段名对应的值</param>
        /// <returns></returns>
        static public DataSet Select(string TableName, string CellId, string Id)
        {
            string query = "SELECT *FROM "+ TableName + " WHERE "+ CellId  + "= @Id order by "+ CellId + " asc;";


            SqlParameter[] parameters = {
                new SqlParameter("@Id",SqlDbType.NVarChar) {Value=Id},
            };

            DataSet result = DBHelper.Query(query, parameters);

            return result;
        }

        /// <summary>
        /// 显示项目详细信息时调用，用于显示负责人的基本信息
        /// </summary>
        /// <param name="project_id">项目id</param>
        /// <returns></returns>
        static public DataSet UserSelect(string project_id)
        {
            string query = "select *from UserInfor where user_number =  " +
                "(\r\nselect user_phone from ProjectApplications where project_id = @project_id \r\n);";
            SqlParameter[] parameters =
            {
                new  SqlParameter("@project_id",SqlDbType.NVarChar) {Value = project_id},
            };

            DataSet result = DBHelper.Query(query, parameters);

            return result;
            
        }
    }
}
