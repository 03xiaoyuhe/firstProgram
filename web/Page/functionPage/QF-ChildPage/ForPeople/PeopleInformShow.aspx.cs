using DAL.DataControl.TableControl;
using DAL.DataControl.ViewControl;
using DAL.DataObject.TableObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm.Page.functionPage.QF_ChildPage.ForPeople
{
    public partial class PeopleInformShow : System.Web.UI.Page
    {

        public string TableName
        {
            get
            {
                //return tableName; 
                return Request.QueryString["tablename"];
            }
            //set { tableName = value; }
        }

        //static string idLable;
        public string IdLable
        {
            get { return Request.QueryString["idlable"]; }
            //set
            //{
            //    idLable = value;
            //}
        }

        //static string id;
        public string Id
        {
            get
            {
                return Request.QueryString["id"];
            }
            //set
            //{
            //    id = value;
            //}
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            PeopleInf.PageData = (PeopleData)(new PeopleControl()).SelectReturnObject(PeopleControl.BuildWhereClause(new Dictionary<string, string>() { { "PeopleBase.PEB_ID", Id } }));
        }
    }
}