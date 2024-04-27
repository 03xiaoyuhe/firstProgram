using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.PageDataSor.ErroMassage
{
    public class OtherErro : ErroBase
    {
        public DataRow dataRow;

        string erroIndex;
        public string ErroIndex
        {
            get
            {
                return erroIndex;
            }
            set
            {
                erroIndex = value;
            }
        }

    }
}
