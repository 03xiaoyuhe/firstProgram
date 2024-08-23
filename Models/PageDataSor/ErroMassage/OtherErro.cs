using System.Data;

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
