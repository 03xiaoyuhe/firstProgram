using DAL.DataControl.Interface;
using DAL.DataObject.TableObject;
using DAL.DataObject.TableObject.ProjectApart;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataControl.ViewControl
{
    public class ProjectViewContron : DataBaseControl, IDataSelect
    {
        /// <summary>
        /// 构建SQL查询语句
        /// </summary>
        /// <param name="fields">指定查询出的字段</param>
        /// <param name="whereString">在SQL中 WHERE 部分需要填入的部分</param>
        /// <param name="orderByField">排序字段</param>
        /// <param name="isAscending">是否升序排序</param>
        /// <param name="pageSize">每页显示的记录数</param>
        /// <param name="pageNumber">当前页索引</param>
        /// <returns>返回SQL查询语句</returns>
        private string BuildSelectSQL(List<string> fields, string whereString, string groupBy, string orderByField, bool isAscending, int? pageSize, int? pageNumber)
        {
            // 如果没有指定字段，则查询所有字段
            string fieldString = fields != null && fields.Count > 0 ? string.Join(", ", fields) : "*";
            string sortOrder = isAscending ? "ASC" : "DESC";

            if (whereString == null) whereString = "1 = 1";
            string orderByString = (orderByField == null ? "" : $"ORDER BY {orderByField} {sortOrder}");
            if (orderByField == null)
            {
                orderByField = "PB_ID";
            }
            string groupString = (groupBy == null ? "" : $"group by {groupBy}");
            // 构建SQL查询语句
            string sql = $"SELECT {fieldString} FROM ProjectInfoView WHERE {whereString} {groupString} {orderByString}";

            // 添加分页逻辑（如果提供了分页参数）
            if (pageSize.HasValue && pageNumber.HasValue)
            {
                int offset = (pageNumber.Value - 1) * pageSize.Value;
                sql += $" OFFSET {offset} ROWS FETCH NEXT {pageSize.Value} ROWS ONLY";
            }

            return sql;
        }

        /// <summary>
        /// 通过指定规则执行查询，并返回查询的数据
        /// </summary>
        /// <param name="whereString">在SQL中 WHERE 部分需要填入的部分</param>
        /// <param name="orderByField">排序字段</param>
        /// <param name="isAscending">是否升序排序</param>
        /// <param name="pageSize">每页显示的记录数</param>
        /// <param name="pageNumber">当前页索引</param>
        /// <returns>返回查询出的所有数据</returns>
        public DataSet Select(string whereString, string groupBy, string orderByField = null, bool isAscending = true, int? pageSize = null, int? pageNumber = null)
        {
            return Select(null, whereString, groupBy, orderByField, isAscending, pageSize, pageNumber);
        }

        /// <summary>
        /// 通过指定规则执行查询，并返回查询的数据
        /// </summary>
        /// <param name="fields">指定查询出的字段</param>
        /// <param name="whereString">在SQL中 WHERE 部分需要填入的部分</param>
        /// <param name="orderByField">排序字段</param>
        /// <param name="isAscending">是否升序排序</param>
        /// <param name="pageSize">每页显示的记录数</param>
        /// <param name="pageNumber">当前页索引</param>
        /// <returns>返回查询出的所有数据</returns>
        public DataSet Select(List<string> fields, string whereString, string groupBy, string orderByField = null, bool isAscending = true, int? pageSize = null, int? pageNumber = null)
        {
            if (string.IsNullOrEmpty(whereString))
            {
                whereString = "1 = 1"; // 默认条件，表示查询所有数据
            }

            string SQL = BuildSelectSQL(fields, whereString, groupBy, orderByField, isAscending, pageSize, pageNumber);
            return DBHelper.Query(SQL);
        }

        /// <summary>
        /// 通过指定规则执行查询，并返回查询的数据类对象
        /// </summary>
        /// <param name="whereString">在SQL中 WHERE 部分需要填入的部分</param>
        /// <returns>对应数据的数据类对象</returns>
        public object SelectReturnObject(string whereString)
        {
            string SQL = BuildSelectSQL(null, whereString, null, "PB_ID", true, 1, 1); // 获取单个对象

            using (SqlConnection connection = new SqlConnection(DBHelper.connectionString))
            {
                SqlCommand command = new SqlCommand(SQL, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                ProjectData projectData = new ProjectData();

                if (reader.Read())
                {
                    // 映射基础表字段
                    if (!reader.IsDBNull(reader.GetOrdinal("PB_ID"))) projectData.Base.PB_ID = reader.GetInt32(reader.GetOrdinal("PB_ID"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ProjectState"))) projectData.Base.ProjectState = reader.GetInt32(reader.GetOrdinal("ProjectState"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ProjectName"))) projectData.Base.ProjectName = reader.GetString(reader.GetOrdinal("ProjectName"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ProjectCategory"))) projectData.Base.ProjectCategory = reader.GetString(reader.GetOrdinal("ProjectCategory"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DisciplineClassificaton"))) projectData.Base.DisciplineClassification = reader.GetString(reader.GetOrdinal("DisciplineClassificaton"));
                    if (!reader.IsDBNull(reader.GetOrdinal("FillDate"))) projectData.Base.FillDate = reader.IsDBNull(reader.GetOrdinal("FillDate")) ? String.Empty : reader.GetDateTime(reader.GetOrdinal("FillDate")).ToString("yyyy-MM-dd");
                    if (!reader.IsDBNull(reader.GetOrdinal("EndingDate"))) projectData.Base.EndingDate = reader.IsDBNull(reader.GetOrdinal("EndingDate")) ? String.Empty : reader.GetDateTime(reader.GetOrdinal("EndingDate")).ToString("yyyy-MM-dd");
                    if (!reader.IsDBNull(reader.GetOrdinal("Ending"))) projectData.Base.Ending = reader.GetString(reader.GetOrdinal("Ending"));
                    // 映射拓展表字段
                    if (!reader.IsDBNull(reader.GetOrdinal("ProjectSignificance"))) projectData.DemonstrationExpand.ProjectSignificance = reader.GetString(reader.GetOrdinal("ProjectSignificance"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ProjectDocument"))) projectData.DemonstrationExpand.ProjectDocument = reader.GetString(reader.GetOrdinal("ProjectDocument"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ProjectReferences"))) projectData.DemonstrationExpand.ProjectReferences = reader.GetString(reader.GetOrdinal("ProjectReferences"));

                    if (!reader.IsDBNull(reader.GetOrdinal("UnitJudge"))) projectData.JudgeExpand.UnitJudge = reader.GetString(reader.GetOrdinal("UnitJudge"));
                    if (!reader.IsDBNull(reader.GetOrdinal("UnitJudgeDate"))) projectData.JudgeExpand.UnitJudgeDate = reader.IsDBNull(reader.GetOrdinal("UnitJudgeDate")) ? String.Empty : reader.GetDateTime(reader.GetOrdinal("UnitJudgeDate")).ToString("yyyy-MM-dd");
                    if (!reader.IsDBNull(reader.GetOrdinal("ExpertJudge"))) projectData.JudgeExpand.ExpertJudge = reader.GetString(reader.GetOrdinal("ExpertJudge"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ExpertJudgeDate"))) projectData.JudgeExpand.ExpertJudgeDate = reader.IsDBNull(reader.GetOrdinal("ExpertJudgeDate")) ? String.Empty : reader.GetDateTime(reader.GetOrdinal("ExpertJudgeDate")).ToString("yyyy-MM-dd");
                    if (!reader.IsDBNull(reader.GetOrdinal("ApprovalOpinion"))) projectData.JudgeExpand.ApprovalOpinion = reader.GetString(reader.GetOrdinal("ApprovalOpinion"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ApprovalOpinionDate"))) projectData.JudgeExpand.ApprovalOpinionDate = reader.IsDBNull(reader.GetOrdinal("ApprovalOpinionDate")) ? String.Empty : reader.GetDateTime(reader.GetOrdinal("ApprovalOpinionDate")).ToString("yyyy-MM-dd");

                    if (!reader.IsDBNull(reader.GetOrdinal("ProjectApprovalNum"))) projectData.ApprovalExpand.ProjectApprovalNum = reader.GetString(reader.GetOrdinal("ProjectApprovalNum"));

                    if (!reader.IsDBNull(reader.GetOrdinal("FinishCertificateNum"))) projectData.FinishExpansion.FinishCertificateNum = reader.GetString(reader.GetOrdinal("FinishCertificateNum"));

                    if (!reader.IsDBNull(reader.GetOrdinal("ChangeState"))) projectData.ChangeExpansion.ChangeState = int.Parse(reader.GetString(reader.GetOrdinal("ChangeState")));
                    if (!reader.IsDBNull(reader.GetOrdinal("ChangeKind"))) projectData.ChangeExpansion.ChangeKind = reader.GetString(reader.GetOrdinal("ChangeKind"));
                    if (!reader.IsDBNull(reader.GetOrdinal("AnotherChangeKind"))) projectData.ChangeExpansion.AnotherChangeKind = reader.GetString(reader.GetOrdinal("AnotherChangeKind"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ChangeDataAndReason"))) projectData.ChangeExpansion.ChangeDataAndReason = reader.GetString(reader.GetOrdinal("ChangeDataAndReason"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ApplicationTime"))) projectData.ChangeExpansion.ApplicationTime = reader.IsDBNull(reader.GetOrdinal("ApplicationTime")) ? String.Empty : reader.GetDateTime(reader.GetOrdinal("ApplicationTime")).ToString("yyyy-MM-dd");
                    if (!reader.IsDBNull(reader.GetOrdinal("UnitOpinion"))) projectData.ChangeExpansion.UnitOpinion = reader.GetString(reader.GetOrdinal("UnitOpinion"));
                }

                return projectData;
            }

        }
    }
}
