using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.PageDataSor.ErroMassage
{
    public class LineAbsentOrUnValidErro : ErroBase
    {
        string lineName;
        public string LineName
        {
            get
            {
                return lineName;
            }
            set
            {
                lineName = value;
            }
        }
    }
}
