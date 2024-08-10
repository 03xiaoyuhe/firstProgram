using DAL.DataBase;
using DAL.DataControl.Interface;
using DAL.DataObject.TableObject;
using DAL.DataObject.TableObject.ProjectApart;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;

namespace DAL.DataControl.TableControl
{
    public class ProjectControl : DataBaseControl, IDataSelect, IDataInsert, IDataDelete, IDataUpdate
    {
        #region 查询功能

        /// <summary>
        /// 构建SQL查询语句
        /// </summary>
        /// <param name="Fields">指定查询出的字段</param>
        /// <param name="whereString">在SQL中 WHERE 部分需要填入的部分</param>
        /// <param name="groupBy">用于分组的字段</param>
        /// <param name="orderByField">用于排序的字段</param>
        /// <param name="isAscending">是否按升序排序</param>
        /// <param name="pageSize">每页数据条数</param>
        /// <param name="pageNumber">页码</param>
        /// <returns>返回SQL查询语句</returns>
        private string BuildSelectSQL(List<string> Fields, string whereString, string groupBy, string orderByField, bool isAscending, int? pageSize, int? pageNumber)
        {
            if (whereString == null) whereString = "1 = 1";
            if (orderByField == null)
            {
                orderByField = "PB_ID";
            }

            // 如果没有指定字段，则查询所有字段
            string fieldString = Fields != null && Fields.Count > 0
                ? string.Join(", ", Fields)
                : @"
            ProjectBase.PB_ID,
            ProjectBase.ProjectState,
            ProjectBase.ProjectName,
            ProjectBase.ProjectCategory,
            ProjectBase.DisciplineClassificaton,
            CONVERT(varchar, ProjectBase.FillDate, 23) AS FillDate,
            ProjectBase.Ending,
            CONVERT(varchar, ProjectBase.EndingDate, 23) AS EndingDate,
            ProjectDemonstrationExpand.ProjectSignificance,
            ProjectDemonstrationExpand.ProjectDocument,
            ProjectDemonstrationExpand.ProjectReferences,
            ProjectJudgeExpand.UnitJudge,
            CONVERT(varchar, ProjectJudgeExpand.UnitJudgeDate, 23) AS UnitJudgeDate,
            ProjectJudgeExpand.ExpertJudge,
            CONVERT(varchar, ProjectJudgeExpand.ExpertJudgeDate, 23) AS ExpertJudgeDate,
            ProjectJudgeExpand.ApprovalOpinion,
            CONVERT(varchar, ProjectJudgeExpand.ApprovalOpinionDate, 23) AS ApprovalOpinionDate,
            ProjectApprovalExpand.ProjectApprovalNum,
            ProjectFinishExpansion.FinishCertificateNum,
            ProjectChangeExpansion.ChangeState,
            ProjectChangeExpansion.ChangeKind,
            ProjectChangeExpansion.AnotherChangeKind,
            ProjectChangeExpansion.ChangeDataAndReason,
            CONVERT(varchar, ProjectChangeExpansion.ApplicationTime, 23) AS ApplicationTime,
            ProjectChangeExpansion.UnitOpinion";

            string OffsetString = "";
            // 添加分页逻辑（如果提供了分页参数）
            if (pageSize.HasValue && pageNumber.HasValue)
            {
                int offset = (pageNumber.Value - 1) * pageSize.Value;
                OffsetString = $" OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY";
            }

            string SQL =
                "-- 项目信息查询SQL\n" +
                "SELECT " + fieldString + "\n" +
                "FROM ProjectBase\n" +
                "LEFT JOIN ProjectDemonstrationExpand ON ProjectBase.PB_ID = ProjectDemonstrationExpand.PB_ID\n" +
                "LEFT JOIN ProjectJudgeExpand ON ProjectBase.PB_ID = ProjectJudgeExpand.PB_ID\n" +
                "LEFT JOIN ProjectApprovalExpand ON ProjectBase.PB_ID = ProjectApprovalExpand.PB_ID\n" +
                "LEFT JOIN ProjectFinishExpansion ON ProjectBase.PB_ID = ProjectFinishExpansion.PB_ID\n" +
                "LEFT JOIN ProjectChangeExpansion ON ProjectBase.PB_ID = ProjectChangeExpansion.PB_ID\n" +
                $"WHERE {whereString}\n" +
                (groupBy == null ? "" : $"GROUP BY {groupBy}\n") +
                "ORDER BY " + orderByField + " " + (isAscending ? "ASC" : "DESC") + "\n" +
                $"{OffsetString}\n";

            return SQL;
        }

