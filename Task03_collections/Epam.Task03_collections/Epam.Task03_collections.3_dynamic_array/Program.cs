using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task03_collections._3_dynamic_array
{
    public class Program
    {
        private static string[] nameOfPeople = { "Aleksey", "Alexander", "artem", "Alexey", "Dmitriy" };

        public static void Main(string[] args)
        {
            try
            {
                DynamicArray<string> testArray = new DynamicArray<string>(nameOfPeople);
                testArray.Add("Max");
                testArray.ShowDataOnConsole();
                Console.WriteLine(testArray[1]);
            }
            catch
            {
                Console.WriteLine("error");
            }
        }
    }
}
