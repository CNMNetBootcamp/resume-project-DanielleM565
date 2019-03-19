using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeProject.Models
{
    public class Education
    {
        public int ID { get; set; }
        public int PersonID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-yyyy}", ApplyFormatInEditMode = false)]
        public DateTime GraduationDate { get; set; }

        public string Degree { get; set; }
        public string School { get; set; }

        public Person People { get; set; }
    }
}
