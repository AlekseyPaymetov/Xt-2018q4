using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task04_delegates_and_ext._5_to_int_or_not_to_int
{
    public class Mantissa
    {
        private string word;
        private DoubleSymbol firstMinusPlus = new DoubleSymbol('-', '+');
        private DoubleSymbol secondMinusPlus = new DoubleSymbol('-', '+');
        private DoubleSymbol separator = new DoubleSymbol('.', ',');
        private DoubleSymbol e = new DoubleSymbol('e', 'E');

        public Mantissa(string str)
        {
            this.word = str;
            this.firstMinusPlus.GetFirstIn(this.word);
            if (this.firstMinusPlus.Index == 0)
            {
                this.secondMinusPlus.GetFirstIn(this.word.Substring(this.firstMinusPlus.Index + 1));
                if (this.secondMinusPlus.ToBool())
                {
                    this.secondMinusPlus.Index += 2;
                }
            }
            else
            {
                this.secondMinusPlus.GetFirstIn(this.word);
                if (this.secondMinusPlus.ToBool())
                {
                    this.secondMinusPlus.Index++;
                }

                this.firstMinusPlus.Index = -1;
            }

            this.separator.GetFirstIn(this.word);
            this.e.GetFirstIn(this.word);
        }

        public bool IsInt()
        {
            if (!this.CheckAllIndexes())
            {
                return false;
            }

            string part1 = string.Empty;
            if (this.firstMinusPlus.ToBool())
            {
                part1 = this.word.Substring(1, this.separator.Index - 1);
            }
            else
            {
                part1 = this.word.Substring(0, this.separator.Index);
            }

            string part2 = string.Empty;
            part2 = this.word.Substring(this.separator.Index + 1, this.e.Index - this.separator.Index - 1);

            string part3 = string.Empty;
            if (this.secondMinusPlus.ToBool())
            {
                part3 = this.word.Substring(this.secondMinusPlus.Index);
            }
            else
            {
                part3 = this.word.Substring(this.e.Index + 1);
            }

            if (string.IsNullOrEmpty(part1) || string.IsNullOrEmpty(part2) || string.IsNullOrEmpty(part3))
            {
                return false;
            }

            if (!this.StringIsNumber(part1) || !this.StringIsNumber(part2) || !this.StringIsNumber(part3))
            {
                return false;
            }

            double result = (this.StrToInt(part1) + this.StrToFraction(part2)) * this.StrToFactor(part3);
            if (this.firstMinusPlus.ToBool() && this.firstMinusPlus.CurrentSymbol == '-')
            {
                result = -result;
            }

            if (result > int.MaxValue || result < int.MinValue)
            {
                return false;
            }

            int intResult = (int)result;
            if ((double)intResult - result != 0.0)
            {
                return false;
            }

            return true;
        }

        private double StrToFactor(string str)
        {
            double factor;
            int number = this.StrToInt(str);
            if (this.secondMinusPlus.ToBool())
            {
                if (this.secondMinusPlus.CurrentSymbol == '-')
                {
                    factor = Math.Pow(10, -number);
                }
            }

            factor = Math.Pow(10, number);
            return factor;
        }

        private double StrToFraction(string str)
        {
            int number = this.StrToInt(str);
            double fraction = number;
            for (int i = 0; i < str.Length; i++)
            {
                fraction *= 0.1;
            }

            return fraction;
        }

        private int StrToInt(string str)
        {
            double number = 0;
            int length = str.Length;
            for (int i = 0; i < str.Length; i++)
            {
                char x = str[i];
                int r = x - '0';
                number += (x - '0') * Math.Pow(10, length - i - 1);
            }

            return (int)number;
        }

        private bool CheckAllIndexes()
        {
            if (this.firstMinusPlus.Index > 0 && this.firstMinusPlus.Index != 0)
            {
                return false;
            }

            if (this.separator.Index < 0 || this.e.Index < 0)
            {
                return false;
            }

            if (this.secondMinusPlus.Index > 0 && this.secondMinusPlus.Index < this.separator.Index && (this.secondMinusPlus.Index - this.e.Index) != 1)
            {
                return false;
            }

            if (this.e.Index < this.separator.Index)
            {
                return false;
            }

            return true;
        }

        private bool StringIsNumber(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (!char.IsNumber(str[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
