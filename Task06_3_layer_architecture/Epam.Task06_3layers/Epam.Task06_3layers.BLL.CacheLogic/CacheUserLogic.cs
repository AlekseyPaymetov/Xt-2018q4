using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06_3layers.AbstractTxtDao;
using Epam.Task06_3layers.BLL.LogicInterface;
using Epam.Task06_3layers.Entities;
using Epam.Task06_3layers.TxtDal;

namespace Epam.Task06_3layers.BLL.CacheLogic
{
    public class CacheUserLogic : IBllLogic<User>
    {
        private AbstractTxtDao<User> txtDao = new WorkWithUsersFromTxtDB();
        private List<User> cacheList = new List<User>();

        public CacheUserLogic()
        {
            this.Initialization();
        }

        public User Create(int id, string name, DateTime dateOfBirth)
        {
            return new User(id, name, dateOfBirth);
        }

        public bool Add(User user)
        {
            this.DelCache();
            return this.txtDao.Add(user);
        }

        public bool Delete(int id)
        {
            this.DelCache();
            return this.txtDao.Delete(id);
        }

        public IEnumerable<User> GetAll()
        {
            if (this.cacheList.Count == 0)
            {
                this.Initialization();
            }

            return this.cacheList;
        }

        private void Initialization()
        {
            foreach (var item in this.txtDao.GetAll())
            {
                this.cacheList.Add(item);
            }
        }

        private void DelCache()
        {
            this.cacheList.Clear();
        }
    }
}
