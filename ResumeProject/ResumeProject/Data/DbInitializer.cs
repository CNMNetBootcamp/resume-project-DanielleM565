using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResumeProject.Models;

namespace ResumeProject.Data
{
    public class DbInitializer
    {
        public static void Inilialize(ResumeContext context)
        {
            context.Database.EnsureCreated();

            //look for where all the peeps at
            //if (context.People.Any())
            //    {
            //        return; //DB seeded
            //    }

            if (context.People.Any())
            {
                foreach (var person in context.People)
                {
                    context.People.Remove(person);
                }
                context.SaveChanges();
                AddPeople(context);
            }
            else
            {
                AddPeople(context);
            }

            if (context.PersonalSkills.Any())
            {
                foreach (var PersonalSkill in context.PersonalSkills)
                {
                    context.PersonalSkills.Remove(PersonalSkill);
                }
                context.SaveChanges();
                AddPersonalSkills(context);
            }
            else
            {
                AddPersonalSkills(context);
            }

            if (context.Educations.Any())
            {
                foreach (var Education in context.Educations)
                {
                    context.Educations.Remove(Education);
                }
                context.SaveChanges();
                AddEducations(context);
            }
            else
            {
                AddEducations(context);
            }

            if (context.Events.Any())
            {
                foreach (var Event in context.Events)
                {
                    context.Events.Remove(Event);
                }
                context.SaveChanges();
                AddEvents(context);
            }
            else
            {
                AddEvents(context);
            }

            if (context.Experiences.Any())
            {
                foreach (var Experience in context.Experiences)
                {
                    context.Experiences.Remove(Experience);
                }
                context.SaveChanges();
                AddExperiences(context);
            }
            else
            {
                AddExperiences(context);
            }

            if (context.Descriptions.Any())
            {
                foreach (var Description in context.Descriptions)
                {
                    context.Descriptions.Remove(Description);
                }
                context.SaveChanges();
                AddDescriptions(context);
            }
            else
            {
                AddDescriptions(context);
            }

        }

        private static void AddDescriptions(ResumeContext context)
        {
            var Descriptions = new Description[]
            {
                //long strings for experience
                new Description
                {
                    ExperienceID = context.Experiences.SingleOrDefault(y => y.Organization == "Mountain Vector Energy").ID,
                    Duties = "Data Analyst for Building/ Energy Management Systems and trending, skilled specifically in data extraction from Trane, Automated Control Systems, and Integrated Control Systems.",
                },
                new Description
                {
                    ExperienceID = context.Experiences.SingleOrDefault(y => y.Organization == "Mountain Vector Energy").ID,
                    Duties = "Build prototype devices for the field which may entail the following: safely solder, program new devices and customize sensor software based on site audits.",
                },
                new Description
                {
                    ExperienceID = context.Experiences.SingleOrDefault(y => y.Organization == "Mountain Vector Energy").ID,
                    Duties = "Front-end Software Developer for client web application. Key partner to development team aiding with site’s style in CSS and functionality JavaScript.",
                },
                new Description
                {
                    ExperienceID = context.Experiences.SingleOrDefault(y => y.Organization == "Mountain Vector Energy").ID,
                    Duties = "Code custom data visualization graphing tools using Highcharts.js library to go from raw data to graph faster than excel (depending on data quality).",
                },
                new Description
                {
                    ExperienceID = context.Experiences.SingleOrDefault(y => y.Organization == "Mountain Vector Energy").ID,
                    Duties = "Knowledgeable in using and fixing tools in Windows 10 and Office 365 applications such as: Outlook, SharePoint, Excel, PowerPoint and others.",
                },
                new Description
                {
                    ExperienceID = context.Experiences.SingleOrDefault(y => y.Organization == "Lab Technician: Biomedical Research").ID,
                    Duties = "Design experiments and analyze data in technical research projects working on a team and individually.",
                },
                new Description
                {
                    ExperienceID = context.Experiences.SingleOrDefault(y => y.Organization == "Lab Technician: Biomedical Research").ID,
                    Duties = "Communicate findings in group meetings and keeping an organized scientific journal.",
                },
                new Description
                {
                    ExperienceID = context.Experiences.SingleOrDefault(y => y.Organization == "Lab Technician: Biomedical Research").ID,
                    Duties = "Attention to detail when interpreting or analyzing data and communicating findings to colleagues.",
                },
                new Description
                {
                    ExperienceID = context.Experiences.SingleOrDefault(y => y.Organization == "AAUW's tech Trek Camp for Girls").ID,
                    Duties = "Monthly meetings with American Association of University Women members to organize activities and plan for the week-long math and science camp held annually at local universities.",
                },
                new Description
                {
                    ExperienceID = context.Experiences.SingleOrDefault(y => y.Organization == "UNM Department of Chemistry").ID,
                    Duties = "Instructed class of up to 75 students at a given time through applied learning styled laboratory experiments.",
                },
                new Description
                {
                    ExperienceID = context.Experiences.SingleOrDefault(y => y.Organization == "UNM Department of Chemistry").ID,
                    Duties = "Skilled in handling emergencies with the utmost care and consideration.",
                },

            };
            foreach (Description d in Descriptions)
            {
                context.Descriptions.Add(d);
            }
            context.SaveChanges();
        }

