using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AllRoads
    {
        /// <summary>
        /// 查询操作
        /// </summary>
        /// <param name="name">查询的表的名字</param>
        /// <returns>DataSet</returns>
        static public DataSet Vision(string name)
        {
            string query = "select *from @name ";//更改为你要查询的表的名字
            SqlParameter[] parameters = {
                new SqlParameter("@name",SqlDbType.NVarChar) {Value = name},
            };
            DataSet result = DBHelper.Query(query);

            return result;
        }


        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="biao_name">表的名字</param>
        /// <param name="ziduan">删除的字段</param>
        /// <param name="ziduan_zhi">字段的对应值</param>
        /// <returns>影响的条数</returns>
        static public bool Delete(string biao_name,string ziduan,string ziduan_zhi)
        {
            string query = "delete from @biao_name where @ziduan = '@ziduan_zhi'";

            SqlParameter[] parameters = {
                new SqlParameter("@biao_name",SqlDbType.NVarChar) {Value = biao_name},
                new SqlParameter("@ziduan",SqlDbType.NVarChar) {Value = ziduan},
                new SqlParameter("@ziduan_zhi",SqlDbType.NVarChar) {Value = ziduan_zhi}
            };

            int rowAffort = DBHelper.ExecuteSql(query, parameters);

            return rowAffort > 0;
        }

    }
}
