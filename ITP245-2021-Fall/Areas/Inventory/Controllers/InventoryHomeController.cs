using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITP245_2021_Fall.Areas.Inventory.Controllers
{
    public class InventoryHomeController : Controller
    {
        // GET: Inventory/InventoryHome
        [Authorize(Roles = "Inventory")]
        public ActionResult Index()
        {
            return View();
        }
    }
}