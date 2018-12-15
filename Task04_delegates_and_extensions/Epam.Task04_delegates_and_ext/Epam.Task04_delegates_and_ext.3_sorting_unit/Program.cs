using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Epam.Task04_delegates_and_ext._3_sorting_unit
{
    public class Program
    {
        private static string[] someStrings1 = new string[] { "Manga", "is", "a", "good", "thing", ".", "And", "now", "i", "am", "typing", "some", "words", "..." };

        private static string[] someStrings2 = new string[] { "string1", "some_text", "abc", "ab", "abc", "abc", "1029" };

        private static int[] someCollectionOfInt = new int[] { -2, 3, 5, 101, -90, 33, 0, -45, -67 };

        public static void Main(string[] args)
        {
            try
            {
                SortingUnit<string> sU1 = new SortingUnit<string>(someStrings1);
                SortingUnit<string> sU2 = new SortingUnit<string>(someStrings2);
                SortingUnit<int> sU3 = new SortingUnit<int>(someCollectionOfInt, MyCompare);
                Console.WriteLine("First array of strings: ");
                sU1.ShowOnConsole();
                Console.WriteLine($"{Environment.NewLine}Another array of strings: ");
                sU2.ShowOnConsole();
                Console.WriteLine($"{Environment.NewLine}Some array of integer: ");
                sU3.ShowOnConsole();
                Console.WriteLine($"{Environment.NewLine}And now the sorting of it's 3 arrays begin at the same time! Please wait.");
                Thread.Sleep(500);
                sU1.MySortInThread();
                sU2.MySortInThread();
                sU3.MySortInThread();
            }
            catch
            {
                Console.WriteLine("Something wrong... ;(");
            }
        }

        private static int MyCompare(int x, int y)
            => Math.Abs(x) - Math.Abs(y);
    }
}
