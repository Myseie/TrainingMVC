using Microsoft.AspNetCore.Mvc;
using TrainingMVC.Models;

namespace TrainingMVC.Controllers
{
    public class TrainingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create ()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Training training)
        {
             var db = new Database();
            db.SaveTraining(training);
            
           

            return Redirect("/Home");
        }

        public IActionResult ShowTraining(Training training)
        {
            var db = new Database();
            db.ShowTraining(training);

            return View(training);


        }
        public IActionResult EditTraining()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditTraining(Training training)
        {
            var db = new Database();
            db.EditTraining(training);

            return Redirect("/Home");
        }

        [HttpPost]
        public IActionResult DeleteTraining(Training training)
        {
            var db = new Database();
            db.DeleteTraining(training);

            return Redirect("/Home");
        }



    }
}
