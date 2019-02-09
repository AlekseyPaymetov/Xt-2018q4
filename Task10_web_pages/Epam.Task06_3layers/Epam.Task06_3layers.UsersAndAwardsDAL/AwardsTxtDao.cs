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
    public class AwardsTxtDao : AbstractTxtDao<Award>
    {
        protected override string DirectoryToWork
        { get; } = "txtDB";

        protected override string TxtNameToWork
        { get; } = "Award.txt";

        protected override int IdInEveryStringNumber
        { get; } = 2;

        public override bool Add(Award award)
        {
            if (!this.CanWork())
            {
                return false;
            }

            if (this.IdExist(award.Id))
            {
                return false;
            }

            try
            {
                string[] awardAsStrings = { award.Id.ToString(), award.Title };
                File.AppendAllLines(this.FullPathToTxtDB, awardAsStrings);
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
            int numberOfLine = 0;
            for (int i = 0; i < allData.Length; i += this.IdInEveryStringNumber)
            {
                if (int.Parse(allData[i]) == id)
                {
                    numberOfLine = i;
                }
            }

            string[] subAllData = new string[allData.Length - this.IdInEveryStringNumber];
            for (int i = 0; i < numberOfLine; i++)
            {
                subAllData[i] = allData[i];
            }

            for (int i = numberOfLine + this.IdInEveryStringNumber, j = numberOfLine; i < allData.Length; i++, j++)
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

        public override IEnumerable<Award> GetAll()
        {
            if (!this.CanWork())
            {
                throw new ArgumentException("Can't access to DB");
            }

            string[] allData = this.GetAllDataFromTxt();
            return this.AwardsFromStrings(allData);
        }

        private List<Award> AwardsFromStrings(string[] allData)
        {
            if (allData.Length % this.IdInEveryStringNumber != 0)
            {
                throw new ArgumentException("Wrong fields in DB");
            }

            List<Award> allAwards = new List<Award>();
            for (int i = 0; i < allData.Length; i += this.IdInEveryStringNumber)
            {
                if (int.TryParse(allData[i], out int id))
                {
                    allAwards.Add(new Award(id, allData[i + 1]));
                }
                else
                {
                    throw new ArgumentException("Wrong fields in DB");
                }
            }

            return allAwards;
        }
    }
}
