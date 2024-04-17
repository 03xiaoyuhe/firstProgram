using Models.PageDataSor.ProgremData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm.ASCX.ProgramInform.ForProgramShow
{
    public partial class DataFormForDoc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        #region 项目论证

        DataForDoc dataForDoc;
        /// <summary>
        /// 项目论证数据
        /// </summary>
        public DataForDoc DatasForDoc
        {
            get
            {
                return dataForDoc;
            }
            set
            {
                dataForDoc = value;
                ProjectIntroduce = value.ProjectIntroduce;
                ProjectMainIdea = value.ProjectMainIdea;
                ProjectAhead = value.ProjectAhead;
            }

        }

        #region 项目论证数据项

        string projectIntroduce;
        /// <summary>
        /// 本项目国内外研究现状述评、选题意义和价值。限 1200 字以内
        /// </summary>
        public string ProjectIntroduce
        {
            get { return projectIntroduce; }
            set
            {
                projectIntroduce = value;
                ProjectIntroduceLable.Text = value;
            }
        }

        string projectMainIdea;
        /// <summary>
        /// 本项目研究的主要观点，基本思路和方法、重点、难点及创新之处。限 2000 字以内
        /// </summary>
        public string ProjectMainIdea
        {
            set
            {
                projectMainIdea = value;
                ProjectAheadLable.Text = value;
            }
            get
            {
                return projectMainIdea;
            }
        }

        string projectAhead;
        /// <summary>
        /// 项目负责人和主要成员前期研究成果及参考文献。限填20项
        /// </summary>
        public string ProjectAhead
        {
            get { return ProjectAhead; }
            set
            {
                ProjectAhead = value;
                ProjectAheadLable.Text = value;
            }
        }

        #endregion

        #endregion


    }
}