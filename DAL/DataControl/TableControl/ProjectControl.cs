using DAL.DataBase;
using DAL.DataControl.Interface;
using DAL.DataObject.TableObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL.DataControl.TableControl
{
    public class ProjectControl : DataBaseControl, IDataSelect, IDataInseart, IDataDelete, IDataUpdate
    {
        #region 查询功能

        /// <summary>
        /// 构建SQL查询语句
        /// </summary>
        /// <param name="Fields">指定查询出的字段</param>
        /// <param name="whereString">在SQL中 WHERE 部分需要填入的部分</param>
        /// <param name="orderByField">用于排序的字段</param>
        /// <param name="isAscending">是否按升序排序</param>
        /// <param name="pageSize">每页数据条数</param>
        /// <param name="pageNumber">页码</param>
        /// <returns>返回SQL查询语句</returns>
        private static string BuildSelectSQL(List<string> Fields, string whereString, string orderByField, bool isAscending, int pageSize = 20, int pageNumber = 1)
        {
            // 如果没有指定字段，则查询所有字段
            string fieldString = Fields != null && Fields.Count > 0 ? string.Join(", ", Fields) : @"
                ProjectBase.PB_ID,
                ProjectBase.ProjectState,
                ProjectBase.ProjectName,
                ProjectBase.ProjectCategory,
                ProjectBase.DisciplineClassificaton,
                ProjectBase.FillDate,
                ProjectBase.Ending,
                ProjectBase.EndingDate,
                ProjectDemonstrationExpand.ProjectSignificance,
                ProjectDemonstrationExpand.ProjectDocument,
                ProjectDemonstrationExpand.ProjectReferences,
                ProjectJudgeExpand.UnitJudge,
                ProjectJudgeExpand.UnitJudgeDate,
                ProjectJudgeExpand.ExpertJudge,
                ProjectJudgeExpand.ExpertJudgeDate,
                ProjectJudgeExpand.ApprovalOpinion,
                ProjectJudgeExpand.ApprovalOpinionDate,
                ProjectApprovalExpand.ProjectApprovalNum,
                ProjectFinishExpansion.FinishCertificateNum,
                ProjectChangeExpansion.ChangeState,
                ProjectChangeExpansion.ChangeKind,
                ProjectChangeExpansion.AnotherChangeKind,
                ProjectChangeExpansion.ChangeDataAndReason,
                ProjectChangeExpansion.ApplicationTime,
                ProjectChangeExpansion.UnitOpinion";

            string SQL =
                "-- 项目信息查询SQL\n" +
                "DECLARE @SelectSQL NVARCHAR(MAX);\n" +
                "DECLARE @Where NVARCHAR(MAX);\n" +
                $"SET @Where = '{whereString}';\n" +
                "SET @SelectSQL =\n" +
                "'SELECT " + fieldString + "\n" +
                "FROM ProjectBase\n" +
                "LEFT JOIN ProjectDemonstrationExpand ON ProjectBase.PB_ID = ProjectDemonstrationExpand.PB_ID\n" +
                "LEFT JOIN ProjectJudgeExpand ON ProjectBase.PB_ID = ProjectJudgeExpand.PB_ID\n" +
                "LEFT JOIN ProjectApprovalExpand ON ProjectBase.PB_ID = ProjectApprovalExpand.PB_ID\n" +
                "LEFT JOIN ProjectFinishExpansion ON ProjectBase.PB_ID = ProjectFinishExpansion.PB_ID\n" +
                "LEFT JOIN ProjectChangeExpansion ON ProjectBase.PB_ID = ProjectChangeExpansion.PB_ID\n" +
                "WHERE ' + @Where + '\n" +
                "ORDER BY " + orderByField + " " + (isAscending ? "ASC" : "DESC") + "\n" +
                "OFFSET " + (pageSize * (pageNumber - 1)) + " ROWS\n" +
                "FETCH NEXT " + pageSize + " ROWS ONLY;';\n" +
                "EXEC sp_executesql @SelectSQL;";

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
        public static DataSet Select(List<string> Fields, string whereString = null, string orderByField = "PB_ID", bool isAscending = true, int pageSize = 20, int pageNumber = 1)
        {
            if (string.IsNullOrEmpty(whereString))
            {
                whereString = "1 = 1"; // 默认条件，表示查询所有数据
            }

            string SQL = BuildSelectSQL(Fields, whereString, orderByField, isAscending, pageSize, pageNumber);
            return DBHelper.Query(SQL);
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
        public static DataSet Select(string whereString = null, string orderByField = "PB_ID", bool isAscending = true, int pageSize = 20, int pageNumber = 1)
        {
            return Select(null, whereString, orderByField, isAscending, pageSize, pageNumber);
        }


        /// <summary>
        /// 提供一个通过指定规则执行查询的功能，该功能会直接返回查询的数据。
        /// </summary>
        /// <param name="whereString">在SQL中 WHERE 部分需要填入的部分</param>
        /// <param name="orderByField">用于排序的字段</param>
        /// <param name="isAscending">是否按升序排序</param>
        /// <returns>对应数据的数据类</returns>
        public static Object SelectReturnObject(string whereString)
        {
            // 构建SQL查询语句
            string SQL = BuildSelectSQL(null, whereString, "PB_ID", true);


            
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
                    projectData.Base.ProjectState = int.Parse(reader.GetString(reader.GetOrdinal("ProjectState")));
                    projectData.Base.ProjectName = reader.GetString(reader.GetOrdinal("ProjectName"));
                    projectData.Base.ProjectCategory = reader.GetString(reader.GetOrdinal("ProjectCategory"));
                    projectData.Base.DisciplineClassificaton = reader.GetString(reader.GetOrdinal("DisciplineClassificaton"));
                    projectData.Base.FillDate = reader.IsDBNull(reader.GetOrdinal("FillDate")) ? String.Empty : reader.GetDateTime(reader.GetOrdinal("UnitJudgeDate")).ToString("yyyy-MM-dd");
                    projectData.Base.EndingDate = reader.IsDBNull(reader.GetOrdinal("EndingDate")) ? String.Empty : reader.GetDateTime(reader.GetOrdinal("UnitJudgeDate")).ToString("yyyy-MM-dd");

                    // 映射拓展表字段
                    projectData.DemonstrationExpand.ProjectSignificance = reader.GetString(reader.GetOrdinal("ProjectSignificance"));
                    projectData.DemonstrationExpand.ProjectDocument = reader.GetString(reader.GetOrdinal("ProjectDocument"));
                    projectData.DemonstrationExpand.ProjectReferences = reader.GetString(reader.GetOrdinal("ProjectReferences"));

                    projectData.JudgeExpand.UnitJudge = reader.GetString(reader.GetOrdinal("UnitJudge"));
                    projectData.JudgeExpand.UnitJudgeDate = reader.IsDBNull(reader.GetOrdinal("UnitJudgeDate")) ? String.Empty : reader.GetDateTime(reader.GetOrdinal("UnitJudgeDate")).ToString("yyyy-MM-dd");
                    projectData.JudgeExpand.ExpertJudge = reader.GetString(reader.GetOrdinal("ExpertJudge"));
                    projectData.JudgeExpand.ExpertJudgeDate = reader.IsDBNull(reader.GetOrdinal("ExpertJudgeDate")) ? String.Empty : reader.GetDateTime(reader.GetOrdinal("UnitJudgeDate")).ToString("yyyy-MM-dd");
                    projectData.JudgeExpand.ApprovalOpinion = reader.GetString(reader.GetOrdinal("ApprovalOpinion"));
                    projectData.JudgeExpand.ApprovalOpinionDate = reader.IsDBNull(reader.GetOrdinal("ApprovalOpinionDate")) ? String.Empty : reader.GetDateTime(reader.GetOrdinal("UnitJudgeDate")).ToString("yyyy-MM-dd");

                    projectData.ApprovalExpand.ProjectApprovalNum = reader.GetString(reader.GetOrdinal("ProjectApprovalNum"));

                    projectData.FinishExpansion.FinishCertificateNum = reader.GetString(reader.GetOrdinal("FinishCertificateNum"));

                    projectData.ChangeExpansion.ChangeState = int.Parse(reader.GetString(reader.GetOrdinal("ChangeState")));
                    projectData.ChangeExpansion.ChangeKind = reader.GetString(reader.GetOrdinal("ChangeKind"));
                    projectData.ChangeExpansion.AnotherChangeKind = reader.GetString(reader.GetOrdinal("AnotherChangeKind"));
                    projectData.ChangeExpansion.ChangeDataAndReason = reader.GetString(reader.GetOrdinal("ChangeDataAndReason"));
                    projectData.ChangeExpansion.ApplicationTime = reader.IsDBNull(reader.GetOrdinal("ApplicationTime")) ? String.Empty : reader.GetDateTime(reader.GetOrdinal("UnitJudgeDate")).ToString("yyyy-MM-dd");
                    projectData.ChangeExpansion.UnitOpinion = reader.GetString(reader.GetOrdinal("UnitOpinion"));
                }

                return projectData;
            }
        }

        #endregion

        #region 插入功能
        private static string BuildInseartSQL(string TableName, List<string> Fields, List<string> Datas)
        {
            string FieldsString = string.Join(", ", Fields);
            string DatesString = string.Join(", ", Datas.Select(data => $"'{data}'"));

            string SQL =
               $"INSERT INTO [{TableName}] ({FieldsString})          \r\n" +
                "OUTPUT inserted.PB_ID as id -- 返回插入数据的ID  \r\n" +
               $"VALUES({DatesString});                           ";
            return SQL;
        }


        public static void Inseart(Object item)
        {
            InseartReturnID(item);
        }

        public static string InseartReturnID(Object item)
        {

            using (SqlConnection conn = new SqlConnection(DBHelper.connectionString))
            {
                conn.Open();
                // 创建一个事务对象，通过事务操作保证插入的可靠性
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        string PB_ID = InseartProjectBaseData(item);
                        InseartProjectDemonstrationExpandData(item, PB_ID);
                        InseartProjectJudgeExpandData(item, PB_ID);
                        InseartProjectApprovalExpandData(item, PB_ID);
                        InseartProjectFinishExpansionExpandData(item, PB_ID);
                        InseartProjectChangeExpansionExpandData(item, PB_ID);
                        trans.Commit();
                        return PB_ID;
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        #region 插入子功能

        /// <summary>
        /// 插入项目基础数据，返回插入数据的ID
        /// </summary>
        /// <param name="item">插入的对象</param>
        /// <returns>插入数据的ID</returns>
        public static string InseartProjectBaseData(Object item)
        {
            ProjectData projectData = (ProjectData)item;
            if (projectData.IsEmpty())
            {
                return string.Empty;
            }
            List<string> fields = new List<string>();
            List<string> datas = new List<string>();
            fields.Add("ProjectState");
            datas.Add(projectData.Base.ProjectState.ToString());

            fields.Add("ProjectName");
            datas.Add(projectData.Base.ProjectName);

            fields.Add("ProjectCategory");
            datas.Add(projectData.Base.ProjectCategory.ToString());

            fields.Add("DisciplineClassificaton");
            datas.Add(projectData.Base.DisciplineClassificaton);

            fields.Add("FillDate");
            datas.Add(projectData.Base.FillDate.ToString());

            fields.Add("Ending");
            datas.Add(projectData.Base.Ending.ToString());

            fields.Add("EndingDate");
            datas.Add(projectData.Base.EndingDate);

            DataSet AnsDataSet = DBHelper.Query(BuildInseartSQL("ProjectBase", fields, datas));

            return AnsDataSet.Tables[0].Rows[0][0].ToString();
        }

        /// <summary>
        /// 插入项目论证拓展信息表
        /// </summary>
        /// <param name="item">插入的对象</param>
        public static void InseartProjectDemonstrationExpandData(Object item, string PB_ID)
        {
            ProjectData projectData = (ProjectData)item;
            if (projectData.DemonstrationExpand.IsEmpty())
            {
                return;
            }
            List<string> fields = new List<string>();
            List<string> datas = new List<string>();
            fields.Add("PB_ID");
            datas.Add(PB_ID);

            fields.Add("ProjectSignificance");
            datas.Add(projectData.DemonstrationExpand.ProjectSignificance);

            fields.Add("ProjectDocument");
            datas.Add(projectData.DemonstrationExpand.ProjectDocument);

            fields.Add("ProjectReferences");
            datas.Add(projectData.DemonstrationExpand.ProjectReferences);

            DataSet AnsDataSet = DBHelper.Query(BuildInseartSQL("ProjectDemonstrationExpand", fields, datas));

        }

        /// <summary>
        /// 插入项目评审拓展信息表
        /// </summary>
        /// <param name="item">插入的对象</param>
        public static void InseartProjectJudgeExpandData(Object item, string PB_ID)
        {
            ProjectData projectData = (ProjectData)item;
            if (projectData.JudgeExpand.IsEmpty())
            {
                return;
            }
            List<string> fields = new List<string>();
            List<string> datas = new List<string>();

            fields.Add("PB_ID");
            datas.Add(PB_ID);

            fields.Add("UnitJudge");
            datas.Add(projectData.JudgeExpand.UnitJudge);

            fields.Add("UnitJudgeDate");
            datas.Add(projectData.JudgeExpand.UnitJudgeDate);

            fields.Add("ExpertJudge");
            datas.Add(projectData.JudgeExpand.ExpertJudge);

            fields.Add("ExpertJudgeDate");
            datas.Add(projectData.JudgeExpand.ExpertJudgeDate);

            fields.Add("ApprovalOpinion");
            datas.Add(projectData.JudgeExpand.ApprovalOpinion);

            fields.Add("ApprovalOpinionDate");
            datas.Add(projectData.JudgeExpand.ApprovalOpinionDate);

            DataSet AnsDataSet = DBHelper.Query(BuildInseartSQL("ProjectJudgeExpand", fields, datas));

        }

        /// <summary>
        /// 插入项目立项拓展信息表
        /// </summary>
        /// <param name="item">插入的对象</param>
        public static void InseartProjectApprovalExpandData(Object item, string PB_ID)
        {
            ProjectData projectData = (ProjectData)item;
            if (projectData.ApprovalExpand.IsEmpty())
            {
                return;
            }
            List<string> fields = new List<string>();
            List<string> datas = new List<string>();

            fields.Add("PB_ID");
            datas.Add(PB_ID);

            fields.Add("ProjectApprovalNum");
            datas.Add(projectData.ApprovalExpand.ProjectApprovalNum);

            DataSet AnsDataSet = DBHelper.Query(BuildInseartSQL("ProjectApprovalExpand", fields, datas));

        }

        /// <summary>
        /// 插入项目结项拓展信息表
        /// </summary>
        /// <param name="item">插入的对象</param>
        public static void InseartProjectFinishExpansionExpandData(Object item, string PB_ID)
        {
            ProjectData projectData = (ProjectData)item;
            if (projectData.FinishExpansion.IsEmpty())
            {
                return;
            }
            List<string> fields = new List<string>();
            List<string> datas = new List<string>();

            fields.Add("PB_ID");
            datas.Add(PB_ID);

            fields.Add("FinishCertificateNum");
            datas.Add(projectData.FinishExpansion.FinishCertificateNum);

            DataSet AnsDataSet = DBHelper.Query(BuildInseartSQL("ProjectFinishExpansion", fields, datas));

        }

        /// <summary>
        /// 插入项目变更信息表
        /// </summary>
        /// <param name="item">插入的对象</param>
        public static void InseartProjectChangeExpansionExpandData(Object item, string PB_ID)
        {
            ProjectData projectData = (ProjectData)item;
            if (projectData.ChangeExpansion.IsEmpty())
            {
                return;
            }
            List<string> fields = new List<string>();
            List<string> datas = new List<string>();

            fields.Add("PB_ID");
            datas.Add(PB_ID);

            fields.Add("ChangeState");
            datas.Add(projectData.ChangeExpansion.ChangeState.ToString());

            fields.Add("ChangeKind");
            datas.Add(projectData.ChangeExpansion.ChangeKind);

            fields.Add("AnotherChangeKind");
            datas.Add(projectData.ChangeExpansion.AnotherChangeKind);

            fields.Add("ChangeDataAndReason");
            datas.Add(projectData.ChangeExpansion.ChangeDataAndReason);

            fields.Add("ApplicationTime");
            datas.Add(projectData.ChangeExpansion.ApplicationTime);

            fields.Add("UnitOpinion");
            datas.Add(projectData.ChangeExpansion.UnitOpinion);

            fields.Add("FinishCertificateNum");
            datas.Add(projectData.ChangeExpansion.ChangeState.ToString());

            fields.Add("FinishCertificateNum");
            datas.Add(projectData.ChangeExpansion.ChangeState.ToString());

            DataSet AnsDataSet = DBHelper.Query(BuildInseartSQL("ProjectChangeExpansion", fields, datas));

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
        private static string BuildDeleteSQL(string tableName, string where)
        {
            return $"DELETE FROM {tableName} WHERE {where}";
        }

        /// <summary>
        /// 删除项目基础数据
        /// </summary>
        /// <param name="ID">项目ID</param>
        /// <returns>影响的条数</returns>
        private static int DeleteProjectBaseData(string ID)
        {
            string sql = BuildDeleteSQL("ProjectBase", $"PB_ID = {ID}");
            return DBHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 删除项目论证拓展信息
        /// </summary>
        /// <param name="ID">项目ID</param>
        /// <returns>影响的条数</returns>
        private static int DeleteProjectDemonstrationExpandData(string ID)
        {
            string sql = BuildDeleteSQL("ProjectDemonstrationExpand", $"PB_ID = {ID}");
            return DBHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 删除项目评审拓展信息
        /// </summary>
        /// <param name="ID">项目ID</param>
        /// <returns>影响的条数</returns>
        private static int DeleteProjectJudgeExpandData(string ID)
        {
            string sql = BuildDeleteSQL("ProjectJudgeExpand", $"PB_ID = {ID}");
            return DBHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 删除项目立项拓展信息
        /// </summary>
        /// <param name="ID">项目ID</param>
        /// <returns>影响的条数</returns>
        private static int DeleteProjectApprovalExpandData(string ID)
        {
            string sql = BuildDeleteSQL("ProjectApprovalExpand", $"PB_ID = {ID}");
            return DBHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 删除项目结项拓展信息
        /// </summary>
        /// <param name="ID">项目ID</param>
        /// <returns>影响的条数</returns>
        private static int DeleteProjectFinishExpansionExpandData(string ID)
        {
            string sql = BuildDeleteSQL("ProjectFinishExpansion", $"PB_ID = {ID}");
            return DBHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 删除项目变更信息
        /// </summary>
        /// <param name="ID">项目ID</param>
        /// <returns>影响的条数</returns>
        private static int DeleteProjectChangeExpansionExpandData(string ID)
        {
            string sql = BuildDeleteSQL("ProjectChangeExpansion", $"PB_ID = {ID}");
            return DBHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 删除完整的项目数据，包括所有相关表的信息
        /// </summary>
        /// <param name="ID">项目ID</param>
        public static int DeleteByID(string ID)
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
                        affectedRows += DeleteProjectChangeExpansionExpandData(ID);
                        affectedRows += DeleteProjectFinishExpansionExpandData(ID);
                        affectedRows += DeleteProjectApprovalExpandData(ID);
                        affectedRows += DeleteProjectJudgeExpandData(ID);
                        affectedRows += DeleteProjectDemonstrationExpandData(ID);
                        affectedRows += DeleteProjectBaseData(ID);
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
        public static int Delete(string Where)
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
                        // 删除 ProjectBase 表中的数据
                        affectedRows += DBHelper.ExecuteSql(BuildDeleteSQL("ProjectBase", Where));

                        // 删除 ProjectDemonstrationExpand 表中的数据
                        affectedRows += DBHelper.ExecuteSql(BuildDeleteSQL("ProjectDemonstrationExpand", Where));

                        // 删除 ProjectJudgeExpand 表中的数据
                        affectedRows += DBHelper.ExecuteSql(BuildDeleteSQL("ProjectJudgeExpand", Where));

                        // 删除 ProjectApprovalExpand 表中的数据
                        affectedRows += DBHelper.ExecuteSql(BuildDeleteSQL("ProjectApprovalExpand", Where));

                        // 删除 ProjectFinishExpansion 表中的数据
                        affectedRows += DBHelper.ExecuteSql(BuildDeleteSQL("ProjectFinishExpansion", Where));

                        // 删除 ProjectChangeExpansion 表中的数据
                        affectedRows += DBHelper.ExecuteSql(BuildDeleteSQL("ProjectChangeExpansion", Where));

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



        #region 更新子功能

        /// <summary>
        /// 构建更新SQL语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="updatePairs">更新字段和值的键值对</param>
        /// <param name="where">更新条件</param>
        /// <returns>更新SQL语句</returns>
        private static string BuildUpdateSQL(string tableName, Dictionary<string, string> updatePairs, string where)
        {
            List<string> setClauses = new List<string>();
            foreach (var pair in updatePairs)
            {
                setClauses.Add($"{pair.Key} = '{pair.Value}'");
            }
            string setClause = string.Join(", ", setClauses);
            return $"UPDATE {tableName} SET {setClause} WHERE {where}";
        }

        /// <summary>
        /// 更新项目基础数据
        /// </summary>
        /// <param name="ID">项目ID</param>
        /// <param name="updatePairs">更新字段和值的键值对</param>
        /// <returns>影响的条数</returns>
        private static int UpdateProjectBaseData(string ID, Dictionary<string, string> updatePairs)
        {
            string sql = BuildUpdateSQL("ProjectBase", updatePairs, $"PB_ID = {ID}");
            return DBHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 更新项目论证拓展信息
        /// </summary>
        /// <param name="ID">项目ID</param>
        /// <param name="updatePairs">更新字段和值的键值对</param>
        /// <returns>影响的条数</returns>
        private static int UpdateProjectDemonstrationExpandData(string ID, Dictionary<string, string> updatePairs)
        {
            string sql = BuildUpdateSQL("ProjectDemonstrationExpand", updatePairs, $"PB_ID = {ID}");
            return DBHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 更新项目评审拓展信息
        /// </summary>
        /// <param name="ID">项目ID</param>
        /// <param name="updatePairs">更新字段和值的键值对</param>
        /// <returns>影响的条数</returns>
        private static int UpdateProjectJudgeExpandData(string ID, Dictionary<string, string> updatePairs)
        {
            string sql = BuildUpdateSQL("ProjectJudgeExpand", updatePairs, $"PB_ID = {ID}");
            return DBHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 更新项目立项拓展信息
        /// </summary>
        /// <param name="ID">项目ID</param>
        /// <param name="updatePairs">更新字段和值的键值对</param>
        /// <returns>影响的条数</returns>
        private static int UpdateProjectApprovalExpandData(string ID, Dictionary<string, string> updatePairs)
        {
            string sql = BuildUpdateSQL("ProjectApprovalExpand", updatePairs, $"PB_ID = {ID}");
            return DBHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 更新项目结项拓展信息
        /// </summary>
        /// <param name="ID">项目ID</param>
        /// <param name="updatePairs">更新字段和值的键值对</param>
        /// <returns>影响的条数</returns>
        private  static int UpdateProjectFinishExpansionExpandData(string ID, Dictionary<string, string> updatePairs)
        {
            string sql = BuildUpdateSQL("ProjectFinishExpansion", updatePairs, $"PB_ID = {ID}");
            return DBHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 更新项目变更信息
        /// </summary>
        /// <param name="ID">项目ID</param>
        /// <param name="updatePairs">更新字段和值的键值对</param>
        /// <returns>影响的条数</returns>
        private static int UpdateProjectChangeExpansionExpandData(string ID, Dictionary<string, string> updatePairs)
        {
            string sql = BuildUpdateSQL("ProjectChangeExpansion", updatePairs, $"PB_ID = {ID}");
            return DBHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 更新完整的项目数据，包括所有相关表的信息
        /// </summary>
        /// <param name="ID">项目ID</param>
        /// <param name="item">包含更新数据的对象</param>
        public static int Update(string ID, Object item)
        {
            ProjectData projectData = (ProjectData)item;
            int affectedRows = 0;

            using (SqlConnection conn = new SqlConnection(DBHelper.connectionString))
            {
                conn.Open();
                // 创建一个事务对象，通过事务操作保证更新的可靠性
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
                                { "DisciplineClassificaton", projectData.Base.DisciplineClassificaton },
                                { "FillDate", projectData.Base.FillDate.ToString() },
                                { "Ending", projectData.Base.Ending.ToString() },
                                { "EndingDate", projectData.Base.EndingDate }
                            };
                            affectedRows += UpdateProjectBaseData(ID, updatePairs);
                        }

                        if (!projectData.DemonstrationExpand.IsEmpty())
                        {
                            Dictionary<string, string> updatePairs = new Dictionary<string, string>
                            {
                                { "ProjectSignificance", projectData.DemonstrationExpand.ProjectSignificance },
                                { "ProjectDocument", projectData.DemonstrationExpand.ProjectDocument },
                                { "ProjectReferences", projectData.DemonstrationExpand.ProjectReferences }
                            };
                            affectedRows += UpdateProjectDemonstrationExpandData(ID, updatePairs);
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
                            affectedRows += UpdateProjectJudgeExpandData(ID, updatePairs);
                        }

                        if (!projectData.ApprovalExpand.IsEmpty())
                        {
                            Dictionary<string, string> updatePairs = new Dictionary<string, string>
                            {
                                { "ProjectApprovalNum", projectData.ApprovalExpand.ProjectApprovalNum }
                            };
                            affectedRows += UpdateProjectApprovalExpandData(ID, updatePairs);
                        }

                        if (!projectData.FinishExpansion.IsEmpty())
                        {
                            Dictionary<string, string> updatePairs = new Dictionary<string, string>
                            {
                                { "FinishCertificateNum", projectData.FinishExpansion.FinishCertificateNum }
                            };
                            affectedRows += UpdateProjectFinishExpansionExpandData(ID, updatePairs);
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
                            affectedRows += UpdateProjectChangeExpansionExpandData(ID, updatePairs);
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

        /// <summary>
        /// 更新符合条件的项目数据
        /// </summary>
        /// <param name="item">包含更新数据的对象</param>
        /// <param name="where">更新条件</param>
        /// <returns>影响的条数</returns>
        public static int Update(Object item, String where)
        {
            ProjectData projectData = (ProjectData)item;
            int affectedRows = 0;

            using (SqlConnection conn = new SqlConnection(DBHelper.connectionString))
            {
                conn.Open();
                // 创建一个事务对象，通过事务操作保证更新的可靠性
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
                                { "DisciplineClassificaton", projectData.Base.DisciplineClassificaton },
                                { "FillDate", projectData.Base.FillDate.ToString() },
                                { "Ending", projectData.Base.Ending.ToString() },
                                { "EndingDate", projectData.Base.EndingDate }
                            };
                            affectedRows += DBHelper.ExecuteSql(BuildUpdateSQL("ProjectBase", updatePairs, where));
                        }

                        if (!projectData.DemonstrationExpand.IsEmpty())
                        {
                            Dictionary<string, string> updatePairs = new Dictionary<string, string>
                            {
                                { "ProjectSignificance", projectData.DemonstrationExpand.ProjectSignificance },
                                { "ProjectDocument", projectData.DemonstrationExpand.ProjectDocument },
                                { "ProjectReferences", projectData.DemonstrationExpand.ProjectReferences }
                            };
                            affectedRows += DBHelper.ExecuteSql(BuildUpdateSQL("ProjectDemonstrationExpand", updatePairs, where));
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
                            affectedRows += DBHelper.ExecuteSql(BuildUpdateSQL("ProjectJudgeExpand", updatePairs, where));
                        }

                        if (!projectData.ApprovalExpand.IsEmpty())
                        {
                            Dictionary<string, string> updatePairs = new Dictionary<string, string>
                            {
                                { "ProjectApprovalNum", projectData.ApprovalExpand.ProjectApprovalNum }
                            };
                            affectedRows += DBHelper.ExecuteSql(BuildUpdateSQL("ProjectApprovalExpand", updatePairs, where));
                        }

                        if (!projectData.FinishExpansion.IsEmpty())
                        {
                            Dictionary<string, string> updatePairs = new Dictionary<string, string>
                            {
                                { "FinishCertificateNum", projectData.FinishExpansion.FinishCertificateNum }
                            };
                            affectedRows += DBHelper.ExecuteSql(BuildUpdateSQL("ProjectFinishExpansion", updatePairs, where));
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
                            affectedRows += DBHelper.ExecuteSql(BuildUpdateSQL("ProjectChangeExpansion", updatePairs, where));
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



    }
}
