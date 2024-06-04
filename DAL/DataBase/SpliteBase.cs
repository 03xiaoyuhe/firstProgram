using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataBase
{
    public class SpliteBase
    {
        /// <summary>
        /// 分页SQL构建
        /// </summary>
        /// <param name="SpliteTable">对该表进行分页查询</param>
        /// <param name="SpliteTableNo">用于分页的字段</param>
        /// <param name="APageLine">一页多少行</param>
        /// <param name="PageNum">页数</param>
        /// <param name="OutTable">输出表</param>
        /// <returns></returns>
        static public string BulidSQL(string SpliteTable, string SpliteTableNo, int APageLine, int PageNum, string OutTable)
        {
            string SQL =
                "--分页查询功能区                                                               " + "\n" +

                "--变量定义区                                                                   " + "\n" +
                "DECLARE @SpliteSQL NVARCHAR(MAX); --分页查询语句                               " + "\n" +

                "DECLARE @APageLine nvarchar(50);                                               " + "\n" +
                "DECLARE @PageNum nvarchar(50);                                                 " + "\n" +

                "DECLARE @SpliteTableNo nvarchar(50); --用于标识的的数据主键                    " + "\n" +
                "DECLARE @SpliteTable nvarchar(50); --用于查找的表                              " + "\n" +

                "DECLARE @SpliteOutTable nvarchar(50); --定义输出表                             " + "\n" +

                "--变量赋值区                                                                   " + "\n" +
               $"set @APageLine = '{APageLine}'; --一页的数据数量                               " + "\n" +
               $"set @PageNum = '{PageNum}'; --第几页(从0开始)                                  " + "\n" +
               $"set @SpliteTableNo = '{SpliteTableNo}'--选择用于标识的键                       " + "\n" +
               $"set @SpliteTable = '{SpliteTable}'; --可以选择数据库已有的表或者查询出的临时表 " + "\n" +
               $"set @SpliteOutTable = '{OutTable}';                                            " + "\n" +
                "            --分页查询(通用型)                                                 " + "\n" +
                "set @SpliteSQL =                                                               " + "\n" +
                "'IF EXISTS                                                                     " + "\n" +
                "(                                                                              " + "\n" +
                "    SELECT *                                                                   " + "\n" +
                "    FROM information_schema.tables                                             " + "\n" +

                "    WHERE table_name = ''SpliteOutTable''                                      " + "\n" +
                ")                                                                              " + "\n" +

                "    Drop Table SpliteOutTable                                                  " + "\n" +
                "select top '+@APageLine+' *                                                    " + "\n" +
                "into '+@SpliteOutTable+'                                                       " + "\n" +
                "from '+@SpliteTable+' where '+@SpliteTableNo+'                                 " + "\n" +
                "not in                                                                         " + "\n" +
                "(                                                                              " + "\n" +
                "    select top('+@APageLine+' * '+@PageNum+') '+@SpliteTableNo+'               " + "\n" +

                "    from '+@SpliteTable+'                                                      " + "\n" +
                "); '                                                                           " + "\n" +

                "EXECUTE sp_executesql @SpliteSQL;                                              " + "\n";

            return SQL;
        }


        /// <summary>
        /// 对指定表执行分页操作返回 DataSet
        /// </summary>
        /// <param name="SpliteTable">对该表进行分页查询</param>
        /// <param name="SpliteTableNo">用于分页的字段</param>
        /// <param name="APageLine">一页多少行</param>
        /// <param name="PageNum">页数</param>
        /// <returns></returns>
        static public DataSet Query(string SpliteTable, string SpliteTableNo, int APageLine, int PageNum)
        {
            DBHelper.ExecuteSql(BulidSQL(SpliteTable, SpliteTableNo, APageLine, PageNum, "SpliteOutTable"));
            return OutputTable.Query("SpliteOutTable");
        }

        /// <summary>
        /// 对指定表执行分页操作 在数据库级别返回表
        /// </summary>
        /// <param name="SpliteTable">对该表进行分页查询</param>
        /// <param name="SpliteTableNo">用于分页的字段</param>
        /// <param name="APageLine">一页多少行</param>
        /// <param name="PageNum">页数</param>
        /// <param name="OutTable">输出表</param>
        static public void Query(string SpliteTable, string SpliteTableNo, int APageLine, int PageNum, string OutTable)
        {
            DBHelper.ExecuteSql(BulidSQL(SpliteTable, SpliteTableNo, APageLine, PageNum, OutTable));
        }
    }
}
