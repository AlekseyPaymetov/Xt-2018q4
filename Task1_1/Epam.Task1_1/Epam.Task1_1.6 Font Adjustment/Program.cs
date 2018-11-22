using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1_1._6_Font_Adjustment
{
    class Program
    {
        [Flags]
        enum SettingsForText
        {
            None = 0x0,
            Bold = 0x1,
            Italic = 0x2,
            Underline = 0x4
        }

        static void Main(string[] args)
        {
            int n = 0;
            SettingsForText set = 0;

            Console.WriteLine("For exit please enter any other number");
            do
            {
                Console.Write($"Settings of text: {set}");
                Console.WriteLine(Environment.NewLine + "Please input:" + Environment.NewLine + "\t1: bold" + Environment.NewLine + "\t2: italic" + Environment.NewLine + "\t3: underline");
                int.TryParse(Console.ReadLine(), out n);
                int combination = (int)Math.Pow(2, n - 1);
                if ((set & (SettingsForText)combination) == (SettingsForText)combination)
                {
                    set = set ^ (SettingsForText)combination;
                }
                else
                {
                    set = set | (SettingsForText)combination;
                }
            }
            while (n > 0 && n < 4);
        }
    }
}
