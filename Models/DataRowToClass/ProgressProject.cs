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

        DataRow dataTable;
        public DataRow DataTable
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
                if (dataTable.Table.Rows.Count == 0 || !dataTable.Table.Columns.Contains("project_name")) return null;
                return dataTable["project_name"].ToString();
            }
            set
            {
                if (dataTable.Table.Rows.Count == 0) return;
                if (dataTable.Table.Columns.Contains("project_name")) return;
                dataTable["project_name"] = value;
            }
        }

        public string ProUser
        {
            get
            {
                if (dataTable.Table.Rows.Count == 0 || !dataTable.Table.Columns.Contains("project_leader")) return null;
                return dataTable["project_leader"].ToString();
            }
            set
            {
                if (dataTable.Table.Rows.Count == 0) return;
                if (dataTable.Table.Columns.Contains("project_leader")) return;
                dataTable["project_leader"] = value;
            }
        }

        public string ProLevel
        {
            get
            {
                if (dataTable.Table.Rows.Count == 0 || !dataTable.Table.Columns.Contains("project_level")) return null;
                return dataTable["project_level"].ToString();
            }
            set
            {
                if (dataTable.Table.Rows.Count == 0) return;
                if (dataTable.Table.Columns.Contains("project_level")) return;
                dataTable["project_level"] = value;
            }
        }
        
        public string ProNumber
        {
            get
            {
                if (dataTable.Table.Rows.Count == 0 || !dataTable.Table.Columns.Contains("project_number")) return null;
                return dataTable["project_number"].ToString();
            }
            set
            {
                if (dataTable.Table.Rows.Count == 0) return;
                if (dataTable.Table.Columns.Contains("project_number")) return;
                dataTable["project_number"] = value;
            }
        }
        
        public string ProCategory
        {
            get
            {
                if (dataTable.Table.Rows.Count == 0 || !dataTable.Table.Columns.Contains("project_category")) return null;
                return dataTable["project_category"].ToString();
            }
            set
            {
                if (dataTable.Table.Rows.Count == 0) return;
                if (dataTable.Table.Columns.Contains("project_category")) return;
                dataTable["project_category"] = value;
            }
        }
    
        public string ProYouth
        {
            get
            {
                if (dataTable.Table.Rows.Count == 0 || !dataTable.Table.Columns.Contains("project_youth")) return null;
                return dataTable["project_youth"].ToString();
            }
            set
            {
                if (dataTable.Table.Rows.Count == 0) return;
                if (dataTable.Table.Columns.Contains("project_youth")) return;
                dataTable["project_youth"] = value;
            }
        }
    
        public string ProResearch
        {
            get
            {
                if (dataTable.Table.Rows.Count == 0 ||!dataTable.Table.Columns.Contains("project_research")) return null;
                return dataTable["project_research"].ToString();
            }
            set
            {
                if (dataTable.Table.Rows.Count == 0) return;
                if (dataTable.Table.Columns.Contains("project_research")) return;
                dataTable["project_research"] = value;
            }
        }
    
        public string ProView
        {
            get
            {
                if (dataTable.Table.Rows.Count == 0 || !dataTable.Table.Columns.Contains("project_view")) return null;
                return dataTable["project_view"].ToString();
            }
            set
            {
                if (dataTable.Table.Rows.Count == 0) return;
                if (dataTable.Table.Columns.Contains("project_view")) return;
                dataTable["project_view"] = value;
            }
        }
    
        public string ProReferences
        {
            get
            {
                if (dataTable.Table.Rows.Count == 0 || !dataTable.Table.Columns.Contains("project_References")) return null;
                return dataTable["project_References"].ToString();
            }
            set
            {
                if (dataTable.Table.Rows.Count == 0) return;
                if (dataTable.Table.Columns.Contains("project_References")) return;
                dataTable["project_References"] = value;
            }
        }
    
        public string ProTime
        {
            get
            {
                if (dataTable.Table.Rows.Count == 0 || !dataTable.Table.Columns.Contains("project_time")) return null;
                return MetarnetRegex.ExcelDateToSQLDate(dataTable["project_time"].ToString());
            }
            set
            {
                if (dataTable.Table.Rows.Count == 0) return;
                if (dataTable.Table.Columns.Contains("project_time")) return;
                dataTable["project_time"] = value;
            }
        }
    
        public string ProForm
        {
            get
            {
                if (dataTable.Table.Rows.Count == 0 || !dataTable.Table.Columns.Contains("project_form")) return null;
                return dataTable["project_form"].ToString();
            }
            set
            {
                if (dataTable.Table.Rows.Count == 0) return;
                if (dataTable.Table.Columns.Contains("project_form")) return;
                dataTable["project_form"] = value;
            }
        }
    
        public string ProOpinion
        {
            get
            {
                if (dataTable.Table.Rows.Count == 0 || !dataTable.Table.Columns.Contains("project_opinion")) return null;
                return dataTable["project_opinion"].ToString();
            }
            set
            {
                if (dataTable.Table.Rows.Count == 0) return;
                if (dataTable.Table.Columns.Contains("project_opinion")) return;
                dataTable["project_opinion"] = value;
            }
        }
    
        public string ProExpert
        {
            get
            {
                if (dataTable.Table.Rows.Count == 0 || !dataTable.Table.Columns.Contains("project_expert_view")) return null;
                return dataTable["project_expert_view"].ToString();
            }
            set
            {
                if (dataTable.Table.Rows.Count == 0) return;
                if (dataTable.Table.Columns.Contains("project_expert_view")) return;
                dataTable["project_expert_view"] = value;
            }
        }
    
        public string ProApproval
        {
            get
            {
                if (dataTable.Table.Rows.Count == 0 || !dataTable.Table.Columns.Contains("project_approval_view")) return null;
                return dataTable["project_approval_view"].ToString();
            }
            set
            {
                if (dataTable.Table.Rows.Count == 0) return;
                if (dataTable.Table.Columns.Contains("project_approval_view")) return;
                dataTable["project_approval_view"] = value;
            }
        }
    

    }
}
