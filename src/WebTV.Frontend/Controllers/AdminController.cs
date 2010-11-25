using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebTV.Frontend.Providers;

namespace WebTV.Frontend.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult addUser(String username, String Password)
        {
            return View();
        }

    }
}
