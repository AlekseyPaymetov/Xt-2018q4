using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06_3layers.BLL.CacheLogic;
using Epam.Task06_3layers.BLL.Logic;
using Epam.Task06_3layers.BLL.LogicInterface;
using Epam.Task06_3layers.Entities;
using Epam.Task06_3layers.PLInterface;

namespace Epam.Task06_3layers.UserInterface
{
    public class ConsoleUI : Iui
    {
        private const int MinYearOfBirth = 1900;
        private IBllLogic<User> currentLogic;

        public void Start()
        {
            this.Inicialization();
            this.Menu();
        }

        private void Menu()
        {
            this.ShowMenu();
            char inputSymbol = Console.ReadKey().KeyChar;
            Console.WriteLine();
            switch (inputSymbol)
            {
                case '1':
                    foreach (var item in this.currentLogic.GetAll())
                    {
                        Console.WriteLine(item);
                    }

                    break;
                case '2':
                    if (this.currentLogic.Add(this.InputUser()))
                    {
                        Console.WriteLine("User was successfully added.");
                    }
                    else
                    {
                        Console.WriteLine("Can't add this user");
                    }

                    break;
                case '3':
                    if (this.currentLogic.Delete(this.InputIdUserForDelete()))
                    {
                        Console.WriteLine("User was successfully deleted.");
                    }
                    else
                    {
                        Console.WriteLine("Can't delete user with this id.");
                    }

                    break;
                case 'q':
                    return;
                default:
                    this.ErrorMessage();
                    break;
            }

            this.Menu();
        }

        private User InputUser()
        {
            int id;
            string name;
            DateTime dateOfBirth;
            do
            {
                Console.Write("Please input id of user: ");
            }
            while (!int.TryParse(Console.ReadLine(), out id));

            do
            {
                Console.Write("Please input name of user: ");
                name = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(name));

            do
            {
                Console.Write("Please input date of birth of user (example - day.mounth.year): ");
            }
            while (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth));

            if (dateOfBirth.Year < MinYearOfBirth || dateOfBirth.Year > DateTime.Now.Year)
            {
                this.ErrorMessage();
                return this.InputUser();
            }

            return this.currentLogic.Create(id, name, dateOfBirth);
        }

        private int InputIdUserForDelete()
        {
            Console.Write("Please enter id of user fot delete: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                this.ErrorMessage();
                return this.InputIdUserForDelete();
            }

            return id;
        }

        private void ErrorMessage()
        {
            Console.WriteLine($"{Environment.NewLine}Incorrect input. Please try again.");
        }

        private void ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Make you choice:");
            Console.WriteLine("1- show all entries");
            Console.WriteLine("2- add entry");
            Console.WriteLine("3- delete entry");
            Console.WriteLine("q- exit");
        }

        private void Inicialization()
        {
            if (this.UseCache())
            {
                this.currentLogic = new CacheUserLogic();
            }
            else
            {
                this.currentLogic = new UserLogic();
            }
        }

        private bool UseCache()
        {
            Console.Write("Use Cache? (y/n): ");
            char inputSymbol = Console.ReadKey().KeyChar;
            if (inputSymbol == 'y' || inputSymbol == 'Y')
            {
                return true;
            }

            if (inputSymbol == 'n' || inputSymbol == 'N')
            {
                return false;
            }

            this.ErrorMessage();
            return this.UseCache();
        }
    }
}
