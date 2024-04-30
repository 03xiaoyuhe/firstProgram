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
            dataTable = new DataTable();
            DataColumn column = new DataColumn("project_name");
            dataTable.Columns.Add(column);
            column = new DataColumn("project_leader");
            dataTable.Columns.Add(column);
            column = new DataColumn("project_level");
            dataTable.Columns.Add(column);
            column = new DataColumn("project_number");
            dataTable.Columns.Add(column);
            column = new DataColumn("project_category");
            dataTable.Columns.Add(column);
            column = new DataColumn("project_youth");
            dataTable.Columns.Add(column);
            column = new DataColumn("project_research");
            dataTable.Columns.Add(column);
            column = new DataColumn("project_view");
            dataTable.Columns.Add(column);
            column = new DataColumn("project_References");
            dataTable.Columns.Add(column);
            column = new DataColumn("project_time");
            dataTable.Columns.Add(column);
            column = new DataColumn("project_form");
            dataTable.Columns.Add(column);
            column = new DataColumn("project_opinion");
            dataTable.Columns.Add(column);
            column = new DataColumn("project_expert_view");
            dataTable.Columns.Add(column);
            column = new DataColumn("project_approval_view");
            dataTable.Columns.Add(column);

        }

        DataTable dataTable;
        public DataTable DataTable
        {
            get
            {
                return dataTable;
            }
            set
            {
                dataTable = value;
            }
        }

        public string ProName
        {
            get
            {
                if (dataTable.Rows.Count == 0 || !dataTable.Columns.Contains("project_name")) return null;
                return dataTable.Rows[0]["project_name"].ToString();
            }
            set
            {
                if (dataTable.Rows.Count == 0) return;
                if (dataTable.Columns.Contains("project_name")) return;
                dataTable.Rows[0]["project_name"] = value;
            }
        }

        public string ProUser
        {
            get
            {
                if (dataTable.Rows.Count == 0 || !dataTable.Columns.Contains("project_leader")) return null;
                return dataTable.Rows[0]["project_leader"].ToString();
            }
            set
            {
                if (dataTable.Rows.Count == 0) return;
                if (dataTable.Columns.Contains("project_leader")) return;
                dataTable.Rows[0]["project_leader"] = value;
            }
        }

        public string ProLevel
        {
            get
            {
                if (dataTable.Rows.Count == 0 || !dataTable.Columns.Contains("project_level")) return null;
                return dataTable.Rows[0]["project_level"].ToString();
            }
            set
            {
                if (dataTable.Rows.Count == 0) return;
                if (dataTable.Columns.Contains("project_level")) return;
                dataTable.Rows[0]["project_level"] = value;
            }
        }
        
        public string ProNumber
        {
            get
            {
                if (dataTable.Rows.Count == 0 || !dataTable.Columns.Contains("project_number")) return null;
                return dataTable.Rows[0]["project_number"].ToString();
            }
            set
            {
                if (dataTable.Rows.Count == 0) return;
                if (dataTable.Columns.Contains("project_number")) return;
                dataTable.Rows[0]["project_number"] = value;
            }
        }
        
        public string ProCategory
        {
            get
            {
                if (dataTable.Rows.Count == 0 || !dataTable.Columns.Contains("project_category")) return null;
                return dataTable.Rows[0]["project_category"].ToString();
            }
            set
            {
                if (dataTable.Rows.Count == 0) return;
                if (dataTable.Columns.Contains("project_category")) return;
                dataTable.Rows[0]["project_category"] = value;
            }
        }
    
        public string ProYouth
        {
            get
            {
                if (dataTable.Rows.Count == 0 || !dataTable.Columns.Contains("project_youth")) return null;
                return dataTable.Rows[0]["project_youth"].ToString();
            }
            set
            {
                if (dataTable.Rows.Count == 0) return;
                if (dataTable.Columns.Contains("project_youth")) return;
                dataTable.Rows[0]["project_youth"] = value;
            }
        }
    
        public string ProResearch
        {
            get
            {
                if (dataTable.Rows.Count == 0 ||!dataTable.Columns.Contains("project_research")) return null;
                return dataTable.Rows[0]["project_research"].ToString();
            }
            set
            {
                if (dataTable.Rows.Count == 0) return;
                if (dataTable.Columns.Contains("project_research")) return;
                dataTable.Rows[0]["project_research"] = value;
            }
        }
    
        public string ProView
        {
            get
            {
                if (dataTable.Rows.Count == 0 || !dataTable.Columns.Contains("project_view")) return null;
                return dataTable.Rows[0]["project_view"].ToString();
            }
            set
            {
                if (dataTable.Rows.Count == 0) return;
                if (dataTable.Columns.Contains("project_view")) return;
                dataTable.Rows[0]["project_view"] = value;
            }
        }
    
        public string ProReferences
        {
            get
            {
                if (dataTable.Rows.Count == 0 || !dataTable.Columns.Contains("project_References")) return null;
                return dataTable.Rows[0]["project_References"].ToString();
            }
            set
            {
                if (dataTable.Rows.Count == 0) return;
                if (dataTable.Columns.Contains("project_References")) return;
                dataTable.Rows[0]["project_References"] = value;
            }
        }
    
        public string ProTime
        {
            get
            {
                if (dataTable.Rows.Count == 0 || !dataTable.Columns.Contains("project_time")) return null;
                return MetarnetRegex.ExcelDateToSQLDate(dataTable.Rows[0]["project_time"].ToString());
            }
            set
            {
                if (dataTable.Rows.Count == 0) return;
                if (dataTable.Columns.Contains("project_time")) return;
                dataTable.Rows[0]["project_time"] = value;
            }
        }
    
        public string ProForm
        {
            get
            {
                if (dataTable.Rows.Count == 0 || !dataTable.Columns.Contains("project_form")) return null;
                return dataTable.Rows[0]["project_form"].ToString();
            }
            set
            {
                if (dataTable.Rows.Count == 0) return;
                if (dataTable.Columns.Contains("project_form")) return;
                dataTable.Rows[0]["project_form"] = value;
            }
        }
    
        public string ProOpinion
        {
            get
            {
                if (dataTable.Rows.Count == 0 || !dataTable.Columns.Contains("project_opinion")) return null;
                return dataTable.Rows[0]["project_opinion"].ToString();
            }
            set
            {
                if (dataTable.Rows.Count == 0) return;
                if (dataTable.Columns.Contains("project_opinion")) return;
                dataTable.Rows[0]["project_opinion"] = value;
            }
        }
    
        public string ProExpert
        {
            get
            {
                if (dataTable.Rows.Count == 0 || !dataTable.Columns.Contains("project_expert_view")) return null;
                return dataTable.Rows[0]["project_expert_view"].ToString();
            }
            set
            {
                if (dataTable.Rows.Count == 0) return;
                if (dataTable.Columns.Contains("project_expert_view")) return;
                dataTable.Rows[0]["project_expert_view"] = value;
            }
        }
    
        public string ProApproval
        {
            get
            {
                if (dataTable.Rows.Count == 0 || !dataTable.Columns.Contains("project_approval_view")) return null;
                return dataTable.Rows[0]["project_approval_view"].ToString();
            }
            set
            {
                if (dataTable.Rows.Count == 0) return;
                if (dataTable.Columns.Contains("project_approval_view")) return;
                dataTable.Rows[0]["project_approval_view"] = value;
            }
        }
    

    }
}
