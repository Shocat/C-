﻿using System.ComponentModel.DataAnnotations;

namespace Test_task.Models
{
    public class lightcar
    {

        
            //[Display(Name = "Имя авто")]
            public string Name_Auto { get; set; }
            public string Autor { get; set; }
            public string Category { get; set; }
            public DateTime Date_Create { get; set; }
            public DateTime Date_Update { get; set; }
            public string ImagePath { get; set; }
            public string info { get; set; }
        

    }
}
