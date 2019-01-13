using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Epam.Task07_regex.WorkWithRegex;

namespace Epam.Task07_regex._2_html_replacer
{
    public class Program
    {
        private static string openTag = @"<\w+.*?>";
        private static string closeTag = @"</\w+?>";

        private static string changeOn = "_";

        public static void Main(string[] args)
        {
            WorkWithRegexInConsole openTagInRegex = new WorkWithRegexInConsole(2, openTag);
            string inputString = openTagInRegex.InputString;
            WorkWithRegexInConsole closeTagInRegex = new WorkWithRegexInConsole(2, closeTag, false);
            closeTagInRegex.InputString = inputString;
            MatchCollection openTagMatches = openTagInRegex.GetAllMatches();
            MatchCollection closeTagMatches = closeTagInRegex.GetAllMatches();
            string result = inputString;

            foreach (var item in openTagMatches)
            {
                int startIndex = result.IndexOf(item.ToString());
                result = result.Remove(startIndex, item.ToString().Length).Insert(startIndex, changeOn);
            }

            foreach (var item in closeTagMatches)
            {
                int startIndex = result.IndexOf(item.ToString());
                result = result.Remove(startIndex, item.ToString().Length).Insert(startIndex, changeOn);
            }

            Console.WriteLine();
            Console.WriteLine("Input string: ");
            Console.WriteLine(inputString);
            Console.WriteLine("Changed input string: ");
            Console.WriteLine(result);

            result = openTagInRegex.ExampleString;
            openTagMatches = openTagInRegex.GetAllMatchesInExample();
            closeTagMatches = closeTagInRegex.GetAllMatchesInExample();
            foreach (var item in openTagMatches)
            {
                int startIndex = result.IndexOf(item.ToString());
                result = result.Remove(startIndex, item.ToString().Length).Insert(startIndex, changeOn);
            }

            foreach (var item in closeTagMatches)
            {
                int startIndex = result.IndexOf(item.ToString());
                result = result.Remove(startIndex, item.ToString().Length).Insert(startIndex, changeOn);
            }

            Console.WriteLine();
            Console.WriteLine("Example string: ");
            Console.WriteLine(closeTagInRegex.ExampleString);
            Console.WriteLine("Changed example string: ");
            Console.WriteLine(result);
        }
    }
}
