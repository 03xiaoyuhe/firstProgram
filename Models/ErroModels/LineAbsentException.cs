using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ErroModels
{
    public class LineAbsentException : Exception
    {
        public LineAbsentException(string Message) : base(Message)
        {

        }
    }
}
