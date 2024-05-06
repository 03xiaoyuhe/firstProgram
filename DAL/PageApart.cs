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
    public class PageApart
    {
        /// <summary>
        /// 通过三个变量进行分页输出数据
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="CellId">字段名</param>
        /// <param name="count">页数-1</param>
        /// <returns></returns>
        static public DataSet Apart(string TableName, string CellId, int count)
        {
            //to do  需要读取config 里的数据

            string query = "select top 10 *" +
                "from (select row_number()" +
                " over(order by "+ CellId + " asc) as rownumber,* from " +
                ""+ TableName + ") temp_row" +
                " where rownumber >"+count+"  *10";
            //SqlParameter[] parameters =
            //{
            //    new SqlParameter("@count",SqlDbType.Int) { Value = count}  
            //};

            DataSet result = DBHelper.Query(query);

            return result; 
        }
    }
}
