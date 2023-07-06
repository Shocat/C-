using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Test_task.Models;

namespace Test_task.Controllers
{
    public class GruzCarController : Controller
    {
        private readonly MyAppDbContext _dbContext;

        public GruzCarController(MyAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var models = _dbContext.Cars
                .Where(c => c.Category == "грузовой")
                .Select(c => new gruzcar
                {
                    Name_Auto = c.Name_Auto,
                    Category = c.Category,
                    Autor = c.Autor,
                    Date_Create = c.Date_Create,
                    Date_Update = c.Date_Update,
                    ImagePath = c.ImagePath,
                    info = c.info
                })
                .ToList();

            return View(models);
        }
    }
}
