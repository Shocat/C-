using Microsoft.EntityFrameworkCore;
using Test_task.Models;

namespace Test_task.Models
{
    public class MyAppDbContext : DbContext
    {
     
        public DbSet<autobuscar> AutobusCars { get; set; }

        public DbSet<Car> Cars { get; set; }
        
        public DbSet<Contents> Contents { get; set; }
        public DbSet<gruzcar> GruzCar { get; set; }
       

        public MyAppDbContext(DbContextOptions<MyAppDbContext> options)
            : base(options)
        {
        }

      
    }
}
