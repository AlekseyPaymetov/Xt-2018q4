using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06_3layers.AbstractTxtDao;
using Epam.Task06_3layers.Entities;

namespace Epam.Task06_3layers.TxtDaoForAwardsForUsers
{
    public class AwardsToUsers : AbstractTxtDao<AwardToUser>
    {
        protected override string DirectoryToWork
        { get; } = "txtDB";

        protected override string TxtNameToWork
        { get; } = "AwardsAndUsers.txt";

        protected override int IdInEveryStringNumber
        { get; } = 3;

        public override bool Add(AwardToUser awardToUser)
        {
            if (!this.CanWork())
            {
                return false;
            }

            if (this.IdExist(awardToUser.Id))
            {
                return false;
            }

            try
            {
                string[] awardsAndUsersAsStrings = { awardToUser.Id.ToString(), awardToUser.IdAward.ToString(), awardToUser.IdUser.ToString() };
                File.AppendAllLines(this.FullPathToTxtDB, awardsAndUsersAsStrings);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public override bool Delete(int id)
        {
            if (!this.IdExist(id))
            {
                return false;
            }

            string[] allData = this.GetAllDataFromTxt();
            int numberOfLineForDelete = 0;
            for (int i = 0; i < allData.Length; i += this.IdInEveryStringNumber)
            {
                if (int.Parse(allData[i]) == id)
                {
                    numberOfLineForDelete = i;
                    break;
                }
            }

            string[] subAllData = new string[allData.Length - this.IdInEveryStringNumber];
            for (int i = 0; i < numberOfLineForDelete; i++)
            {
                subAllData[i] = allData[i];
            }

            for (int i = numberOfLineForDelete + this.IdInEveryStringNumber, j = numberOfLineForDelete; i < allData.Length; i++, j++)
            {
                subAllData[j] = allData[i];
            }

            try
            {
                File.WriteAllLines(this.FullPathToTxtDB, subAllData);
            }
            catch
            {
                throw new ArgumentException("Failed write to DB");
            }

            return true;
        }

        public override IEnumerable<AwardToUser> GetAll()
        {
            if (!this.CanWork())
            {
                throw new ArgumentException("Can't access to DB");
            }

            string[] allData = this.GetAllDataFromTxt();
            return this.AwardsAndUsersFromStrings(allData);
        }

        private List<AwardToUser> AwardsAndUsersFromStrings(string[] allData)
        {
            if (allData.Length % this.IdInEveryStringNumber != 0)
            {
                throw new ArgumentException("Wrong fields in DB");
            }

            List<AwardToUser> allAwardsAndUsers = new List<AwardToUser>();
            for (int i = 0; i < allData.Length; i += this.IdInEveryStringNumber)
            {
                if (int.TryParse(allData[i], out int id) && int.TryParse(allData[i + 1], out int idAward) && int.TryParse(allData[i + 2], out int idUser))
                {
                    allAwardsAndUsers.Add(new AwardToUser(id, idAward, idUser));
                }
                else
                {
                    throw new ArgumentException("Wrong fields in DB");
                }
            }

            return allAwardsAndUsers;
        }
    }
}
