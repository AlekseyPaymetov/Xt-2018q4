using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02_oop._8_game
{
    public class Menu
    {
        public Menu(string type)
        {
            if (type == "Main menu")
            {
                Coordinates positionForMainMenu = new Coordinates();
                string nameForMainMenu = string.Empty;
                this.StartNewGame = new Button(positionForMainMenu, nameForMainMenu);
                this.Settings = new Button(positionForMainMenu, nameForMainMenu);
                this.ExitGame = new Button(positionForMainMenu, nameForMainMenu);
            }
            else if (type == "Sub menu")
            {
                Coordinates positionForSubMenu = new Coordinates();
                string nameForSubMenu = string.Empty;
                this.StartNewGame = new Button(positionForSubMenu, nameForSubMenu);
                this.Settings = new Button(positionForSubMenu, nameForSubMenu);
                this.ExitGame = new Button(positionForSubMenu, nameForSubMenu);
            }
            else
            {
                throw new ArgumentNullException("Wrong menu");
            }
        }

        public Button StartNewGame
        {
            get;
            private set;
        }

        public Button Settings
        {
            get;
            private set;
        }

        public Button ExitGame
        {
            get;
            private set;
        }

        public void Show()
        {
        }

        public void Close()
        {
        }
    }
}
