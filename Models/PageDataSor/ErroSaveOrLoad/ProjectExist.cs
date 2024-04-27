using Models.PageDataSor.ErroMassage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
