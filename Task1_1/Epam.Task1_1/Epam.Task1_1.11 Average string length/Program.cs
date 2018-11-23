using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1_1._11_Average_string_length
{

    class Program
    {

        static bool IsSymbol(char c) =>
            (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');

        static void Main(string[] args)
        {
            Console.WriteLine("Please input a string:");
            string s=Console.ReadLine();
            char[] arrayOfChars = s.ToArray();

            bool wordStarted = false;
            int countOfWords = 0;
            int countOfSymblosInWords = 0;
            
            for (int i=0; i<arrayOfChars.Length; i++)
            {
                
                if (IsSymbol(arrayOfChars[i]))
                {
                    countOfSymblosInWords++;
                    wordStarted = true;
                }
                else
                {
                    if (wordStarted)
                    {
                        wordStarted = false;
                        countOfWords++;
                    } 
                }
            }

            if (IsSymbol(arrayOfChars[arrayOfChars.Length-1]))
            {
                countOfWords++;
            }
            Console.WriteLine("Avarage length of words is: {0:0.###}",(double)countOfSymblosInWords/(countOfWords));

        }
    }
}
