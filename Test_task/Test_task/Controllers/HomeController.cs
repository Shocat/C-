using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Test_task.Models;
using Npgsql;
using System.Collections.Generic;
namespace Test_task.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Npgsql;
    using System.Collections.Generic;
    using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


    namespace Test_task.Controllers
    {
        public class HomeController : Controller
        {
            private readonly ILogger<HomeController> _logger;
            private readonly string _connectionString = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=admin";

            public HomeController(ILogger<HomeController> logger)
            {
                _logger = logger;
            }

            public IActionResult Index()
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand("SELECT cars.*, content.* FROM cars INNER JOIN content ON cars.id = content.id", connection))
                        
                    {
                       
                        var models = new List<MyModel>();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var model = new MyModel
                                {
                                    Name_Auto = reader.GetString(2),
                                    Category = reader.GetString(1),
                                    Autor = reader.GetString(5),
                                    Date_Create = reader.GetDateTime(3),
                                    Date_Update = reader.GetDateTime(4),
                                    ImagePath = reader.GetString(reader.GetOrdinal("image_path")),
                                    info = reader.GetString(reader.GetOrdinal("info"))
                                };
                                models.Add(model);
                            }
                        }
                        return View(models);
                    }
                }
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

}
