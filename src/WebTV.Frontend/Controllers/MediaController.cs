﻿using System;
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
        public JsonResult Edit(int id) {
            Media media = Context.Media.SingleOrDefault(m => m.MediaId.Equals(id));
            var metadata = new {
                Id = media.MediaId,
                Name = media.PropertyWithName("Naam").Value, 
                Price = media.PropertyWithName("Prijs").Value, 
                Description = media.PropertyWithName("Omschrijving").Value
            };
            
            return Json(metadata, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Edit(int id, string name, string price, string description) {
            Media media = Context.Media.SingleOrDefault(m => m.MediaId.Equals(id));
            media.PropertyWithName("Naam").Value = name;
            media.PropertyWithName("Prijs").Value = price;
            media.PropertyWithName("Omschrijving").Value = description;
            Context.SaveChanges();

            if (media.MediaGroupId.HasValue)
                return RedirectToAction("Edit", "MediaGroup", new { id = media.MediaGroupId });
            else
                return RedirectToAction("Edit", "MediaSet", new { id = media.MediaSetId });
        }

        public FilePathResult Show(string id) {
            Media media = Context.Media.SingleOrDefault(m => m.Filename.Equals(id));
            if (media == null) {
                throw new HttpException(404, "Image not found");
            }

            string path = Path.Combine(Server.MapPath("/"), Media.BaseDir, media.Filename);
            return new FilePathResult(path, media.MimeType);
        }

        public ActionResult Delete(int? id) {
            try {
                var media = Context.Media.Single(m => m.MediaId == id);
                Context.DeleteObject(media);
                Context.SaveChanges();
                TempData["message"] = new InfoMessage("Foto is verwijderd.", InfoMessage.InfoType.Notice);
            }
            catch (Exception e) {
                Elmah.ErrorSignal.FromCurrentContext().Raise(e);
                TempData["message"] = new InfoMessage("Er is een fout opgetreden bij het verwijderen van de foto.", InfoMessage.InfoType.Error);
            }
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Copy(int id, int? mediaSetId, int? mediaGroupId, string name, string description, string price) {
            try {
                var media = Context.Media.Single(s => s.MediaId == id);
                var set = mediaSetId.HasValue ? Context.MediaSets.Single(a => a.MediaSetId == mediaSetId) : media.MediaSet;
                var group = mediaGroupId.HasValue ? Context.MediaGroups.Single(a => a.MediaGroupId == mediaGroupId) : media.MediaGroup;
                var copy = media.Copy();

                if (name != null && description != null && price != null) {
                    media.PropertyWithName("Naam").Value = name;
                    media.PropertyWithName("Prijs").Value = price;
                    media.PropertyWithName("Omschrijving").Value = description;
                }
                if (mediaSetId.HasValue)
                    set.Media.Add(copy);
                if (mediaGroupId.HasValue)
                    group.Media.Add(copy);

                Context.SaveChanges();
                TempData["message"] = new InfoMessage("Foto is gekopiëerd naar " + set.Name + ".", InfoMessage.InfoType.Notice);
            }
            catch (Exception e) {
                Elmah.ErrorSignal.FromCurrentContext().Raise(e);
                TempData["message"] = new InfoMessage("Er is een fout opgetreden bij het kopieëren van de set.", InfoMessage.InfoType.Error);
            }
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Upload(int mediaSetId, int? mediaGroupId) {
            ViewData["mediaSetId"] = mediaSetId;
            ViewData["mediaSetName"] = Context.MediaSets.Single(
                                       ms => ms.MediaSetId == mediaSetId)
                                       .Name;
            
            if (mediaGroupId.HasValue) {
                ViewData["mediaGroupId"] = mediaGroupId.Value;

                var mediagroup = Context.MediaGroups.Single(mg => mg.MediaGroupId == mediaGroupId);
                ViewData["mediaGroupName"] = mediagroup.PropertyWithName("Naam").Value;
                if (ViewData["mediaGroupName"] == "") ViewData["mediaGroupName"] = "Naamloze groep";
            }

            var uploadedFiles = new List<ViewDataFileUpload>();
            if (Request.Files.Count > 0) {
                foreach (string item in Request.Files) {
                    var file = Request.Files[item] as HttpPostedFileBase;
                    var originalName = file.FileName;
                    var checkResult = new ImageChecker().Check(file.InputStream);

                    if (checkResult.IsOK) {
                        var media = new Media() {
                            MediaSetId = mediaSetId,
                            MimeType = file.ContentType
                        };
                        if (mediaGroupId.HasValue) {
                            media.MediaGroupId = mediaGroupId.Value;
                        }

                        string fullPath = Path.Combine(Server.MapPath("/"), Media.BaseDir, media.Filename);
                        file.SaveAs(fullPath);
                        Context.Media.AddObject(media);
                        Context.SaveChanges();
                    }

                    uploadedFiles.Add(new ViewDataFileUpload {
                        Filename = originalName,
                        Filesize = file.ContentLength,
                        CheckResult = checkResult
                    });
                }
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
