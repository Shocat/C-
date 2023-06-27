using Microsoft.AspNetCore.Mvc;

namespace Test_task.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
