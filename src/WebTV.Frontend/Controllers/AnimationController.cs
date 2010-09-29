using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTV.Model;

namespace WebTV.Frontend.Controllers
{
    public class AnimationController : Controller
    {
        private WebTVContext context;

        public AnimationController() {
            context = new WebTVContext();
        }

        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);
            context.Dispose();
        }

        public ActionResult Index()
        {
            IEnumerable<Animation> animations;
            
            animations = context.Animations.ToList();
            
            return View(animations);
        }

        public ActionResult Edit(int id) {
            Animation animation;
            animation = context.Animations.Single(a => a.AnimationId == id);
            return View("Edit", animation);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult IndexJson() {
            IEnumerable<object> animations;
            animations = (from animation in context.Animations
                            select new {
                                Name = animation.Name,
                                Media = animation.Media.Select(m => new {
                                    Url = m.Url,
                                    Properties = m.Properties.Select(p => new { 
                                        Name = p.PropertyDescriptor.Name,
                                        Value = p.Value
                                    }),
                                }),
                                Message = animation.Message
                            }).ToList();
            return Json(animations, JsonRequestBehavior.AllowGet);
        }
    }
}
