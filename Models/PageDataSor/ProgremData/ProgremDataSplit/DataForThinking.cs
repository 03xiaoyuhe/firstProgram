using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.PageDataSor.ProgremData
{
    public class DataForThinking
    {

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
            }
        }

    }
}
