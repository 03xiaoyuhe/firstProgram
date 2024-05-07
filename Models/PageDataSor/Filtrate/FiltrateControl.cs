using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.PageDataSor.Filtrate
{
    public class FiltrateControl
    {
        static FiltrateData data;
        static public FiltrateData Data
        {
            get
            {
                if(data == null) data= new FiltrateData();
                return data;
            }
            set
            {
                data = value;
            }
        }
    }
}
