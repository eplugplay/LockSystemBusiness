using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LockSystemBusiness.Models;

namespace LockSystemBusiness.Controllers
{
    public class LocksController : Controller
    {
        //
        // GET: /Pants/

        public ActionResult Index()
        {
            return View(new ImageModel("LocksImages", true));
        }

        [HttpPost]
        public PartialViewResult ReloadImg()
        {
            return PartialView("_AllImg", new ImageModel("LocksImages", true));
        }
    }
}
