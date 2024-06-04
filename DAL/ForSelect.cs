using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ForSelect
    {
        static public DataSet Select(string DataBash, string DataLine, string LikeString)
        {
            string DataLikeString = "%";
            for(int i = 0; i < LikeString.Length; i++) 
            {
                DataLikeString += $"{LikeString[i]}%";
            }
            return DBHelper.Query($"select * from {DataBash} where {DataLikeString}");
        }
    }
}
