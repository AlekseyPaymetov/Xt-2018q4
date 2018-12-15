using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task02_oop._3_user;

namespace Epam.Task02_oop._5__employee
{
    public class Employee : User
    {
        private string post;
        private DateTime carierStart;

        public Employee(string name, string surname, string patronymic, DateTime birthDate, string post, DateTime carierStart) : base(name, surname, patronymic, birthDate)
        {
            this.CarierStart = carierStart;
            this.Post = post;
        }

        public DateTime CarierStart
        {
            get => this.carierStart;
            set
            {
                this.CheckCarierStart(value);
                this.carierStart = value;
            }
        }

        public int WorkExperience
        {
            get => this.CalcYears(this.CarierStart);
        }

        public string Post
        {
            get => this.post;
            set
            {
                this.CheckOnSymbols(value);
                this.post = value;
            }
        }

        public override void ShowOnConsole()
        {
            base.ShowOnConsole();
            Console.WriteLine($"Post: {this.Post}");
            Console.WriteLine("Carier start: {0:d}", this.CarierStart);
            Console.WriteLine($"Work experience: {this.WorkExperience} year's");
        }

        protected void CheckCarierStart(DateTime carierStart)
        {
            if (carierStart > DateTime.Now)
            {
                throw new ArgumentException("Wrong date of carier start. It's in future.", nameof(carierStart));
            }

            if (carierStart < BirthDate.AddYears(18))
            {
                throw new ArgumentException("Work officially only adult,", nameof(carierStart));
            }
        }
    }
}
