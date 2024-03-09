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
        static public DataSet Apart(string TableName, string CellId, int count)
        {
            string query = "select top 12 *" +
                "from (select row_number()" +
                " over(order by "+ CellId + " asc) as rownumber,* from " +
                ""+ TableName + ") temp_row" +
                " where rownumber >"+count+"  *12";
            //SqlParameter[] parameters =
            //{
            //    new SqlParameter("@count",SqlDbType.Int) { Value = count}
            //};

            DataSet result = DBHelper.Query(query);

            return result; 
        }
    }
}
