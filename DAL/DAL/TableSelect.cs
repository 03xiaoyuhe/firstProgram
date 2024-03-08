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
        static public bool Select(string TableName, string CellId, string Id)
        {
            string query = "SELECT *FROM @TableName WHERE @CellId=@Id;";

            SqlParameter[] parameters =
             {
                new SqlParameter("@TableName",SqlDbType.Int) {Value = TableName},
                new SqlParameter("@CellId",SqlDbType.NVarChar) {Value = CellId},
                new SqlParameter("@Id",SqlDbType.NVarChar) {Value=Id},
            };

            object rowsAffected = DBHelper.GetSingle(query, parameters);

            int count = Convert.ToInt32(rowsAffected);

            return (count > 0);
        }
    }
}
