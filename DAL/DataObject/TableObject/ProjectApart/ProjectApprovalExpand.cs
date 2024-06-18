namespace DAL.DataObject.TableObject.ProjectApart
{
    public class ProjectApprovalExpand : DataObjectBase
    {
        public override bool IsEmpty()
        {
            if (
                //PA_ID == 0 &&
                PB_ID == 0 &&
                ProjectApprovalNum == ""
                )
                return false;
            return true;
        }

        #region 属性与字段

        // 信息 ID 是未知的
        //int pA_ID;

        //public int PA_ID
        //{
        //    get
        //    {
        //        return pA_ID;
        //    }
        //    set
        //    {
        //        pA_ID = value;
        //    }
        //}

        int pB_ID;
        /// <summary>
        /// 项目 ID
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

        string projectApprovalNum;
        /// <summary>
        /// 项目批准编号
        /// </summary>
        public string ProjectApprovalNum
        {
            get
            {
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
