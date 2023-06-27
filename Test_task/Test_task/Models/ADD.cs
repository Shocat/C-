using System.ComponentModel.DataAnnotations;

namespace Test_task.Models
{
    public class ADD
    {
    
        [Required(ErrorMessage = "Пропустил имя")]
        public string Name {get; set;}
        [Required(ErrorMessage ="Пропустил фамилию")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Пропустил почту")]
        public string mail { get; set; }

        [Required(ErrorMessage = "Пропустил пароль")]
        public string pass { get; set; }

        [Required(ErrorMessage = "Пожалуйста, выберите файл фотографии")]
        public IFormFile Photo { get; set; }



    }
}
