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

        public ActionResult Edit(int id) {
            Animation animation;
            animation = Context.Animations.Single(a => a.AnimationId == id);
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
