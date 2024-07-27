using System;
using System.Collections.Generic;

namespace DAL.DataObject.TableObject.ProjectApart
{
    public class ProjectDemonstrationExpand : DataObjectBase
    {
        public override bool IsEmpty()
        {
            if (
                PB_ID == 0 &&
                ProjectSignificance == string.Empty &&
                ProjectDocument == string.Empty &&
                ProjectReferences == string.Empty
               )
            {
                return true;
            }
            else { return false; }
        }

        #region 属性及字段

        int pB_ID;
        /// <summary>
        /// 项目 ID
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

        string projectSignificance;
        /// <summary>
        /// 项目国内外研究现状述评，选题意义即价值
        /// </summary>
        public string ProjectSignificance
        {
            get
            {
                if (State == DataObjectState.PraiseDateTableToData)
                {
                    Object Data = DataTableHelper.GetRowColumnValue(DataTable, RowIndex, "ProjectSignificance");
                    if (Data != null)
                    {
                        return Data.ToString();
                    }
                    else return String.Empty;
                }
                if (projectSignificance == null) projectSignificance = string.Empty;
                return projectSignificance;
            }
            set
            {
                projectSignificance = value;
            }
        }

        string projectDocument;
        /// <summary>
        /// 项目研究的主要观点、基本思路和方法、重点难点即创新之处
        /// </summary>
        public string ProjectDocument
        {
            get
            {
                if (State == DataObjectState.PraiseDateTableToData)
                {
                    Object Data = DataTableHelper.GetRowColumnValue(DataTable, RowIndex, "ProjectDocument");
                    if (Data != null)
                    {
                        return Data.ToString();
                    }
                    else return String.Empty;
                }
                if (projectDocument == null) projectDocument = string.Empty;
                return projectDocument;
            }
            set
            {
                projectDocument = value;
            }
        }

        string projectReferences;
        /// <summary>
        /// 项目负责人和主要成员前期研究成果及主要参考文献
        /// </summary>
        public string ProjectReferences
        {
            get
            {
                if (State == DataObjectState.PraiseDateTableToData)
                {
                    Object Data = DataTableHelper.GetRowColumnValue(DataTable, RowIndex, "ProjectReferences");
                    if (Data != null)
                    {
                        return Data.ToString();
                    }
                    else return String.Empty;
                }
                if (projectReferences == null) projectReferences = string.Empty;
                return projectReferences;
            }
            set
            {
                projectReferences = value;
            }
        }

        #endregion
    }
}
