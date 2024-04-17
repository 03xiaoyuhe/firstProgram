using Models.PageDataSor.ProgremData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm.ASCX.ProgramInform.ForProgramShow
{
    public partial class DataFormForThinking : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        #region 评审意见

        DataForThinking dataForThinking;
        /// <summary>
        /// 评审意见数据集
        /// </summary>
        public DataForThinking DatasForThinking
        {
            get
            {
                return dataForThinking;
            }
            set
            {
                dataForThinking = value;
                WhereThink = value.WhereThink;
                WhereThinkTime = value.WhereThinkTime;
                MajorThink = value.MajorThink;
                MajorThinkTime = value.MajorThinkTime;
                EndThink = value.EndThink;
                EndThinkTime = value.EndThinkTime;
            }
        }

        #region 评审意见数据项

        string whereThink;
        /// <summary>
        /// 项目负责人所在单位审核意见(本栏由申请人所在单位根据申报要求，认真审核后进行填写，电子版申请书可不盖公章
        /// </summary>
        public string WhereThink
        {
            get { return whereThink; }
            set
            {
                whereThink = value;
            }
        }


        DateTime whereThinkTime;
        /// <summary>
        /// 项目负责人所在单位审核意见时间
        /// </summary>
        public DateTime WhereThinkTime
        {
            get
            {
                return whereThinkTime;
            }
            set
            {
                whereThinkTime = value;
                WhereThinkTimeLable.Text = value.Year.ToString() + "--" + value.Month.ToString() + "--" + value.Day.ToString();
            }
        }


        string majorThink;
        /// <summary>
        /// 专家组评审意见
        /// </summary>
        public string MajorThink
        {
            get { return majorThink; }
            set
            {
                majorThink = value;
            }
        }


        DateTime majorThinkTime;
        /// <summary>
        /// 专家组评审意见时间
        /// </summary>
        public DateTime MajorThinkTime
        {
            get
            {
                return majorThinkTime;
            }
            set
            {
                majorThinkTime = value;
                MajorThinkTimeLable.Text = value.Year.ToString() + "--" + value.Month.ToString() + "--" + value.Day.ToString();
            }
        }


        string endThink;
        /// <summary>
        /// 审批意见
        /// </summary>
        public string EndThink
        {
            get { return endThink; }
            set
            {
                endThink = value;
            }
        }


        DateTime endThinkTime;
        /// <summary>
        /// 审批意见时间
        /// </summary>
        public DateTime EndThinkTime
        {
            get
            {
                return majorThinkTime;
            }
            set
            {
                endThinkTime = value;
                EndThinkTimeLable.Text = value.Year.ToString() + "--" + value.Month.ToString() + "--" + value.Day.ToString();
            }
        }

        #endregion


        #endregion
    }
}