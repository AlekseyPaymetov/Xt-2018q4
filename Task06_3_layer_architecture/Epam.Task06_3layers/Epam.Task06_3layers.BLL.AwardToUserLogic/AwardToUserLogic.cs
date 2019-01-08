using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06_3layers.AbstractTxtDao;
using Epam.Task06_3layers.BLL.AwardLogicInterface;
using Epam.Task06_3layers.BLL.AwardToUserLogicInterface;
using Epam.Task06_3layers.Entities;
using Epam.Task06_3layers.TxtDaoForAwardsForUsers;

namespace Epam.Task06_3layers.BLL_AwardToUserLogic
{
    public class AwardToUserLogic : IBllAwardToUserLogic<AwardToUser>
    {
        private AbstractTxtDao<AwardToUser> txtDao = new AwardsToUsers();
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
