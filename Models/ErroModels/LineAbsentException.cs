using System;

namespace Models.ErroModels
{
    public class LineAbsentException : Exception
    {
        public LineAbsentException(string Message) : base(Message)
        {

        }
    }
}
