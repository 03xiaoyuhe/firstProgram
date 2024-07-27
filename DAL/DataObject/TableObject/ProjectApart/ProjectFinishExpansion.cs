using System;
using System.Collections.Generic;

namespace DAL.DataObject.TableObject.ProjectApart
{
    public class ProjectFinishExpansion : DataObjectBase
    {
        public override bool IsEmpty()
        {
            if (
                PB_ID == 0 &&
                FinishCertificateNum == string.Empty
               )
            {
                return true;
            }
            return false;
        }

        #region 属性与字段

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

        string finishCertificateNum;
        /// <summary>
        /// 结项证书编号
        /// </summary>
        public string FinishCertificateNum
        {
            get
            {
                if (State == DataObjectState.PraiseDateTableToData)
                {
                    Object Data = DataTableHelper.GetRowColumnValue(DataTable, RowIndex, "FinishCertificateNum");
                    if (Data != null)
                    {
                        return Data.ToString();
                    }
                    else return String.Empty;
                }
                if (finishCertificateNum == null) finishCertificateNum = string.Empty;
                return finishCertificateNum;
            }
            set
            {
                finishCertificateNum = value;
            }
        }

        #endregion
    }
}
