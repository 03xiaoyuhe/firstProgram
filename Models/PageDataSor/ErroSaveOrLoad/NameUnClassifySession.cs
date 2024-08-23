using Models.PageDataSor.ErroMassage;
using System.Collections.Generic;
using System.Web.UI;

namespace Models.PageDataSor.ErroSaveOrLoad
{
    public class NameUnClassifySession : UserControl
    {

        public List<OtherErro> NameUnClassifyErro
        {
            get
            {
                return Session["NameUnClassifyErro"] as List<OtherErro>;
            }
            set
            {
                Session["NameUnClassifyErro"] = value;
            }
        }

        public void Clear()
        {
            Session["NameUnClassifyErro"] = null;
        }
    }
}
