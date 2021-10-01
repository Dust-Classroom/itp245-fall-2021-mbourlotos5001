using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITP245_2021_Fall.Models;

namespace ITP245_2021_Fall.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.TodaysDate = DateTime.Today.ToString("d");
            ViewBag.Name = "Michael Bourlotos";
            var goals = new List<string>();
            goals.Add("Graduate Spring 2022");
            goals.Add("Possibly Apprentice at " + "<a href=\"https://maxxpotential.com/apprentice/\"> Maxx Potential</a>");
            goals.Add("Find some kind of job");
            var hobbies = new List<string>();
            hobbies.Add("Surfing");
            hobbies.Add("Biking");
            hobbies.Add("<a href=\"https://photoaday.michaelbourlotos.com/\"> Photography</a>");
            hobbies.Add("<a href=\"https://wearekomodo.bandcamp.com/releases\"> Music</a>");
            var user = new Models.About()
            {
                AboutPhoto = "<img height=\"200\" src=\"/ITP24511/Content/images/olive.png\" alt=\"Michael with puggle\" />",
                Description = "Programming Student",
                FirstName = "Michael",
                LastName = "Bourlotos",
                Goals = goals,
                Hobbies = hobbies
                
            };



            return View(user);
        }

       
    }
}