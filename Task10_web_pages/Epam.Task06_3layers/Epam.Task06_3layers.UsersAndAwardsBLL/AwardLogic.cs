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
    public class AwardLogic : IAwardLogic<Award>
    {
        private AbstractTxtDao<Award> txtDao = new AwardsTxtDao();
        private List<Award> cacheList = new List<Award>();

        public AwardLogic()
        {
            this.Initialization();
        }

        public Award Create(int id, string title)
            => new Award(id, title);

        public bool Add(Award award)
        {
            this.DeleteCache();
            return this.txtDao.Add(award);
        }

        public bool Delete(int id)
        {
            this.DeleteCache();
            return this.txtDao.Delete(id);
        }

        public IEnumerable<Award> GetAll()
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
