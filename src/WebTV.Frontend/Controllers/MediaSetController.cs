using System;
using System.Linq;
using System.Web.Mvc;
using WebTV.Model;
using System.Web.Routing;

namespace WebTV.Frontend.Controllers
{
    [Authorize]
    public class MediaSetController : ControllerBase {
        public ActionResult Index() {
            ViewData["Animations"] = Customer.Animations;
            return View(Customer.Animations.SelectMany(a => a.MediaSets));
        }

        public ActionResult Edit(int id) {
            var set = Context.MediaSets.Single(s => s.MediaSetId == id);
            ViewData["Animations"] = Customer.Animations.Where(a => a.MediaGroupedBy == set.Animation.MediaGroupedBy);
            ViewData["HasMissingGroups"] = set.MediaGroups.Any(g => g.Media.Count < set.Animation.MediaGroupedBy);

            return View(set);
        }

        [HttpPost]
        public ActionResult Edit(MediaSet newSet) {
            string[] includeProps = new string[] { "Name", "StartDate", "EndDate", "Message" };
            MediaSet set = null;
            try {
                set = Context.MediaSets.Single(s => s.MediaSetId == newSet.MediaSetId);
                UpdateModel(set, includeProps);
                Context.SaveChanges();
                TempData["message"] = new InfoMessage("Fotoset aangepast.", InfoMessage.InfoType.Notice);
            }
            catch (Exception e) {
                Elmah.ErrorSignal.FromCurrentContext().Raise(e);
                TempData["message"] = new InfoMessage("Fout bij het bewerken van fotoset.", InfoMessage.InfoType.Error);
            }

            return RedirectToAction("Edit", new { id = set.MediaSetId });
        }

        public ActionResult New(int? animationId, string name) {
            try {
                Context.MediaSets.AddObject(new MediaSet() {
                    AnimationId = animationId.HasValue ? animationId.Value : Customer.Animations.First().AnimationId,
                    Name = String.IsNullOrWhiteSpace(name) ? "Nieuwe fotoset" : name,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(7)
                });
                Context.SaveChanges();
                TempData["message"] = new InfoMessage("Nieuwe set is aangemaakt.", InfoMessage.InfoType.Notice);
            }
            catch (Exception e) {
                Elmah.ErrorSignal.FromCurrentContext().Raise(e);
                TempData["message"] = new InfoMessage("Er is een fout opgetreden bij het maken van de set.", InfoMessage.InfoType.Error);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id) {
            try {
                var set = Context.MediaSets.Single(s => s.MediaSetId == id);
                Context.DeleteObject(set);
                Context.SaveChanges();
                TempData["message"] = new InfoMessage("Set is verwijderd.", InfoMessage.InfoType.Notice);
            }
            catch (Exception e) {
                Elmah.ErrorSignal.FromCurrentContext().Raise(e);
                TempData["message"] = new InfoMessage("Er is een fout opgetreden bij het verwijderen van de set.", InfoMessage.InfoType.Error);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Copy(int id, int animationId, string name) {
            try {
                var set = Context.MediaSets.Single(s => s.MediaSetId == id);
                var animation = Context.Animations.Single(a => a.AnimationId == animationId);
                var copy = set.Copy();
                if (!String.IsNullOrWhiteSpace(name)) {
                    copy.Name = name;
                }
                animation.MediaSets.Add(copy);

                Context.SaveChanges();
            }
            catch (Exception e) {
                Elmah.ErrorSignal.FromCurrentContext().Raise(e);
                TempData["message"] = new InfoMessage("Er is een fout opgetreden bij het kopieëren van de set.", InfoMessage.InfoType.Error);
            }
            return RedirectToAction("Index");
        }
        
        public ActionResult Preview(int id) // id == MediaSetId
        {
            var mediaSet = Context.MediaSets.Single(ms => ms.MediaSetId == id);
            var animation = Context.Animations.Single(a => a.AnimationId == mediaSet.AnimationId);
            String MediaSetLocation = Url.Action("Details", "Animation",
                new RouteValueDictionary(
                    new
                    {
                        id = animation.AnimationId,
                        mediaSetId = id,
                        type = "json"
                    }),
                    Request.Url.Scheme, Request.Url.Host);

            TempData["MediaSetLocation"] = MediaSetLocation.ToString();
            TempData["AnimationFile"] = animation.Name.ToString().ToLower() + ".swf";
            return View();
        }

        [HttpPost]
        public ActionResult Preview(int AnimationId, int MediaSetId)
        {
            var animation = Context.Animations.Single(a => a.AnimationId == AnimationId); 
            String MediaSetLocation = Url.Action("Details", "Animation", 
                new RouteValueDictionary(
                    new { 
                        id = animation.AnimationId,
                        mediaSetId = MediaSetId, 
                        type="json" }),
                    Request.Url.Scheme, Request.Url.Host);

            TempData["MediaSetLocation"] = MediaSetLocation.ToString();
            TempData["AnimationFile"] = animation.Name.ToString().ToLower() + ".swf";
            return View();
        }
    }
}
