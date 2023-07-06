using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Test_task.Models;

namespace Test_task.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyAppDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, MyAppDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var models = _dbContext.Cars
                .Join(_dbContext.Contents, car => car.Id, content => content.Car_Id, (car, content) => new Car
                {
                    Name_Auto = car.Name_Auto,
                    Category = car.Category,
                    Autor = car.Autor,
                    Date_Create = car.Date_Create,
                    Date_Update = car.Date_Update,
                    ImagePath = content.ImagePath,
                    Info = content.Info
                })
                .ToList();

            return View(models);
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Check()
        {
            return View("Index");
        }
    }
}
