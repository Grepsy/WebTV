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
        public FilePathResult Show(string id) {
            Media media = Context.Media.SingleOrDefault(m => m.Filename.Equals(id));
            if (media == null) {
                throw new HttpException(404, "Image not found");
            }

            string path = Path.Combine(ConfigurationManager.AppSettings["MediaPath"], media.Filename);
            return new FilePathResult(path, media.MimeType);
        }

        public ActionResult Delete(int? id) {
            try {
                var media = Context.Media.Single(m => m.MediaId == id);
                Context.DeleteObject(media);
                Context.SaveChanges();
                TempData["message"] = new InfoMessage("Foto is verwijderd.", InfoMessage.InfoType.Notice);
            }
            catch (Exception) {
                TempData["message"] = new InfoMessage("Er is een fout opgetreden bij het verwijderen van de foto.", InfoMessage.InfoType.Error);
            }
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Copy(int id, int? mediaSetId) {
            try {
                var media = Context.Media.Single(s => s.MediaId == id);
                var set = mediaSetId.HasValue ? Context.MediaSets.Single(a => a.MediaSetId == mediaSetId) : media.MediaSet;
                set.Media.Add(media.Copy());
                Context.SaveChanges();
                TempData["message"] = new InfoMessage("Foto is gekopiëerd naar " + set.Name + ".", InfoMessage.InfoType.Notice);
            }
            catch (Exception) {
                TempData["message"] = new InfoMessage("Er is een fout opgetreden bij het kopieëren van de set.", InfoMessage.InfoType.Error);
            }
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Upload(int? mediaSetId) {
            ViewData["mediaSetId"] = mediaSetId.Value;

            var uploadedFiles = new List<ViewDataFileUpload>();
            foreach (string item in Request.Files) {
                var file = Request.Files[item] as HttpPostedFileBase;
                var originalName = file.FileName;
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
                    Filename = originalName,
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
