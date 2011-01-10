using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTV.Frontend.Controllers
{
    public class StaticController : Controller
    {
        public ActionResult Static(String PageName)
        {
            return View(PageName);
        }
    }
}
