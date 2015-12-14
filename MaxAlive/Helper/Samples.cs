using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxAlive.Model;

namespace MaxAlive.Helper
{
    /// <summary> 
    /// Samples class using random to Generate a list of People object contains born/die years 
    /// Assumption1: People's live is less than 100 years. 
    /// Assumption2: People can born before 1900, and die after 2000. so born range is (1800,2000), die rang(1900,2100)
    /// Assumption3: If a person born or die in a certain year, that partial year still count as alive.
    /// </summary>
    public class Samples
    {
        /// <summary>
        /// Random generate a sample list of People that born or die year overlap range 1900-2000
        /// </summary>
        /// <param name="quantity"># of people to be sampled</param>
        /// <returns>list of people objects contain born and death year</returns>
        public static List<People> GeneratePeopleslList(int quantity)
        {
            List<People> peoples = new List<People>();
            Random r = new Random();
            Random d = new Random();
            
            for (int i = 0; i < quantity; i++)
            {
                int bornYear =r.Next((1900-100)+d.Next(0,100), 2000);
                int dieYear = r.Next(Process.GetLeftBound(bornYear), (bornYear+101)); //getLeftBound will guarantee die year has to be >= 1900
                peoples.Add(new People("Person"+i.ToString(),bornYear,dieYear)); 
            }
            return peoples;
        }
    }
}
