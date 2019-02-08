using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task06_3layers.UsersAndAwardsInterfaceBLL
{
    public interface IAwardToUserLogic<T>
    {
        T Create(int id, int idAward, int idUser);

        bool Add(T someObject);

        bool Delete(int id);

        IEnumerable<T> GetAll();
    }
}
