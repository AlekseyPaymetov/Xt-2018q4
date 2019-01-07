using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task06_3layers.AbstractTxtDao
{
    public abstract class AbstractTxtDao<T>
    {
        protected abstract string DirectoryToWork { get; }

        protected abstract string TxtNameToWork { get; }

        protected string FullDirectoryToTxtDB
        {
            get
            {
                return Path.Combine(Directory.GetCurrentDirectory(), this.DirectoryToWork);
            }
        }

        protected string FullPathToTxtDB
        {
            get
            {
                return Path.Combine(this.FullDirectoryToTxtDB, this.TxtNameToWork);
            }
        }

        public abstract bool Add(T someObject);

        public abstract bool Delete(int id);

        public abstract IEnumerable<T> GetAll();
    }
}
