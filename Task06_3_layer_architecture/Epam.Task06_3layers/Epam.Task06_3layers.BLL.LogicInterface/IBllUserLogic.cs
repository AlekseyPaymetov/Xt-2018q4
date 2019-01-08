using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task06_3layers.BLL.LogicInterface
{
    public interface IBllUserLogic<T>
    {
        T Create(int id, string name, DateTime dateOfBirt);

        bool Add(T someObject);

        bool Delete(int id);

        IEnumerable<T> GetAll();
    }
}
