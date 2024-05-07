using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Models.PageDataSor.Filtrate
{
    public class FiltrateData
    {
        public HashSet<string> this[string index]
        {
            get
            {
                return CacheGenericity<HashSet<string>>.Data[$"Filtrate-Choose-{index}"];
            }
            set
            {
                CacheGenericity<HashSet<string>>.Data[$"Filtrate-Choose-{index}"] = value;
            }
        }
    }
}
