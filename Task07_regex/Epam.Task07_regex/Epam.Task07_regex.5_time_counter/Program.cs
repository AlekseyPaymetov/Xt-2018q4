using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Epam.Task07_regex.WorkWithRegex;

namespace Epam.Task07_regex._5_time_counter
{
    public class Program
    {
        private static string reg0 = @"\d:[0,5]\d";
        private static string reg1 = @"1\d:[0,5]\d";
        private static string reg2 = @"2[0,4]:[0,5]\d";

        public static void Main(string[] args)
        {
            int summaryCount = 0;
            Console.WriteLine("Please input string: ");
            string inputString = Console.ReadLine();
            summaryCount += FindMatches(reg0, inputString);
            summaryCount += FindMatches(reg1, inputString);
            summaryCount += FindMatches(reg2, inputString);
            Console.WriteLine($"Time in this string is present {summaryCount} times.{Environment.NewLine}");

            inputString = "В 7:55 я встал, позавтракал и к 10:77 пошёл на работу.";
            summaryCount = 0;
            summaryCount += FindMatches(reg0, inputString);
            summaryCount += FindMatches(reg1, inputString);
            summaryCount += FindMatches(reg2, inputString);
            Console.WriteLine($"{Environment.NewLine}Example:");
            Console.WriteLine(inputString);
            Console.WriteLine($"Time in this example is present {summaryCount} times.{Environment.NewLine}");
        }

        private static int FindMatches(string reg, string workString)
        {
            WorkWithRegexInConsole workWithRegex = new WorkWithRegexInConsole(5, reg, false);
            workWithRegex.InputString = workString;
            MatchCollection matches = workWithRegex.GetAllMatches();
            return matches.Count;
        }
    }
}
