using System;
using System.Collections.Generic;

namespace DAL.DataObject.TableObject.ProjectApart
{
    public class ProjectBase : DataObjectBase
    {
        public override bool IsEmpty()
        {
            if (
                //PB_ID == 0 &&
                ProjectState == 0 &&
                ProjectName == string.Empty &&
                ProjectCategory == string.Empty &&
                DisciplineClassification == string.Empty &&
                FillDate == String.Empty &&
                Ending == string.Empty &&
                EndingDate == string.Empty
                )
            {
                return true;
            }
            else return false;
        }

        #region 属性及字段




        // 查询数据时有效
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

        int projectState;
        /// <summary>
        /// 项目状态
        /// </summary>
        public int ProjectState
        {
            get
            {
                if (State == DataObjectState.PraiseDateTableToData)
                {
                    Object Data = DataTableHelper.GetRowColumnValue(DataTable, RowIndex, "ProjectState");
                    if (Data != null)
                    {
                        return ProjectStateMeanToInt[Data.ToString()];
                    }
                    else return 0;
                }
                return projectState;
            }
            set
            {
                projectState = value;
            }
        }

        string projectName;
        /// <summary>
        /// 课题名称
        /// </summary>
        public string ProjectName
        {
            get
            {
                if (State == DataObjectState.PraiseDateTableToData)
                {
                    Object Data = DataTableHelper.GetRowColumnValue(DataTable, RowIndex, "ProjectName");
                    if ( Data != null )
                    {
                        return Data.ToString();
                    }
                    else return String.Empty;
                }
                if (projectName == null) projectName = string.Empty;
                return projectName;
            }
            set
            {
                projectName = value;
            }
        }

        string projectCategory;
        /// <summary>
        /// 项目类别
        /// </summary>
        public string ProjectCategory
        {
            get
            {
                if (State == DataObjectState.PraiseDateTableToData)
                {
                    Object Data = DataTableHelper.GetRowColumnValue(DataTable, RowIndex, "ProjectCategory");
                    if (Data != null)
                    {
                        return Data.ToString();
                    }
                    else return String.Empty;
                }
                if (projectCategory == null) projectCategory = string.Empty;
                return projectCategory;
            }
            set
            {
                projectCategory = value;
            }
        }

        string disciplineClassification;
        /// <summary>
        /// 学科分类
        /// </summary>
        public string DisciplineClassification
        {
            get
            {
                if (State == DataObjectState.PraiseDateTableToData)
                {
                    Object Data = DataTableHelper.GetRowColumnValue(DataTable, RowIndex, "DisciplineClassificaton");
                    if (Data != null)
                    {
                        return Data.ToString();
                    }
                    else return String.Empty;
                }
                if (disciplineClassification == null) disciplineClassification = string.Empty;
                return disciplineClassification;
            }
            set
            {
                disciplineClassification = value;
            }
        }

        string fillDate;
        /// <summary>
        /// 填表日期
        /// </summary>
        public string FillDate
        {
            get
            {
                if (State == DataObjectState.PraiseDateTableToData)
                {
                    Object Data = DataTableHelper.GetRowColumnValue(DataTable, RowIndex, "FillDate");
                    if (Data != null)
                    {
                        return Data.ToString();
                    }
                    else return String.Empty;
                }
                if (fillDate == null) fillDate = String.Empty;
                return fillDate;
            }
            set
            {
                fillDate = value;
            }
        }

        string ending;
        /// <summary>
        /// 最后成果形式
        /// </summary>
        public string Ending
        {
            get
            {
                if (State == DataObjectState.PraiseDateTableToData)
                {
                    Object Data = DataTableHelper.GetRowColumnValue(DataTable, RowIndex, "Ending");
                    if (Data != null)
                    {
                        return Data.ToString();
                    }
                    else return String.Empty;
                }
                return ending;
            }
            set
            {
                ending = value;
            }
        }

        string endingDate;
        /// <summary>
        /// 项目完成时间
        /// </summary>
        public string EndingDate
        {
            get
            {
                if (State == DataObjectState.PraiseDateTableToData)
                {
                    Object Data = DataTableHelper.GetRowColumnValue(DataTable, RowIndex, "EndingDate");
                    if (Data != null)
                    {
                        return Data.ToString();
                    }
                    else return String.Empty;
                }
                if (endingDate == null) endingDate = string.Empty;
                return endingDate;
            }
            set
            {
                endingDate = value;
            }
        }

        #endregion


        #region 数据项含义翻译

        /// <summary>
        /// 项目状态，数字转换为其含义
        /// </summary>
        static public Dictionary<int, string> ProjectStateIntToMean = new Dictionary<int, string>()
        {
            {0, "" },
            {1,"申报" },
            {2,"在研" },
            {3,"结项" },
            {4,"终止" },
            {5,"撤销" },
        };


        public static Dictionary<string, int> ProjectStateMeanToInt = new Dictionary<string, int>()
        {
            {"", 0 },
            {"申报", 1},
            {"在研", 2},
            {"结项", 3},
            {"终止", 4},
            {"撤销", 5},
        };

        ///// <summary>
        ///// 项目状态，数字转换为其含义
        ///// </summary>
        //static public Dictionary<int, string> ProjectCategoryIntToMean = new Dictionary<int, string>()
        //{
        //    {0, "" },
        //    {1,"一般项目" },
        //    {2,"青年项目" },
        //    {3,"重点项目" },
        //    {4,"研究专项" },
        //    {5,"特别委托项目" },
        //    {6,"重大招标项目" },
        //    {7,"智库项目" },
        //};

        ///// <summary>
        ///// 项目状态，数字转换为其含义
        ///// </summary>
        //static public Dictionary<int, string> EndingIntToMean = new Dictionary<int, string>()
        //{
        //    {0, "" },
        //    {1,"著作" },
        //    {2,"论文" },
        //    {3,"研究报告" },
        //};



        #endregion

    }
}
