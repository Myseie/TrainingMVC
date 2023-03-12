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
            db = db.SaveTraining(exercise, sets,);
            var collection = db.GetCollection<Training>();
            collection.Insertone(training);

            return Redirect("/Home");
        }
    }
}
