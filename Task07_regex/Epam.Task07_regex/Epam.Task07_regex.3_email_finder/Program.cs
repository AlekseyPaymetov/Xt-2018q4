using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Epam.Task07_regex.WorkWithRegex;

namespace Epam.Task07_regex._3_email_finder
{
    public class Program
    {
        private static string reg = @"\w[\w\.-_]+@[-\w+\.]+\.[A-zА-яЁё]{2,6}";

        public static void Main(string[] args)
        {
            WorkWithRegexInConsole workWithEmailRegex = new WorkWithRegexInConsole(3, reg);
            MatchCollection matches = workWithEmailRegex.GetAllMatches();
            Console.WriteLine("Found email addresses:");
            foreach (var item in matches)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine();
            Console.WriteLine($"For example:{Environment.NewLine}{workWithEmailRegex.ExampleString}{Environment.NewLine}Found email addresses:");
            matches = workWithEmailRegex.GetAllMatchesInExample();
            foreach (var item in matches)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
