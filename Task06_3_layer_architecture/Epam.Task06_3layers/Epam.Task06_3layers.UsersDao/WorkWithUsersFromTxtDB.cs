using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06_3layers.AbstractTxtDao;
using Epam.Task06_3layers.Entities;

namespace Epam.Task06_3layers.TxtDal
{
    public class WorkWithUsersFromTxtDB : AbstractTxtDao<User>
    {
        protected override string DirectoryToWork
        { get; } = "txtDB";

        protected override string TxtNameToWork
        { get; } = "txtDB.txt";

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
                string[] userAsStrings = { user.Id.ToString(), user.Name, user.DateOfBirth.ToLongDateString() };
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
            int numberOfLine = 0;
            for (int i = 0; i < allData.Length; i += 3)
            {
                if (int.Parse(allData[i]) == id)
                {
                    numberOfLine = i;
                }
            }

            string[] subAllData = new string[allData.Length - 3];
            for (int i = 0; i < numberOfLine; i++)
            {
                subAllData[i] = allData[i];
            }

            for (int i = numberOfLine + 3, j = numberOfLine; i < allData.Length; i++, j++)
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

        private bool CanWork()
        {
            if (File.Exists(this.FullPathToTxtDB))
            {
                return true;
            }
            else
            {
                if (Directory.Exists(this.FullDirectoryToTxtDB))
                {
                    try
                    {
                        var temp = File.Create(FullPathToTxtDB);
                        temp.Close();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
                else
                {
                    try
                    {
                        Directory.CreateDirectory(this.FullDirectoryToTxtDB);
                        var temp = File.Create(FullPathToTxtDB);
                        temp.Close();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }

        private List<User> UsersFromStrings(string[] allData)
        {
            if (allData.Length % 3 != 0)
            {
                throw new ArgumentException("Wrong fields in DB");
            }

            List<User> allUsers = new List<User>();
            for (int i = 0; i < allData.Length; i += 3)
            {
                if (int.TryParse(allData[i], out int id) && DateTime.TryParse(allData[i + 2], out DateTime someDate))
                {
                    allUsers.Add(new User(id, allData[i + 1], someDate));
                }
                else
                {
                    throw new ArgumentException("Wrong fields in DB");
                }
            }

            return allUsers;
        }

        private string[] GetAllDataFromTxt()
        {
            try
            {
                string[] allData = File.ReadAllLines(FullPathToTxtDB);
                return allData;
            }
            catch
            {
                throw new ArgumentException("Can't access to DB");
            }
        }

        private bool IdExist(int id)
        {
            string[] allData = this.GetAllDataFromTxt();
            if (allData.Length == 0)
            {
                return false;
            }

            if (allData.Length % 3 != 0)
            {
                throw new ArgumentException("Wrong fields in DB");
            }

            for (int i = 0, j = 0; i < allData.Length; i += 3, j++)
            {
                int currentId;
                if (int.TryParse(allData[i], out currentId))
                {
                    if (currentId == id)
                    {
                        return true;
                    }

                    continue;
                }
                else
                {
                    throw new ArgumentException("Wrong fields in DB");
                }
            }

            return false;
        }
    }
}
