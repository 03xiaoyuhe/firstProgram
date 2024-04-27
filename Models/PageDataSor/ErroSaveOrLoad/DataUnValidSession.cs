using Models.PageDataSor.ErroMassage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace Models.PageDataSor.ErroSaveOrLoad
{
    public class DataUnValidErroSession : UserControl
    {
        public List<OtherErro> DataUnValidErro
        {
            get
            {
                return Session["DataUnValidErro"] as List<OtherErro>;
            }
            set
            {
                Session["DataUnValidErro"] = value;
            }
        }

        public void Clear()
        {
            Session["DataUnValidErro"] = null;
        }

    }
}
