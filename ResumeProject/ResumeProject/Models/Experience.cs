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
        public string Role { get; set; }
        public string Organization { get; set; }
        public Boolean CurrentlyStillWorking { get; set; }
        [Display(Name = "Years of Service")]
        //[DisplayFormat(DataFormatString = {value} + " years")]
        public int YearsService { get; set; }

        //navigational properties
        public ICollection<Person> Persons { get; set; }
    }
}