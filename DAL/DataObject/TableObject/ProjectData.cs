using DAL.DataObject.TableObject.ProjectApart;

namespace DAL.DataObject.TableObject
{
    /// <summary>
    /// 项目数据
    /// </summary>
    public class ProjectData : DataObjectBase
    {
        public override bool IsEmpty()
        {
            // 基础数据为空，项目数据即为空，因为基础数据不可省略
            if (Base.IsEmpty()) return true;
            return false;
        }

        #region 属性及字段

        ProjectBase _Base;
        /// <summary>
        /// 项目基础信息
        /// </summary>
        public ProjectBase Base
        {
            get
            {
                if (_Base == null) return _Base = new ProjectBase();
                return _Base;
            }
            set
            {
                _Base = value;
            }
        }

        ProjectDemonstrationExpand _DemonstrationExpand;
        /// <summary>
        /// 项目论证拓展信息
        /// </summary>
        public ProjectDemonstrationExpand DemonstrationExpand
        {
            get
            {
                if (_DemonstrationExpand == null) _DemonstrationExpand = new ProjectDemonstrationExpand();
                return _DemonstrationExpand;
            }
            set
            {
                _DemonstrationExpand = value;
            }
        }

        ProjectJudgeExpand _JudgeExpand;
        /// <summary>
        /// 项目评审拓展信息
        /// </summary>
        public ProjectJudgeExpand JudgeExpand
        {
            get
            {
                if (_JudgeExpand == null) _JudgeExpand = new ProjectJudgeExpand();
                return _JudgeExpand;
            }
            set
            {
                _JudgeExpand = value;
            }
        }

        ProjectApprovalExpand _ApprovalExpand;
        /// <summary>
        /// 项目立项拓展信息
        /// </summary>
        public ProjectApprovalExpand ApprovalExpand
        {
            get
            {
                if (_ApprovalExpand == null) _ApprovalExpand = new ProjectApprovalExpand();
                return _ApprovalExpand;
            }
            set
            {
                _ApprovalExpand = value;
            }
        }

        ProjectFinishExpansion _FinishExpansion;
        /// <summary>
        /// 项目结项拓展信息
        /// </summary>
        public ProjectFinishExpansion FinishExpansion
        {
            get
            {
                if (_FinishExpansion == null) _FinishExpansion = new ProjectFinishExpansion();
                return _FinishExpansion;
            }
            set
            {
                _FinishExpansion = value;
            }
        }

        ProjectChangeExpansion _ChangeExpansion;
        /// <summary>
        /// 项目变更信息
        /// </summary>
        public ProjectChangeExpansion ChangeExpansion
        {
            get
            {
                if (_ChangeExpansion == null) _ChangeExpansion = new ProjectChangeExpansion();
                return _ChangeExpansion;
            }
            set
            {
                _ChangeExpansion = value;
            }
        }

        #endregion

    }
}
