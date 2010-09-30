using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTV.Imaging;

namespace WebTV.Frontend.Controllers {
    public class MediaController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult Upload() {
            var uploadedFiles = new List<ViewDataFileUpload>();
            foreach (string item in Request.Files) {
                var file = Request.Files[item] as HttpPostedFileBase;
                var checkResult = new ImageChecker().Check(file.InputStream);

                if (checkResult.IsOK) {
                    // file.SaveAs()
                }

                uploadedFiles.Add(new ViewDataFileUpload {
                    Filename = file.FileName,
                    Filesize = file.ContentLength,
                    CheckResult = checkResult
                });
            }

            return View(uploadedFiles);
        }
    }

    public class ViewDataFileUpload {
        public string Filename { get; set; }
        public int Filesize { get; set; }
        public ImageChecker.Result CheckResult { get; set; }
    }
}
