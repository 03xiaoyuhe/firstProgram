using DAL.DataObject.TableObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm.ASCX.PeopleInform
{
    public partial class PeopleAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public void ClearAll()
        {
            PEB_Name.InputData = string.Empty;
            PEB_Sex.InputData = string.Empty;
            PEB_Birthday.InputData = string.Empty;
            PEB_Job.InputData = string.Empty;
            PEB_Title.InputData = string.Empty;
            PEB_Employer.InputData = string.Empty;




            PE_Major.InputData = string.Empty;
            PE_Speciality.InputData = string.Empty;
            PE_Engage.InputData = string.Empty;
            PE_Address.InputData = string.Empty;
            PE_IsYouth.InputData = string.Empty;
            PE_OfficePhone.InputData = string.Empty;
            PE_MobilePhone.InputData = string.Empty;
            PE_Email.InputData = string.Empty;

        }


        #region 网站数据

        public PeopleData PeopleData
        {
            get
            {
                return new PeopleData()
                {
                    Base = new DAL.DataObject.TableObject.PeopleApart.PeopleBase()
                    {
                        PEB_Name = this.PEB_Name.InputData,
                        PEB_Sex = this.PEB_Sex.InputData,
                        PEB_Birthday = this.PEB_Birthday.InputData,
                        PEB_Job = this.PEB_Job.InputData,
                        PEB_Title = this.PEB_Title.InputData,
                        PEB_Employer = this.PEB_Employer.InputData,
                    },
                    PrincipalExpand = new DAL.DataObject.TableObject.PeopleApart.PeoplePrincipalExpand()
                    {
                        PE_Major = this.PE_Major.InputData,
                        PE_Speciality = this.PE_Speciality.InputData,
                        PE_Engage = this.PE_Engage.InputData,
                        PE_Address = this.PE_Address.InputData,
                        PE_IsYouth = this.PE_IsYouth.InputData,
                        PE_OfficePhone = this.PE_OfficePhone.InputData,
                        PE_MobilePhone = this.PE_MobilePhone.InputData,
                        PE_Email = this.PE_Email.InputData,
                    }
                };
            }
        }

        #endregion
    }
}