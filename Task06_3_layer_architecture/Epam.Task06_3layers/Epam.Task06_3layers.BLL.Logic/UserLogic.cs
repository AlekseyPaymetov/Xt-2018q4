using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06_3layers.BLL.LogicInterface;
using Epam.Task06_3layers.DalInterface;
using Epam.Task06_3layers.Entities;
using Epam.Task06_3layers.TxtDal;

namespace Epam.Task06_3layers.BLL.Logic
{
    public class UserLogic : IBllLogic<User>
    {
        private Idal<User> txtDao = new WorkWithUsersFromTxtDB();

        public User Create(int id, string name, DateTime dateOfBirth)
            => new User(id, name, dateOfBirth);

        public bool Add(User user)
            => this.txtDao.Add(user);

        public bool Delete(int id)
            => this.txtDao.Delete(id);

        public IEnumerable<User> GetAll()
            => this.txtDao.GetAll();
    }
}
