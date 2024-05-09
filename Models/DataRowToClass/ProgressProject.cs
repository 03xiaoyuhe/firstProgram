using Models.PageDataSor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataRowToClass
{
    public class ProgressProject
    {
        public ProgressProject()
        {

        }

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

        public string ProName
        {
            get
            {
                if (dataRow.Table.Rows.Count == 0 || !dataRow.Table.Columns.Contains("project_name")) return null;
                return dataRow["project_name"].ToString();
            }
            set
            {
                if (dataRow.Table.Rows.Count == 0) return;
                if (dataRow.Table.Columns.Contains("project_name")) return;
                dataRow["project_name"] = value;
            }
        }

        public string ProUser
        {
            get
            {
                if (dataRow.Table.Rows.Count == 0 || !dataRow.Table.Columns.Contains("project_leader")) return null;
                return dataRow["project_leader"].ToString();
            }
            set
            {
                if (dataRow.Table.Rows.Count == 0) return;
                if (dataRow.Table.Columns.Contains("project_leader")) return;
                dataRow["project_leader"] = value;
            }
        }

        public string ProLevel
        {
            get
            {
                if (dataRow.Table.Rows.Count == 0 || !dataRow.Table.Columns.Contains("project_level")) return null;
                return dataRow["project_level"].ToString();
            }
            set
            {
                if (dataRow.Table.Rows.Count == 0) return;
                if (dataRow.Table.Columns.Contains("project_level")) return;
                dataRow["project_level"] = value;
            }
        }
        
        public string ProNumber
        {
            get
            {
                if (dataRow.Table.Rows.Count == 0 || !dataRow.Table.Columns.Contains("project_number")) return null;
                return dataRow["project_number"].ToString();
            }
            set
            {
                if (dataRow.Table.Rows.Count == 0) return;
                if (dataRow.Table.Columns.Contains("project_number")) return;
                dataRow["project_number"] = value;
            }
        }
        
        public string ProCategory
        {
            get
            {
                if (dataRow.Table.Rows.Count == 0 || !dataRow.Table.Columns.Contains("project_category")) return null;
                return dataRow["project_category"].ToString();
            }
            set
            {
                if (dataRow.Table.Rows.Count == 0) return;
                if (dataRow.Table.Columns.Contains("project_category")) return;
                dataRow["project_category"] = value;
            }
        }
    
        public string ProYouth
        {
            get
            {
                if (dataRow.Table.Rows.Count == 0 || !dataRow.Table.Columns.Contains("project_youth")) return null;
                return dataRow["project_youth"].ToString();
            }
            set
            {
                if (dataRow.Table.Rows.Count == 0) return;
                if (dataRow.Table.Columns.Contains("project_youth")) return;
                dataRow["project_youth"] = value;
            }
        }
    
        public string ProResearch
        {
            get
            {
                if (dataRow.Table.Rows.Count == 0 ||!dataRow.Table.Columns.Contains("project_research")) return null;
                return dataRow["project_research"].ToString();
            }
            set
            {
                if (dataRow.Table.Rows.Count == 0) return;
                if (dataRow.Table.Columns.Contains("project_research")) return;
                dataRow["project_research"] = value;
            }
        }
    
        public string ProView
        {
            get
            {
                if (dataRow.Table.Rows.Count == 0 || !dataRow.Table.Columns.Contains("project_view")) return null;
                return dataRow["project_view"].ToString();
            }
            set
            {
                if (dataRow.Table.Rows.Count == 0) return;
                if (dataRow.Table.Columns.Contains("project_view")) return;
                dataRow["project_view"] = value;
            }
        }
    
        public string ProReferences
        {
            get
            {
                if (dataRow.Table.Rows.Count == 0 || !dataRow.Table.Columns.Contains("project_References")) return null;
                return dataRow["project_References"].ToString();
            }
            set
            {
                if (dataRow.Table.Rows.Count == 0) return;
                if (dataRow.Table.Columns.Contains("project_References")) return;
                dataRow["project_References"] = value;
            }
        }
    
        public string ProTime
        {
            get
            {
                if (dataRow.Table.Rows.Count == 0 || !dataRow.Table.Columns.Contains("project_time")) return null;
                return MetarnetRegex.ExcelDateToSQLDate(dataRow["project_time"].ToString());
            }
            set
            {
                if (dataRow.Table.Rows.Count == 0) return;
                if (dataRow.Table.Columns.Contains("project_time")) return;
                dataRow["project_time"] = value;
            }
        }
    
        public string ProForm
        {
            get
            {
                if (dataRow.Table.Rows.Count == 0 || !dataRow.Table.Columns.Contains("project_form")) return null;
                return dataRow["project_form"].ToString();
            }
            set
            {
                if (dataRow.Table.Rows.Count == 0) return;
                if (dataRow.Table.Columns.Contains("project_form")) return;
                dataRow["project_form"] = value;
            }
        }
    
        public string ProOpinion
        {
            get
            {
                if (dataRow.Table.Rows.Count == 0 || !dataRow.Table.Columns.Contains("project_opinion")) return null;
                return dataRow["project_opinion"].ToString();
            }
            set
            {
                if (dataRow.Table.Rows.Count == 0) return;
                if (dataRow.Table.Columns.Contains("project_opinion")) return;
                dataRow["project_opinion"] = value;
            }
        }
    
        public string ProExpert
        {
            get
            {
                if (dataRow.Table.Rows.Count == 0 || !dataRow.Table.Columns.Contains("project_expert_view")) return null;
                return dataRow["project_expert_view"].ToString();
            }
            set
            {
                if (dataRow.Table.Rows.Count == 0) return;
                if (dataRow.Table.Columns.Contains("project_expert_view")) return;
                dataRow["project_expert_view"] = value;
            }
        }
    
        public string ProApproval
        {
            get
            {
                if (dataRow.Table.Rows.Count == 0 || !dataRow.Table.Columns.Contains("project_approval_view")) return null;
                return dataRow["project_approval_view"].ToString();
            }
            set
            {
                if (dataRow.Table.Rows.Count == 0) return;
                if (dataRow.Table.Columns.Contains("project_approval_view")) return;
                dataRow["project_approval_view"] = value;
            }
        }


        public List<string> PartersInform
        {
            get
            {
                List<string> list = new List<string>();
                for(int i = 0; i < 13; i++)
                {
                    if (dataRow.Table.Rows.Count == 0 || !dataRow.Table.Columns.Contains($"UserId{i}") || dataRow[$"UserId{i}"] == null || dataRow[$"UserId{i}"].ToString() == "") continue;
                    list.Add(dataRow[$"UserId{i}"].ToString());
                }
                return list;
            }
        }


    }
}
