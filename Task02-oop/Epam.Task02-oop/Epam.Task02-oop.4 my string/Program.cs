using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02_oop._4_my_string
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Please input some string1: ");
            string string1 = Console.ReadLine();
            Console.Write("Please input some string2: ");
            string string2 = Console.ReadLine();

            MyString myString1 = new MyString(string1);
            MyString myString2 = new MyString(string2);

            Console.WriteLine("string1 as string: {0}", myString1.ToString());
            Console.WriteLine($"string concatenation: {myString1 + myString2}");
            if (myString1 > myString2)
            {
                Console.WriteLine("string1 > string2");
            }

            if (myString1 < myString2)
            {
                Console.WriteLine("string1 < string2");
            }

            if (myString1 == myString2)
            {
                Console.WriteLine("string1 == string2");
            }
            else
            {
                Console.WriteLine("string1 != string2");
            }

            if (myString1 >= myString2)
            {
                Console.WriteLine("string1 >= string2");
            }

            if (myString1 <= myString2)
            {
                Console.WriteLine("string1 <= string2");
            }

            if (myString1.IndexOf('a') >= 0)
            {
                Console.WriteLine($"String1 has symbol 'a'. It's index is: {myString1.IndexOf('a')}.");
            }
            else
            {
                Console.WriteLine($"String1 has not symbol 'a'.");
            }

            if (myString1.IndexOf(myString2) >= 0)
            {
                Console.WriteLine("String1 has string2 as substring.");
            }
            else
            {
                Console.WriteLine("String1 has not string2 as substring.");
            }
        }
    }
}
