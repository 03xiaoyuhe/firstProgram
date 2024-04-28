using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataRowToClass
{
    public class ProgressProject
    {
        DataRow dataRow;
        public DataRow DataRow
        {
            get
            {
                return dataRow;
            }
            set
            {
                dataRow = value;
            }
        }

        ProName["project_name"];
        ProLevel["project_level"];
        ProNumber["project_number"];
        ProCategory["project_category"];
        ProYouth["project_youth"];
        ProResearch["project_research"];
        ProView["project_view"];
        ProReferences["project_References"];
        ProTime["project_time"];
        ProForm["project_form"];
        ProOpinion["project_opinion"];
        ProExpert["project_expert_view"];
        ProApproval["project_approval_view"];

    }
}
