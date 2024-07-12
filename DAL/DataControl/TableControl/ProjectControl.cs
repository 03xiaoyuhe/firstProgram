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
        /// 构建 SQL 查询语句，查询项目信息及其拓展信息
        /// </summary>
        /// <param name="OutTable">输出表名，可选</param>
        /// <param name="where">WHERE 条件，默认查询所有项目信息</param>
        /// <returns>构建好的 SQL 查询语句</returns>
        private string BuildSelectSQL(string OutTable = "", string where = "1=1")
        {
            string SQL =
                "-- 查询项目信息及其拓展信息                          \n" +
                "SELECT                                             \n" +
                "    PB.ProjectState,                              \n" +
                "    PB.ProjectName,                               \n" +
                "    PB.ProjectCategory,                           \n" +
                "    PB.DisciplineClassificaton,                   \n" +
                "    PB.FillDate,                                  \n" +
                "    PB.Ending,                                    \n" +
                "    PB.EndingDate,                                \n" +
                "    PDE.ProjectSignificance,                      \n" +
                "    PDE.ProjectDocument,                          \n" +
                "    PDE.ProjectReferences,                        \n" +
                "    PJ.UnitJudge,                                 \n" +
                "    PJ.UnitJudgeDate,                             \n" +
                "    PJ.ExpertJudge,                               \n" +
                "    PJ.ExpertJudgeDate,                           \n" +
                "    PJ.ApprovalOpinion,                           \n" +
                "    PJ.ApprovalOpinionDate,                       \n" +
                "    PA.ProjectApprovalNum,                        \n" +
                "    PF.FinishCertificateNum,                      \n" +
                "    PC.ChangeState,                               \n" +
                "    PC.ChangeKind,                                \n" +
                "    PC.AnotherChangeKind,                         \n" +
                "    PC.ChangeDataAndReason,                       \n" +
                "    PC.ApplicationTime,                           \n" +
                "    PC.UnitOpinion                                \n" +
                "FROM                                               \n" +
                "    ProjectBase PB                                  \n" +
                "LEFT JOIN ProjectDemonstrationExpand PDE            \n" +
                "    ON PB.PB_ID = PDE.PB_ID                        \n" +
                "LEFT JOIN ProjectJudgeExpand PJ                    \n" +
                "    ON PB.PB_ID = PJ.PB_ID                         \n" +
                "LEFT JOIN ProjectApprovalExpand PA                 \n" +
                "    ON PB.PB_ID = PA.PB_ID                         \n" +
                "LEFT JOIN ProjectFinishExpansion PF                \n" +
                "    ON PB.PB_ID = PF.PB_ID                         \n" +
                "LEFT JOIN ProjectChangeExpansion PC                \n" +
                "    ON PB.PB_ID = PC.PB_ID                         \n" +
                "WHERE " + where + ";                               \n";

            if (!string.IsNullOrEmpty(OutTable))
            {
                SQL = $"SELECT * INTO {OutTable} FROM ({SQL}) AS ProjectData;";
            }

            return SQL;
        }

        /// <summary>
        /// 执行查询，并返回 DataSet 对象
        /// </summary>
        /// <param name="whereString">WHERE 条件，默认查询所有项目信息</param>
        /// <returns>包含查询结果的 DataSet 对象</returns>
        public DataSet Select(string whereString = "1=1")
        {
            return DBHelper.Query(BuildSelectSQL("", whereString));
        }

        /// <summary>
        /// 执行查询，并将结果保存到指定表中
        /// </summary>
        /// <param name="OutTable">保存查询结果的表名</param>
        /// <param name="whereString">WHERE 条件，默认查询所有项目信息</param>
        public void Select(string OutTable, string whereString = "1=1")
        {
            DBHelper.ExecuteSql(BuildSelectSQL(OutTable, whereString));
        }

        #endregion

        #region 插入功能
        private string BuildInseartSQL(string TableName, List<string> Fields, List<string> Datas)
        {
            string FieldsString = string.Join(", ", Fields);
            string DatesString = string.Join(", ", Datas.Select(data => $"'{data}'"));

            string SQL =
               $"INSERT INTO [{TableName}] ({FieldsString})          \r\n" +
                "OUTPUT inserted.PB_ID as id -- 返回插入数据的ID  \r\n" +
               $"VALUES({DatesString});                           ";
            return SQL;
        }


        public void Inseart(Object item)
        {
            InseartReturnID(item);
        }

        public string InseartReturnID(Object item)
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
        public string InseartProjectBaseData(Object item)
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
        public void InseartProjectDemonstrationExpandData(Object item, string PB_ID)
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
        public void InseartProjectJudgeExpandData(Object item, string PB_ID)
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
        public void InseartProjectApprovalExpandData(Object item, string PB_ID)
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
        public void InseartProjectFinishExpansionExpandData(Object item, string PB_ID)
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
        public void InseartProjectChangeExpansionExpandData(Object item, string PB_ID)
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
            datas.Add(projectData.ChangeExpansion.ApplicationTime.ToString("yyyy-MM-dd"));

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
        private string BuildDeleteSQL(string tableName, string where)
        {
            return $"DELETE FROM {tableName} WHERE {where}";
        }

        /// <summary>
        /// 删除项目基础数据
        /// </summary>
        /// <param name="ID">项目ID</param>
        /// <returns>影响的条数</returns>
        private int DeleteProjectBaseData(string ID)
        {
            string sql = BuildDeleteSQL("ProjectBase", $"PB_ID = {ID}");
            return DBHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 删除项目论证拓展信息
        /// </summary>
        /// <param name="ID">项目ID</param>
        /// <returns>影响的条数</returns>
        private int DeleteProjectDemonstrationExpandData(string ID)
        {
            string sql = BuildDeleteSQL("ProjectDemonstrationExpand", $"PB_ID = {ID}");
            return DBHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 删除项目评审拓展信息
        /// </summary>
        /// <param name="ID">项目ID</param>
        /// <returns>影响的条数</returns>
        private int DeleteProjectJudgeExpandData(string ID)
        {
            string sql = BuildDeleteSQL("ProjectJudgeExpand", $"PB_ID = {ID}");
            return DBHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 删除项目立项拓展信息
        /// </summary>
        /// <param name="ID">项目ID</param>
        /// <returns>影响的条数</returns>
        private int DeleteProjectApprovalExpandData(string ID)
        {
            string sql = BuildDeleteSQL("ProjectApprovalExpand", $"PB_ID = {ID}");
            return DBHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 删除项目结项拓展信息
        /// </summary>
        /// <param name="ID">项目ID</param>
        /// <returns>影响的条数</returns>
        private int DeleteProjectFinishExpansionExpandData(string ID)
        {
            string sql = BuildDeleteSQL("ProjectFinishExpansion", $"PB_ID = {ID}");
            return DBHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 删除项目变更信息
        /// </summary>
        /// <param name="ID">项目ID</param>
        /// <returns>影响的条数</returns>
        private int DeleteProjectChangeExpansionExpandData(string ID)
        {
            string sql = BuildDeleteSQL("ProjectChangeExpansion", $"PB_ID = {ID}");
            return DBHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 删除完整的项目数据，包括所有相关表的信息
        /// </summary>
        /// <param name="ID">项目ID</param>
        public int DeleteByID(string ID)
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
        public int Delete(string Where)
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
        private string BuildUpdateSQL(string tableName, Dictionary<string, string> updatePairs, string where)
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
        private int UpdateProjectBaseData(string ID, Dictionary<string, string> updatePairs)
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
        private int UpdateProjectDemonstrationExpandData(string ID, Dictionary<string, string> updatePairs)
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
        private int UpdateProjectJudgeExpandData(string ID, Dictionary<string, string> updatePairs)
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
        private int UpdateProjectApprovalExpandData(string ID, Dictionary<string, string> updatePairs)
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
        private int UpdateProjectFinishExpansionExpandData(string ID, Dictionary<string, string> updatePairs)
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
        private int UpdateProjectChangeExpansionExpandData(string ID, Dictionary<string, string> updatePairs)
        {
            string sql = BuildUpdateSQL("ProjectChangeExpansion", updatePairs, $"PB_ID = {ID}");
            return DBHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 更新完整的项目数据，包括所有相关表的信息
        /// </summary>
        /// <param name="ID">项目ID</param>
        /// <param name="item">包含更新数据的对象</param>
        public int Update(string ID, Object item)
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
                                { "ApplicationTime", projectData.ChangeExpansion.ApplicationTime.ToString("yyyy-MM-dd") },
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
        public int Update(Object item, String where)
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
                                { "ApplicationTime", projectData.ChangeExpansion.ApplicationTime.ToString("yyyy-MM-dd") },
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
