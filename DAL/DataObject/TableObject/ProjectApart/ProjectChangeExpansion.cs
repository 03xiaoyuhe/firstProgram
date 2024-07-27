using System;
using System.Collections.Generic;

namespace DAL.DataObject.TableObject.ProjectApart
{
    public class ProjectChangeExpansion : DataObjectBase
    {
        public override bool IsEmpty()
        {
            if (
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
            else return false;
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

        int changeState;
        /// <summary>
        /// 变更状态
        /// </summary>
        public int ChangeState
        {
            get
            {
                if (State == DataObjectState.PraiseDateTableToData)
                {
                    Object Data = DataTableHelper.GetRowColumnValue(DataTable, RowIndex, "ChangeState");
                    if (Data != null)
                    {
                        return int.Parse(Data.ToString());
                    }
                    else return 0;
                }
                return changeState;
            }
            set
            {
                changeState = value;
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
                if (State == DataObjectState.PraiseDateTableToData)
                {
                    Object Data = DataTableHelper.GetRowColumnValue(DataTable, RowIndex, "ChangeKind");
                    if (Data != null)
                    {
                        return Data.ToString();
                    }
                    else return String.Empty;
                }
                if (changeKind == null) changeKind = string.Empty;
                return changeKind;
            }
            set
            {
                changeKind = value;
            }
        }

        string anotherChangeKind;
        /// <summary>
        /// 其他变更内容
        /// </summary>
        public string AnotherChangeKind
        {
            get
            {
                if (State == DataObjectState.PraiseDateTableToData)
                {
                    Object Data = DataTableHelper.GetRowColumnValue(DataTable, RowIndex, "AnotherChangeKind");
                    if (Data != null)
                    {
                        return Data.ToString();
                    }
                    else return String.Empty;
                }
                if (anotherChangeKind == null) anotherChangeKind = string.Empty;
                return anotherChangeKind;
            }
            set
            {
                anotherChangeKind = value;
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
                if (State == DataObjectState.PraiseDateTableToData)
                {
                    Object Data = DataTableHelper.GetRowColumnValue(DataTable, RowIndex, "ChangeDataAndReason");
                    if (Data != null)
                    {
                        return Data.ToString();
                    }
                    else return String.Empty;
                }
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
                if (State == DataObjectState.PraiseDateTableToData)
                {
                    Object Data = DataTableHelper.GetRowColumnValue(DataTable, RowIndex, "ApplicationTime");
                    if (Data != null)
                    {
                        return Data.ToString();
                    }
                    else return String.Empty;
                }
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
                if (State == DataObjectState.PraiseDateTableToData)
                {
                    Object Data = DataTableHelper.GetRowColumnValue(DataTable, RowIndex, "UnitOpinion");
                    if (Data != null)
                    {
                        return Data.ToString();
                    }
                    else return String.Empty;
                }
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
