﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeProject.Models
{
    public class Experience
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        public string Role { get; set; }
        public string Organization { get; set; }
        [Display(Name = "Currently Still Working")]
        public Boolean CurrentlyStillWorking { get; set; }
        [Display(Name = "Years of Service")]
        public int YearsService { get; set; }
        public string ExperienceType { get; set; }
        
        //navigational properties
        public Person People { get; set; }
        public ICollection<Description> Descriptions { get; set; }
    }
}
