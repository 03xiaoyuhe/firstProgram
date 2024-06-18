using System.Data;

namespace DAL.DataBase
{
    public class OutputTable
    {

        /// <summary>
        /// 构建SQL语句
        /// </summary>
        /// <param name="OutputTable"></param>
        /// <returns></returns>
        static public string BulidSQL(string OutputTable)
        {
            string SQL =
                "--输出表功能                                       " + "\n" +
                "DECLARE @OutPutSQL NVARCHAR(MAX); --分页查询语句   " + "\n" +
                "DECLARE @OutPutTable NVARCHAR(MAX); --分页查询语句 " + "\n" +

                "--赋值部分                                         " + "\n" +
               $"set @OutPutTable = '{OutputTable}';                " + "\n" +

                "set @OutPutSQL =                                   " + "\n" +
                "'select *                                          " + "\n" +
                "from '+@OutPutTable+'                              " + "\n" +
                "; '                                                " + "\n" +
                "EXECUTE sp_executesql @OutPutSQL;                  ";
            return SQL;
        }

        static public DataSet Query(string OutputTable)
        {
            return DBHelper.Query(BulidSQL(OutputTable));
        }
    }
}
