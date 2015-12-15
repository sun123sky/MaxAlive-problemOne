using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MaxAlive.Model;

namespace MaxAlive
{
    public class Process
    {
     /// <summary>
        /// Calculate the year(years) with the most number of people alive.
        /// </summary>
        /// <param name="peoples">list of peoples, each people has name, bornYear, dieYear</param>
        /// <returns>A list of (year,count) pair that most people alive</returns>
        public static Dictionary<int, int> GetYearofMaxAlive(List<People> peoples)
     {
            //if people born die in range (1950-1970), the hash table will only open rows for 1950-1970
         var min =GetLeftBound(peoples.Min(m => m.BornYear));
         var max =GetRightBound(peoples.Max(a => a.DieYear));

            //Console.WriteLine("min: " + min + Environment.NewLine + "max: "+ max);

            Dictionary<int, int> yearHolder = new Dictionary<int, int>();
            for (int i = min; i <= max; i++)
            {

                var alive = peoples.Where(a => ((a.BornYear <= i) && (a.DieYear) >= i));
                yearHolder.Add(i,alive.Count());
            }
            //find Max year, 
            int maxLives = yearHolder.Values.Max();
            //subset year,count pair from original library that contains Max value.
            var resultYears = yearHolder.Where(a => a.Value == maxLives).ToDictionary(dict => dict.Key, dict => dict.Value);

            return resultYears;
        }
        /// <summary>
        /// 2nd approach: iterate through people once and for each person, mark the corresponding live year cells in dictionary.
        /// </summary>
        /// <param name="peoples"></param>
        /// <returns></returns>
        public static Dictionary<int, int> GetYearofMaxAlive2(List<People> peoples)
        {
            Dictionary<int, int> yearHolder = new Dictionary<int, int>();
            for (int i = 1900; i < 2001; i++)
            {
                yearHolder.Add(i, 0);
            }
            foreach (var p in peoples)
            {
                int leftB = GetLeftBound(p.BornYear);
                int rightB = GetRightBound(p.DieYear);
                if (leftB != -1 && rightB != -1)
                {
                    //loop from lower to upper year bound to mark for this person's lived years.
                    for (int i = leftB; i <= rightB; i++)
                    {
                        yearHolder[i] = yearHolder[i] + 1;
                    }
                }
            }
            //find Max year, 
            int maxLives = yearHolder.Values.Max();
            //subset year,count pair from original library that contains Max value.
            var resultYears = yearHolder.Where(a => a.Value == maxLives).ToDictionary(dict => dict.Key, dict => dict.Value);

            return resultYears;
        }






        /// <summary>
        /// Compare birth year with time range (1900-2000) and get the beginning marking key that within yearholder range        
        /// </summary>
        /// <param name="born">birth year</param>
        /// <returns>beginning alive year to be marked</returns>
        public static int GetLeftBound(int born)
        {
            int leftBound;
            if (born < 1900)
            {
                leftBound = 1900;
            }
            else if (born >= 1900 && born <= 2000)
            {
                leftBound = born;
            }
            else
            {
                leftBound = -1;
            }
            return leftBound;
        }

        /// <summary>
        /// Compare death year with time range(1900-2000) and get the ending marking key that within yearholder range
        /// </summary>
        /// <param name="death">death year</param>
        /// <returns>ending alive year to be marked</returns>
        public static int GetRightBound(int death)
        {
            int rightBound;
            if (death >= 1900 && death <= 2000)
            {
                rightBound = death;
            }
            else if (death > 2000)
            {
                rightBound = 2000;
            }
            else //(death < 1900) and other invalid cases, never alived in rang 1900-2000
            {
                rightBound = -1;
            }
            return rightBound;
        }

        public static void tryBranch()
        {
            
        }
    }
}