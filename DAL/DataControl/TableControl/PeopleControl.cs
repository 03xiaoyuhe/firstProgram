using DAL.DataControl.Interface;
using DAL.DataObject.TableObject;
using DAL.DataObject.TableObject.PeopleApart;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.DataControl.TableControl
{
    /// <summary>
    /// 人员信息访问类，用于执行对人员信息数据的查询、插入、删除和更新操作。
    /// </summary>
    public class PeopleDataAccess : DataBaseControl, IDataSelect, IDataInsert, IDataDelete, IDataUpdate
    {
        private readonly string _connectionString;

        /// <summary>
        /// 初始化 PeopleDataAccess 类的新实例。
        /// </summary>
        /// <param name="connectionString">用于连接数据库的连接字符串。</param>
        public PeopleDataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

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
            string query = BuildSelectSQL(whereString, groupBy, orderByField, isAscending, pageSize, pageNumber);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
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
            string fieldString = fields != null && fields.Count > 0 ? string.Join(", ", fields) : "*";
            string query = BuildSelectSQL(whereString, groupBy, orderByField, isAscending, pageSize, pageNumber, fieldString);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
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
            string query = BuildSelectSQL(whereString);

            using (SqlConnection connection = new SqlConnection(_connectionString))
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
                                    PEB_ID = reader.GetInt32(0),
                                    PEB_Name = reader.GetString(1),
                                    PEB_Sex = reader.GetString(2),
                                    PEB_Birthday = reader.GetDateTime(3).ToString("yyyy-MM-dd"),
                                    PEB_Job = reader.GetString(4),
                                    PEB_Title = reader.GetString(5),
                                    PEB_Employer = reader.GetString(6)
                                },
                                PrincipalExpand = new PeoplePrincipalExpand
                                {
                                    PEB_ID = reader.GetInt32(7),
                                    PE_Major = reader.GetString(8),
                                    PE_Speciality = reader.GetString(9),
                                    PE_Engage = reader.GetString(10),
                                    PE_Address = reader.GetString(11),
                                    PE_Employer = reader.GetString(12),
                                    PE_IsYouth = reader.GetString(13),
                                    PE_OfficePhone = reader.GetString(14),
                                    PE_MobilePhone = reader.GetString(15),
                                    PE_Email = reader.GetString(16)
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
        private string BuildSelectSQL(string whereString, string groupBy = null, string orderByField = null, bool isAscending = true, int? pageSize = null, int? pageNumber = null, string fields = "*")
        {
            string query = $"SELECT {fields} FROM PeopleBase";

            if (!string.IsNullOrEmpty(whereString))
            {
                query += $" WHERE {whereString}";
            }

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
            if (item is PeopleData peopleData)
            {
                string baseQuery = BuildInseartSQL();

                using (SqlCommand baseCommand = new SqlCommand(baseQuery, sqlTransaction.Connection, sqlTransaction))
                {
                    baseCommand.Parameters.AddWithValue("@Name", peopleData.Base.PEB_Name);
                    baseCommand.Parameters.AddWithValue("@Sex", peopleData.Base.PEB_Sex);
                    baseCommand.Parameters.AddWithValue("@Birthday", peopleData.Base.PEB_Birthday);
                    baseCommand.Parameters.AddWithValue("@Job", peopleData.Base.PEB_Job);
                    baseCommand.Parameters.AddWithValue("@Title", peopleData.Base.PEB_Title);
                    baseCommand.Parameters.AddWithValue("@Employer", peopleData.Base.PEB_Employer);

                    baseCommand.ExecuteNonQuery();
                }

                string expandQuery = BuildInseartSQL();

                using (SqlCommand expandCommand = new SqlCommand(expandQuery, sqlTransaction.Connection, sqlTransaction))
                {
                    expandCommand.Parameters.AddWithValue("@ID", peopleData.Base.PEB_ID);
                    expandCommand.Parameters.AddWithValue("@Major", peopleData.PrincipalExpand.PE_Major);
                    expandCommand.Parameters.AddWithValue("@Speciality", peopleData.PrincipalExpand.PE_Speciality);
                    expandCommand.Parameters.AddWithValue("@Engage", peopleData.PrincipalExpand.PE_Engage);
                    expandCommand.Parameters.AddWithValue("@Address", peopleData.PrincipalExpand.PE_Address);
                    expandCommand.Parameters.AddWithValue("@Employer", peopleData.PrincipalExpand.PE_Employer);
                    expandCommand.Parameters.AddWithValue("@IsYouth", peopleData.PrincipalExpand.PE_IsYouth);
                    expandCommand.Parameters.AddWithValue("@OfficePhone", peopleData.PrincipalExpand.PE_OfficePhone);
                    expandCommand.Parameters.AddWithValue("@MobilePhone", peopleData.PrincipalExpand.PE_MobilePhone);
                    expandCommand.Parameters.AddWithValue("@Email", peopleData.PrincipalExpand.PE_Email);

                    expandCommand.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 插入指定内容，并返回插入数据的 ID。
        /// </summary>
        /// <param name="item">插入的指定表的数据对象。</param>
        /// <returns>数据的 ID。</returns>
        public string InsertReturnID(SqlTransaction sqlTransaction, object item)
        {
            if (item is PeopleData peopleData)
            {
                string baseQuery = BuildInseartSQL(true);

                using (SqlCommand baseCommand = new SqlCommand(baseQuery, sqlTransaction.Connection, sqlTransaction))
                {
                    baseCommand.Parameters.AddWithValue("@Name", peopleData.Base.PEB_Name);
                    baseCommand.Parameters.AddWithValue("@Sex", peopleData.Base.PEB_Sex);
                    baseCommand.Parameters.AddWithValue("@Birthday", peopleData.Base.PEB_Birthday);
                    baseCommand.Parameters.AddWithValue("@Job", peopleData.Base.PEB_Job);
                    baseCommand.Parameters.AddWithValue("@Title", peopleData.Base.PEB_Title);
                    baseCommand.Parameters.AddWithValue("@Employer", peopleData.Base.PEB_Employer);

                    string newID = baseCommand.ExecuteScalar()?.ToString();

                    if (!string.IsNullOrEmpty(newID))
                    {
                        string expandQuery = BuildInseartSQL();

                        using (SqlCommand expandCommand = new SqlCommand(expandQuery, sqlTransaction.Connection, sqlTransaction))
                        {
                            expandCommand.Parameters.AddWithValue("@ID", newID);
                            expandCommand.Parameters.AddWithValue("@Major", peopleData.PrincipalExpand.PE_Major);
                            expandCommand.Parameters.AddWithValue("@Speciality", peopleData.PrincipalExpand.PE_Speciality);
                            expandCommand.Parameters.AddWithValue("@Engage", peopleData.PrincipalExpand.PE_Engage);
                            expandCommand.Parameters.AddWithValue("@Address", peopleData.PrincipalExpand.PE_Address);
                            expandCommand.Parameters.AddWithValue("@Employer", peopleData.PrincipalExpand.PE_Employer);
                            expandCommand.Parameters.AddWithValue("@IsYouth", peopleData.PrincipalExpand.PE_IsYouth);
                            expandCommand.Parameters.AddWithValue("@OfficePhone", peopleData.PrincipalExpand.PE_OfficePhone);
                            expandCommand.Parameters.AddWithValue("@MobilePhone", peopleData.PrincipalExpand.PE_MobilePhone);
                            expandCommand.Parameters.AddWithValue("@Email", peopleData.PrincipalExpand.PE_Email);

                            expandCommand.ExecuteNonQuery();
                        }
                    }

                    return newID;
                }
            }

            return null;
        }

        /// <summary>
        /// 构建 INSERT SQL 语句。
        /// </summary>
        /// <param name="outputID">是否需要返回插入数据的 ID。</param>
        /// <returns>构建的 INSERT SQL 语句。</returns>
        private string BuildInseartSQL(bool outputID = false)
        {
            string baseQuery = "INSERT INTO PeopleBase (PEB_Name, PEB_Sex, PEB_Birthday, PEB_Job, PEB_Title, PEB_Employer)";

            if (outputID)
            {
                baseQuery += " OUTPUT INSERTED.PEB_ID";
            }

            baseQuery += " VALUES (@Name, @Sex, @Birthday, @Job, @Title, @Employer)";
            return baseQuery;
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
            string query = BuildDeleteSQL("PEB_ID = @ID");

            using (SqlCommand command = new SqlCommand(query, sqlTransaction.Connection, sqlTransaction))
            {
                command.Parameters.AddWithValue("@ID", ID);
                return command.ExecuteNonQuery();
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
            string query = BuildDeleteSQL(Where);

            using (SqlCommand command = new SqlCommand(query, sqlTransaction.Connection, sqlTransaction))
            {
                return command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 构建 DELETE SQL 语句。
        /// </summary>
        /// <param name="whereString">SQL 删除语句中的 WHERE 子句。</param>
        /// <returns>构建的 DELETE SQL 语句。</returns>
        private string BuildDeleteSQL(string whereString)
        {
            return $"DELETE FROM PeopleBase WHERE {whereString}";
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
            if (Item is PeopleData peopleData)
            {
                string query = BuildUpdateSQL("PEB_ID = @ID");

                using (SqlCommand command = new SqlCommand(query, sqlTransaction.Connection, sqlTransaction))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    command.Parameters.AddWithValue("@Name", peopleData.Base.PEB_Name);
                    command.Parameters.AddWithValue("@Sex", peopleData.Base.PEB_Sex);
                    command.Parameters.AddWithValue("@Birthday", peopleData.Base.PEB_Birthday);
                    command.Parameters.AddWithValue("@Job", peopleData.Base.PEB_Job);
                    command.Parameters.AddWithValue("@Title", peopleData.Base.PEB_Title);
                    command.Parameters.AddWithValue("@Employer", peopleData.Base.PEB_Employer);

                    return command.ExecuteNonQuery();
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
            if (Item is PeopleData peopleData)
            {
                string query = BuildUpdateSQL(Where);

                using (SqlCommand command = new SqlCommand(query, sqlTransaction.Connection, sqlTransaction))
                {
                    command.Parameters.AddWithValue("@Name", peopleData.Base.PEB_Name);
                    command.Parameters.AddWithValue("@Sex", peopleData.Base.PEB_Sex);
                    command.Parameters.AddWithValue("@Birthday", peopleData.Base.PEB_Birthday);
                    command.Parameters.AddWithValue("@Job", peopleData.Base.PEB_Job);
                    command.Parameters.AddWithValue("@Title", peopleData.Base.PEB_Title);
                    command.Parameters.AddWithValue("@Employer", peopleData.Base.PEB_Employer);

                    return command.ExecuteNonQuery();
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
