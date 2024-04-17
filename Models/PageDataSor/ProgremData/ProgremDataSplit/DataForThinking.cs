using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.PageDataSor.ProgremData
{
    public class DataForThinking
    {
        public DataForThinking() 
        {
            WhereThink = "未赋值";
            whereThinkTime = "未赋值";
            MajorThink = "未赋值";
            MajorThinkTime = "未赋值";
            EndThink = "未赋值";
            EndThinkTime = "未赋值";
        }

        public DataForThinking(string whereThink, string whereThinkTime, string majorThink, string majorThinkTime, string endThink, string endThinkTime)
        {
            WhereThink = whereThink;
            WhereThinkTime = whereThinkTime;
            MajorThink = majorThink;
            MajorThinkTime = majorThinkTime;
            EndThink = endThink;
            EndThinkTime = endThinkTime;
        }

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

        string whereThinkTime;
        /// <summary>
        /// 项目负责人所在单位审核意见时间
        /// </summary>
        public string WhereThinkTime
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

        string majorThinkTime;
        /// <summary>
        /// 专家组评审意见时间
        /// </summary>
        public string MajorThinkTime
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

        string endThinkTime;
        /// <summary>
        /// 审批意见时间
        /// </summary>
        public string EndThinkTime
        {
            get
            {
                return endThinkTime;
            }
            set
            {
                endThinkTime = value;
            }
        }

    }
}
