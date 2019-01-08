using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task06_3layers.Entities
{
    public class Award
    {
        public Award(int id, string title)
        {
            this.Id = id;
            this.Title = title;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public override string ToString()
        {
            return $"Id: {this.Id}{Environment.NewLine}Title: {this.Title}{Environment.NewLine}";
        }
    }
}
