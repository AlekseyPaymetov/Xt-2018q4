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
    public class UsersTxtDao : AbstractTxtDao<User>
    {
        protected override string DirectoryToWork
        { get; } = "txtDB";

        protected override string TxtNameToWork
        { get; } = "userDB.txt";

        protected override int IdInEveryStringNumber
        { get; } = 4;

        public override bool Add(User user)
        {
            if (!this.CanWork())
            {
                return false;
            }

            if (this.IdExist(user.Id))
            {
                return false;
            }

            try
            {
                string[] userAsStrings = { user.Id.ToString(), user.Name, user.DateOfBirth.ToLongDateString(), user.ImgPath };
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

        public override IEnumerable<User> GetAll()
        {
            if (!this.CanWork())
            {
                throw new ArgumentException("Can't access to DB");
            }

            string[] allData = this.GetAllDataFromTxt();
            return this.UsersFromStrings(allData);
        }

        private List<User> UsersFromStrings(string[] allData)
        {
            if (allData.Length % this.IdInEveryStringNumber != 0)
            {
                throw new ArgumentException("Wrong fields in DB");
            }

            List<User> allUsers = new List<User>();
            for (int i = 0; i < allData.Length; i += this.IdInEveryStringNumber)
            {
                if (int.TryParse(allData[i], out int id) && DateTime.TryParse(allData[i + 2], out DateTime someDate))
                {
                    allUsers.Add(new User(id, allData[i + 1], someDate, allData[i + 3]));
                }
                else
                {
                    throw new ArgumentException("Wrong fields in DB");
                }
            }

            return allUsers;
        }
    }
}
