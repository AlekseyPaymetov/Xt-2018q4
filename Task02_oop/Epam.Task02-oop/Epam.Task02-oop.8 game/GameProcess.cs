using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02_oop._8_game
{
    public class GameProcess
    {
        private Menu mainMenu;
        private Menu subMenu;
        private Map map;
        private List<Unit> units;

        public GameProcess()
        {
            this.mainMenu = new Menu("Main menu");
            this.mainMenu.Show();
        }

        public void StartGame()
        {
            this.mainMenu.Close();
            this.units = this.CreateNewUnitsOnMap("Some settings");
            int settingWidth = 960;
            int settingHeight = 800;
            this.map = new Map(this.units, settingHeight, settingWidth);
        }

        public void PauseGame()
        {
        }

        public void ExitGame()
        {
        }

        public void ShowSubMenu()
        {
            this.subMenu = new Menu("Sub menu");
            this.PauseGame();
            this.subMenu.Show();
        }

        private List<Unit> CreateNewUnitsOnMap(string settings)
        {
            return new List<Unit>();
        }

        private void IniMap(List<Unit> currentLevel)
        {
        }
    }
}