        private static void AddExperiences(ResumeContext context)
        {
            var Experiences = new Experience[]
            {
                //add experience
                new Experience
                {
                    PersonID = context.People.SingleOrDefault(y => y.FirstName == "Danielle").ID,
                    Role = "Technical Project Manager",
                    Organization = "Mountain Vector Energy",
                    CurrentlyStillWorking = true,
                    YearsService = 2,
                    ExperienceType = "Work",
                },
                new Experience
                {
                    PersonID = context.People.SingleOrDefault(y => y.FirstName == "Danielle").ID,
                    Role = "Lab Technician: Biomedical Research",
                    Organization = "University of New Mexico's Department of Biochemistry & Molecular Biology",
                    CurrentlyStillWorking = false,
                    YearsService = 1,
                    ExperienceType = "Work",
                },
                new Experience
                {
                    PersonID = context.People.SingleOrDefault(y => y.FirstName == "Danielle").ID,
                    Role = "Counselor, Dorm supervisor, Photographer",
                    Organization = "AAUW's tech Trek Camp for Girls",
                    CurrentlyStillWorking = true,
                    YearsService = 5,
                    ExperienceType = "Volunteering",
                },
                new Experience
                {
                    PersonID = context.People.SingleOrDefault(y => y.FirstName == "Danielle").ID,
                    Role = "Lab Technician Assistant",
                    Organization = "UNM Department of Chemistry",
                    CurrentlyStillWorking = false,
                    YearsService = 2,
                    ExperienceType = "Teaching",
                }
            };
            foreach (Experience e in Experiences)
            {
                context.Experiences.Add(e);
            }
            context.SaveChanges();
        }

        private static void AddEvents(ResumeContext context)
        {
            var Events = new Event[]
            {
                //add conferences and hack-a-thons here
                new Event
                {
                    PersonID = context.People.SingleOrDefault(y => y.FirstName == "Danielle").ID,
                    EventType = "Conference",
                    Role = "Poster Presenter",
                    Description = "ACS- American Chemical Society National Conference Denver, Co",
                    EventDate = DateTime.Parse("03-01-2015")
                },
                 new Event
                {
                    PersonID = context.People.SingleOrDefault(y => y.FirstName == "Danielle").ID,
                    EventType = "Conference",
                    Role = "Poster Presenter",
                    Description = "INBRE- IDeA Networks of Biomedical Research Excellence Santa Fe, NM",
                    EventDate = DateTime.Parse("03-01-2015")
                },
                 new Event
                {
                    PersonID = context.People.SingleOrDefault(y => y.FirstName == "Danielle").ID,
                    EventType = "Conference",
                    Role = "Panel",
                    Description = "SKC- Shared Knowledge Conference: Engaging Students in STEM",
                    EventDate = DateTime.Parse("04-01-2015")
                },
                 new Event
                {
                    PersonID = context.People.SingleOrDefault(y => y.FirstName == "Danielle").ID,
                    EventType = "Hack-a-thon",
                    Role = "3rd Place Winner",
                    Description = "Suncode in Oakland, California Hosted by Powerhouse (of 24 teams)",
                    EventDate = DateTime.Parse("04-01-2018")
                },
                  new Event
                {
                    PersonID = context.People.SingleOrDefault(y => y.FirstName == "Danielle").ID,
                    EventType = "Hack-a-thon",
                    Role = "Organizer",
                    Description = "Deep Dive first annual Code-a-thon. Civic style hackathon with focus on poverty",
                    EventDate = DateTime.Parse("03-01-2018")
                },
            };
            foreach (Event e in Events)
            {
                context.Events.Add(e);
            }
            context.SaveChanges(); 
        }

