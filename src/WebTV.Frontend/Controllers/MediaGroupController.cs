using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTV.Model;

namespace WebTV.Frontend.Controllers
{
    public class MediaGroupController : ControllerBase
    {
        public ActionResult New(int mediaSetId)
        {
            try {
                Context.MediaGroups.AddObject(new MediaGroup() {
                    MediaSetId = mediaSetId
                });
                Context.SaveChanges();
                TempData["message"] = new InfoMessage("Nieuwe groep is aangemaakt.", InfoMessage.InfoType.Notice);
            }
            catch (Exception e) {
                Elmah.ErrorSignal.FromCurrentContext().Raise(e);
                TempData["message"] = new InfoMessage("Er is een fout opgetreden bij het maken van de group.", InfoMessage.InfoType.Error);
            }
            return RedirectToAction("Index");
        }

    }
}
