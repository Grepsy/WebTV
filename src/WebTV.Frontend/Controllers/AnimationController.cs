using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTV.Model;
using System.Security.Permissions;

namespace WebTV.Frontend.Controllers {
    public class AnimationController : ControllerBase {
        
        public ActionResult Index(int id) {
            var animation = Context.Animations.Single(a => a.AnimationId == id);
           
            if (Request.Params["type"] == "json") {
                return Json(AnimationToJson(animation), JsonRequestBehavior.AllowGet);
            }
            
            return View(animation);
        }

        public ActionResult Details(int id, int mediaSetId) {
            var animation = Context.Animations.Single(a => 
                    a.AnimationId == id &&
                    a.MediaSets.Any(s => s.MediaSetId == mediaSetId));
            
            return Json(AnimationToJson(animation, mediaSetId), JsonRequestBehavior.AllowGet);
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
                MediaSets = animation.MediaSets
                    .Where(m => m.StartDate.HasValue && m.EndDate.HasValue)
                    .Where(m => m.StartDate.Value < DateTime.Now && m.EndDate.Value > DateTime.Now)
                    .Select(s => new { 
                        Name = s.Name,
                        StartDate = s.StartDate,
                        EndDate = s.EndDate,
                        Message  = s.Message,
                        Media = animation.MediaGroupedBy == 1 ? s.Media.Select(m => m.ToJsonObject(imageUrl)) : null,
                        Groups = s.MediaGroups.Select(g => g.ToJsonObject(imageUrl))
                })
            };
            return json;
        }
        
        private object AnimationToJson(Animation animation, int mediaSetId) {
            string imageUrl = Url.Action("Show", "Media", null, Request.Url.Scheme, Request.Url.Host);
            var json = new {
                Name = animation.Name,
                MediaGroupedBy = animation.MediaGroupedBy,
                MediaSets = animation.MediaSets.Where(m => m.MediaSetId == mediaSetId).Select(s => new { 
                    Name = s.Name,
                    StartDate = s.StartDate,
                    EndDate = s.EndDate,
                    Message  = s.Message,
                    Media = animation.MediaGroupedBy == 1 ? s.Media.Select(m => m.ToJsonObject(imageUrl)) : null,
                    Groups = s.MediaGroups.Select(g => g.ToJsonObject(imageUrl))
                })
            };
            return json;
        }
    }
}
