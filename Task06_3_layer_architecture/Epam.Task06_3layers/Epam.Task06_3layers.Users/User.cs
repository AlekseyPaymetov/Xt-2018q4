using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task06_3layers.Entities
{
    public class User
    {
        public User(int id, string name, DateTime dateOfBirth)
        {
            this.Id = id;
            this.Name = name;
            this.DateOfBirth = dateOfBirth;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age
        {
            get
            {
                return this.CalcYears(this.DateOfBirth);
            }
        }

        public override string ToString()
        {
            return $"Id: {this.Id}{Environment.NewLine}Name: {this.Name}{Environment.NewLine}Age: {this.Age}{Environment.NewLine}Date of birth: {this.DateOfBirth.ToShortDateString()}{Environment.NewLine}";
        }

        private int CalcYears(DateTime time)
        {
            DateTime now = DateTime.Now;

            if (now.Month > time.Month)
            {
                return now.Year - time.Year;
            }
            else
            {
                if (now.Month < time.Month)
                {
                    return now.Year - time.Year - 1;
                }
                else
                {
                    if (now.Day >= time.Day)
                    {
                        return now.Year - time.Year;
                    }
                    else
                    {
                        return now.Year - time.Year - 1;
                    }
                }
            }
        }
    }
}
