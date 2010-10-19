using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTV.Model;

namespace WebTV.Frontend.Controllers {
    public class AnimationController : ControllerBase {
        public ActionResult Index() {
            var animations = Context.Animations.ToList();
            return View(animations);
        }

        public ActionResult NewSet(int animationId, string name) {
            try {
                Context.MediaSets.AddObject(new MediaSet() {
                    AnimationId = animationId,
                    Name = name,
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

        public ActionResult DeleteSet(int setId) {
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

        public ActionResult CopySet(int setId, int animationId) {
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

        public ActionResult Edit(int id) {
            var animation = Context.Animations.Single(a => a.AnimationId == id);
            return View("Edit", animation);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult IndexJson() {
            string imageUrl = Url.Action("Show", "Media", null, Request.Url.Scheme, Request.Url.Host);
            IEnumerable<object> animations;
            animations = (from animation in Context.Animations
                          select new {
                              Name = animation.Name,
                              MediaSets = animation.MediaSets.Select(s => new { 
                                Name = s.Name,
                                StartDate = s.StartDate,
                                EndDate = s.EndDate,
                                Media = s.Media.Select(m => new {
                                  Url = imageUrl + "/" + m.Filename,
                                  Properties = m.Properties.Select(p => new {
                                      Name = p.PropertyDescriptor.Name,
                                      Value = p.Value
                                  }),
                                }),
                              }),
                              Message = animation.Message
                          }).ToList();
            return Json(animations, JsonRequestBehavior.AllowGet);
        }
    }
}
