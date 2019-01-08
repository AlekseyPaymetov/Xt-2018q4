using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06_3layers.AbstractTxtDao;
using Epam.Task06_3layers.BLL.AwardLogicInterface;
using Epam.Task06_3layers.Entities;
using Epam.Task06_3layers.TxtDalForAward;

namespace Epam.Task06_3layers.BLL_AwardLogic
{
    public class AwardLogic : IBllAwardLogic<Award>
    {
        private AbstractTxtDao<Award> txtDao = new AwardTxt();
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
