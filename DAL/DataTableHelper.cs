using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataTableHelper
    {
        /// <summary>
        /// 查询DataTable中第一行的指定列值。
        /// 如果不存在该列则返回null，如果存在则返回该列的值。
        /// </summary>
        /// <param name="dataTable">要查询的DataTable</param>
        /// <param name="columnName">要查询的列名</param>
        /// <returns>第一行指定列的值，或null如果列不存在</returns>
        public static object GetRowColumnValue(DataTable dataTable, int RowIndex, string columnName)
        {
            if (dataTable == null || string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentException("DataTable和列名不能为空");
            }

            if (!dataTable.Columns.Contains(columnName))
            {
                return null;
            }

            if (dataTable.Rows.Count == 0)
            {
                return null;
            }

            return dataTable.Rows[RowIndex][columnName];
        }
    }
}
