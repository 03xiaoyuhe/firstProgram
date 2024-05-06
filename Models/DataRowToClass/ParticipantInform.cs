using Models.PageDataSor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataRowToClass
{
    public class ParticipantInform
    {
        public ParticipantInform()
        {
            //dataTable = new DataTable();
            //DataColumn column = new DataColumn("UseName");
            //dataTable.Columns.Add(column);
            //column = new DataColumn("UserDate");
            //dataTable.Columns.Add(column);
            //column = new DataColumn("UserSex");
            //dataTable.Columns.Add(column);
            //column = new DataColumn("UserPosition");
            //dataTable.Columns.Add(column);
            //column = new DataColumn("UserTitle");
            //dataTable.Columns.Add(column);
            //column = new DataColumn("UserSpeciality");
            //dataTable.Columns.Add(column);
            //column = new DataColumn("UserResearch");
            //dataTable.Columns.Add(column);
            //column = new DataColumn("UserResearch_now");
            //dataTable.Columns.Add(column);
            //column = new DataColumn("UserWorkplace");
            //dataTable.Columns.Add(column);
            //column = new DataColumn("UserAddress");
            //dataTable.Columns.Add(column);
            //column = new DataColumn("UserOffice_number");
            //dataTable.Columns.Add(column);
            //column = new DataColumn("UserNumber");
            //dataTable.Columns.Add(column);
            //column = new DataColumn("UserEmail");
            //dataTable.Columns.Add(column);
            

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

        public string PeoName
        {
            get
            {
                if (dataTable.Table.Rows.Count == 0 || !dataTable.Table.Columns.Contains("UseName")) return null;
                return dataTable["UseName"].ToString();
            }
            set
            {
                if (dataTable.Table.Rows.Count == 0) return;
                if (dataTable.Table.Columns.Contains("UseName")) return;
                dataTable["UseName"] = value;
            }
        }

        public string PeoDate
        {
            get
            {
                if (dataTable.Table.Rows.Count == 0 || !dataTable.Table.Columns.Contains("UserDate")) return null;
                return MetarnetRegex.ExcelDateToSQLDate(dataTable["UserDate"].ToString());
            }
            set
            {
                if (dataTable.Table.Rows.Count == 0) return;
                if (dataTable.Table.Columns.Contains("UserDate")) return;
                dataTable["UserDate"] = value;
            }
        }

        public string PeoSex
        {
            get
            {
                if (dataTable.Table.Rows.Count == 0 || !dataTable.Table.Columns.Contains("UserSex")) return null;
                return dataTable["UserSex"].ToString();
            }
            set
            {
                if (dataTable.Table.Rows.Count == 0) return;
                if (dataTable.Table.Columns.Contains("UserSex")) return;
                dataTable["UserSex"] = value;
            }
        }

        public string PeoPosition
        {
            get
            {
                if (dataTable.Table.Rows.Count == 0 || !dataTable.Table.Columns.Contains("UserPosition")) return null;
                return dataTable["UserPosition"].ToString();
            }
            set
            {
                if (dataTable.Table.Rows.Count == 0) return;
                if (dataTable.Table.Columns.Contains("UserPosition")) return;
                dataTable["UserPosition"] = value;
            }
        }

        public string PeoTitle
        {
            get
            {
                if (dataTable.Table.Rows.Count == 0 || !dataTable.Table.Columns.Contains("UserTitle")) return null;
                return dataTable["UserTitle"].ToString();
            }
            set
            {
                if (dataTable.Table.Rows.Count == 0) return;
                if (dataTable.Table.Columns.Contains("UserTitle")) return;
                dataTable["UserTitle"] = value;
            }
        }

        public string PeoSpeciality
        {
            get
            {
                if (dataTable.Table.Rows.Count == 0 || !dataTable.Table.Columns.Contains("UserSpeciality")) return null;
                return dataTable["UserSpeciality"].ToString();
            }
            set
            {
                if (dataTable.Table.Rows.Count == 0) return;
                if (dataTable.Table.Columns.Contains("UserSpeciality")) return;
                dataTable["UserSpeciality"] = value;
            }
        }

        public string PeoResearch
        {
            get
            {
                if (dataTable.Table.Rows.Count == 0 || !dataTable.Table.Columns.Contains("UserResearch")) return null;
                return dataTable["UserResearch"].ToString();
            }
            set
            {
                if (dataTable.Table.Rows.Count == 0) return;
                if (dataTable.Table.Columns.Contains("UserResearch")) return;
                dataTable["UserResearch"] = value;
            }
        }
        public string PeoReNow
        {
            get
            {
                if (dataTable.Table.Rows.Count == 0 || !dataTable.Table.Columns.Contains("UserResearch_now")) return null;
                return dataTable["UserResearch_now"].ToString();
            }
            set
            {
                if (dataTable.Table.Rows.Count == 0) return;
                if (dataTable.Table.Columns.Contains("UserResearch_now")) return;
                dataTable["UserResearch_now"] = value;
            }
        }

        public string PeoWork
        {
            get
            {
                if (dataTable.Table.Rows.Count == 0 || !dataTable.Table.Columns.Contains("UserWorkplace")) return null;
                return dataTable["UserWorkplace"].ToString();
            }
            set
            {
                if (dataTable.Table.Rows.Count == 0) return;
                if (dataTable.Table.Columns.Contains("UserWorkplace")) return;
                dataTable["UserWorkplace"] = value;
            }
        }

        public string ProAddress
        {
            get
            {
                if (dataTable.Table.Rows.Count == 0 || !dataTable.Table.Columns.Contains("UserAddress")) return null;
                return dataTable["UserAddress"].ToString();
            }
            set
            {
                if (dataTable.Table.Rows.Count == 0) return;
                if (dataTable.Table.Columns.Contains("UserAddress")) return;
                dataTable["UserAddress"] = value;
            }
        }

        public string PeoOffNum
        {
            get
            {
                if (dataTable.Table.Rows.Count == 0 || !dataTable.Table.Columns.Contains("UserOffice_number")) return null;
                return dataTable["UserOffice_number"].ToString();
            }
            set
            {
                if (dataTable.Table.Rows.Count == 0) return;
                if (dataTable.Table.Columns.Contains("UserOffice_number")) return;
                dataTable["UserOffice_number"] = value;
            }
        }

        public string PeoNumber
        {
            get
            {
                if (dataTable.Table.Rows.Count == 0 || !dataTable.Table.Columns.Contains("UserNumber")) return null;
                return dataTable["UserNumber"].ToString();
            }
            set
            {
                if (dataTable.Table.Rows.Count == 0) return;
                if (dataTable.Table.Columns.Contains("UserNumber")) return;
                dataTable["UserNumber"] = value;
            }
        }

        public string ProEmail
        {
            get
            {
                if (dataTable.Table.Rows.Count == 0 || !dataTable.Table.Columns.Contains("UserEmail")) return null;
                return dataTable["UserEmail"].ToString();
            }
            set
            {
                if (dataTable.Table.Rows.Count == 0) return;
                if (dataTable.Table.Columns.Contains("UserEmail")) return;
                dataTable["UserEmail"] = value;
            }
        }

        

    }
}
