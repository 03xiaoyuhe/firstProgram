using System.Collections.Generic;

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
