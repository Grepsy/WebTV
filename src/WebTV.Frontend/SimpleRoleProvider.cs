using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace WebTV.Frontend {
    public class SimpleRoleProvider : RoleProvider {
        public override string[] GetRolesForUser(string username) {
            if (username.Equals("Administrator"))
                return new string[] { "Administrator", "User" };
            else
                return new string[] { "User" };
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames) {
            throw new NotImplementedException();
        }

        public override string ApplicationName {
            get {
                return "WebTV";
            }
            set { }
        }

        public override void CreateRole(string roleName) {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole) {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch) {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles() {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName) {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName) {
            return !(roleName == "Administrator" && username != "Administrator");
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames) {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName) {
            return new string[] { "Administrator", "User" }.Contains(roleName);
        }
    }
}