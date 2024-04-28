using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataRowToClass
{
    public class ParticipantInform
    {
        DataRow dataRow;
        public DataRow DataRow
        {
            get
            {
                return dataRow;
            }
            set
            {
                dataRow = value;
            }
        }

    }
}
