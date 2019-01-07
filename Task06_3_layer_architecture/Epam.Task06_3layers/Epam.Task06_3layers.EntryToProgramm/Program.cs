using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06_3layers.PLInterface;
using Epam.Task06_3layers.UserInterface;

namespace Epam.Task06_3layers.EntryToProgramm
{
   public class Program
    {
        public static void Main(string[] args)
        {
            Iui currentUI = new ConsoleUI();
            currentUI.Start();
        }
    }
}
