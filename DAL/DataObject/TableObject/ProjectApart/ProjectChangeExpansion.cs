using System;
using System.Collections.Generic;

namespace DAL.DataObject.TableObject.ProjectApart
{
    public class ProjectChangeExpansion : DataObjectBase
    {
        public override bool IsEmpty()
        {
            if (
                //PC_ID == 0 &&
                PB_ID == 0 &&
                ChangeState == 0 &&
                ChangeKind == string.Empty &&
                AnotherChangeKind == string.Empty &&
                ChangeDataAndReason == string.Empty &&
                ApplicationTime == string.Empty &&
                UnitOpinion == string.Empty
                )
            {
                return true;
            }
            return false;
        }

        #region 属性及字段

        //int pC_ID;
        ///// <summary>
        ///// 信息ID
        ///// </summary>
        //public int PC_ID
        //{
        //    get
        //    {
        //        return this.pC_ID;
        //    }
        //    set
        //    {
        //        this.pC_ID = value;
        //    }
        //}

        int pB_ID;
        /// <summary>
        /// 项目ID
        /// </summary>
        public int PB_ID
        {
            get
            {
                return this.pB_ID;
            }
            set
            {
                this.pB_ID = value;
            }
        }

        int changeState;
        /// <summary>
        /// 变更状态
        /// </summary>
        public int ChangeState
        {
            get
            {
                return this.changeState;
            }
            set
            {
                this.changeState = value;
            }
        }

        string changeKind;
        /// <summary>
        /// 变更内容
        /// </summary>
        public string ChangeKind
        {
            get
            {
                return this.changeKind;
            }
            set { this.changeKind = value; }
        }

        string anotherChangeKind;
        /// <summary>
        /// 其他变更内容
        /// </summary>
        public string AnotherChangeKind
        {
            get
            {
                if (anotherChangeKind == null) anotherChangeKind = string.Empty;
                return this.anotherChangeKind;
            }
            set
            {
                this.anotherChangeKind = value;
            }
        }

        string changeDataAndReason;
        /// <summary>
        /// 变更内容及原因
        /// </summary>
        public string ChangeDataAndReason
        {
            get
            {
                if (changeDataAndReason == null) changeDataAndReason = string.Empty;
                return changeDataAndReason;
            }
            set
            {
                changeDataAndReason = value;
            }
        }

        string applicationTime;
        /// <summary>
        /// 申请时间
        /// </summary>
        public string ApplicationTime
        {
            get
            {
                if (applicationTime == null) applicationTime = string.Empty;
                return applicationTime;
            }
            set
            {
                applicationTime = value;
            }
        }

        string unitOpinion;
        /// <summary>
        /// 立项单位科研管理部门意见
        /// </summary>
        public string UnitOpinion
        {
            get
            {
                if (unitOpinion == null) unitOpinion = string.Empty;
                return unitOpinion;
            }
            set
            {
                unitOpinion = value;
            }
        }

        #endregion

        #region 数据项含义翻译

        /// <summary>
        /// 项目状态，数字转换为其含义
        /// </summary>
        static public Dictionary<int, string> ChangeStateIntToMean = new Dictionary<int, string>()
        {
            {0, "" },
            {1,"申请变更" },
            {2,"变更成功" },
        };

        ///// <summary>
        ///// 项目状态，数字转换为其含义
        ///// </summary>
        //static public Dictionary<int, string> ChangeKindIntToMean = new Dictionary<int, string>()
        //{
        //    {0, "" },
        //    {1,"其他" },
        //    {2,"改变项目名称" },
        //    {3,"改变最终成果形式" },
        //    {4,"项目有重大调整" },
        //    {5,"变更项目管理单位" },
        //    {6,"申请延期" },
        //    {7,"终止项目" },
        //    {8,"撤销项目" },
        //};

        #endregion 

    }
}
