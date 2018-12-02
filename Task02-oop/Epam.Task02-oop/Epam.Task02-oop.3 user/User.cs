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
            get
            {
                DateTime now = DateTime.Now;

                if (now.Month > this.birthDate.Month)
                {
                    return now.Year - this.birthDate.Year;
                }
                else
                {
                    if (now.Month < this.birthDate.Month)
                    {
                        return now.Year - this.birthDate.Year - 1;
                    }
                    else
                    {
                        if (now.Day >= this.birthDate.Day)
                        {
                            return now.Year - this.birthDate.Year;
                        }
                        else
                        {
                            return now.Year - this.birthDate.Year - 1;
                        }
                    }
                }
            }
        }

        public void ShowDataToConsole()
        {
            Console.WriteLine($"Name: {this.Name}");
            Console.WriteLine($"Surame: {this.Surname}");
            Console.WriteLine($"Patronymic: {this.Patronymic}");
            Console.WriteLine("Birth date: {0:d}", this.BirthDate);
            Console.WriteLine($"Age: {this.Age}");
        }

        private void CheckOnSymbols(string checkString)
        {
            char[] arrayOfString = checkString.ToCharArray();
            foreach (char symbol in arrayOfString)
            {
                if (!char.IsLetter(symbol))
                {
                    throw new ArgumentException("Input data isn't words.");
                }
            }
        }

        private void CheckBirthDate(DateTime birthDate)
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
