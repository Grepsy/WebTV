using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTV.Model;

namespace WebTV.Frontend.Controllers {
    public class ControllerBase : Controller {
        protected WebTVContext Context { get; set; }
        protected Customer Customer {
            get {
                return Context.Customers.Single(c => c.Name == User.Identity.Name);
            }
        }

        public ControllerBase() {
            Context = new WebTVContext();
        }

        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);
            Context.Dispose();
        }
    }
}