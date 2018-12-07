using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task03_collections._1_lost
{
    public class Program
    {
        private static string[] nameOfPeople = { "Aleksey", "Alexander", "artem", "Alexey", "Dmitriy", "Egor", "Gleb", "Roman", "Alexei", "Anastasiya", "Anderei", "Elisey", "irina", "Kirill" };

        private static Random rng = new Random();
        private static LinkedList<string> list = new LinkedList<string>();

        public static void Main(string[] args)
        {
            UI(out int n);
            GenerateList(n);
            Console.WriteLine($"{Environment.NewLine}Random round of people: ");
            ShowList();
            Console.WriteLine($"{Environment.NewLine}Then deleted every 2nd man: ");
            while (list.Count>1)
            {
                DelEveryTwo();
                ShowList();
            }
            
        }

        private static void GenerateList(int n)
        {
            StringBuilder buildName = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                buildName.Clear();
                buildName.Append(i + 1 + ": ");
                buildName.Append(nameOfPeople[rng.Next(nameOfPeople.Length)]);
                list.AddLast(buildName.ToString());
            }
        }

        private static void ShowList()
        {
            Console.WriteLine();
            foreach (var item in list)
            {
                Console.Write(item + "; ");
            }

            Console.WriteLine();
        }

        private static void DelEveryTwo()
        {
            string[] array = new string[list.Count];
            int i = 0;
            foreach (var item in list)
            {
                array[i] = item;
                i++;
            }

            list.Clear();
            for (i = 1; i <= array.Length; i++)
            {
                if (i % 2 == 0)
                {
                    continue;
                }

                list.AddLast(array[i - 1]);
            }
        }

        private static void UI(out int n)
        {
            Console.Write("Please enter number of people N: ");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out n))
            {
                Console.WriteLine("Incorrect input");
                return;
            }

            if (n < 0)
            {
                Console.WriteLine("Input number should be positive");
                return;
            }
        }
    }
}
