using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02_oop._4_my_string
{
    public class MyString
    {
        private char[] myString;

        public MyString(string inputString)
        {
            this.myString = inputString.ToCharArray();
        }

        public int Length
        {
            get => this.myString.Length;
        }

        public char this[int index]
        {
            get
            {
                this.CheckIndex(index);
                return this.myString[index];
            }

            set
            {
                this.CheckIndex(index);
                this.myString[index] = value;
            }
        }

        public static bool operator >(MyString string1, MyString string2)
        {
            if (string1.Length > string2.Length)
            {
                for (int i = 0; i < string2.Length; i++)
                {
                    if (string1[i] > string2[i])
                    {
                        return true;
                    }

                    if (string1[i] < string2[i])
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                for (int i = 0; i < string1.Length; i++)
                {
                    if (string1[i] > string2[i])
                    {
                        return true;
                    }

                    if (string1[i] < string2[i])
                    {
                        return false;
                    }
                }

                return false;
            }
        }

        public static bool operator <(MyString string1, MyString string2) =>
             string2 > string1 && string1 != string2;

        public static bool operator >=(MyString string1, MyString string2) =>
            string1 > string2 || string1 == string2;

        public static bool operator <=(MyString string1, MyString string2) =>
            string1 < string2 || string1 == string2;

        public static MyString operator +(MyString string1, MyString string2)
        {
            return new MyString(string1.ToString() + string2.ToString());
        }

        public static bool operator ==(MyString string1, MyString string2)
        {
            if (string1.Length != string2.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < string1.Length; i++)
                {
                    if (string1[i] != string2[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public static bool operator !=(MyString string1, MyString string2) =>
            !(string1 == string2);

        public override string ToString() =>
            new string(this.myString);

        public int IndexOf(char symbol)
        {
            for (int i = 0; i < this.myString.Length; i++)
            {
                if (this.myString[i] == symbol)
                {
                    return i;
                }
            }

            return -1;
        }

        // Or i must write full serch function (use for)?
        public int IndexOf(string subString) =>
            new string(this.myString).IndexOf(subString);

        public int IndexOf(MyString mySubString) =>
             new string(this.myString).IndexOf(mySubString.ToString());

        public char[] ToCharArray() =>
            this.myString;
        
        private void CheckIndex(int index)
        {
            if (index < 0 || index > this.myString.Length)
            {
                throw new ArgumentException("Wrong index");
            }
        }
    }
}
