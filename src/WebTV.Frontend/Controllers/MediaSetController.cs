using System;
using System.Linq;
using System.Web.Mvc;
using WebTV.Model;

namespace WebTV.Frontend.Controllers
{
    [Authorize]
    public class MediaSetController : ControllerBase {
        public ActionResult Index() {
            return View(Context.MediaSets);
        }

        public ActionResult Edit(int setId) {
            var set = Context.MediaSets.Single(s => s.MediaSetId == setId);
            return View(set);
        }

        public ActionResult New(int? animationId, string name) {
            try {
                Context.MediaSets.AddObject(new MediaSet() {
                    AnimationId = animationId.HasValue ? animationId.Value : Context.Animations.First().AnimationId,
                    Name = String.IsNullOrWhiteSpace(name) ? "Nieuwe fotoset" : name,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(7)
                });
                Context.SaveChanges();
                TempData["message"] = new InfoMessage("Nieuwe set is aangemaakt.", InfoMessage.InfoType.Notice);
            }
            catch (Exception) {
                TempData["message"] = new InfoMessage("Er is een fout opgetreden bij het maken van de set.", InfoMessage.InfoType.Error);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int setId) {
            try {
                var set = Context.MediaSets.Single(s => s.MediaSetId == setId);
                Context.DeleteObject(set);
                Context.SaveChanges();
                TempData["message"] = new InfoMessage("Set is verwijderd.", InfoMessage.InfoType.Notice);
            }
            catch (Exception) {
                TempData["message"] = new InfoMessage("Er is een fout opgetreden bij het verwijderen van de set.", InfoMessage.InfoType.Error);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Copy(int setId, int animationId) {
            try {
                var set = Context.MediaSets.Single(s => s.MediaSetId == setId);
                var animation = Context.Animations.Single(a => a.AnimationId == animationId);

                animation.MediaSets.Add(set.Copy());

                Context.SaveChanges();
            }
            catch (Exception) {
                TempData["message"] = new InfoMessage("Er is een fout opgetreden bij het kopieëren van de set.", InfoMessage.InfoType.Error);
            }
            return RedirectToAction("Index");
        }
    }
}
