using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net.NetworkInformation;
using System.Collections;

namespace DAL
{
    public class PageApart
    {
        /// <summary>
        /// 分页查询数据，并由排序功能
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="CellId">排序字段</param>
        /// <param name="count">页数-1</param>
        /// <param name="value">正序或倒叙</param>
        /// <returns></returns>
        static public DataSet Apart(string TableName, string CellId, int count,string value)
        {
            //to do  需要读取config 里的数据

            string query = "select top 10 *" +
                "from (select row_number()" +
                " over(order by "+ CellId + " "+ value +") as rownumber,* from " +
                ""+ TableName + ") temp_row" +
                " where rownumber >"+count+"  *10";
            //SqlParameter[] parameters =
            //{
            //    new SqlParameter("@count",SqlDbType.Int) { Value = count}  
            //};

            DataSet result = DBHelper.Query(query);
            return result; 
        }
        /// <summary>
        /// 对筛选后的数据显示并有排序功能
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="CellId"></param>
        /// <param name="count"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        static public DataSet ApartSelect(string sql, string CellId, int count,string value)
        {
            string query1 = "create view a as " + sql;
            string query2 = 
                "select top 10 *" +
                "from (select row_number()" +
                " over(order by " +CellId + " " + value + ") as rownumber,* from a " +
                   ") temp_row" +
                " where rownumber >" + count + "  *10;\r\n"
                + "drop view a;";
            int rowAfforts = DBHelper.ExecuteSql(query1);
            DataSet result = DBHelper.Query(query2);
            return result;
        }
    }
}
