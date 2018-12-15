using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task04_delegates_and_ext._5_to_int_or_not_to_int
{
    public class DoubleSymbol
    {
        private char firstSymbol;
        private char secondSymbol;

        public DoubleSymbol(char firstSymbol, char secondSymbol)
        {
            this.firstSymbol = firstSymbol;
            this.secondSymbol = secondSymbol;
            this.Index = -1;
        }

        public char CurrentSymbol
        {
            get;
            protected set;
        }

        public int Index
        {
            get;
            set;
        }

        public bool ToBool()
            => this.Index >= 0;

        public int GetFirstIn(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == this.firstSymbol || str[i] == this.secondSymbol)
                {
                    this.CurrentSymbol = str[i];
                    this.Index = i;
                    return this.Index;
                }
            }

            return this.Index;
        }
    }
}
