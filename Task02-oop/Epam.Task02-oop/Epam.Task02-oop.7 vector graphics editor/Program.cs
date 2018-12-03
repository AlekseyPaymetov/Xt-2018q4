using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02_oop._7_vector_graphics_editor
{
    public class Program
    {
        private static List<Shape> shapes = new List<Shape>();

        public static Line CreateLine()
        {
            string input;
            Console.Write("Please enter x1: ");
            input = Console.ReadLine();
            if (!double.TryParse(input, out double x1))
            {
                throw new ArgumentException("Incorrect input");
            }

            Console.Write("Please enter y1: ");
            input = Console.ReadLine();
            if (!double.TryParse(input, out double y1))
            {
                throw new ArgumentException("Incorrect input");
            }

            Console.Write("Please enter x2: ");
            input = Console.ReadLine();
            if (!double.TryParse(input, out double x2))
            {
                throw new ArgumentException("Incorrect input");
            }

            Console.Write("Please enter y2: ");
            input = Console.ReadLine();
            if (!double.TryParse(input, out double y2))
            {
                throw new ArgumentException("Incorrect input");
            }

            return new Line(x1, y1, x2, y2);
        }

        public static Circle CreateCircle()
        {
            string input;
            Console.Write("Please enter x: ");
            input = Console.ReadLine();
            if (!double.TryParse(input, out double x))
            {
                throw new ArgumentException("Incorrect input");
            }

            Console.Write("Please enter y: ");
            input = Console.ReadLine();
            if (!double.TryParse(input, out double y))
            {
                throw new ArgumentException("Incorrect input");
            }

            Console.Write("Please enter radius: ");
            input = Console.ReadLine();
            if (!double.TryParse(input, out double radius))
            {
                throw new ArgumentException("Incorrect input");
            }

            return new Circle(x, y, radius);
        }

        public static Rectangle CreateRectangle()
        {
            string input;
            Console.Write("Please enter x1: ");
            input = Console.ReadLine();
            if (!double.TryParse(input, out double x1))
            {
                throw new ArgumentException("Incorrect input");
            }

            Console.Write("Please enter y1: ");
            input = Console.ReadLine();
            if (!double.TryParse(input, out double y1))
            {
                throw new ArgumentException("Incorrect input");
            }

            Console.Write("Please enter x2: ");
            input = Console.ReadLine();
            if (!double.TryParse(input, out double x2))
            {
                throw new ArgumentException("Incorrect input");
            }

            Console.Write("Please enter y2: ");
            input = Console.ReadLine();
            if (!double.TryParse(input, out double y2))
            {
                throw new ArgumentException("Incorrect input");
            }

            return new Rectangle(x1, y1, x2, y2);
        }

        public static Round CreateRound()
        {
            string input;
            Console.Write("Please enter x: ");
            input = Console.ReadLine();
            if (!double.TryParse(input, out double x))
            {
                throw new ArgumentException("Incorrect input");
            }

            Console.Write("Please enter y: ");
            input = Console.ReadLine();
            if (!double.TryParse(input, out double y))
            {
                throw new ArgumentException("Incorrect input");
            }

            Console.Write("Please enter radius: ");
            input = Console.ReadLine();
            if (!double.TryParse(input, out double radius))
            {
                throw new ArgumentException("Incorrect input");
            }

            return new Round(x, y, radius);
        }

        public static Ring CreateRing()
        {
            string input;
            Console.Write("Please enter x: ");
            input = Console.ReadLine();
            if (!double.TryParse(input, out double x))
            {
                throw new ArgumentException("Incorrect input");
            }

            Console.Write("Please enter y: ");
            input = Console.ReadLine();
            if (!double.TryParse(input, out double y))
            {
                throw new ArgumentException("Incorrect input");
            }

            Console.Write("Please enter inner radius: ");
            input = Console.ReadLine();
            if (!double.TryParse(input, out double innerRadius))
            {
                throw new ArgumentException("Incorrect input");
            }

            Console.Write("Please enter outer radius: ");
            input = Console.ReadLine();
            if (!double.TryParse(input, out double outerRadius))
            {
                throw new ArgumentException("Incorrect input");
            }

            return new Ring(x, y, innerRadius, outerRadius);
        }

        public static void AddShape(int number)
        {
            switch (number)
            {
                case 0:
                    foreach (var shape in shapes)
                    {
                        shape.Show();
                    }

                    break;
                case 1:
                    shapes.Add(CreateLine());
                    break;
                case 2:
                    shapes.Add(CreateCircle());
                    break;
                case 3:
                    shapes.Add(CreateRectangle());
                    break;
                case 4:
                    shapes.Add(CreateRound());
                    break;
                case 5:
                    shapes.Add(CreateRing());
                    break;
                default:
                    Console.WriteLine("Incorrect input number");
                    break;
            }
        }

        public static void Menu()
        {
            string readLine;
            do
            {
                Console.WriteLine();
                Console.WriteLine("For add some shape please input a number: ");
                Console.WriteLine("1- line.");
                Console.WriteLine("2- circle.");
                Console.WriteLine("3- rectangle.");
                Console.WriteLine("4- round.");
                Console.WriteLine("5- ring.");
                Console.WriteLine("0- show all input shapes.");
                Console.WriteLine("q- exit");
                readLine = Console.ReadLine();
                if (int.TryParse(readLine, out int choice))
                {
                    AddShape(choice);
                }
            }
            while (readLine != "q");
        }

        public static void Main(string[] args)
        {
            try
            {
                Menu();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
