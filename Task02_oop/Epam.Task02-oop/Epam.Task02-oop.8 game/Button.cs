using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02_oop._8_game
{
    public class Button : IPosition
    {
        public Button(Coordinates position, string nameOfButton)
        {
            this.Position = position;
            this.NameOfButton = nameOfButton;
        }

        public string NameOfButton
        {
            get; private set;
        }

        public Coordinates Position { get; private set; }

        public void OnClick()
        {
        }

        private void DrawButton()
        {
        }
    }
}
