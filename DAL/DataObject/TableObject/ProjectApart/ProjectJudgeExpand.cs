namespace DAL.DataObject.TableObject.ProjectApart
{
    public class ProjectJudgeExpand : DataObjectBase
    {

        public override bool IsEmpty()
        {
            if (
                PJ_ID == 0 &&
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

        int pJ_ID;
        /// <summary>
        /// 数据ID
        /// </summary>
        public int PJ_ID
        {
            get
            {
                return pJ_ID;
            }
            set
            {
                pJ_ID = value;
            }
        }

        int pB_ID;
        /// <summary>
        /// 项目ID
        /// </summary>
        public int PB_ID
        {
            get
            {
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
                if (unitJudge == null) unitJudge = string.Empty;
                return unitJudge;
            }
            set
            {
                value = unitJudge;
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
