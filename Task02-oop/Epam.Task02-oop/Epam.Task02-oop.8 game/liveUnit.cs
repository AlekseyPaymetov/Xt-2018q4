using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02_oop._8_game
{
    public class LiveUnit : BonusUnit
    {
        public LiveUnit(string nameOfUnit, Coordinates position) : base(nameOfUnit, position)
        {
        }

        public int Damage
        {
            get; set;
        }

        public int Health
        {
            get; set;
        }

        public int MoveSpeed
        {
            get; set;
        }

        public void Move(Coordinates newPosition)
        {
        }

        private void MoveAlgoritm()
        {
        }
    }
}
