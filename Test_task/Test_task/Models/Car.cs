using System.ComponentModel.DataAnnotations;

namespace Test_task.Models
{
      public class Car
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Name_Auto { get; set; }
        public DateTime Date_Create { get; set; }
        public DateTime Date_Update { get; set; }
        public string Autor { get; set; }

        public string Info { get; set; }
        public string ImagePath { get; set; }
        public Content Content { get; set; }
    }

}
