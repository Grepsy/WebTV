using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTV.Imaging;
using System.IO;
using System.Configuration;
using WebTV.Model;

namespace WebTV.Frontend.Controllers {
    public class MediaController : ControllerBase {
        public ActionResult Index() {
            return View();
        }

        public FilePathResult Show(string id) {
            Media media = Context.Media.SingleOrDefault(m => m.Filename.Equals(id));
            if (media == null) {
                throw new HttpException(404, "Image not found");
            }

            string path = Path.Combine(ConfigurationManager.AppSettings["MediaPath"], media.Filename);
            return new FilePathResult(path, media.MimeType);
        }
        
        public ActionResult Upload(int? mediaSetId) {
            var uploadedFiles = new List<ViewDataFileUpload>();
            foreach (string item in Request.Files) {
                var file = Request.Files[item] as HttpPostedFileBase;
                var checkResult = new ImageChecker().Check(file.InputStream);

                if (checkResult.IsOK) {
                    string fileguid = Guid.NewGuid().ToString();
                    file.SaveAs(Path.Combine(ConfigurationManager.AppSettings["MediaPath"], fileguid));

                    Media image = new Media() {
                        MediaSetId = mediaSetId.Value,
                        Filename = fileguid,
                        MimeType = file.ContentType
                    };
                    Context.Media.AddObject(image);
                    Context.SaveChanges();
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
