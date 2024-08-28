using DAL.DataObject.TableObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm.ASCX.PeopleInform.ForPeopleShow
{
    public partial class SingleLineDataFormForPeople : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        PeopleData peopleData = null;

        /// <summary>
        /// 信息
        /// </summary>
        public PeopleData PeopleData
        {
            set
            {
                peopleData = value;
                if (peopleData != null)
                {
                    PEB_ID.Data = value.Base.PEB_ID.ToString();
                    PEB_Name.Data = value.Base.PEB_Name;
                    PEB_Employer.Data = value.Base.PEB_Employer;
                    PEB_Job.Data = value.Base.PEB_Job;

                }
            }
            get
            {
                return peopleData;
            }
        }
    }
}