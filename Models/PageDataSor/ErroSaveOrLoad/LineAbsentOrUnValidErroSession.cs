using Models.PageDataSor.ErroMassage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace Models.PageDataSor.ErroSaveOrLoad
{
    public class LineAbsentOrUnValidErroSession : UserControl
    {
        /// <summary>
        /// 放置行缺失错误
        /// </summary>
        public List<LineAbsentOrUnValidErro> LineAbsentErro
        {
            get
            {
                return Session["LineAbsentErro"] as List<LineAbsentOrUnValidErro>;
            }
            set
            {
                Session["LineAbsentErro"] = value;
            }
        }


        /// <summary>
        /// 放置无法识别的行错误
        /// </summary>
        public List<LineAbsentOrUnValidErro> LineUnValidErro
        {
            get
            {
                return Session["LineUnValidErro"] as List<LineAbsentOrUnValidErro>;
            }
            set
            {
                Session["LineUnValidErro"] = value;
            }
        }
    }
}