        private static void AddEducations(ResumeContext context)
        {
            var Educations = new Education[]
            {
                //add education here
                new Education
                {
                    PersonID = context.People.SingleOrDefault(y => y.FirstName == "Danielle").ID,
                    Degree = "Bachlors of Science in Biochemistry",
                    School = "University of New Mexico",
                    GraduationDate = DateTime.Parse("05-01-2015")
                },
                new Education
                {
                    PersonID = context.People.SingleOrDefault(y => y.FirstName == "Danielle").ID,
                    Degree = "PHP Full-Stack Web Development",
                    School = "Deep Dive Coding Bootcamp",
                    GraduationDate = DateTime.Parse("05-01-2017")
                },
                new Education
                {
                    PersonID = context.People.SingleOrDefault(y => y.FirstName == "Danielle").ID,
                    Degree = ".NET Development",
                    School = "Deep Dive Coding Bootcamp",
                    GraduationDate = DateTime.Parse("03-21-2019")
                },
                new Education
                {
                    PersonID = context.People.SingleOrDefault(y => y.FirstName == "Danielle").ID,
                    Degree = "High School Diploma",
                    School = "Public Academy for the Performing Arts",
                    GraduationDate = DateTime.Parse("05-01-2009")
                }
            };
            foreach (Education e in Educations)
            {
                context.Educations.Add(e);
            }
            context.SaveChanges();
        }

        private static void AddPersonalSkills(ResumeContext context)
        {
            var PersonalSkills = new PersonalSkill[]
            {
                //add skillz here
                new PersonalSkill
                {
                    PersonID = context.People.SingleOrDefault(y => y.FirstName == "Danielle").ID,
                    Skill = "Freelance photographer and videographer with 8+ years of experience in Adobe products: Lightroom, Photoshop, More recently Premiere cut Pro and Illustrator.",
                    //YearsExperience = 10
                },
                new PersonalSkill
                {
                    PersonID = context.People.SingleOrDefault(y => y.FirstName == "Danielle").ID,
                    Skill = "International Traveler- I enjoy traveling and have comfortably been all over the US and Canada and have traveled internationally to China and India.",
                    //YearsExperience = 9
                },
                new PersonalSkill
                {
                    PersonID = context.People.SingleOrDefault(y => y.FirstName == "Danielle").ID,
                    Skill = "Years of theatre and film experience as well as  Public Speaking instruction has helped my confidence with giving talks in-front of large crowds.",
                    //YearsExperience = 10
                },
                new PersonalSkill
                {
                    PersonID = context.People.SingleOrDefault(y => y.FirstName == "Danielle").ID,
                    Skill = "Over 10 years of experience working in customer service in a variety of settings including; face-to-face, over the phone and via electronic communications. Positions held including hostess, waitress and cashier",
                    //YearsExperience = 9
                },
            };
            foreach (PersonalSkill p in PersonalSkills)
            {
                context.PersonalSkills.Add(p);
            }
            context.SaveChanges();
        }

        private static void AddPeople(ResumeContext context)
        {
            var People = new Person[]
            {
                //add people here
                new Person
                {
                    FirstName="Danielle",
                    LastName="Isles Martin",
                    PhoneNumber=505-803-7519,
                    Email="danielleislesmartin@gmail.com"
                }
            };
            foreach (Person p in People)
            {
                context.People.Add(p);
            }
            context.SaveChanges();
        }

    }
}
