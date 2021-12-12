using System.Web;
using System.Web.Mvc;

namespace ITP245_2021_Fall.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public string Index()
        {
            return "Reynolds is a schooooooool";
        }
        public string Details(int id)
        {
            return $"The Student ID is {id}";
        }
        public string Browse(string name)
        {
            var student = HttpUtility.HtmlEncode(name);
            return student;
        }
        public ActionResult Transcript(int id)
        {
            string[][] transcript = new[]
            {
                new[] { "Pastsa", "Pesto", "Potato:" },
                new[] { "Pastsa", "Pesto", "Potato:" },
                new[] { "Pastsa", "Pesto", "Potato:" }
            };
            return View(transcript);
        }
    }
}