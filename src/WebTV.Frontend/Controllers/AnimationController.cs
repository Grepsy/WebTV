using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTV.Model;
using System.Security.Permissions;

namespace WebTV.Frontend.Controllers {
    public class AnimationController : ControllerBase {
        
        public ActionResult Index() {
            var animations = Context.Animations.ToList();
            if (Request.Params["type"] == "json") {
                return Json(animations.ConvertAll(AnimationToJson), JsonRequestBehavior.AllowGet);
            }
            
            return View(animations);
        }

        public ActionResult Details(int id, int? mediaSetId) {
            Animation animation;
            if (mediaSetId.HasValue) {
                animation = Context.Animations.Single(a => 
                    a.AnimationId == id &&
                    a.MediaSets.Any(s => s.MediaSetId == mediaSetId));
            }
            else {
                animation = Context.Animations.Single(a => a.AnimationId == id);
            }

            if (Request.Params["type"] == "json") {
                return Json(AnimationToJson(animation), JsonRequestBehavior.AllowGet);
            }
            else {
                return View(animation);
            }
        }

        [Authorize(Roles = "Administrator,User")]
        public ActionResult Edit(int id) {
            var animation = Context.Animations.Single(a => a.AnimationId == id);
            return View("Edit", animation);
        }

        private object AnimationToJson(Animation animation) {
            string imageUrl = Url.Action("Show", "Media", null, Request.Url.Scheme, Request.Url.Host);
            var json = new {
                Name = animation.Name,
                MediaGroupedBy = animation.MediaGroupedBy,
                MediaSets = animation.MediaSets.Select(s => new { 
                    Name = s.Name,
                    StartDate = s.StartDate,
                    EndDate = s.EndDate,
                    Message  = s.Message,
                    Media = animation.MediaGroupedBy == 1 ? s.Media.Select(m => m.ToJsonObject(imageUrl)) : null,
                    Groups = s.MediaGroups.Select(g => new {
                        Media = g.Media.Select(m => m.ToJsonObject(imageUrl))
                    })
                })
            };
            return json;
        }
    }
}
