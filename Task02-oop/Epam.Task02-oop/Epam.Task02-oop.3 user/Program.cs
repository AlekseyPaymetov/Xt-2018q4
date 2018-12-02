﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02_oop._3_user
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Please enter name of user: ");
            string name = Console.ReadLine();

            Console.Write("Please enter surname of user: ");
            string surname = Console.ReadLine();

            Console.Write("Please enter surname of user: ");
            string patronymic = Console.ReadLine();

            Console.Write("Please enter birth date of user: ");
            string time = Console.ReadLine();
            DateTime.TryParse(time, out DateTime birthDate);

            try
            {
                User user = new User(name, surname, patronymic, birthDate);
                Console.WriteLine($"{Environment.NewLine}Input user:");
                user.ShowDataToConsole();
                Console.WriteLine($"{Environment.NewLine}Then i changed user name and date of birth in program on my:{Environment.NewLine}");
                user.Name = "Aleksey";
                DateTime.TryParse("17.03.1988", out birthDate);
                user.BirthDate = birthDate;
                user.ShowDataToConsole();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"{Environment.NewLine}Error! {e.Message}");
            }
        }
    }
}