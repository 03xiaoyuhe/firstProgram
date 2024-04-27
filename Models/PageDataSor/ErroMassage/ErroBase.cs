using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using System.Web.UI;

namespace Models.PageDataSor.ErroMassage
{
    public enum ErroState{Unsolve, Solve};
    public enum ErroKids { LineAbsent, LineUnValid, DataUnValid, ProjectExist, NameUnClassify};
    public class ErroBase : UserControl
    {
        ErroKids kids;
        public ErroKids Kids 
        {
            get { return kids; }
            set { kids = value; }
        }

        ErroState state;
        public ErroState ErroState
        {
            get
            {
                return state;
            }
            set 
            { 
                state = value;
            }
        }

    }
}
