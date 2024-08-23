using DAL.DataControl.Interface;
using DAL.DataObject.RelationObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DAL.DataControl.RelationshipControl
{
    public class RelationForPrincipalControl : DataBaseControl, IDataSelect, IDataInsert, IDataDelete, IDataUpdate
    {
        #region 查询功能

        /// <summary>
        /// 构建SQL查询语句
        /// </summary>
        /// <param name="fields">查询的字段列表</param>
        /// <param name="whereString">查询条件</param>
        /// <param name="groupBy">分组字段</param>
        /// <param name="orderByField">排序字段</param>
        /// <param name="isAscending">是否升序</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="pageNumber">分页页码</param>
        /// <returns>构建好的SQL查询语句</returns>
        private string BuildSelectQuery(List<string> fields, string whereString, string groupBy, string orderByField, bool isAscending, int? pageSize, int? pageNumber)
        {
            string fieldList = fields != null && fields.Count > 0 ? string.Join(", ", fields) : "*";
            string query = $"SELECT {fieldList} FROM RelationForPrincipal";

            if (!string.IsNullOrEmpty(whereString))
            {
                query += " WHERE " + whereString;
            }

            if (!string.IsNullOrEmpty(groupBy))
            {
                query += " GROUP BY " + groupBy;
            }

            if (!string.IsNullOrEmpty(orderByField))
            {
                query += " ORDER BY " + orderByField + (isAscending ? " ASC" : " DESC");
            }

            if (pageSize.HasValue && pageNumber.HasValue)
            {
                int offset = (pageNumber.Value - 1) * pageSize.Value;
                query += $" OFFSET {offset} ROWS FETCH NEXT {pageSize.Value} ROWS ONLY";
            }

            return query;
        }

        public DataSet Select(string whereString, string groupBy, string orderByField, bool isAscending, int? pageSize, int? pageNumber)
        {
            string query = BuildSelectQuery(null, whereString, groupBy, orderByField, isAscending, pageSize, pageNumber);

            using (SqlConnection connection = GetSqlConnection())
            {
                OpenSqlConnection();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    OpenSqlConnection();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    return dataSet;
                }
            }
        }

        public DataSet Select(List<string> fields, string whereString, string groupBy, string orderByField, bool isAscending, int? pageSize, int? pageNumber)
        {
            string query = BuildSelectQuery(fields, whereString, groupBy, orderByField, isAscending, pageSize, pageNumber);

            using (SqlConnection connection = GetSqlConnection())
            {
                OpenSqlConnection();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    return dataSet;
                }
            }
        }

        /// <summary>
        /// 根据查询条件返回一个记录结果的对象列表
        /// </summary>
        /// <param name="whereString">查询条件</param>
        /// <returns>返回List\<RelationForPrincipalCell\> 用于记录结果</returns>
        public Object SelectReturnObject(string whereString)
        {
            string query = BuildSelectQuery(null, whereString, null, null, true, null, null);

            List<RelationForPrincipalCell> result = new List<RelationForPrincipalCell>();

            using (SqlConnection connection = GetSqlConnection())
            {
                OpenSqlConnection();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var cell = new RelationForPrincipalCell
                            {
                                PEB_ID = reader.GetInt32(reader.GetOrdinal("PEB_ID")),
                                PB_ID = reader.GetInt32(reader.GetOrdinal("PB_ID"))
                            };
                            result.Add(cell);
                        }
                    }
                }
            }
            return result;
        }

        #endregion

        #region 插入功能
        private string BuildInsertSQL(List<RelationForPrincipalCell> items)
        {
            // 构建基础的 INSERT INTO 语句
            string sql = "INSERT INTO RelationForPrincipal (PEB_ID, PB_ID) VALUES ";

            // 添加每一行的占位符
            for (int i = 0; i < items.Count; i++)
            {
                sql += $"(@PEB_ID{i}, @PB_ID{i})";
                if (i < items.Count - 1)
                {
                    sql += ", ";
                }
            }

            return sql;
        }
        void IDataInsert.Insert(SqlTransaction Transaction, object Item)
        {
            var items = Item as List<RelationForPrincipalCell>;
            if (items == null || items.Count == 0)
            {
                throw new ArgumentException("Item cannot be null or empty");
            }

            // 获取插入 SQL 语句
            string sqlInsert = BuildInsertSQL(items);

            SqlTransaction sqlTransaction = Transaction;
            if (Transaction == null)
            {
                SqlConnection sqlConnection = GetSqlConnection();
                OpenSqlConnection();
                sqlTransaction = sqlConnection.BeginTransaction();
            }

            using (SqlCommand command = new SqlCommand(sqlInsert, sqlTransaction.Connection, sqlTransaction))
            {
                // 动态添加参数
                for (int i = 0; i < items.Count; i++)
                {
                    command.Parameters.AddWithValue($"@PEB_ID{i}", items[i].PEB_ID);
                    command.Parameters.AddWithValue($"@PB_ID{i}", items[i].PB_ID);
                }

                // 执行插入操作
                command.ExecuteNonQuery();


                if(Transaction != null)
                    sqlTransaction.Commit();
            }

        }

        string IDataInsert.InsertReturnID(SqlTransaction Transaction, object Item)
        {
            var items = Item as List<RelationForPrincipalCell>;
            if (items == null || items.Count == 0)
            {
                throw new ArgumentException("Item cannot be null or empty");
            }

            List<string> insertedIds = new List<string>();

            // 获取插入 SQL 语句
            string sqlInsert = BuildInsertSQL(items);

            SqlTransaction sqlTransaction = Transaction;
            if (Transaction == null)
            {
                SqlConnection sqlConnection = GetSqlConnection();
                OpenSqlConnection();
                sqlTransaction = sqlConnection.BeginTransaction();
            }
            using (SqlCommand command = new SqlCommand(sqlInsert, sqlTransaction.Connection, sqlTransaction))
            {
                // 动态添加参数
                for (int i = 0; i < items.Count; i++)
                {
                    command.Parameters.AddWithValue($"@PEB_ID{i}", items[i].PEB_ID);
                    command.Parameters.AddWithValue($"@PB_ID{i}", items[i].PB_ID);

                    // 记录插入的主键
                    insertedIds.Add($"{items[i].PEB_ID}-{items[i].PB_ID}");
                }

                // 执行插入操作
                command.ExecuteNonQuery();


                if (Transaction != null)
                    sqlTransaction.Commit();
            }

            // 返回插入的主键 ID 列表，以逗号分隔
            return string.Join(",", insertedIds);
        }

        #endregion

        #region 删除功能
        private string BuildDeleteSQL(string whereClause = null, string id = null)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return "DELETE FROM RelationForPrincipal WHERE PEB_ID = @PEB_ID";
            }
            else if (!string.IsNullOrEmpty(whereClause))
            {
                return $"DELETE FROM RelationForPrincipal WHERE {whereClause}";
            }
            else
            {
                throw new ArgumentException("Either ID or Where condition must be provided.");
            }
        }

        int IDataDelete.DeleteByID(SqlTransaction Transaction, string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                throw new ArgumentException("ID cannot be null or empty");
            }

            string sqlDelete = BuildDeleteSQL(id: ID);


            SqlTransaction sqlTransaction = Transaction;
            if (Transaction == null)
            {
                SqlConnection sqlConnection = GetSqlConnection();
                OpenSqlConnection();
                sqlTransaction = sqlConnection.BeginTransaction();
            }


            using (SqlCommand command = new SqlCommand(sqlDelete, sqlTransaction.Connection, sqlTransaction))
            {
                command.Parameters.AddWithValue("@PEB_ID", ID);


                if (Transaction != null)
                    sqlTransaction.Commit();


                return command.ExecuteNonQuery();
            }
        }

        int IDataDelete.Delete(SqlTransaction Transaction, string Where)
        {
            if (string.IsNullOrEmpty(Where))
            {
                throw new ArgumentException("Where condition cannot be null or empty");
            }

            string sqlDelete = BuildDeleteSQL(whereClause: Where);


            SqlTransaction sqlTransaction = Transaction;
            if (Transaction == null)
            {
                SqlConnection sqlConnection = GetSqlConnection();
                OpenSqlConnection();
                sqlTransaction = sqlConnection.BeginTransaction();
            }


            using (SqlCommand command = new SqlCommand(sqlDelete, sqlTransaction.Connection, sqlTransaction))
            {
                int ans = command.ExecuteNonQuery();



                if (Transaction != null)
                    sqlTransaction.Commit();


                return ans;
            }
        }

        #endregion

        #region 更新功能
        private void AddUpdateParameters(SqlCommand command, RelationForPrincipalCell updateItem)
        {
            if (updateItem.PEB_ID != 0)
            {
                command.Parameters.AddWithValue("@PEB_ID", updateItem.PEB_ID);
            }
            if (updateItem.PB_ID != 0)
            {
                command.Parameters.AddWithValue("@PB_ID", updateItem.PB_ID);
            }
            // 根据需要添加更多字段的参数
        }

        private string BuildUpdateSQL(RelationForPrincipalCell updateItem, string condition)
        {
            var updateFields = new List<string>();

            if (updateItem.PEB_ID != 0)
            {
                updateFields.Add("PEB_ID = @PEB_ID");
            }
            if (updateItem.PB_ID != 0)
            {
                updateFields.Add("PB_ID = @PB_ID");
            }
            // 根据需要添加更多字段

            string updateFieldString = string.Join(", ", updateFields);

            return $"UPDATE RelationForPrincipal SET {updateFieldString} WHERE {condition}";
        }

        int IDataUpdate.Update(SqlTransaction Transaction, string ID, object Item)
        {
            if (string.IsNullOrEmpty(ID))
            {
                throw new ArgumentException("ID cannot be null or empty");
            }

            if (!(Item is List<RelationForPrincipalCell>))
            {
                throw new ArgumentException("Item must be a List of RelationForPrincipalCell");
            }

            var updateItems = (List<RelationForPrincipalCell>)Item;
            int affectedRows = 0;

            SqlTransaction sqlTransaction = Transaction;
            if (Transaction == null)
            {
                SqlConnection sqlConnection = GetSqlConnection();
                OpenSqlConnection();
                sqlTransaction = sqlConnection.BeginTransaction();
            }


            foreach (var updateItem in updateItems)
            {
                // 构建 SQL 更新语句
                string sqlUpdate = BuildUpdateSQL(updateItem, "PEB_ID = @PEB_ID");

                using (SqlCommand command = new SqlCommand(sqlUpdate, sqlTransaction.Connection, sqlTransaction))
                {
                    // 添加更新所需的参数
                    AddUpdateParameters(command, updateItem);

                    // 设置 ID 参数
                    command.Parameters.AddWithValue("@PEB_ID", ID);

                    // 执行更新操作并累加影响的行数
                    affectedRows += command.ExecuteNonQuery();
                }
            }


            if (Transaction != null)
                sqlTransaction.Commit();

            return affectedRows;
        }

        int IDataUpdate.Update(SqlTransaction Transaction, object Item, string Where)
        {
            if (string.IsNullOrEmpty(Where))
            {
                throw new ArgumentException("Where condition cannot be null or empty");
            }

            if (!(Item is List<RelationForPrincipalCell>))
            {
                throw new ArgumentException("Item must be a List of RelationForPrincipalCell");
            }

            var updateItems = (List<RelationForPrincipalCell>)Item;
            int affectedRows = 0;


            SqlTransaction sqlTransaction = Transaction;
            if (Transaction == null)
            {
                SqlConnection sqlConnection = GetSqlConnection();
                OpenSqlConnection();
                sqlTransaction = sqlConnection.BeginTransaction();
            }

            foreach (var updateItem in updateItems)
            {
                // 构建 SQL 更新语句
                string sqlUpdate = BuildUpdateSQL(updateItem, Where);

                using (SqlCommand command = new SqlCommand(sqlUpdate, sqlTransaction.Connection, sqlTransaction))
                {
                    // 添加更新所需的参数
                    AddUpdateParameters(command, updateItem);

                    // 执行更新操作并累加影响的行数
                    affectedRows += command.ExecuteNonQuery();
                }
            }


            if (Transaction != null)
                sqlTransaction.Commit();

            return affectedRows;
        }

        #endregion
    }
}
