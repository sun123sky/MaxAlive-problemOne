using System;
using System.Collections.Generic;
//using System.Diagnostics.Eventing.Reader;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using MaxAlive.Helper;
using MaxAlive.Model;

namespace MaxAlive
{
    class Program
    {
        /// <summary>
        /// Main entry of the whole application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            if (args.Length == 0) throw new ArgumentException("Argument is empty collection", nameof(args));
            do
            {
                MainProcedure();
            } while (AskTryAgain());
        }

        /// <summary>
    /// user has option to make another sample or quit program
    /// </summary>
    /// <returns></returns>
     private static Boolean AskTryAgain()
        {
            bool doAgain = false;
            Console.WriteLine("TryAgain? Y/N:");
            string input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                if (input.ToUpper() == "Y" || input.ToUpper() == "YES")
                {
                    doAgain = true;
                }
            }
            return doAgain;
        }

        /// <summary>
        /// Main steps 1. Generate a list of people and print on screen; 2. GetYearofMaxAlive and output to screen
        /// </summary>
        private static void MainProcedure()
        {
            int sampleQuantity;
            Console.WriteLine("Please enter number of people as sample:");

            try
            {
                if (Int32.TryParse(Console.ReadLine(), out sampleQuantity))
                {
                    Console.WriteLine("Input # of people to be generated: " + sampleQuantity);
                    if (sampleQuantity > 0)
                    {
                        List<People> peoples = Samples.GeneratePeopleslList(sampleQuantity);
                        Dictionary<int, int> resultYears = Process.GetYearofMaxAlive(peoples);
                        foreach (var p in peoples)
                        {
                            Console.WriteLine(p.Name + " " + p.BornYear + " " + p.DieYear);
                        }
                        Console.WriteLine(Environment.NewLine + "Max Year/Years people alive:");
                        Console.WriteLine("Year: " + "NumberofAlives");
                        foreach (var y in resultYears)
                        {
                            Console.WriteLine(y.Key + ": " + y.Value);
                        }
                    }
                    else
                    {
                        Console.WriteLine("zero input, nothing processed!");
                    }


                }
                else
                {
                    Console.WriteLine("Please enter a valid number");
                }
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
