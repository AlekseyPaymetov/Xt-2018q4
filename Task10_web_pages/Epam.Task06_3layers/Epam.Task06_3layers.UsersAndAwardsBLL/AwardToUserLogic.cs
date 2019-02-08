using Epam.Task06_3layers.Entities;
using Epam.Task06_3layers.UsersAndAwardsDAL;
using Epam.Task06_3layers.UsersAndAwardsInterfaceBLL;
using Epam.Task06_3layers.UsersAndAwardsInterfaceDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task06_3layers.UsersAndAwardsBLL
{
    public class AwardToUserLogic : IAwardToUserLogic <AwardToUser>
    {
        private AbstractTxtDao<AwardToUser> txtDao = new AwardsToUsersTxtDao();
        private List<AwardToUser> cacheList = new List<AwardToUser>();

        public AwardToUserLogic()
        {
            this.Initialization();
        }

        public AwardToUser Create(int id, int idAward, int idUser)
            => new AwardToUser(id, idAward, idUser);

        public bool Add(AwardToUser awardToUser)
        {
            this.DeleteCache();
            return this.txtDao.Add(awardToUser);
        }

        public bool Delete(int id)
        {
            this.DeleteCache();
            return this.txtDao.Delete(id);
        }

        public IEnumerable<AwardToUser> GetAll()
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
