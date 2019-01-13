using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Epam.Task07_regex.WorkWithRegex;

namespace Epam.Task07_regex._1_date_existance
{
    public class Program
    {
        private static string reg = @"\d{2}-\d{2}-\d{4}";

        public static void Main(string[] args)
        {
            WorkWithRegexInConsole workWithRegex = new WorkWithRegexInConsole(1, reg);
            MatchCollection matches = workWithRegex.GetAllMatches();
            string find = "no ";
            if (matches.Count > 0)
            {
                foreach (var item in matches)
                {
                    if (DateTime.TryParse(item.ToString(), out DateTime notUsedDate))
                    {
                        find = string.Empty;
                        break;
                    }
                }
            }

            Console.WriteLine($"Input string \"{workWithRegex.InputString}\" has {find}date.");

            find = "no ";
            matches = workWithRegex.GetAllMatchesInExample();
            if (matches.Count > 0)
            {
                foreach (var item in matches)
                {
                    if (DateTime.TryParse(item.ToString(), out DateTime notUsedDate))
                    {
                        find = string.Empty;
                        break;
                    }
                }
            }

            Console.WriteLine($"Example string \"{workWithRegex.ExampleString}\" has {find}date.");
        }
    }
}
