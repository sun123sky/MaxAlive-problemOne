using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxAlive.Model
{
    public class People
    {
        public string Name { get; }
        public int BornYear { get;}
        public int DieYear { get; }

        public People(string name, int bornYear, int dieYear)
        {
            Name = name;
            BornYear = bornYear;
            DieYear = dieYear;
        }
        
    }
}
