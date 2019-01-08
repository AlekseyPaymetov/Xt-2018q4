using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06_3layers.BLL.AwardLogicInterface;
using Epam.Task06_3layers.BLL.AwardToUserLogicInterface;
using Epam.Task06_3layers.BLL.Logic;
using Epam.Task06_3layers.BLL.LogicInterface;
using Epam.Task06_3layers.BLL_AwardLogic;
using Epam.Task06_3layers.BLL_AwardToUserLogic;
using Epam.Task06_3layers.Entities;

namespace Epam.Task06_3layers.BLL.FullLogic
{
    public class FullLogic
    {
        private IBllUserLogic<User> workWithUsers;
        private IBllAwardLogic<Award> workWithAwards;
        private IBllAwardToUserLogic<AwardToUser> workWithAwardsToUsers;

        public FullLogic()
        {
            this.workWithUsers = new UserLogic();
            this.workWithAwards = new AwardLogic();
            this.workWithAwardsToUsers = new AwardToUserLogic();
        }

        public User CreateUser(int id, string name, DateTime dateOfBirth)
            => this.workWithUsers.Create(id, name, dateOfBirth);

        public Award CreateAward(int id, string title)
            => this.workWithAwards.Create(id, title);

        public AwardToUser CreateAwardToUser(int idAward, int idUser)
            => this.workWithAwardsToUsers.Create(this.CreateUniqueIdForAwardToUser(), idAward, idUser);

        public bool AddUser(User user)
            => this.workWithUsers.Add(user);

        public bool AddAward(Award award)
            => this.workWithAwards.Add(award);

        public bool AddAwardToUser(AwardToUser awardToUser)
        {
            int idUserFind = -1;
            int idAwardFind = -1;

            foreach (var user in this.workWithUsers.GetAll())
            {
                if (user.Id == awardToUser.IdUser)
                {
                    idUserFind = user.Id;
                    break;
                }
            }

            if (idUserFind < 0)
            {
                return false;
            }

            foreach (var award in this.workWithAwards.GetAll())
            {
                if (award.Id == awardToUser.IdAward)
                {
                    idAwardFind = award.Id;
                    break;
                }
            }

            if (idAwardFind < 0)
            {
                return false;
            }

            int counterForAwardToUser = this.CreateUniqueIdForAwardToUser();

            return this.workWithAwardsToUsers.Add(new AwardToUser(counterForAwardToUser, idAwardFind, idUserFind));
        }

        public bool DeleteUser(int id)
            => this.workWithUsers.Delete(id);

        public bool DeleteAward(int idAward)
        {
            if (this.workWithAwards.Delete(idAward))
            {
                List<int> idsForDelete = new List<int>();
                foreach (var item in this.workWithAwardsToUsers.GetAll())
                {
                    if (item.IdAward == idAward)
                    {
                        idsForDelete.Add(item.Id);
                    }
                }

                foreach (var item in idsForDelete)
                {
                    this.workWithAwardsToUsers.Delete(item);
                }

                return true;
            }

            return false;
        }

        public bool DeleteAwardToUser(int idAward, int idUser)
        {
            int idForDelete = -1;
            foreach (var item in this.workWithAwardsToUsers.GetAll())
            {
                if (item.IdAward == idAward && item.IdUser == idUser)
                {
                    idForDelete = item.Id;
                }
            }

            if (idForDelete < 0)
            {
                return false;
            }

            return this.workWithAwardsToUsers.Delete(idForDelete);
        }

        public List<string> GetAllInfoAboutAwards()
        {
            List<string> awarsList = new List<string>();
            foreach (var item in this.workWithAwards.GetAll())
            {
                awarsList.Add("Id: " + item.Id.ToString());
                awarsList.Add("Title: " + item.Title);
            }

            return awarsList;
        }

        public List<string> GetAllInfoAboutUsers()
        {
            List<string> usersInfo = new List<string>();
            foreach (var user in this.workWithUsers.GetAll())
            {
                usersInfo.Add(user.ToString());
                foreach (var userToAward in this.workWithAwardsToUsers.GetAll())
                {
                    if (user.Id == userToAward.IdUser)
                    {
                        int idAward = userToAward.IdAward;
                        foreach (var award in this.workWithAwards.GetAll())
                        {
                            if (award.Id == idAward)
                            {
                                usersInfo.Add($"Has award id: {award.Id} title: {award.Title}");
                            }
                        }
                    }
                }

                usersInfo.Add(string.Empty);
            }

            return usersInfo;
        }

        public List<string> GetAllInfoUsersFromAwards()
        {
            List<string> awardsAndUsers = new List<string>();
            foreach (var award in this.workWithAwards.GetAll())
            {
                awardsAndUsers.Add("Award: " + award.Title + " id: " + award.Id);
                foreach (var awardToUser in this.workWithAwardsToUsers.GetAll())
                {
                    if (award.Id == awardToUser.IdAward)
                    {
                        foreach (var user in this.workWithUsers.GetAll())
                        {
                            if (user.Id == awardToUser.IdUser)
                            {
                                awardsAndUsers.Add("Find user:");
                                awardsAndUsers.Add(user.ToString());
                                break;
                            }
                        }
                    }
                }

                awardsAndUsers.Add(string.Empty);
            }

            return awardsAndUsers;
        }

        private int CreateUniqueIdForAwardToUser()
        {
            int counterForAwardToUser = 0;
            bool uniqueIdFind = false;
            while (!uniqueIdFind)
            {
                uniqueIdFind = true;
                foreach (var item in this.workWithAwardsToUsers.GetAll())
                {
                    if (item.Id == counterForAwardToUser)
                    {
                        uniqueIdFind = false;
                    }
                }

                if (!uniqueIdFind)
                {
                    counterForAwardToUser++;
                }
            }

            return counterForAwardToUser;
        }
    }
}
