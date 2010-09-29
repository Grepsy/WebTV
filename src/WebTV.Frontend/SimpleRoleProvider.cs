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
    }
}