using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeProject.Models
{
    public class Event
    {
        public int ID { get; set; }
        public int PersonID { get; set; }

        public string EventType { get; set; }
        public string Role { get; set; }
        public string Description { get; set; }

        public ICollection<Person> Persons { get; set; }
    }
}
