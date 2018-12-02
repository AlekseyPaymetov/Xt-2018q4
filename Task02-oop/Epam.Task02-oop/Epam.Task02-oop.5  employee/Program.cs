using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02_oop._5__employee
{
    public class Program
    {
        private static void Main(string[] args)
        {
            DateTime.TryParse("17.03.1988", out DateTime birthDate);
            DateTime.TryParse("3.12.2010", out DateTime startCarier);
            Employee someOne = new Employee("Aleksey", "Paymetov", "Yurevich", birthDate, "programmer", startCarier);
            someOne.ShowOnConsole();
        }
    }
}
