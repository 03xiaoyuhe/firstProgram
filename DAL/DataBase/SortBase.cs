using System.Data;

namespace DAL.DataBase
{
    public class SortBase
    {
        /// <summary>
        /// 构建SQL语句
        /// </summary>
        /// <param name="SortTable">用于排序的表</param>
        /// <param name="SortRule">SQL排序规则</param>
        /// <param name="OutTable">结果输出表</param>
        /// <returns></returns>
        static public string BulidSQL(string SortTable, string SortRule, string OutTable)
        {
            string SQL =
                "--排序功能区                                                 " + "\n" +

                "--AddTime 升序, ID 升序                                      " + "\n" +
                "--select* from DS_Finance ORDER BY AddTime, ID;              " + "\n" +

                "           DECLARE @SortSQL NVARCHAR(MAX); --分页查询语句    " + "\n" +

                "DECLARE @SortRule nvarchar(MAX); --排序规则                  " + "\n" +

                "DECLARE @SortTable nvarchar(50); --用于排序的表              " + "\n" +
                "DECLARE @SortOutTable nvarchar(50); --定义输出表             " + "\n" +

                "--变量赋值区                                                 " + "\n" +
               $"set @SortTable = '{SortTable}';                              " + "\n" +
               $"set @SortRule = '{SortRule}';                                " + "\n" +
               $"set @SortOutTable = '{OutTable}';                            " + "\n" +

                "set @SortSQL =                                               " + "\n" +
                "'IF EXISTS                                                   " + "\n" +
                "(                                                            " + "\n" +
                "   SELECT *                                                  " + "\n" +
                "   FROM information_schema.tables                            " + "\n" +


                "   WHERE table_name = '''+@SortOutTable+'''                  " + "\n" +
                ")                                                            " + "\n" +

                "   Drop Table '+@SortOutTable+'                              " + "\n" +
                "select *                                                     " + "\n" +
                "into '+@SortOutTable+'                                       " + "\n" +
                "from '+@SortTable+'                                          " + "\n" +
                "ORDER BY '+@SortRule+';                                      " + "\n" +
                "            ';                                               " + "\n" +
                "EXECUTE sp_executesql @SortSQL;                              " + "\n";
            return SQL;
        }

        /// <summary>
        /// 对指定表进行指定规则排序 在数据库级输出表
        /// </summary>
        /// <param name="SortTable">对该表进行排序</param>
        /// <param name="SortRule">排序规则</param>
        /// <param name="OutTable">输出表</param>
        static public void Query(string SortTable, string SortRule, string OutTable)
        {
            DBHelper.ExecuteSql(BulidSQL(SortTable, SortRule, OutTable));
        }

        /// <summary>
        /// 对指定表进行指定规则排序 返回排序结果DataSet
        /// </summary>
        /// <param name="SortTable">对该表进行排序</param>
        /// <param name="SortRule">排序规则</param>
        /// <returns></returns>
        static public DataSet Query(string SortTable, string SortRule)
        {
            DBHelper.ExecuteSql(BulidSQL(SortTable, SortRule, "SortOutTable"));
            return OutputTable.Query("SortOutTable");
        }
    }
}
