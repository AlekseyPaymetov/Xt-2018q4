using Epam.Task06_3layers.AbstractTxtDao;
using Epam.Task06_3layers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task06_3layers.TxtDalForAward
{
    public class AwardTxt : AbstractTxtDao<Award>
    {
        protected override string DirectoryToWork 

        protected override string TxtNameToWork => throw new NotImplementedException();

        public override bool Add(Award someObject)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Award> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
