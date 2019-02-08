using Epam.Task06_3layers.Common;
using Epam.Task06_3layers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task06_3layers
{
    public class ConsoleUI : IPL
    {
        private const int MinYearOfBirth = 1900;
        private DependencyResolves logic = new DependencyResolves();

        public void Start()
        {
            this.MainMenu();
        }

        private void MainMenu()
        {
            this.ShowMainMenu();
            char inputSymbol = Console.ReadKey().KeyChar;
            Console.WriteLine();
            switch (inputSymbol)
            {
                case '1':
                    foreach (var item in this.logic.GetAllInfoAboutUsers())
                    {
                        Console.WriteLine(item);
                    }

                    break;
                case '2':
                    if (this.logic.AddUser(this.InputUser()))
                    {
                        Console.WriteLine("User was successfully added.");
                    }
                    else
                    {
                        Console.WriteLine("Can't add this user");
                    }

                    break;
                case '3':
                    if (this.logic.DeleteUser(this.InputIdForDelete("user")))
                    {
                        Console.WriteLine("User was successfully deleted.");
                    }
                    else
                    {
                        Console.WriteLine("Can't delete user with this id.");
                    }

                    break;
                case 'a':
                    this.AwardMenu();
                    break;
                case 'q':
                    return;
                default:
                    this.ErrorMessage();
                    break;
            }

            this.MainMenu();
        }

        private void ShowAwardMenu()
        {
            Console.WriteLine();
            Console.WriteLine("--- Award menu ---");
            Console.WriteLine("Make you choice:");
            Console.WriteLine("1- show all awards");
            Console.WriteLine("2- add award");
            Console.WriteLine("3- add award to user");
            Console.WriteLine("4- delete award");
            Console.WriteLine("5- delete a user award ");
            Console.WriteLine("6- show all awards and users with them");
            Console.WriteLine("q- back to main menu");
        }

        private void AwardMenu()
        {
            this.ShowAwardMenu();
            char inputSymbol = Console.ReadKey().KeyChar;
            Console.WriteLine();
            switch (inputSymbol)
            {
                case '1':
                    foreach (var item in this.logic.GetAllInfoAboutAwards())
                    {
                        Console.WriteLine(item);
                    }

                    break;
                case '2':
                    if (this.logic.AddAward(this.InputAward()))
                    {
                        Console.WriteLine("Award was successfully added.");
                    }
                    else
                    {
                        Console.WriteLine("Can't add this reward");
                    }

                    break;
                case '3':
                    if (this.logic.AddAwardToUser(this.InputAwardToUser()))
                    {
                        Console.WriteLine("Award to user was successfully added.");
                    }
                    else
                    {
                        Console.WriteLine("Can't add award to user");
                    }

                    break;
                case '4':
                    if (this.logic.DeleteAward(this.InputIdForDelete("award")))
                    {
                        Console.WriteLine("Award was successfully deleted.");
                    }
                    else
                    {
                        Console.WriteLine("Can't delete award.");
                    }

                    break;
                case '5':
                    int idAward = this.InputId("award");
                    int idUser = this.InputId("user");
                    if (this.logic.DeleteAwardToUser(idAward, idUser))
                    {
                        Console.WriteLine($"Award with id: {idAward} for user with id: {idUser} was successfully deleted.");
                    }
                    else
                    {
                        Console.WriteLine("Can't delete award to user.");
                    }

                    break;
                case '6':
                    foreach (var item in this.logic.GetAllInfoUsersFromAwards())
                    {
                        Console.WriteLine(item);
                    }

                    break;
                case 'q':
                    return;
                default:
                    this.ErrorMessage();
                    break;
            }

            this.AwardMenu();
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

            return this.logic.CreateUser(id, name, dateOfBirth);
        }

        private Award InputAward()
        {
            int id;
            string title;

            do
            {
                Console.Write("Please input id of award: ");
            }
            while (!int.TryParse(Console.ReadLine(), out id));

            do
            {
                Console.Write("Please input title: ");
                title = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(title));

            return this.logic.CreateAward(id, title);
        }

        private int InputId(string name)
        {
            int id;
            do
            {
                Console.Write($"Please input id of {name}: ");
            }
            while (!int.TryParse(Console.ReadLine(), out id));

            return id;
        }

        private AwardToUser InputAwardToUser()
        {
            int idUser;
            int idAward;

            do
            {
                Console.Write("Please input id of award: ");
            }
            while (!int.TryParse(Console.ReadLine(), out idAward));

            do
            {
                Console.Write("Please input id of user: ");
            }
            while (!int.TryParse(Console.ReadLine(), out idUser));

            return this.logic.CreateAwardToUser(idAward, idUser);
        }

        private int InputIdForDelete(string nameOfObject)
        {
            Console.Write($"Please enter id of {nameOfObject} fot delete: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                this.ErrorMessage();
                return this.InputIdForDelete(nameOfObject);
            }

            return id;
        }

        private void ErrorMessage()
        {
            Console.WriteLine($"{Environment.NewLine}Incorrect input. Please try again.");
        }

        private void ShowMainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("--- Main menu ---");
            Console.WriteLine("Make you choice:");
            Console.WriteLine("1- show all users");
            Console.WriteLine("2- add user");
            Console.WriteLine("3- delete user");
            Console.WriteLine("a- open award menu");
            Console.WriteLine("q- exit");
        }
    }
}
