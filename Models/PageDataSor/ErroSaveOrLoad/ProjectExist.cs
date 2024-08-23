using Models.PageDataSor.ErroMassage;
using System.Collections.Generic;
using System.Web.UI;

namespace Models.PageDataSor.ErroSaveOrLoad
{
    public class ProjectExistSession : UserControl
    {

        public List<OtherErro> ProjectExistErro
        {
            get
            {
                return Session["ProjectExistErro"] as List<OtherErro>;
            }
            set
            {
                Session["ProjectExistErro"] = value;
            }
        }

        public void Clear()
        {
            Session["ProjectExistErro"] = null;
        }
    }
}
