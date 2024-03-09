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

    public class TableDetele
    {
        /// <summary>
        /// 对所有的表都适合的删除操作
        /// 其中函数需要三个标量
        /// 分别为 “表名” “字段名” “字段名对应的值”
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="CellId">字段名</param>
        /// <param name="Id">字段名对应的值</param>
        /// <returns></returns>
        static public bool Delete(string TableName,string CellId,string Id)
        {
            string query = "DELETE FROM "+ TableName + " WHERE "+ CellId + " = @Id;";
            SqlParameter [] parameters =
             {
                new SqlParameter("@Id",SqlDbType.NVarChar) {Value=Id},
            };
            object rowsAffected = DBHelper.GetSingle(query, parameters);

            int count = Convert.ToInt32(rowsAffected);

            return (count>0);
        }
    }
}
