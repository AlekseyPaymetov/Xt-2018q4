using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02_oop._1_Round
{
    public class Program
    {
        private static void Main(string[] args)
        {
            string inputLine;

            Console.Write("Please enter x: ");
            inputLine = Console.ReadLine();
            if (!double.TryParse(inputLine, out double x))
            {
                Console.WriteLine("Incorrect input");
                return;
            }

            Console.Write("Please enter y: ");
            inputLine = Console.ReadLine();
            if (!double.TryParse(inputLine, out double y))
            {
                Console.WriteLine("Incorrect input");
                return;
            }

            Console.Write("Please enter radius: ");
            inputLine = Console.ReadLine();
            if (!double.TryParse(inputLine, out double radius))
            {
                Console.WriteLine("Incorrect input");
                return;
            }

            try
            {
                Round someRound = new Round(x, y, radius);

                Console.WriteLine("Length of input round: {0:.000}", someRound.Length);
                Console.WriteLine("Area of input round: {0:.000}", someRound.Area);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
