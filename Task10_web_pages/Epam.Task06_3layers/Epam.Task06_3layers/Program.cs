using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task06_3layers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IPL currentUI = new ConsoleUI();
            currentUI.Start();
        }
    }
}
