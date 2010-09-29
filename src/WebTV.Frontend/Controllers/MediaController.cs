using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTV.Frontend.Controllers {
    public class MediaController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult Upload() {
            var uploadedFiles = new List<string>();
            foreach (string file in Request.Files) {
                var postedFile = Request.Files[file] as HttpPostedFileBase;
                uploadedFiles.Add(postedFile.FileName);
            }

            return View(uploadedFiles);
        }
    }
}
