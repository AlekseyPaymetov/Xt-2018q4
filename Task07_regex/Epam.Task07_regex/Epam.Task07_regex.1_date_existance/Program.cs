using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.Task07_regex._1_date_existance
{
    public class Program
    {
        private static string inputString = string.Empty;
        private static Regex regex = new Regex(@"\d{2}-\d{2}-\d{4}");

        public static void Main(string[] args)
        {
            Console.WriteLine("Please input a sting:");
            inputString = Console.ReadLine();
            FindRegexAndShowResultOnConsole();

            Console.WriteLine();
            Console.WriteLine("For example in task: ");
            inputString = "2020 год наступит 01-01-2020";
            FindRegexAndShowResultOnConsole();
        }

        private static void ShowResult(bool find = false)
        {
            if (find)
            {
                Console.WriteLine($"Input string \"{inputString}\" has date.");
            }
            else
            {
                Console.WriteLine($"Input string \"{inputString}\" has not date.");
            }
        }

        private static void FindRegexAndShowResultOnConsole()
        {
            MatchCollection matches = regex.Matches(inputString);
            if (matches.Count > 0)
            {
                foreach (var item in matches)
                {
                    if (DateTime.TryParse(item.ToString(), out DateTime someTempDate))
                    {
                        ShowResult(true);
                        return;
                    }
                }

                ShowResult();
            }
            else
            {
                ShowResult();
            }
        }
    }
}
