using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Epam.Task06_3layers.Entities;
using Epam.Task06_3layers.UsersAndAwardsDAL;

namespace DemoWebPages.RolveProvider
{
    public class MyRoleProvider : RoleProvider
    {
        private static SiteUsersTxtDao siteUsers = new SiteUsersTxtDao();

        #region NotImplemented
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        #endregion

        public override bool IsUserInRole(string username, string roleName)
        {
            if (username == "admin" && roleName == "admin")
            {
                return true;
            }

            if (username == "guest" && roleName == "guest")
            {
                return true;
            }

            foreach (SiteUser item in siteUsers.GetAll())
            {
                if (item.Name == username && roleName == "user")
                {
                    return true;
                }
            }

            return false;
        }

        public override string[] GetRolesForUser(string username)
        {
            if (username == "admin")
            {
                return new string[] { "admin" };
            }

            foreach (SiteUser item in siteUsers.GetAll())
            {
                if (item.Name == username)
                {
                    return new string[] { "user" };
                }
            }

            return new string[] { "guest" };
        }
    }
}