        /// <summary>
        /// 通过指定规则执行查询，并返回查询的数据
        /// </summary>
        /// <param name="Fields">指定查询出的字段</param>
        /// <param name="whereString">在SQL中 WHERE 部分需要填入的部分</param>
        /// <param name="orderByField">用于排序的字段</param>
        /// <param name="isAscending">是否按升序排序</param>
        /// <param name="pageSize">每页数据条数</param>
        /// <param name="pageNumber">页码</param>
        /// <returns>返回查询出的所有数据</returns>
        public DataSet Select(List<string> Fields, string whereString, string groupBy, string orderByField, bool isAscending, int? pageSize, int? pageNumber)
        {
            if (string.IsNullOrEmpty(whereString))
            {
                whereString = "1 = 1"; // 默认条件，表示查询所有数据
            }

            string SQL = BuildSelectSQL(Fields, whereString, groupBy, orderByField, isAscending, pageSize, pageNumber);

            using (SqlConnection connection = new SqlConnection(DBHelper.connectionString))
            {
                SqlCommand command = new SqlCommand(SQL, connection);

                // 添加分页参数
                if (pageSize.HasValue)
                {
                    command.Parameters.AddWithValue("@pageSize", pageSize.Value);
                }
                if (pageNumber.HasValue)
                {
                    int offset = (pageNumber.Value - 1) * pageSize.Value;
                    command.Parameters.AddWithValue("@offset", offset);
                }

                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds;
            }
        }

        /// <summary>
        /// 通过指定规则执行查询，并返回查询的数据，返回所有字段
        /// </summary>
        /// <param name="whereString">在SQL中 WHERE 部分需要填入的部分</param>
        /// <param name="orderByField">用于排序的字段</param>
        /// <param name="isAscending">是否按升序排序</param>
        /// <param name="pageSize">每页数据条数</param>
        /// <param name="pageNumber">页码</param>
        /// <returns>返回查询出的所有数据</returns>
        public DataSet Select(string whereString, string groupBy, string orderByField, bool isAscending, int? pageSize, int? pageNumber)
        {
            return Select(null, whereString, groupBy, orderByField, isAscending, pageSize, pageNumber);
        }

        /// <summary>
        /// 提供一个通过指定规则执行查询的功能，该功能会直接返回查询的数据。
        /// </summary>
        /// <param name="whereString">在SQL中 WHERE 部分需要填入的部分</param>
        /// <param name="orderByField">用于排序的字段</param>
        /// <param name="isAscending">是否按升序排序</param>
        /// <returns>对应数据的数据类</returns>
        public Object SelectReturnObject(string whereString)
        {
            // 构建SQL查询语句
            string SQL = BuildSelectSQL(null, whereString, null, "PB_ID", true, null, null);

            using (SqlConnection connection = new SqlConnection(DBHelper.connectionString))
            {
                SqlCommand command = new SqlCommand(SQL, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                ProjectData projectData = new ProjectData();

                if (reader.Read())
                {
                    // 映射基础表字段
                    projectData.Base.PB_ID = reader.GetInt32(reader.GetOrdinal("PB_ID"));
                    projectData.Base.ProjectState = reader.IsDBNull(reader.GetOrdinal("ProjectState")) ? 0 : reader.GetInt32(reader.GetOrdinal("ProjectState"));
                    projectData.Base.ProjectName = reader.GetString(reader.GetOrdinal("ProjectName"));
                    projectData.Base.ProjectCategory = reader.GetString(reader.GetOrdinal("ProjectCategory"));
                    projectData.Base.DisciplineClassification = reader.GetString(reader.GetOrdinal("DisciplineClassificaton"));
                    projectData.Base.FillDate = reader.IsDBNull(reader.GetOrdinal("FillDate")) ? String.Empty : reader.GetDateTime(reader.GetOrdinal("FillDate")).ToString("yyyy-MM-dd");
                    projectData.Base.EndingDate = reader.IsDBNull(reader.GetOrdinal("EndingDate")) ? String.Empty : reader.GetDateTime(reader.GetOrdinal("EndingDate")).ToString("yyyy-MM-dd");

                    // 映射拓展表字段
                    projectData.DemonstrationExpand.ProjectSignificance = reader.GetString(reader.GetOrdinal("ProjectSignificance"));
                    projectData.DemonstrationExpand.ProjectDocument = reader.GetString(reader.GetOrdinal("ProjectDocument"));
                    projectData.DemonstrationExpand.ProjectReferences = reader.GetString(reader.GetOrdinal("ProjectReferences"));

                    projectData.JudgeExpand.UnitJudge = reader.GetString(reader.GetOrdinal("UnitJudge"));
                    projectData.JudgeExpand.UnitJudgeDate = reader.IsDBNull(reader.GetOrdinal("UnitJudgeDate")) ? String.Empty : reader.GetDateTime(reader.GetOrdinal("UnitJudgeDate")).ToString("yyyy-MM-dd");
                    projectData.JudgeExpand.ExpertJudge = reader.GetString(reader.GetOrdinal("ExpertJudge"));
                    projectData.JudgeExpand.ExpertJudgeDate = reader.IsDBNull(reader.GetOrdinal("ExpertJudgeDate")) ? String.Empty : reader.GetDateTime(reader.GetOrdinal("ExpertJudgeDate")).ToString("yyyy-MM-dd");
                    projectData.JudgeExpand.ApprovalOpinion = reader.GetString(reader.GetOrdinal("ApprovalOpinion"));
                    projectData.JudgeExpand.ApprovalOpinionDate = reader.IsDBNull(reader.GetOrdinal("ApprovalOpinionDate")) ? String.Empty : reader.GetDateTime(reader.GetOrdinal("ApprovalOpinionDate")).ToString("yyyy-MM-dd");

                    projectData.ApprovalExpand.ProjectApprovalNum = reader.GetString(reader.GetOrdinal("ProjectApprovalNum"));

                    projectData.FinishExpansion.FinishCertificateNum = reader.GetString(reader.GetOrdinal("FinishCertificateNum"));

                    projectData.ChangeExpansion.ChangeState = reader.IsDBNull(reader.GetOrdinal("ChangeState")) ? 0 : reader.GetInt32(reader.GetOrdinal("ChangeState"));
                    projectData.ChangeExpansion.ChangeKind = reader.GetString(reader.GetOrdinal("ChangeKind"));
                    projectData.ChangeExpansion.AnotherChangeKind = reader.GetString(reader.GetOrdinal("AnotherChangeKind"));
                    projectData.ChangeExpansion.ChangeDataAndReason = reader.GetString(reader.GetOrdinal("ChangeDataAndReason"));
                    projectData.ChangeExpansion.ApplicationTime = reader.IsDBNull(reader.GetOrdinal("ApplicationTime")) ? String.Empty : reader.GetDateTime(reader.GetOrdinal("ApplicationTime")).ToString("yyyy-MM-dd");
                    projectData.ChangeExpansion.UnitOpinion = reader.GetString(reader.GetOrdinal("UnitOpinion"));
                }

                return projectData;
            }
        }

        #endregion

        #region 插入功能

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
                "OUTPUT inserted.PB_ID as id -- 返回插入数据的ID\n" +
                $"VALUES({ValuesString});";

            return SQL;
        }

