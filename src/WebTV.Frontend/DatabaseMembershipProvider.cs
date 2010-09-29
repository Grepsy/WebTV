using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace WebTV.Frontend {
    public class DatabaseMembershipProvider : MembershipProvider {
        public override bool ValidateUser(string username, string password) {
            return true;
        }
    }
}