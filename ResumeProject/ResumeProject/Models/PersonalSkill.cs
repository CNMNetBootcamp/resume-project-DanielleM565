using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeProject.Models
{
    public class PersonalSkill
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        public string Skill { get; set; }

        //navigational Properties
        public Person People { get; set; }
    }
}
