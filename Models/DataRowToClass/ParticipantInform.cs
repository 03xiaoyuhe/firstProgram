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
            dataTable = new DataTable();
            DataColumn column = new DataColumn("UseName");
            dataTable.Columns.Add(column);
            column = new DataColumn("UserDate");
            dataTable.Columns.Add(column);
            column = new DataColumn("UserSex");
            dataTable.Columns.Add(column);
            column = new DataColumn("UserPosition");
            dataTable.Columns.Add(column);
            column = new DataColumn("UserTitle");
            dataTable.Columns.Add(column);
            column = new DataColumn("UserSpeciality");
            dataTable.Columns.Add(column);
            column = new DataColumn("UserResearch");
            dataTable.Columns.Add(column);
            column = new DataColumn("UserResearch_now");
            dataTable.Columns.Add(column);
            column = new DataColumn("UserWorkplace");
            dataTable.Columns.Add(column);
            column = new DataColumn("UserAddress");
            dataTable.Columns.Add(column);
            column = new DataColumn("UserOffice_number");
            dataTable.Columns.Add(column);
            column = new DataColumn("UserNumber");
            dataTable.Columns.Add(column);
            column = new DataColumn("UserEmail");
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

        public string PeoName
        {
            get
            {
                if (dataTable.Rows.Count == 0 || dataTable.Columns.Contains("UseName")) return null;
                return dataTable.Rows[0].ToString();
            }
            set
            {
                if (dataTable.Rows.Count == 0) return;
                if (dataTable.Columns.Contains("UseName")) return;
                dataTable.Rows[0]["UseName"] = value;
            }
        }

        public string PeoDate
        {
            get
            {
                if (dataTable.Rows.Count == 0 || dataTable.Columns.Contains("UserDate")) return null;
                return dataTable.Rows[0].ToString();
            }
            set
            {
                if (dataTable.Rows.Count == 0) return;
                if (dataTable.Columns.Contains("UserDate")) return;
                dataTable.Rows[0]["UserDate"] = value;
            }
        }

        public string PeoSex
        {
            get
            {
                if (dataTable.Rows.Count == 0 || dataTable.Columns.Contains("UserSex")) return null;
                return dataTable.Rows[0].ToString();
            }
            set
            {
                if (dataTable.Rows.Count == 0) return;
                if (dataTable.Columns.Contains("UserSex")) return;
                dataTable.Rows[0]["UserSex"] = value;
            }
        }

        public string PeoPosition
        {
            get
            {
                if (dataTable.Rows.Count == 0 || dataTable.Columns.Contains("UserPosition")) return null;
                return dataTable.Rows[0].ToString();
            }
            set
            {
                if (dataTable.Rows.Count == 0) return;
                if (dataTable.Columns.Contains("UserPosition")) return;
                dataTable.Rows[0]["UserPosition"] = value;
            }
        }

        public string PeoTitle
        {
            get
            {
                if (dataTable.Rows.Count == 0 || dataTable.Columns.Contains("UserTitle")) return null;
                return dataTable.Rows[0].ToString();
            }
            set
            {
                if (dataTable.Rows.Count == 0) return;
                if (dataTable.Columns.Contains("UserTitle")) return;
                dataTable.Rows[0]["UserTitle"] = value;
            }
        }

        public string PeoSpeciality
        {
            get
            {
                if (dataTable.Rows.Count == 0 || dataTable.Columns.Contains("UserSpeciality")) return null;
                return dataTable.Rows[0].ToString();
            }
            set
            {
                if (dataTable.Rows.Count == 0) return;
                if (dataTable.Columns.Contains("UserSpeciality")) return;
                dataTable.Rows[0]["UserSpeciality"] = value;
            }
        }

        public string PeoResearch
        {
            get
            {
                if (dataTable.Rows.Count == 0 || dataTable.Columns.Contains("UserResearch")) return null;
                return dataTable.Rows[0].ToString();
            }
            set
            {
                if (dataTable.Rows.Count == 0) return;
                if (dataTable.Columns.Contains("UserResearch")) return;
                dataTable.Rows[0]["UserResearch"] = value;
            }
        }
        public string PeoReNow
        {
            get
            {
                if (dataTable.Rows.Count == 0 || dataTable.Columns.Contains("UserResearch_now")) return null;
                return dataTable.Rows[0].ToString();
            }
            set
            {
                if (dataTable.Rows.Count == 0) return;
                if (dataTable.Columns.Contains("UserResearch_now")) return;
                dataTable.Rows[0]["UserResearch_now"] = value;
            }
        }

        public string PeoWork
        {
            get
            {
                if (dataTable.Rows.Count == 0 || dataTable.Columns.Contains("UserWorkplace")) return null;
                return dataTable.Rows[0].ToString();
            }
            set
            {
                if (dataTable.Rows.Count == 0) return;
                if (dataTable.Columns.Contains("UserWorkplace")) return;
                dataTable.Rows[0]["UserWorkplace"] = value;
            }
        }

        public string ProAddress
        {
            get
            {
                if (dataTable.Rows.Count == 0 || dataTable.Columns.Contains("UserAddress")) return null;
                return dataTable.Rows[0].ToString();
            }
            set
            {
                if (dataTable.Rows.Count == 0) return;
                if (dataTable.Columns.Contains("UserAddress")) return;
                dataTable.Rows[0]["UserAddress"] = value;
            }
        }

        public string PeoOffNum
        {
            get
            {
                if (dataTable.Rows.Count == 0 || dataTable.Columns.Contains("UserOffice_number")) return null;
                return dataTable.Rows[0].ToString();
            }
            set
            {
                if (dataTable.Rows.Count == 0) return;
                if (dataTable.Columns.Contains("UserOffice_number")) return;
                dataTable.Rows[0]["UserOffice_number"] = value;
            }
        }

        public string PeoNumber
        {
            get
            {
                if (dataTable.Rows.Count == 0 || dataTable.Columns.Contains("UserNumber")) return null;
                return dataTable.Rows[0].ToString();
            }
            set
            {
                if (dataTable.Rows.Count == 0) return;
                if (dataTable.Columns.Contains("UserNumber")) return;
                dataTable.Rows[0]["UserNumber"] = value;
            }
        }

        public string ProEmail
        {
            get
            {
                if (dataTable.Rows.Count == 0 || dataTable.Columns.Contains("UserEmail")) return null;
                return dataTable.Rows[0].ToString();
            }
            set
            {
                if (dataTable.Rows.Count == 0) return;
                if (dataTable.Columns.Contains("UserEmail")) return;
                dataTable.Rows[0]["UserEmail"] = value;
            }
        }

        

    }
}