        /// <summary>
        /// 执行插入操作，并返回插入数据的ID
        /// </summary>
        /// <param name="sqlTransaction">SQL事务</param>
        /// <param name="item">要插入的数据对象</param>
        public void Insert(SqlTransaction sqlTransaction, Object item)
        {
            InsertReturnID(sqlTransaction, item);
        }

        /// <summary>
        /// 执行插入操作，并返回插入数据的ID
        /// </summary>
        /// <param name="sqlTransaction">SQL事务</param>
        /// <param name="item">要插入的数据对象</param>
        /// <returns>插入数据的ID</returns>
        public string InsertReturnID(SqlTransaction sqlTransaction, Object item)
        {
            using (SqlConnection conn = GetSqlConnection())
            {
                OpenSqlConnection();
                SqlTransaction tx;

                if (sqlTransaction == null)
                    tx = conn.BeginTransaction();
                else
                    tx = sqlTransaction;

                try
                {
                    string PB_ID = InsertProjectBaseData(item, conn, tx);
                    InsertProjectDemonstrationExpandData(item, PB_ID, conn, tx);
                    InsertProjectJudgeExpandData(item, PB_ID, conn, tx);
                    InsertProjectApprovalExpandData(item, PB_ID, conn, tx);
                    InsertProjectFinishExpansionExpandData(item, PB_ID, conn, tx);
                    InsertProjectChangeExpansionExpandData(item, PB_ID, conn, tx);

                    if (sqlTransaction == null)
                        tx.Commit();

                    return PB_ID;
                }
                catch
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        #region 插入子功能

        /// <summary>
        /// 插入项目基础数据，返回插入数据的ID
        /// </summary>
        /// <param name="item">要插入的数据对象</param>
        /// <param name="conn">数据库连接</param>
        /// <param name="tx">SQL事务</param>
        /// <returns>插入数据的ID</returns>
        public string InsertProjectBaseData(Object item, SqlConnection conn, SqlTransaction tx)
        {
            ProjectData projectData = (ProjectData)item;
            if (projectData.IsEmpty())
            {
                return string.Empty;
            }

            List<string> fields = new List<string>
    {
        "ProjectState",
        "ProjectName",
        "ProjectCategory",
        "DisciplineClassificaton",
        "FillDate",
        "Ending",
        "EndingDate"
    };

            List<string> datas = new List<string>
    {
        projectData.Base.ProjectState.ToString(),
        projectData.Base.ProjectName,
        projectData.Base.ProjectCategory.ToString(),
        projectData.Base.DisciplineClassification,
        projectData.Base.FillDate,
        projectData.Base.Ending.ToString(),
        projectData.Base.EndingDate
    };

            string SQL = BuildInsertSQL("ProjectBase", fields, datas);

            using (SqlCommand cmd = new SqlCommand(SQL, conn, tx))
            {
                for (int i = 0; i < datas.Count; i++)
                {
                    cmd.Parameters.AddWithValue($"@param{i}", datas[i]);
                }

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);

                return ds.Tables[0].Rows[0]["id"].ToString();
            }
        }

        /// <summary>
        /// 插入项目论证拓展信息表
        /// </summary>
        /// <param name="item">要插入的数据对象</param>
        /// <param name="PB_ID">项目ID</param>
        /// <param name="conn">数据库连接</param>
        /// <param name="tx">SQL事务</param>
        public void InsertProjectDemonstrationExpandData(Object item, string PB_ID, SqlConnection conn, SqlTransaction tx)
        {
            ProjectData projectData = (ProjectData)item;
            if (projectData.DemonstrationExpand.IsEmpty())
            {
                return;
            }

            List<string> fields = new List<string>
    {
        "PB_ID",
        "ProjectSignificance",
        "ProjectDocument",
        "ProjectReferences"
    };

            List<string> datas = new List<string>
    {
        PB_ID,
        projectData.DemonstrationExpand.ProjectSignificance,
        projectData.DemonstrationExpand.ProjectDocument,
        projectData.DemonstrationExpand.ProjectReferences
    };

            string SQL = BuildInsertSQL("ProjectDemonstrationExpand", fields, datas);

            using (SqlCommand cmd = new SqlCommand(SQL, conn, tx))
            {
                for (int i = 0; i < datas.Count; i++)
                {
                    cmd.Parameters.AddWithValue($"@param{i}", datas[i]);
                }

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 插入项目评审拓展信息表
        /// </summary>
        /// <param name="item">要插入的数据对象</param>
        /// <param name="PB_ID">项目ID</param>
        /// <param name="conn">数据库连接</param>
        /// <param name="tx">SQL事务</param>
        public void InsertProjectJudgeExpandData(Object item, string PB_ID, SqlConnection conn, SqlTransaction tx)
        {
            ProjectData projectData = (ProjectData)item;
            if (projectData.JudgeExpand.IsEmpty())
            {
                return;
            }

            List<string> fields = new List<string>
    {
        "PB_ID",
        "UnitJudge",
        "UnitJudgeDate",
        "ExpertJudge",
        "ExpertJudgeDate",
        "ApprovalOpinion",
        "ApprovalOpinionDate"
    };

            List<string> datas = new List<string>
    {
        PB_ID,
        projectData.JudgeExpand.UnitJudge,
        projectData.JudgeExpand.UnitJudgeDate,
        projectData.JudgeExpand.ExpertJudge,
        projectData.JudgeExpand.ExpertJudgeDate,
        projectData.JudgeExpand.ApprovalOpinion,
        projectData.JudgeExpand.ApprovalOpinionDate
    };

            string SQL = BuildInsertSQL("ProjectJudgeExpand", fields, datas);

            using (SqlCommand cmd = new SqlCommand(SQL, conn, tx))
            {
                for (int i = 0; i < datas.Count; i++)
                {
                    cmd.Parameters.AddWithValue($"@param{i}", datas[i]);
                }

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 插入项目立项拓展信息表
        /// </summary>
        /// <param name="item">要插入的数据对象</param>
        /// <param name="PB_ID">项目ID</param>
        /// <param name="conn">数据库连接</param>
        /// <param name="tx">SQL事务</param>
        public void InsertProjectApprovalExpandData(Object item, string PB_ID, SqlConnection conn, SqlTransaction tx)
        {
            ProjectData projectData = (ProjectData)item;
            if (projectData.ApprovalExpand.IsEmpty())
            {
                return;
            }

            List<string> fields = new List<string>
    {
        "PB_ID",
        "ProjectApprovalNum"
    };

            List<string> datas = new List<string>
    {
        PB_ID,
        projectData.ApprovalExpand.ProjectApprovalNum
    };

            string SQL = BuildInsertSQL("ProjectApprovalExpand", fields, datas);

            using (SqlCommand cmd = new SqlCommand(SQL, conn, tx))
            {
                for (int i = 0; i < datas.Count; i++)
                {
                    cmd.Parameters.AddWithValue($"@param{i}", datas[i]);
                }

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 插入项目结项拓展信息表
        /// </summary>
        /// <param name="item">要插入的数据对象</param>
        /// <param name="PB_ID">项目ID</param>
        /// <param name="conn">数据库连接</param>
        /// <param name="tx">SQL事务</param>
        public void InsertProjectFinishExpansionExpandData(Object item, string PB_ID, SqlConnection conn, SqlTransaction tx)
        {
            ProjectData projectData = (ProjectData)item;
            if (projectData.FinishExpansion.IsEmpty())
            {
                return;
            }

            List<string> fields = new List<string>
    {
        "PB_ID",
        "FinishCertificateNum"
    };

            List<string> datas = new List<string>
    {
        PB_ID,
        projectData.FinishExpansion.FinishCertificateNum
    };

            string SQL = BuildInsertSQL("ProjectFinishExpansion", fields, datas);

            using (SqlCommand cmd = new SqlCommand(SQL, conn, tx))
            {
                for (int i = 0; i < datas.Count; i++)
                {
                    cmd.Parameters.AddWithValue($"@param{i}", datas[i]);
                }

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 插入项目变更信息表
        /// </summary>
        /// <param name="item">要插入的数据对象</param>
        /// <param name="PB_ID">项目ID</param>
        /// <param name="conn">数据库连接</param>
        /// <param name="tx">SQL事务</param>
        public void InsertProjectChangeExpansionExpandData(Object item, string PB_ID, SqlConnection conn, SqlTransaction tx)
        {
            ProjectData projectData = (ProjectData)item;
            if (projectData.ChangeExpansion.IsEmpty())
            {
                return;
            }

            List<string> fields = new List<string>
    {
        "PB_ID",
        "ChangeState",
        "ChangeKind",
        "AnotherChangeKind",
        "ChangeDataAndReason",
        "ApplicationTime",
        "UnitOpinion"
    };

            List<string> datas = new List<string>
    {
        PB_ID,
        projectData.ChangeExpansion.ChangeState.ToString(),
        projectData.ChangeExpansion.ChangeKind,
        projectData.ChangeExpansion.AnotherChangeKind,
        projectData.ChangeExpansion.ChangeDataAndReason,
        projectData.ChangeExpansion.ApplicationTime,
        projectData.ChangeExpansion.UnitOpinion
    };

            string SQL = BuildInsertSQL("ProjectChangeExpansion", fields, datas);

            using (SqlCommand cmd = new SqlCommand(SQL, conn, tx))
            {
                for (int i = 0; i < datas.Count; i++)
                {
                    cmd.Parameters.AddWithValue($"@param{i}", datas[i]);
                }

                cmd.ExecuteNonQuery();
            }
        }

        #endregion

        #endregion

        #region 删除子功能

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

        /// <summary>
        /// 删除项目基础数据
        /// </summary>
        /// <param name="ID">项目ID</param>
        /// <returns>影响的条数</returns>
        private int DeleteProjectBaseData(SqlTransaction sqlTransaction, string ID)
        {
            string sql = BuildDeleteSQL("ProjectBase", $"PB_ID = @ID");
            return ExecuteSQL(sqlTransaction, sql, new List<SqlParameter> { new SqlParameter("@ID", ID) });
        }

        /// <summary>
        /// 删除项目论证拓展信息
        /// </summary>
        /// <param name="ID">项目ID</param>
        /// <returns>影响的条数</returns>
        private int DeleteProjectDemonstrationExpandData(SqlTransaction sqlTransaction, string ID)
        {
            string sql = BuildDeleteSQL("ProjectDemonstrationExpand", $"PB_ID = @ID");
            return ExecuteSQL(sqlTransaction, sql, new List<SqlParameter> { new SqlParameter("@ID", ID) });
        }

        /// <summary>
        /// 删除项目评审拓展信息
        /// </summary>
        /// <param name="ID">项目ID</param>
        /// <returns>影响的条数</returns>
        private int DeleteProjectJudgeExpandData(SqlTransaction sqlTransaction, string ID)
        {
            string sql = BuildDeleteSQL("ProjectJudgeExpand", $"PB_ID = @ID");
            return ExecuteSQL(sqlTransaction, sql, new List<SqlParameter> { new SqlParameter("@ID", ID) });
        }

        /// <summary>
        /// 删除项目立项拓展信息
        /// </summary>
        /// <param name="ID">项目ID</param>
        /// <returns>影响的条数</returns>
        private int DeleteProjectApprovalExpandData(SqlTransaction sqlTransaction, string ID)
        {
            string sql = BuildDeleteSQL("ProjectApprovalExpand", $"PB_ID = @ID");
            return ExecuteSQL(sqlTransaction, sql, new List<SqlParameter> { new SqlParameter("@ID", ID) });
        }

        /// <summary>
        /// 删除项目结项拓展信息
        /// </summary>
        /// <param name="ID">项目ID</param>
        /// <returns>影响的条数</returns>
        private int DeleteProjectFinishExpansionExpandData(SqlTransaction sqlTransaction, string ID)
        {
            string sql = BuildDeleteSQL("ProjectFinishExpansion", $"PB_ID = @ID");
            return ExecuteSQL(sqlTransaction, sql, new List<SqlParameter> { new SqlParameter("@ID", ID) });
        }

        /// <summary>
        /// 删除项目变更信息
        /// </summary>
        /// <param name="ID">项目ID</param>
        /// <returns>影响的条数</returns>
        private int DeleteProjectChangeExpansionExpandData(SqlTransaction sqlTransaction, string ID)
        {
            string sql = BuildDeleteSQL("ProjectChangeExpansion", $"PB_ID = @ID");
            return ExecuteSQL(sqlTransaction, sql, new List<SqlParameter> { new SqlParameter("@ID", ID) });
        }

        /// <summary>
        /// 删除完整的项目数据，包括所有相关表的信息
        /// </summary>
        /// <param name="ID">项目ID</param>
        public int DeleteByID(SqlTransaction sqlTransaction, string ID)
        {
            int affectedRows = 0;
            using (SqlConnection conn = new SqlConnection(DBHelper.connectionString))
            {
                conn.Open();
                // 创建一个事务对象，通过事务操作保证删除的可靠性
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        affectedRows += DeleteProjectChangeExpansionExpandData(trans, ID);
                        affectedRows += DeleteProjectFinishExpansionExpandData(trans, ID);
                        affectedRows += DeleteProjectApprovalExpandData(trans, ID);
                        affectedRows += DeleteProjectJudgeExpandData(trans, ID);
                        affectedRows += DeleteProjectDemonstrationExpandData(trans, ID);
                        affectedRows += DeleteProjectBaseData(trans, ID);
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
            return affectedRows;
        }

        /// <summary>
        /// 删除符合Where语句条件的数据项
        /// </summary>
        /// <param name="Where">限制条件</param>
        /// <returns>影响的条数</returns>
        public int Delete(SqlTransaction sqlTransaction, string Where)
        {
            int affectedRows = 0;

            using (SqlConnection conn = GetSqlConnection())
            {
                OpenSqlConnection();
                // 创建一个事务对象，通过事务操作保证删除的可靠性
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    SqlTransaction tx;

                    // 判断是否要创建事务操作
                    if (sqlTransaction == null) tx = conn.BeginTransaction();
                    else tx = sqlTransaction;

                    cmd.Transaction = tx;
                    try
                    {
                        // 删除 ProjectDemonstrationExpand 表中的数据
                        cmd.CommandText = BuildDeleteSQL("ProjectDemonstrationExpand", Where);
                        affectedRows += cmd.ExecuteNonQuery();

                        // 删除 ProjectJudgeExpand 表中的数据
                        cmd.CommandText = BuildDeleteSQL("ProjectJudgeExpand", Where);
                        affectedRows += cmd.ExecuteNonQuery();

                        // 删除 ProjectApprovalExpand 表中的数据
                        cmd.CommandText = BuildDeleteSQL("ProjectApprovalExpand", Where);
                        affectedRows += cmd.ExecuteNonQuery();

                        // 删除 ProjectFinishExpansion 表中的数据
                        cmd.CommandText = BuildDeleteSQL("ProjectFinishExpansion", Where);
                        affectedRows += cmd.ExecuteNonQuery();

                        // 删除 ProjectChangeExpansion 表中的数据
                        cmd.CommandText = BuildDeleteSQL("ProjectChangeExpansion", Where);
                        affectedRows += cmd.ExecuteNonQuery();

                        // 删除 基础数据内容
                        cmd.CommandText = BuildDeleteSQL("ProjectBase", Where);
                        affectedRows += cmd.ExecuteNonQuery();

                        // 如果传入参数中有事务操作，则交由操作方进行事务的提交
                        if (sqlTransaction == null)
                            tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }

            return affectedRows;
        }

        #endregion

        #region 更新功能

        #region Helper Methods

        /// <summary>
        /// 构建更新SQL语句和参数
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="updatePairs">更新字段和值的键值对</param>
        /// <param name="where">更新条件</param>
        /// <param name="parameters">SQL参数</param>
        /// <returns>更新SQL语句</returns>
        private static string BuildUpdateSQL(string tableName, Dictionary<string, string> updatePairs, string where, out List<SqlParameter> parameters)
        {
            List<string> setClauses = new List<string>();
            parameters = new List<SqlParameter>();

            foreach (var pair in updatePairs)
            {
                string paramName = $"@{pair.Key}";
                setClauses.Add($"{pair.Key} = {paramName}");
                parameters.Add(new SqlParameter(paramName, pair.Value ?? (object)DBNull.Value));
            }

            string setClause = string.Join(", ", setClauses);
            string sql = $"UPDATE {tableName} SET {setClause} WHERE {where}";

            return sql;
        }

        #endregion

        #region IDataUpdate Implementation

        public int Update(SqlTransaction sqlTransaction, string ID, Object Item)
        {
            ProjectData projectData = (ProjectData)Item;
            int affectedRows = 0;

            using (SqlConnection conn = new SqlConnection(DBHelper.connectionString))
            {
                conn.Open();

                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        if (!projectData.Base.IsEmpty())
                        {
                            Dictionary<string, string> updatePairs = new Dictionary<string, string>
                            {
                                { "ProjectState", projectData.Base.ProjectState.ToString() },
                                { "ProjectName", projectData.Base.ProjectName },
                                { "ProjectCategory", projectData.Base.ProjectCategory.ToString() },
                                { "DisciplineClassificaton", projectData.Base.DisciplineClassification },
                                { "FillDate", projectData.Base.FillDate.ToString() },
                                { "Ending", projectData.Base.Ending.ToString() },
                                { "EndingDate", projectData.Base.EndingDate }
                            };

                            string sql = BuildUpdateSQL("ProjectBase", updatePairs, "PB_ID = @ID", out List<SqlParameter> parameters);
                            parameters.Add(new SqlParameter("@ID", ID));
                            affectedRows += ExecuteSQL(trans, sql, parameters);
                        }

                        if (!projectData.DemonstrationExpand.IsEmpty())
                        {
                            Dictionary<string, string> updatePairs = new Dictionary<string, string>
                            {
                                { "ProjectSignificance", projectData.DemonstrationExpand.ProjectSignificance },
                                { "ProjectDocument", projectData.DemonstrationExpand.ProjectDocument },
                                { "ProjectReferences", projectData.DemonstrationExpand.ProjectReferences }
                            };

                            string sql = BuildUpdateSQL("ProjectDemonstrationExpand", updatePairs, "PB_ID = @ID", out List<SqlParameter> parameters);
                            parameters.Add(new SqlParameter("@ID", ID));
                            affectedRows += ExecuteSQL(trans, sql, parameters);
                        }

                        if (!projectData.JudgeExpand.IsEmpty())
                        {
                            Dictionary<string, string> updatePairs = new Dictionary<string, string>
                            {
                                { "UnitJudge", projectData.JudgeExpand.UnitJudge },
                                { "UnitJudgeDate", projectData.JudgeExpand.UnitJudgeDate },
                                { "ExpertJudge", projectData.JudgeExpand.ExpertJudge },
                                { "ExpertJudgeDate", projectData.JudgeExpand.ExpertJudgeDate },
                                { "ApprovalOpinion", projectData.JudgeExpand.ApprovalOpinion },
                                { "ApprovalOpinionDate", projectData.JudgeExpand.ApprovalOpinionDate }
                            };

                            string sql = BuildUpdateSQL("ProjectJudgeExpand", updatePairs, "PB_ID = @ID", out List<SqlParameter> parameters);
                            parameters.Add(new SqlParameter("@ID", ID));
                            affectedRows += ExecuteSQL(trans, sql, parameters);
                        }

                        if (!projectData.ApprovalExpand.IsEmpty())
                        {
                            Dictionary<string, string> updatePairs = new Dictionary<string, string>
                            {
                                { "ProjectApprovalNum", projectData.ApprovalExpand.ProjectApprovalNum }
                            };

                            string sql = BuildUpdateSQL("ProjectApprovalExpand", updatePairs, "PB_ID = @ID", out List<SqlParameter> parameters);
                            parameters.Add(new SqlParameter("@ID", ID));
                            affectedRows += ExecuteSQL(trans, sql, parameters);
                        }

                        if (!projectData.FinishExpansion.IsEmpty())
                        {
                            Dictionary<string, string> updatePairs = new Dictionary<string, string>
                            {
                                { "FinishCertificateNum", projectData.FinishExpansion.FinishCertificateNum }
                            };

                            string sql = BuildUpdateSQL("ProjectFinishExpansion", updatePairs, "PB_ID = @ID", out List<SqlParameter> parameters);
                            parameters.Add(new SqlParameter("@ID", ID));
                            affectedRows += ExecuteSQL(trans, sql, parameters);
                        }

                        if (!projectData.ChangeExpansion.IsEmpty())
                        {
                            Dictionary<string, string> updatePairs = new Dictionary<string, string>
                            {
                                { "ChangeState", projectData.ChangeExpansion.ChangeState.ToString() },
                                { "ChangeKind", projectData.ChangeExpansion.ChangeKind },
                                { "AnotherChangeKind", projectData.ChangeExpansion.AnotherChangeKind },
                                { "ChangeDataAndReason", projectData.ChangeExpansion.ChangeDataAndReason },
                                { "ApplicationTime", projectData.ChangeExpansion.ApplicationTime },
                                { "UnitOpinion", projectData.ChangeExpansion.UnitOpinion }
                            };

                            string sql = BuildUpdateSQL("ProjectChangeExpansion", updatePairs, "PB_ID = @ID", out List<SqlParameter> parameters);
                            parameters.Add(new SqlParameter("@ID", ID));
                            affectedRows += ExecuteSQL(trans, sql, parameters);
                        }

                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }

            return affectedRows;
        }

        public int Update(SqlTransaction sqlTransaction, Object Item, String Where)
        {
            ProjectData projectData = (ProjectData)Item;
            int affectedRows = 0;

            using (SqlConnection conn = new SqlConnection(DBHelper.connectionString))
            {
                conn.Open();

                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        if (!projectData.Base.IsEmpty())
                        {
                            Dictionary<string, string> updatePairs = new Dictionary<string, string>
                            {
                                { "ProjectState", projectData.Base.ProjectState.ToString() },
                                { "ProjectName", projectData.Base.ProjectName },
                                { "ProjectCategory", projectData.Base.ProjectCategory.ToString() },
                                { "DisciplineClassificaton", projectData.Base.DisciplineClassification },
                                { "FillDate", projectData.Base.FillDate.ToString() },
                                { "Ending", projectData.Base.Ending.ToString() },
                                { "EndingDate", projectData.Base.EndingDate }
                            };

                            string sql = BuildUpdateSQL("ProjectBase", updatePairs, Where, out List<SqlParameter> parameters);
                            affectedRows += ExecuteSQL(trans, sql, parameters);
                        }

                        if (!projectData.DemonstrationExpand.IsEmpty())
                        {
                            Dictionary<string, string> updatePairs = new Dictionary<string, string>
                            {
                                { "ProjectSignificance", projectData.DemonstrationExpand.ProjectSignificance },
                                { "ProjectDocument", projectData.DemonstrationExpand.ProjectDocument },
                                { "ProjectReferences", projectData.DemonstrationExpand.ProjectReferences }
                            };

                            string sql = BuildUpdateSQL("ProjectDemonstrationExpand", updatePairs, Where, out List<SqlParameter> parameters);
                            affectedRows += ExecuteSQL(trans, sql, parameters);
                        }

                        if (!projectData.JudgeExpand.IsEmpty())
                        {
                            Dictionary<string, string> updatePairs = new Dictionary<string, string>
                            {
                                { "UnitJudge", projectData.JudgeExpand.UnitJudge },
                                { "UnitJudgeDate", projectData.JudgeExpand.UnitJudgeDate },
                                { "ExpertJudge", projectData.JudgeExpand.ExpertJudge },
                                { "ExpertJudgeDate", projectData.JudgeExpand.ExpertJudgeDate },
                                { "ApprovalOpinion", projectData.JudgeExpand.ApprovalOpinion },
                                { "ApprovalOpinionDate", projectData.JudgeExpand.ApprovalOpinionDate }
                            };

                            string sql = BuildUpdateSQL("ProjectJudgeExpand", updatePairs, Where, out List<SqlParameter> parameters);
                            affectedRows += ExecuteSQL(trans, sql, parameters);
                        }

                        if (!projectData.ApprovalExpand.IsEmpty())
                        {
                            Dictionary<string, string> updatePairs = new Dictionary<string, string>
                            {
                                { "ProjectApprovalNum", projectData.ApprovalExpand.ProjectApprovalNum }
                            };

                            string sql = BuildUpdateSQL("ProjectApprovalExpand", updatePairs, Where, out List<SqlParameter> parameters);
                            affectedRows += ExecuteSQL(trans, sql, parameters);
                        }

                        if (!projectData.FinishExpansion.IsEmpty())
                        {
                            Dictionary<string, string> updatePairs = new Dictionary<string, string>
                            {
                                { "FinishCertificateNum", projectData.FinishExpansion.FinishCertificateNum }
                            };

                            string sql = BuildUpdateSQL("ProjectFinishExpansion", updatePairs, Where, out List<SqlParameter> parameters);
                            affectedRows += ExecuteSQL(trans, sql, parameters);
                        }

                        if (!projectData.ChangeExpansion.IsEmpty())
                        {
                            Dictionary<string, string> updatePairs = new Dictionary<string, string>
                            {
                                { "ChangeState", projectData.ChangeExpansion.ChangeState.ToString() },
                                { "ChangeKind", projectData.ChangeExpansion.ChangeKind },
                                { "AnotherChangeKind", projectData.ChangeExpansion.AnotherChangeKind },
                                { "ChangeDataAndReason", projectData.ChangeExpansion.ChangeDataAndReason },
                                { "ApplicationTime", projectData.ChangeExpansion.ApplicationTime },
                                { "UnitOpinion", projectData.ChangeExpansion.UnitOpinion }
                            };

                            string sql = BuildUpdateSQL("ProjectChangeExpansion", updatePairs, Where, out List<SqlParameter> parameters);
                            affectedRows += ExecuteSQL(trans, sql, parameters);
                        }

                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }

            return affectedRows;
        }

        #endregion

        #endregion



    }
}
