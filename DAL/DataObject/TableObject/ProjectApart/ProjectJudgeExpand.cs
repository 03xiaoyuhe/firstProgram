using System;
using System.Collections.Generic;

namespace DAL.DataObject.TableObject.ProjectApart
{
    public class ProjectJudgeExpand : DataObjectBase
    {

        public override bool IsEmpty()
        {
            if (
                PB_ID == 0 &&
                UnitJudge == string.Empty &&
                UnitJudgeDate == string.Empty &&
                ExpertJudge == string.Empty &&
                ExpertJudgeDate == string.Empty &&
                ApprovalOpinion == string.Empty &&
                ApprovalOpinionDate == string.Empty
               )
            {
                return true;
            }
            return false;
        }

        #region 属性及字段

        int pB_ID;
        /// <summary>
        /// 项目ID
        /// </summary>
        public int PB_ID
        {
            get
            {
                if (State == DataObjectState.PraiseDateTableToData)
                {
                    Object Data = DataTableHelper.GetRowColumnValue(DataTable, RowIndex, "PB_ID");
                    if (Data != null)
                    {
                        return int.Parse(Data.ToString());
                    }
                    else return 0;
                }
                return pB_ID;
            }
            set
            {
                pB_ID = value;
            }
        }

        string unitJudge;
        /// <summary>
        /// 所在单位评审意见
        /// </summary>
        public string UnitJudge
        {
            get
            {
                if (State == DataObjectState.PraiseDateTableToData)
                {
                    Object Data = DataTableHelper.GetRowColumnValue(DataTable, RowIndex, "UnitJudge");
                    if (Data != null)
                    {
                        return Data.ToString();
                    }
                    else return String.Empty;
                }
                if (unitJudge == null) unitJudge = string.Empty;
                return unitJudge;
            }
            set
            {
                unitJudge = value;
            }
        }

        string unitJudgeDate;
        /// <summary>
        /// 所在单位评审意见时间
        /// </summary>
        public string UnitJudgeDate
        {
            get
            {
                if (State == DataObjectState.PraiseDateTableToData)
                {
                    Object Data = DataTableHelper.GetRowColumnValue(DataTable, RowIndex, "UnitJudgeDate");
                    if (Data != null)
                    {
                        return Data.ToString();
                    }
                    else return String.Empty;
                }
                if (unitJudgeDate == null) unitJudgeDate = string.Empty;
                return unitJudgeDate;
            }
            set
            {
                unitJudgeDate = value;
            }
        }

        string expertJudge;
        /// <summary>
        /// 专家组评审意见
        /// </summary>
        public string ExpertJudge
        {
            get
            {
                if (State == DataObjectState.PraiseDateTableToData)
                {
                    Object Data = DataTableHelper.GetRowColumnValue(DataTable, RowIndex, "ExpertJudge");
                    if (Data != null)
                    {
                        return Data.ToString();
                    }
                    else return String.Empty;
                }
                if (expertJudge == null) expertJudge = string.Empty;
                return expertJudge;
            }
            set
            {
                expertJudge = value;
            }
        }

        string expertJudgeDate;
        /// <summary>
        /// 专家组评审意见时间
        /// </summary>
        public string ExpertJudgeDate
        {
            get
            {
                if (State == DataObjectState.PraiseDateTableToData)
                {
                    Object Data = DataTableHelper.GetRowColumnValue(DataTable, RowIndex, "ExpertJudgeDate");
                    if (Data != null)
                    {
                        return Data.ToString();
                    }
                    else return String.Empty;
                }
                if (expertJudgeDate == null) expertJudgeDate = string.Empty;
                return expertJudgeDate;
            }
            set
            {
                expertJudgeDate = value;
            }
        }

        string approvalOpinion;
        /// <summary>
        /// 审批意见
        /// </summary>
        public string ApprovalOpinion
        {
            get
            {
                if (State == DataObjectState.PraiseDateTableToData)
                {
                    Object Data = DataTableHelper.GetRowColumnValue(DataTable, RowIndex, "ApprovalOpinion");
                    if (Data != null)
                    {
                        return Data.ToString();
                    }
                    else return String.Empty;
                }
                if (approvalOpinion == null) approvalOpinion = string.Empty;
                return approvalOpinion;
            }
            set
            {
                approvalOpinion = value;
            }
        }

        string approvalOpinionDate;
        /// <summary>
        /// 审批意见时间
        /// </summary>
        public string ApprovalOpinionDate
        {
            get
            {
                if (State == DataObjectState.PraiseDateTableToData)
                {
                    Object Data = DataTableHelper.GetRowColumnValue(DataTable, RowIndex, "ApprovalOpinionDate");
                    if (Data != null)
                    {
                        return Data.ToString();
                    }
                    else return String.Empty;
                }
                if (approvalOpinionDate == null) approvalOpinionDate = string.Empty;
                return approvalOpinionDate;
            }
            set
            {
                approvalOpinionDate = value;
            }
        }

        #endregion
    }
}
