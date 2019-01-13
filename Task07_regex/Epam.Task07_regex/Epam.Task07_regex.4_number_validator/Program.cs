using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Epam.Task07_regex.WorkWithRegex;

namespace Epam.Task07_regex._4_number_validator
{
    public class Program
    {
        private static string regForNumber = @"^[-+]?\d+(\.?\d+)?$";
        private static string regForENumber = @"^[-+]?\d\.\d+[eE][+-]?\d+$";

        public static void Main(string[] args)
        {
            WorkWithRegexInConsole findNumberInRegex = new WorkWithRegexInConsole(4, regForNumber);

            if (findNumberInRegex.GetAllMatches().Count > 0)
            {
                Console.WriteLine("Input string is a number in ordinary notation");
                return;
            }

            WorkWithRegexInConsole findENumberInRegex = new WorkWithRegexInConsole(4, regForENumber, false);
            findENumberInRegex.InputString = findNumberInRegex.InputString;
            if (findENumberInRegex.GetAllMatches().Count > 0)
            {
                Console.WriteLine("Input string is a number in scientific notation");
                return;
            }

            Console.WriteLine("Input string is not a number.");
        }
    }
}
