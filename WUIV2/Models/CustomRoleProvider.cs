using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace WUIV2.Models
{
    public class CustomRoleProvider : RoleProvider 
    {
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool IsUserInRole(string mail, string roleName)
        {
            using (var usersContext = new AnimalContext())
            {
                var user = usersContext.Utilisateurs.SingleOrDefault(u => u.mail == mail);
                if (user == null)
                    return false;
                return user.role != null;
            }
        }

        public override string[] GetRolesForUser(string mail)
        {
            using (var usersContext = new AnimalContext())
            {
                var user = usersContext.Utilisateurs.SingleOrDefault(u => u.mail == mail);
                if (user == null)
                    return new string[] { };
                return user.role == null ? new string[] { } : new string[] { user.role };
            }
        }

        // -- Snip --

        public override string[] GetAllRoles()
        {
                return new string[] { "ADMINISTRATEUR", "MEMBRE" };
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }
    }
}