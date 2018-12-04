using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02_oop._8_game
{
    public class Unit 
    {
        public Unit(string nameOfUnit, Coordinates position)
        {
            this.NameOfUnit = nameOfUnit;
            this.Position = position;
        }

        public string NameOfUnit
        {
            get; private set;
        }

        public Coordinates Position
        {
            get; private set;
        }

        public virtual void DrawUnit()
        {
        }
    }
}
