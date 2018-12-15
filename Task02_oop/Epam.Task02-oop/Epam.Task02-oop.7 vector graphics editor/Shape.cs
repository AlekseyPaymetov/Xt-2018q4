using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02_oop._7_vector_graphics_editor
{
    public abstract class Shape
    {
        public double Length
        {
            get; protected set;
        }

        public abstract void Show();
    }
}