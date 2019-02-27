using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeProject.Models
{
    public class Description
    {
        public int ID { get; set; }
        public int ExperienceID { get; set; }
        public string Duties { get; set; }

        //navigational properties 
        public Experience Experience { get; set; }
    }
}
