using DAL.DataObject.TableObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm.ASCX.PeopleInform
{
    public partial class PeopleShow : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public PeopleData PageData
        {
            set
            {
                PEB_ID.Data = value.Base.PEB_ID.ToString();
                PEB_Name.Data = value.Base.PEB_Name;
                PEB_Sex.Data = value.Base.PEB_Sex;
                PEB_Birthday.Data = value.Base.PEB_Birthday;
                PEB_Job.Data = value.Base.PEB_Job;
                PEB_Title.Data = value.Base.PEB_Title;
                PEB_Employer.Data = value.Base.PEB_Employer;

                PE_Major.Data = value.PrincipalExpand.PE_Major;
                PE_Speciality.Data = value.PrincipalExpand.PE_Speciality;
                PE_Engage.Data = value.PrincipalExpand.PE_Engage;
                PE_Address.Data = value.PrincipalExpand.PE_Address;
                PE_IsYouth.Data = value.PrincipalExpand.PE_IsYouth;
                PE_OfficePhone.Data = value.PrincipalExpand.PE_OfficePhone;
                PE_MobilePhone.Data = value.PrincipalExpand.PE_MobilePhone;
                PE_Email.Data = value.PrincipalExpand.PE_Email;
            }
        }
    }
}