using Models.PageDataSor.ErroMassage;
using System.Collections.Generic;
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
