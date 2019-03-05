using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeProject.Models
{
    public class Person
    {
        public int ID { get; set; }
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public int PhoneNumber { get; set; }
        public string Email { get; set; }

        //navigational properties
        public Experience Experience { get; set; }
        public ICollection<Education> Educations { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<PersonalSkill> PersonalSkills { get; set; }
    }


}
