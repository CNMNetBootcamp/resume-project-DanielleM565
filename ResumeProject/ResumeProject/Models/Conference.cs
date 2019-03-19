using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeProject.Models
{
    public class Conference
    {
        public int ID { get; set; }
        public int PersonID { get; set; }

        public string EventType { get; set; }
        public string Role { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-yyyy}", ApplyFormatInEditMode = false)]
        public DateTime EventDate { get; set; }

        public Person People { get; set; }
    }
}