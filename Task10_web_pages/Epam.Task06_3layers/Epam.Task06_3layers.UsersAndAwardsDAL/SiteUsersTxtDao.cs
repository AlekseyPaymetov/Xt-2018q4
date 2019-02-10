using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06_3layers.Entities;
using Epam.Task06_3layers.UsersAndAwardsInterfaceDAL;

namespace Epam.Task06_3layers.UsersAndAwardsDAL
{
    public class SiteUsersTxtDao : AbstractTxtDao<SiteUser>
    {
        protected override string DirectoryToWork
        { get; } = "txtDB";

        protected override string TxtNameToWork
        { get; } = "siteUsersDB.txt";

        protected override int IdInEveryStringNumber
        { get; } = 2;

        public override bool Add(SiteUser user)
        {
            if (!this.CanWork())
            {
                return false;
            }

            if (this.NameExist(user.Name))
            {
                return false;
            }

            try
            {
                string[] userAsStrings = { user.Name, user.Password };
                File.AppendAllLines(this.FullPathToTxtDB, userAsStrings);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public override bool Delete(int id)
        {
            return false;
        }

        public override IEnumerable<SiteUser> GetAll()
        {
            if (!this.CanWork())
            {
                throw new ArgumentException("Can't access to DB");
            }

            string[] allData = this.GetAllDataFromTxt();
            return this.UsersFromStrings(allData);
        }

        private List<SiteUser> UsersFromStrings(string[] allData)
        {
            if (allData.Length % this.IdInEveryStringNumber != 0)
            {
                throw new ArgumentException("Wrong fields in DB");
            }

            List<SiteUser> allUsers = new List<SiteUser>();
            for (int i = 0; i < allData.Length; i += this.IdInEveryStringNumber)
            {
                allUsers.Add(new SiteUser(allData[i], allData[i + 1]));
            }

            return allUsers;
        }

        private bool NameExist(string name)
        {
            string[] allData = this.GetAllDataFromTxt();
            if (allData.Length == 0)
            {
                return false;
            }

            if (allData.Length % this.IdInEveryStringNumber != 0)
            {
                throw new ArgumentException("Wrong fields in DB");
            }

            for (int i = 0, j = 0; i < allData.Length; i += this.IdInEveryStringNumber, j++)
            {
                string currentName = allData[i];
                if (currentName == name)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
