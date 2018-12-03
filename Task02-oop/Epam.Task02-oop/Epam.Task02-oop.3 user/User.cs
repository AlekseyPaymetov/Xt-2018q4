using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02_oop._3_user
{
    public class User
    {
        private string name;
        private string surname;
        private string patronymic;
        private DateTime birthDate;

        public User(string name, string surname, string patronymic, DateTime birthDate)
        {
            this.Name = name;
            this.Surname = surname;
            this.Patronymic = patronymic;
            this.BirthDate = birthDate;
        }

        public string Name
        {
            get => this.name;
            set
            {
                this.CheckOnSymbols(value);
                this.name = value;
            }
        }

        public string Surname
        {
            get => this.surname;
            set
            {
                this.CheckOnSymbols(value);
                this.surname = value;
            }
        }

        public string Patronymic
        {
            get => this.patronymic;
            set
            {
                this.CheckOnSymbols(value);
                this.patronymic = value;
            }
        }

        public DateTime BirthDate
        {
            get => this.birthDate;
            set
            {
                this.CheckBirthDate(value);
                this.birthDate = value;
            }
        }

        public int Age
        {
            get => this.CalcYears(this.BirthDate);
        }

        public virtual void ShowOnConsole()
        {
            Console.WriteLine($"Name: {this.Name}");
            Console.WriteLine($"Surame: {this.Surname}");
            Console.WriteLine($"Patronymic: {this.Patronymic}");
            Console.WriteLine("Birth date: {0:d}", this.BirthDate);
            Console.WriteLine($"Age: {this.Age} years");
        }

        protected int CalcYears(DateTime time)
        {
            DateTime now = DateTime.Now;

            if (now.Month > time.Month)
            {
                return now.Year - time.Year;
            }
            else
            {
                if (now.Month < time.Month)
                {
                    return now.Year - time.Year - 1;
                }
                else
                {
                    if (now.Day >= time.Day)
                    {
                        return now.Year - time.Year;
                    }
                    else
                    {
                        return now.Year - time.Year - 1;
                    }
                }
            }
        }

        protected void CheckOnSymbols(string checkString)
        {
            if (string.IsNullOrEmpty(checkString))
            {
                throw new ArgumentException("Input string is null or empty");
            }

            char[] arrayOfString = checkString.ToCharArray();
            foreach (char symbol in arrayOfString)
            {
                if (!char.IsLetter(symbol))
                {
                    throw new ArgumentException("Input data isn't words.");
                }
            }
        }

        protected void CheckBirthDate(DateTime birthDate)
        {
            if (birthDate.Year < 1900)
            {
                throw new ArgumentException("Incoorect date of birth (maybe too small year of birth).");
            }

            if (birthDate > DateTime.Now)
            {
                throw new ArgumentException("Data of birth in future.");
            }
        }
    }
}
