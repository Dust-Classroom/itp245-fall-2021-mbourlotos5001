using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITP245_2021_Fall.Areas.School.Controllers
{
    public class SchoolHomeController : Controller
    {
        // GET: School/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}