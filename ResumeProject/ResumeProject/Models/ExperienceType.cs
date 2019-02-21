using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeProject.Models
{
    public class ExperienceType
    {
        public int ID { get; set; }
        
        public List<string> ExpType
        {
           get {
                string[] input =
                    { "Volunteering", "Work", "Teaching" };
                List<string> typeArray = new List<string>(input);
                return typeArray;
                }
        }

        //navigational properties
        public Experience Experience { get; set; }
    }
}
