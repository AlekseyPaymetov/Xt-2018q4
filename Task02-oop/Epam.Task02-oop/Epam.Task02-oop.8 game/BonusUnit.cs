﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02_oop._8_game
{
    public class BonusUnit : Unit
    {
        public BonusUnit(string nameOfUnit, Coordinates position) : base(nameOfUnit, position)
        {
        }

        public void Destroy()
        {
        }
    }
}
