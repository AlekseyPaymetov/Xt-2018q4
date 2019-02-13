using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task06_3layers.UsersAndAwardsInterfaceDAL
{
    public abstract class AbstractDBDao<T>
    {
        public AbstractDBDao()
        {
            this.ConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        protected string ConnectionString { get; set; }

        public abstract bool Add(T someObject);

        public abstract bool Delete(int id);

        public abstract IEnumerable<T> GetAll();
    }
}
