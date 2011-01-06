using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTV.Model;

namespace WebTV.Frontend.Controllers {
    public class MediaGroupController : ControllerBase {
        public ActionResult New(int mediaSetId) {
            try {
                var group = new MediaGroup() {
                    MediaSetId = mediaSetId
                };
                Context.MediaGroups.AddObject(group);
                //group.PropertyWithName("Naam").Value = "Nieuwe groep";

                Context.SaveChanges();
                TempData["message"] = new InfoMessage("Nieuwe groep is aangemaakt.", InfoMessage.InfoType.Notice);
            }
            catch (Exception e) {
                Elmah.ErrorSignal.FromCurrentContext().Raise(e);
                TempData["message"] = new InfoMessage("Er is een fout opgetreden bij het maken van de group.", InfoMessage.InfoType.Error);
            }
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Edit(int id) {
            var group = Context.MediaGroups.Single(s => s.MediaGroupId == id);
            if (Request.Params["type"] == "json") {
                var metadata = new {
                    Id = group.MediaGroupId,
                    Name = group.PropertyWithName("Naam").Value,
                    Price = group.PropertyWithName("Prijs").Value,
                    Description = group.PropertyWithName("Omschrijving").Value
                };

                return Json(metadata, JsonRequestBehavior.AllowGet);
            }
            else {
                group = Context.MediaGroups.Single(s => s.MediaGroupId == id);
                return View(group);
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, string name, string description, string price) {
            MediaGroup group = null;
            try {
                group = Context.MediaGroups.Single(s => s.MediaGroupId == id);
                group.PropertyWithName("Naam").Value = name;
                group.PropertyWithName("Omschrijving").Value = description;
                group.PropertyWithName("Prijs").Value = price;

                Context.SaveChanges();
                TempData["message"] = new InfoMessage("Groep aangepast.", InfoMessage.InfoType.Notice);
            }
            catch (Exception e) {
                Elmah.ErrorSignal.FromCurrentContext().Raise(e);
                TempData["message"] = new InfoMessage("Fout bij het bewerken van groep.", InfoMessage.InfoType.Error);
            }

            return View(group);
        }

        public ActionResult Delete(int id) {
            try {
                var group = Context.MediaGroups.Single(s => s.MediaGroupId == id);
                // Work around ref. constraint problem
                for (int i = 0; i < group.Properties.Count; i++)
                    Context.DeleteObject(group.Properties.ElementAt(i));
                for (int i = 0; i < group.Media.Count; i++)
                    Context.DeleteObject(group.Media.ElementAt(i));
                Context.DeleteObject(group);
                Context.SaveChanges();
                TempData["message"] = new InfoMessage("Groep is verwijderd.", InfoMessage.InfoType.Notice);
            }
            catch (Exception e) {
                Elmah.ErrorSignal.FromCurrentContext().Raise(e);
                TempData["message"] = new InfoMessage("Er is een fout opgetreden bij het verwijderen van de groep.", InfoMessage.InfoType.Error);
            }
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}
