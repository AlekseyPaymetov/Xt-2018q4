using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task06_3layers.Entities
{
    public class AwardToUser
    {
        public AwardToUser(int id, int idAward, int idUser)
        {
            this.Id = id;
            this.IdAward = idAward;
            this.IdUser = idUser;
        }

        public int Id { get; set; }

        public int IdAward { get; set; }

        public int IdUser { get; set; }

        public override string ToString()
        {
            return $"Id: {this.Id}{Environment.NewLine}IdAward: {this.IdAward}{Environment.NewLine}IdUser: {this.IdUser}{Environment.NewLine}";
        }
    }
}
