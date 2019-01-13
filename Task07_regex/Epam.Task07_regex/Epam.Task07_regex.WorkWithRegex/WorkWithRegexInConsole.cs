using System;
using System.Text.RegularExpressions;

namespace Epam.Task07_regex.WorkWithRegex
{
    public class WorkWithRegexInConsole
    {
        private Regex regex;

        public WorkWithRegexInConsole(int numberOfTask, string regex, bool askInput = true)
        {
            this.regex = new Regex(@regex);
            this.SetExampleString(numberOfTask);
            if (askInput)
            {
                this.SetInputString();
            }
        }

        public string InputString
        {
            get;
            set;
        }
            = string.Empty;

        public string ExampleString
        {
            get;
            private set;
        }
            = string.Empty;

        public void SetInputString()
        {
            Console.WriteLine("Please input string: ");
            this.InputString = Console.ReadLine();
        }

        public MatchCollection GetAllMatches()
        {
            return this.regex.Matches(this.InputString);
        }

        public MatchCollection GetAllMatchesInExample()
        {
            return this.regex.Matches(this.ExampleString);
        }

        private void SetExampleString(int numberOfTask)
        {
            switch (numberOfTask)
            {
                case 1:
                    this.ExampleString = "2016 год наступит 01-01-2016";
                    break;
                case 2:
                    this.ExampleString = "<b>Это</b> текст <i>с</i> <font color=\"red\">HTML</font> кодами";
                    break;
                case 3:
                    this.ExampleString = "Иван: ivan@mail.ru, Петр: p_ivanov@mail.rol.ru";
                    break;
                case 4:
                    this.ExampleString = "5.75e-5";
                    break;
                case 5:
                    this.ExampleString = "В 7:55 я встал, позавтракал и к 10:77 пошёл на работу.";
                    break;
                default:
                    break;
            }
        }
    }
}
