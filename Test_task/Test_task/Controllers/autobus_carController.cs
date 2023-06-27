using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Test_task.Controllers.Test_task.Controllers;
using Test_task.Models;

namespace Test_task.Controllers
{
    public class autobus_carController : Controller
    {
        private readonly string _connectionString = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=admin";



        public IActionResult Index()
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT cars.*, content.* FROM cars INNER JOIN content ON cars.id = content.id WHERE cars.category = 'автобус'", connection))
                {

                    var models = new List<autobuscar>();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var model = new autobuscar
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

    }
}
