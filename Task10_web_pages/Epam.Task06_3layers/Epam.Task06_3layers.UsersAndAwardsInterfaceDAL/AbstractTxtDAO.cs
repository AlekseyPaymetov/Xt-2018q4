using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task06_3layers.UsersAndAwardsInterfaceDAL
{
    public abstract class AbstractTxtDao<T>
    {
        protected abstract string DirectoryToWork { get; }

        protected abstract string TxtNameToWork { get; }

        protected abstract int IdInEveryStringNumber { get; }

        protected string FullDirectoryToTxtDB
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, this.DirectoryToWork);
            }
        }

        protected string FullPathToTxtDB
        {
            get
            {
                return Path.Combine(this.FullDirectoryToTxtDB, this.TxtNameToWork);
            }
        }

        public abstract bool Add(T someObject);

        public abstract bool Delete(int id);

        public abstract IEnumerable<T> GetAll();

        protected bool CanWork()
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
                        var temp = File.Create(this.FullPathToTxtDB);
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
                        var temp = File.Create(this.FullPathToTxtDB);
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

        protected bool IdExist(int id)
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

        protected string[] GetAllDataFromTxt()
        {
            try
            {
                string[] allData = File.ReadAllLines(this.FullPathToTxtDB);
                return allData;
            }
            catch
            {
                throw new ArgumentException("Can't access to DB");
            }
        }
    }
}
