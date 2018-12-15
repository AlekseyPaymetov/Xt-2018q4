using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Epam.Task04_delegates_and_ext._6_i_seek_you
{
    public class Program
    {
        private const int NumberOfElentsInList = 1000000;
        private const int NumberOfTests = 100;
        private const int MinRngVallue = -10000;
        private const int MaxRngValue = 10000;

        private static Random rng = new Random();
        private static int[] someIntArray = new int[NumberOfElentsInList];

        public static List<int> SimpleGetPositive(IEnumerable<int> collection)
        {
            var newCollection = new List<int>();
            foreach (var item in collection)
            {
                if (item >= 0)
                {
                    newCollection.Add(item);
                }
            }

            return newCollection;
        }

        public static List<int> GetPositive(IEnumerable<int> collection, Predicate<int> predicate)
        {
            var newCollection = new List<int>();
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    newCollection.Add(item);
                }
            }

            return newCollection;
        }

        public static void CreateRandomList(ref List<int> list)
        {
            list.Clear();
            for (int i = 0; i < NumberOfElentsInList; i++)
            {
                list.Add(rng.Next(MinRngVallue, MaxRngValue));
            }
        }

        public static bool OnlyPositive(int x)
            => x >= 0;

        public static double GetMedian(int[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("Array with times is empty");
            }

            Array.Sort(array);
            if (array.Length % 2 == 0)
            {
                int index = (array.Length / 2) - 1;
                return (array[index] + array[index + 1]) / 2;
            }

            return array[(array.Length / 2) + 1];
        }

        public static double MakeCalc(int option)
        {
            if (option < 0 || option > 5)
            {
                throw new ArgumentException("Wrong value of option");
            }

            List<int> list = new List<int>();
            list.Capacity = NumberOfElentsInList * 5;
            Stopwatch sw = new Stopwatch();
            int[] arrayForMs = new int[NumberOfTests];
            for (int i = 0; i < arrayForMs.Length; i++)
            {
                CreateRandomList(ref list);
                switch (option)
                {
                    case 1:
                        sw.Start();
                        SimpleGetPositive(list);
                        break;
                    case 2:
                        sw.Start();
                        Predicate<int> predicate = OnlyPositive;
                        GetPositive(list, predicate);
                        break;
                    case 3:
                        sw.Start();
                        GetPositive(list, delegate(int x) { return x >= 0; });
                        break;
                    case 4:
                        sw.Start();
                        GetPositive(list, x => x >= 0);
                        break;
                    case 5:
                        sw.Start();
                        var requst = (from item in list
                                      where item >= 0
                                      select item).ToList<int>();
                        break;
                }

                sw.Stop();
                TimeSpan ts = sw.Elapsed;
                arrayForMs[i] = ts.Milliseconds;
                sw.Reset();
            }

            return GetMedian(arrayForMs);
        }

        public static void ShowMessage(int i)
        {
            Console.WriteLine($"For paragraph {i} time is: {MakeCalc(i)}ms");
        }

        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine($"Please wait a several seconds.{Environment.NewLine}{Environment.NewLine}You can change numberOfElentsInList or/and numberOfTests in programm for change working time. {Environment.NewLine}");
                for (int i = 1; i < 6; i++)
                {
                    ShowMessage(i);
                }
            }
            catch
            {
                Console.WriteLine("Somthing wrong...");
            }

            Console.WriteLine();
        }
    }
}
