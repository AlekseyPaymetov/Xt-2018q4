using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task06_3layers.Entities
{
    public class SiteUser
    {
        public SiteUser(string name, string password)
        {
            this.Name = name;
            this.Password = password;
        }

        public string Name { get; set; }

        public string Password { get; set; }
    }
}
