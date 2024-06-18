namespace DAL.DataObject.TableObject.ProjectApart
{
    public class ProjectDemonstrationExpand : DataObjectBase
    {

        public override bool IsEmpty()
        {
            if (
                //DE_ID == 0 &&
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

        //int dE_ID;

        //public int DE_ID
        //{
        //    get
        //    {
        //        return dE_ID;
        //    }
        //    set
        //    {
        //        dE_ID = value;
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


        string projectSignificance;
        /// <summary>
        /// 项目国内外研究现状述评，选题意义即价值
        /// </summary>
        public string ProjectSignificance
        {
            get
            {
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
