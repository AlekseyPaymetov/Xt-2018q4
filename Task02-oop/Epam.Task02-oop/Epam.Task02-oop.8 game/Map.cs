using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02_oop._8_game
{
    public class Map
    {
        public Map(List<Unit> units, int height, int width)
        {
            this.Units = units;
            this.Widsth = width;
            this.Height = height;
            this.DrawMap();
        }

        public List<Unit> Units
        {
            get; private set;
        }

        public int Height
        {
            get; private set;
        }

        public int Widsth
        {
            get; private set;
        }

        public void DrawMap()
        {
        }
    }
}
