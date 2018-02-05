using Cuelogic.Clrm.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cuelogic.Clrm.Api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            ViewBag.Title = "Home Page";
            var list = MasterGroupSrv.GetIdentityGroupList();
            return View();
        }
    }
}
