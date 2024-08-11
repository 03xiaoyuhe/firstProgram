using DAL.DataControl.Interface;
using DAL.DataObject.TableObject;
using DAL.DataObject.TableObject.PeopleApart;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL.DataControl.TableControl
{
    /// <summary>
    /// 人员信息访问类，用于执行对人员信息数据的查询、插入、删除和更新操作。
    /// </summary>
    public class PeopleControl : DataBaseControl, IDataSelect, IDataInsert, IDataDelete, IDataUpdate
    {

        #region 查询功能

        /// <summary>
        /// 执行查询并返回符合条件的数据集。
        /// </summary>
        /// <param name="whereString">SQL 查询中的 WHERE 子句。</param>
        /// <param name="groupBy">SQL 查询中的 GROUP BY 子句。</param>
        /// <param name="orderByField">用于排序的字段名称。</param>
        /// <param name="isAscending">是否升序排序。</param>
        /// <param name="pageSize">分页大小。</param>
        /// <param name="pageNumber">页码。</param>
        /// <returns>包含查询结果的数据集。</returns>
        public DataSet Select(string whereString, string groupBy, string orderByField, bool isAscending, int? pageSize, int? pageNumber)
        {
            string query = BuildSelectSQL(null, whereString, groupBy, orderByField, isAscending, pageSize, pageNumber);

            using (SqlConnection connection = GetSqlConnection())
            {
                OpenSqlConnection();
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    return dataSet;
                }
            }
        }

        /// <summary>
        /// 执行查询并返回符合条件的指定字段的数据集。
        /// </summary>
        /// <param name="fields">要查询的字段列表。</param>
        /// <param name="whereString">SQL 查询中的 WHERE 子句。</param>
        /// <param name="groupBy">SQL 查询中的 GROUP BY 子句。</param>
        /// <param name="orderByField">用于排序的字段名称。</param>
        /// <param name="isAscending">是否升序排序。</param>
        /// <param name="pageSize">分页大小。</param>
        /// <param name="pageNumber">页码。</param>
        /// <returns>包含查询结果的数据集。</returns>
        public DataSet Select(List<string> fields, string whereString, string groupBy, string orderByField, bool isAscending, int? pageSize, int? pageNumber)
        {
            string query = BuildSelectSQL(fields, whereString, groupBy, orderByField, isAscending, pageSize, pageNumber);

            using (SqlConnection connection = GetSqlConnection())
            {
                OpenSqlConnection();
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    return dataSet;
                }
            }
        }

        /// <summary>
        /// 执行查询并返回符合条件的数据类对象。
        /// </summary>
        /// <param name="whereString">SQL 查询中的 WHERE 子句。</param>
        /// <returns>查询到的数据类对象。</returns>
        public object SelectReturnObject(string whereString)
        {
            string query = BuildSelectSQL(null, whereString);

            using (SqlConnection connection = GetSqlConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            PeopleData peopleData = new PeopleData
                            {
                                Base = new PeopleBase
                                {
                                    PEB_ID = reader.GetInt32(reader.GetOrdinal("PEB_ID")),
                                    PEB_Name = reader.GetString(reader.GetOrdinal("PEB_Name")),
                                    PEB_Sex = reader.GetString(reader.GetOrdinal("PEB_Sex")),
                                    PEB_Birthday = reader.GetDateTime(reader.GetOrdinal("PEB_Birthday")).ToString("yyyy-MM-dd"),
                                    PEB_Job = reader.GetString(reader.GetOrdinal("PEB_Job")),
                                    PEB_Title = reader.GetString(reader.GetOrdinal("PEB_Title")),
                                    PEB_Employer = reader.GetString(reader.GetOrdinal("PEB_Employer"))
                                },
                                PrincipalExpand = new PeoplePrincipalExpand
                                {
                                    PEB_ID = reader.GetInt32(reader.GetOrdinal("PEB_ID")),
                                    PE_Major = reader.GetString(reader.GetOrdinal("PE_Major")),
                                    PE_Speciality = reader.GetString(reader.GetOrdinal("PE_Speciality")),
                                    PE_Engage = reader.GetString(reader.GetOrdinal("PE_Engage")),
                                    PE_Address = reader.GetString(reader.GetOrdinal("PE_Address")),
                                    PE_IsYouth = reader.GetString(reader.GetOrdinal("PE_IsYouth")),
                                    PE_OfficePhone = reader.GetString(reader.GetOrdinal("PE_OfficePhone")),
                                    PE_MobilePhone = reader.GetString(reader.GetOrdinal("PE_MobilePhone")),
                                    PE_Email = reader.GetString(reader.GetOrdinal("PE_Email"))
                                }
                            };
                            return peopleData;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// 构建 SELECT SQL 语句。
        /// </summary>
        /// <param name="whereString">SQL 查询中的 WHERE 子句。</param>
        /// <param name="groupBy">SQL 查询中的 GROUP BY 子句。</param>
        /// <param name="orderByField">用于排序的字段名称。</param>
        /// <param name="isAscending">是否升序排序。</param>
        /// <param name="pageSize">分页大小。</param>
        /// <param name="pageNumber">页码。</param>
        /// <param name="fields">要查询的字段列表。</param>
        /// <returns>构建的 SELECT SQL 语句。</returns>
        private string BuildSelectSQL(List<string> fields, string whereString, string groupBy = null, string orderByField = null, bool isAscending = true, int? pageSize = null, int? pageNumber = null)
        {

            string fieldString = fields != null && fields.Count > 0 ? string.Join(", ", fields)
                : @"
            PeopleBase.PEB_ID ,
            PeopleBase.PEB_Name ,
            PeopleBase.PEB_Sex ,
            CONVERT(varchar, PeopleBase.PEB_Birthday , 23) AS PEB_Birthday,
            PeopleBase.PEB_Job ,
            PeopleBase.PEB_Title ,
            PeopleBase.PEB_Employer ,

            PeoplePrincipalExpandData.PE_ID ,
            PeoplePrincipalExpandData.PE_Major ,
            PeoplePrincipalExpandData.PE_Speciality ,
            PeoplePrincipalExpandData.PE_Engage ,
            PeoplePrincipalExpandData.PE_Address ,
            PeoplePrincipalExpandData.PE_IsYouth ,
            PeoplePrincipalExpandData.PE_OfficePhone ,
            PeoplePrincipalExpandData.PE_MobilePhone ,
            PeoplePrincipalExpandData.PE_Email ";

            string query = $"SELECT {fieldString} FROM PeopleBase " +
                $"LEFT JOIN PeoplePrincipalExpandData ON PeopleBase.PEB_ID = PeoplePrincipalExpandData.PEB_ID";

            if (!string.IsNullOrEmpty(whereString))
            {
                query += $" WHERE {whereString}";
            }
            else query += " WHERE 1 = 1";

            if (!string.IsNullOrEmpty(groupBy))
            {
                query += $" GROUP BY {groupBy}";
            }

            if (!string.IsNullOrEmpty(orderByField))
            {
                query += $" ORDER BY {orderByField} {(isAscending ? "ASC" : "DESC")}";
            }

            if (pageSize.HasValue && pageNumber.HasValue)
            {
                int offset = (pageNumber.Value - 1) * pageSize.Value;
                query += $" OFFSET {offset} ROWS FETCH NEXT {pageSize.Value} ROWS ONLY";
            }

            return query;
        }

        #endregion

        #region 插入功能

        /// <summary>
        /// 插入指定内容。
        /// </summary>
        /// <param name="item">插入的指定表的数据对象。</param>
        public void Insert(SqlTransaction sqlTransaction, object item)
        {
            InsertReturnID(sqlTransaction, item);
        }

        /// <summary>
        /// 插入指定内容，并返回插入数据的 ID。
        /// </summary>
        /// <param name="item">插入的指定表的数据对象。</param>
        /// <returns>数据的 ID。</returns>
        public string InsertReturnID(SqlTransaction sqlTransaction, object item)
        {

            using (SqlConnection conn = GetSqlConnection())
            {
                OpenSqlConnection();
                SqlTransaction tx;

                if (sqlTransaction == null)
                    tx = conn.BeginTransaction();
                else
                    tx = sqlTransaction;

                PeopleData Data = (PeopleData)item;

                if (!Data.Base.IsEmpty())
                {
                    try
                    {
                        List<string> fields = new List<string>
                        {
                            "PEB_Name",
                            "PEB_Sex",
                            "PEB_Birthday",
                            "PEB_Job",
                            "PEB_Title",
                            "PEB_Employer",
                        };

                        List<string> datas = new List<string>
                        {
                            Data.Base.PEB_Name,
                            Data.Base.PEB_Sex,
                            Data.Base.PEB_Birthday,
                            Data.Base.PEB_Job,
                            Data.Base.PEB_Title,
                            Data.Base.PEB_Employer

                        };

                        string SQL = BuildInsertSQL("PeopleBase", fields, datas);

                        string newID;

                        using (SqlCommand cmd = new SqlCommand(SQL, conn, tx))
                        {
                            for (int i = 0; i < datas.Count; i++)
                            {
                                cmd.Parameters.AddWithValue($"@param{i}", datas[i]);
                            }


                            newID = cmd.ExecuteScalar()?.ToString();
                        }

                        if (!string.IsNullOrEmpty(newID) && !Data.PrincipalExpand.IsEmpty())
                        {
                            fields = new List<string>
                            {
                                "PEB_ID",
                                "PE_Major",
                                "PE_Speciality",
                                "PE_Engage",
                                "PE_Address",
                                "PE_IsYouth",
                                "PE_OfficePhone",
                                "PE_MobilePhone",
                                "PE_Email",
                            };

                            datas = new List<string>
                            {
                                newID,
                                Data.PrincipalExpand.PE_Major,
                                Data.PrincipalExpand.PE_Speciality,
                                Data.PrincipalExpand.PE_Engage,
                                Data.PrincipalExpand.PE_Address,
                                Data.PrincipalExpand.PE_IsYouth,
                                Data.PrincipalExpand.PE_OfficePhone,
                                Data.PrincipalExpand.PE_MobilePhone,
                                Data.PrincipalExpand.PE_Email,
                            };

                            string expandQuery = BuildInsertSQL("PeoplePrincipalExpandData", fields, datas);

                            using (SqlCommand expandCommand = new SqlCommand(expandQuery, tx.Connection, tx))
                            {
                                for (int i = 0; i < datas.Count; i++)
                                {
                                    expandCommand.Parameters.AddWithValue($"@param{i}", datas[i]);
                                }

                                expandCommand.ExecuteNonQuery();
                            }
                        }

                        if (sqlTransaction == null)
                        {
                            tx.Commit();
                        }
                        return newID;


                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 构建SQL插入语句
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="Fields">字段列表</param>
        /// <param name="Datas">数据列表</param>
        /// <returns>返回SQL插入语句</returns>
        public string BuildInsertSQL(string TableName, List<string> Fields, List<string> Datas)
        {
            string FieldsString = string.Join(", ", Fields);
            string ValuesString = string.Join(", ", Datas.Select((data, index) => $"@param{index}"));

            string SQL =
                $"INSERT INTO [{TableName}] ({FieldsString})\n" +
                "OUTPUT inserted.PEB_ID as id -- 返回插入数据的ID\n" +
                $"VALUES({ValuesString});";

            return SQL;
        }

        #endregion

        #region 删除功能

        /// <summary>
        /// 删除指定数据 ID 对应的数据行。
        /// </summary>
        /// <param name="sqlTransaction">SQL 事务。</param>
        /// <param name="ID">指定的 ID。</param>
        /// <returns>影响的条数。</returns>
        public int DeleteByID(SqlTransaction sqlTransaction, string ID)
        {
            string query = BuildDeleteSQL("","PEB_ID = @ID");

            SqlTransaction tx;

            if (sqlTransaction == null)
            {
                SqlConnection connection = GetSqlConnection();
                OpenSqlConnection();
                tx = connection.BeginTransaction();
            }
            else
            {
                tx = sqlTransaction;
            }


            try
            {
                using (SqlCommand command = new SqlCommand(query, tx.Connection, tx))
                {
                    command.CommandText = BuildDeleteSQL("PeoplePrincipalExpandData", "PEB_ID = @ID");
                    command.Parameters.AddWithValue("@ID", ID);
                    int count = command.ExecuteNonQuery();

                    command.CommandText = BuildDeleteSQL("PeopleBase", "PEB_ID = @ID");
                    command.Parameters.AddWithValue("@ID", ID);
                    count += command.ExecuteNonQuery();
                    if (sqlTransaction == null)
                    {
                        tx.Commit();
                    }
                    return count;
                }

            }
            catch
            {
                tx.Rollback();
                throw;
            }

        }

        /// <summary>
        /// 删除符合 WHERE 语句条件的数据项。
        /// </summary>
        /// <param name="sqlTransaction">SQL 事务。</param>
        /// <param name="Where">限制条件。</param>
        /// <returns>影响的条数。</returns>
        public int Delete(SqlTransaction sqlTransaction, string Where)
        {
            string query = BuildDeleteSQL("PeopleBase", Where);

            SqlTransaction tx;

            if (sqlTransaction == null)
            {
                SqlConnection connection = GetSqlConnection();
                OpenSqlConnection();
                tx = connection.BeginTransaction();
            }
            else
            {
                tx = sqlTransaction;
            }


            try
            {
                using (SqlCommand command = new SqlCommand(query, tx.Connection, tx))
                {
                    command.CommandText = BuildDeleteSQL("PeoplePrincipalExpandData", Where);
                    int count = command.ExecuteNonQuery();

                    command.CommandText = BuildDeleteSQL("PeopleBase", Where);
                    count += command.ExecuteNonQuery();



                    if (sqlTransaction == null)
                    {
                        tx.Commit();
                    }
                    return count;
                }

            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }

        /// <summary>
        /// 构建删除SQL语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="where">删除条件</param>
        /// <returns>删除SQL语句</returns>
        public string BuildDeleteSQL(string tableName, string where)
        {
            return $"DELETE FROM {tableName} WHERE {where}";
        }

        #endregion

        #region 更新功能

        /// <summary>
        /// 将指定数据 ID 的记录的指定字段替换为 Item 对象里存放的数据。
        /// </summary>
        /// <param name="sqlTransaction">SQL 事务。</param>
        /// <param name="ID">指定的数据 ID。</param>
        /// <param name="Item">要替换的内容。</param>
        /// <returns>影响的条数。</returns>
        public int Update(SqlTransaction sqlTransaction, string ID, object Item)
        {

            SqlTransaction tx;
            if (Item is PeopleData peopleData)
            {
                string query = BuildUpdateSQL("PEB_ID = @ID");


                if (sqlTransaction == null)
                {
                    SqlConnection connection = GetSqlConnection();
                    OpenSqlConnection();
                    tx = connection.BeginTransaction();
                }
                else
                {
                    tx = sqlTransaction;
                }


                try
                {
                    int count;
                    using (SqlCommand command = new SqlCommand(query, tx.Connection, tx))
                    {
                        command.Parameters.AddWithValue("@ID", ID);
                        command.Parameters.AddWithValue("@Name", peopleData.Base.PEB_Name);
                        command.Parameters.AddWithValue("@Sex", peopleData.Base.PEB_Sex);
                        command.Parameters.AddWithValue("@Birthday", peopleData.Base.PEB_Birthday);
                        command.Parameters.AddWithValue("@Job", peopleData.Base.PEB_Job);
                        command.Parameters.AddWithValue("@Title", peopleData.Base.PEB_Title);
                        command.Parameters.AddWithValue("@Employer", peopleData.Base.PEB_Employer);

                        count = command.ExecuteNonQuery();
                    }


                    if (sqlTransaction == null)
                    {
                        tx.Commit();
                    }
                    return count;
                }
                catch
                {
                    tx.Rollback();
                    throw;
                }
            }

            return 0;
        }

        /// <summary>
        /// 提供一个将所有符合 WHERE 语句的记录的指定字段替换为 Item 对象里存放的数据。
        /// </summary>
        /// <param name="sqlTransaction">SQL 事务。</param>
        /// <param name="Item">要替换的内容。</param>
        /// <param name="Where">限制条件。</param>
        /// <returns>影响的条数。</returns>
        public int Update(SqlTransaction sqlTransaction, object Item, string Where)
        {

            SqlTransaction tx;
            if (Item is PeopleData peopleData)
            {
                string query = BuildUpdateSQL(Where);


                if (sqlTransaction == null)
                {
                    SqlConnection connection = GetSqlConnection();
                    OpenSqlConnection();
                    tx = connection.BeginTransaction();
                }
                else
                {
                    tx = sqlTransaction;
                }


                try
                {
                    int count;
                    using (SqlCommand command = new SqlCommand(query, tx.Connection, tx))
                    {
                        command.Parameters.AddWithValue("@Name", peopleData.Base.PEB_Name);
                        command.Parameters.AddWithValue("@Sex", peopleData.Base.PEB_Sex);
                        command.Parameters.AddWithValue("@Birthday", peopleData.Base.PEB_Birthday);
                        command.Parameters.AddWithValue("@Job", peopleData.Base.PEB_Job);
                        command.Parameters.AddWithValue("@Title", peopleData.Base.PEB_Title);
                        command.Parameters.AddWithValue("@Employer", peopleData.Base.PEB_Employer);

                        count = command.ExecuteNonQuery();
                    }


                    if (sqlTransaction == null)
                    {
                        tx.Commit();
                    }
                    return count;
                }
                catch
                {
                    tx.Rollback();
                    throw;
                }
            }

            return 0;
        }

        /// <summary>
        /// 构建 UPDATE SQL 语句。
        /// </summary>
        /// <param name="whereString">SQL 更新语句中的 WHERE 子句。</param>
        /// <returns>构建的 UPDATE SQL 语句。</returns>
        private string BuildUpdateSQL(string whereString)
        {
            return "UPDATE PeopleBase SET " +
                   "PEB_Name = @Name, " +
                   "PEB_Sex = @Sex, " +
                   "PEB_Birthday = @Birthday, " +
                   "PEB_Job = @Job, " +
                   "PEB_Title = @Title, " +
                   "PEB_Employer = @Employer " +
                   $"WHERE {whereString}";
        }

        #endregion
    }
}
