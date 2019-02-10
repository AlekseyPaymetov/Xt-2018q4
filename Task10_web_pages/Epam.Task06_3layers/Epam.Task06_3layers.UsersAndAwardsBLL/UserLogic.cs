using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06_3layers.Entities;
using Epam.Task06_3layers.UsersAndAwardsDAL;
using Epam.Task06_3layers.UsersAndAwardsInterfaceBLL;
using Epam.Task06_3layers.UsersAndAwardsInterfaceDAL;

namespace Epam.Task06_3layers.UsersAndAwardsBLL
{
    public class UserLogic : IUserLogic<User>
    {
        private AbstractTxtDao<User> txtDao = new UsersTxtDao();
        private List<User> cacheList = new List<User>();

        public UserLogic()
        {
            this.Initialization();
        }

        public User Create(int id, string name, DateTime dateOfBirth, string imgPath = @"img\Default.jpg")
        {
            return new User(id, name, dateOfBirth, imgPath);
        }

        public bool Add(User user)
        {
            this.DeleteCache();
            return this.txtDao.Add(user);
        }

        public bool Delete(int id)
        {
            this.DeleteCache();
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

        private void DeleteCache()
        {
            this.cacheList.Clear();
        }
    }
}
