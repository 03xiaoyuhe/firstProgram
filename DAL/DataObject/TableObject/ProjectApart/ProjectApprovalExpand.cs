using System;
using System.Collections.Generic;

namespace DAL.DataObject.TableObject.ProjectApart
{
    public class ProjectApprovalExpand : DataObjectBase
    {
        public override bool IsEmpty()
        {
            if (
                PB_ID == 0 &&
                ProjectApprovalNum == string.Empty
                )
            {
                return true;
            }
            else return false;
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

        string projectApprovalNum;
        /// <summary>
        /// 项目批准编号
        /// </summary>
        public string ProjectApprovalNum
        {
            get
            {
                if (State == DataObjectState.PraiseDateTableToData)
                {
                    Object Data = DataTableHelper.GetRowColumnValue(DataTable, RowIndex, "ProjectApprovalNum");
                    if (Data != null)
                    {
                        return Data.ToString();
                    }
                    else return String.Empty;
                }
                if (projectApprovalNum == null) projectApprovalNum = string.Empty;
                return projectApprovalNum;
            }
            set
            {
                projectApprovalNum = value;
            }
        }

        #endregion
    }
}
