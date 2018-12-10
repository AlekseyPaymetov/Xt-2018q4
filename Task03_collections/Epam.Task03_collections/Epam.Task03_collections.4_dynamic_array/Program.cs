using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task03_collections._4_dynamic_array
{
    public class Program
    {
        private static int[] numbers = { 1, 17, 3, 1988 };

        public static void Main(string[] args)
        {
            try
            {
                DynamycArrayHardcoreMode<int> testArray = new DynamycArrayHardcoreMode<int>(numbers);
                testArray.Add(88);
                Console.WriteLine("Default data with added\"88\":");
                testArray.ShowDataOnConsole();
                Console.WriteLine($"-3 elemtnnt: {testArray[-3]}");
                testArray.Capacity = 2;
                Console.WriteLine("Capacity of dynamic array became 2:");
                testArray.ShowDataOnConsole();
                Console.WriteLine("...Cloning dynamic array...");
                DynamycArrayHardcoreMode<int> cloneArray = (DynamycArrayHardcoreMode<int>)testArray.Clone();
                Console.WriteLine("Add for default dynamic array \"88\":");
                testArray.Add(88);
                testArray.ShowDataOnConsole();
                Console.WriteLine("It's clone dynamic array:");
                cloneArray.ShowDataOnConsole();
                int[] array = testArray.ToArray();
                Console.WriteLine("This is array: ");
                for (int i = 0; i < array.Length; i++)
                {
                    Console.WriteLine(array[i]);
                }

                Console.Write("For start CycledDynamicArray please enter any key: ");
                Console.ReadLine();
                CycledDynamicArray<int> cycledArray = new CycledDynamicArray<int>(testArray);
                foreach (var item in cycledArray)
                {
                    Console.Write($"{item} ");
                }
            }
            catch
            {
                Console.WriteLine("Error");
            }
        }
    }
}
