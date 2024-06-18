namespace DAL.DataObject.TableObject.ProjectApart
{
    public class ProjectFinishExpansion : DataObjectBase
    {
        public override bool IsEmpty()
        {
            if (
                PF_ID == 0 &&
                PB_ID == 0 &&
                FinishCertificateNum == string.Empty
               )
            {
                return true;
            }
            return false;
        }

        #region 属性与字段

        int pF_ID;
        /// <summary>
        /// 信息ID
        /// </summary>
        public int PF_ID
        {
            get
            {
                return pF_ID;
            }
            set
            {
                pF_ID = value;
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

        string finishCertificateNum;
        /// <summary>
        /// 结项证书编号
        /// </summary>
        public string FinishCertificateNum
        {
            get
            {
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
