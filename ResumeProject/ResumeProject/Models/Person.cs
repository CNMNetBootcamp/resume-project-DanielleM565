using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeProject.Models
{
    public class Person
    {
        public int ID { get; set; }
        [StringLength(50)]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public int PhoneNumber { get; set; }
        public string Email { get; set; }
    }


}
