﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task06_3layers.Entities;
using Epam.Task06_3layers.UsersAndAwardsBLL;
using Epam.Task06_3layers.UsersAndAwardsInterfaceBLL;

namespace Epam.Task06_3layers.Common
{
    public class DependencyResolves
    {
        private IUserLogic<User> workWithUsers;
        private IAwardLogic<Award> workWithAwards;
        private IAwardToUserLogic<AwardToUser> workWithAwardsToUsers;

        public DependencyResolves()
        {
            this.workWithUsers = new UserLogic();
            this.workWithAwards = new AwardLogic();
            this.workWithAwardsToUsers = new AwardToUserLogic();
        }

        public User CreateUser(int id, string name, DateTime dateOfBirth, string imgPath = @"img\users\default.jpg")
            => this.workWithUsers.Create(id, name, dateOfBirth, imgPath);

        public Award CreateAward(int id, string title, string imgPath = @"img\award\default.png")
            => this.workWithAwards.Create(id, title, imgPath);

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

        public List<User> GetAllUsers()
        {
            List<User> allUsers = new List<User>();
            foreach (var item in this.workWithUsers.GetAll())
            {
                allUsers.Add(item);
            }

            return allUsers;
        }
            
        public List<Award> GetAllAwards()
        {
            List<Award> allAwards = new List<Award>();
            foreach (var item in this.workWithAwards.GetAll())
            {
                allAwards.Add(item);
            }

            return allAwards;
        }

        public List<AwardToUser> GetAllUserAwards()
        {
            List<AwardToUser> allUserAwards = new List<AwardToUser>();
            foreach (var item in this.workWithAwardsToUsers.GetAll())
            {
                allUserAwards.Add(item);
            }

            return allUserAwards;
        }

        public bool DeleteAwardFromAllUsers(int idAward, int idUser)
        {
            if (this.DeleteAwardToUser(idAward, idUser))
            {
                List<int> idsForDel = new List<int>();
                foreach (var item in this.workWithAwardsToUsers.GetAll())
                {
                    if (item.IdAward == idAward)
                    {
                        idsForDel.Add(item.Id);
                    }
                }

                foreach (var item in idsForDel)
                {
                    this.workWithAwardsToUsers.Delete(item);
                }

                return true;
            }
            else
            {
                return false;
            }
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
