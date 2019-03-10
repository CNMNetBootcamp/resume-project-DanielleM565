using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeProject.Models
{
    public class Description
    {
        public int ID { get; set; }
        public string Duties { get; set; }

        //navigational Properties
        public int ExperienceID { get; set; }
        public Experience Experiences { get; set; }
    }
}
