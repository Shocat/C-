using Microsoft.AspNetCore.Mvc;
using Test_task.Models;

namespace Test_task.Controllers
{
    public class ADDController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult  Check(ADD add)
        {
            if (ModelState.IsValid)
            {
                return Redirect("/Home");
            }
            return View("Index");
        }
    }
}
