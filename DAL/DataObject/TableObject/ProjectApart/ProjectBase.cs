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
                DisciplineClassificaton == string.Empty &&
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

        // 信息ID 是 未知的
        //int pB_ID;

        ///// <summary>
        ///// 项目ID
        ///// </summary>
        //public int PB_ID
        //{
        //    get
        //    {
        //        return pB_ID;
        //    }
        //    set
        //    {
        //        pB_ID = value;
        //    }
        //}

        int projectState;
        /// <summary>
        /// 项目状态
        /// </summary>
        public int ProjectState
        {
            get
            {
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
                return projectCategory;
            }
            set
            {
                projectCategory = value;
            }
        }

        string disciplineClassificaton;
        /// <summary>
        /// 学科分类
        /// </summary>
        public string DisciplineClassificaton
        {
            get
            {
                if (disciplineClassificaton == null) disciplineClassificaton = string.Empty;
                return disciplineClassificaton;
            }
            set
            {
                disciplineClassificaton = value;
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
