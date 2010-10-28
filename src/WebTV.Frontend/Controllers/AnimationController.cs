using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTV.Model;

namespace WebTV.Frontend.Controllers {
    public class AnimationController : ControllerBase {
        public ActionResult Index(int? id) {
            if (id.HasValue) {
                var animation = Context.Animations.Single(a => a.AnimationId == id);
                if (Request.Params["type"] == "json") {
                    return Json(AnimationToJson(animation), JsonRequestBehavior.AllowGet);
                }

                return View(animation);
            }

            var animations = Context.Animations.ToList();
            if (Request.Params["type"] == "json") {
                return Json(animations.ConvertAll(AnimationToJson), JsonRequestBehavior.AllowGet);
            }
            
            return View(animations);
        }
        
        public ActionResult Edit(int id) {
            var animation = Context.Animations.Single(a => a.AnimationId == id);
            return View("Edit", animation);
        }

        private object AnimationToJson(Animation animation) {
            string imageUrl = Url.Action("Show", "Media", null, Request.Url.Scheme, Request.Url.Host);
            var json = new {
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
            };
            return json;
        }
    }
}
