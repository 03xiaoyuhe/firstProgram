using System;
using System.Collections.Generic;
using System.Web;

namespace WebForm.functionPage
{
    public partial class TestP : System.Web.UI.Page
    {

        Dictionary<string, HttpPostedFile> files = new Dictionary<string, HttpPostedFile>();
        public Dictionary<string, HttpPostedFile> Files
        {
            get
            {
                return test.Files;
            }
            set
            {
                test.Files = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}