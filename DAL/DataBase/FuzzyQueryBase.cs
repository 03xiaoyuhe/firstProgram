using System.Data;

namespace DAL.DataBase
{
    public class FuzzyQueryBase
    {
        /// <summary>
        /// 构建SQL语句
        /// </summary>
        /// <param name="SelectTable">在该表中查询</param>
        /// <param name="SelectLable">匹配该字段</param>
        /// <param name="SQLLikeRule">以何规则匹配</param>
        /// <param name="OutTable">设置输出表</param>
        /// <returns></returns>
        static public string BulidSQL(string SelectTable, string SelectLable, string SQLLikeRule, string OutTable)
        {
            string SQL =
            "--模糊查询功能区                                                         " + "\n" +
            "--变量定义区                                                             " + "\n" +

            "DECLARE @SelectSQL NVARCHAR(MAX); --模糊查询语句                         " + "\n" +
            "DECLARE @LikeRule nvarchar(MAX); --模糊查询规则                          " + "\n" +
            "DECLARE @SelectTable nvarchar(50); --用于模糊查询的表                    " + "\n" +
            "DECLARE @SelectLable nvarchar(50); --用于模糊查询的字段                  " + "\n" +
           $"DECLARE @SelectOutTable nvarchar(50) = '{OutTable}'; --定义输出表        " + "\n" +
            "--变量赋值区                                                             " + "\n" +

           $"set @SelectTable = '{SelectTable}';                                      " + "\n" +
           $"set @SelectLable = '{SelectLable}';                                      " + "\n" +
           $"set @LikeRule = '{SQLLikeRule}';                                         " + "\n" +
            "set @SelectSQL =                                                         " + "\n" +
            "'IF EXISTS                                                               " + "\n" +
            "(                                                                        " + "\n" +
            "    SELECT *                                                             " + "\n" +
            "    FROM information_schema.tables                                       " + "\n" +

           $"    WHERE table_name = '''+@SelectOutTable+'''                           " + "\n" +
            ")                                                                        " + "\n" +

           $"Drop Table '+@SelectOutTable+'                                           " + "\n" +
            "select*                                                                  " + "\n" +
            "into '+@SelectOutTable+'                                                 " + "\n" +
            "from '+@SelectTable+'                                                    " + "\n" +
            "where '+@SelectLable+' like '''+@LikeRule+''';                           " + "\n" +
            "';                                                                       " + "\n" +
            "EXECUTE sp_executesql @SelectSQL;                                        " + "\n";
            return SQL;
        }

        /// <summary>
        /// 在指定表中进行查询 在数据库级返回表
        /// </summary>
        /// <param name="SelectTable">在该表中进行搜索</param>
        /// <param name="SelectLable">搜索的字段</param>
        /// <param name="SQLLikeRule">SQL匹配规则</param>
        /// <param name="OutTable">输出表名</param>
        static public void Query(string SelectTable, string SelectLable, string SQLLikeRule, string OutTable)
        {
            DBHelper.ExecuteSql(BulidSQL(SelectTable, SelectLable, SQLLikeRule, OutTable));
        }

        /// <summary>
        /// 在指定表中进行查询 返回查询结果DateSet
        /// </summary>
        /// <param name="SelectTable">在该表中进行搜索</param>
        /// <param name="SelectLable">搜索的字段</param>
        /// <param name="SQLLikeRule">SQL匹配规则</param>
        static public DataSet Query(string SelectTable, string SelectLable, string SQLLikeRule)
        {
            DBHelper.ExecuteSql(BulidSQL(SelectTable, SelectLable, SQLLikeRule, "SelectOutTable"));
            return OutputTable.Query("SelectOutTable");
        }
    }
}
