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
            if (context.People.Any())
            {
                return; //DB seeded
            }

            if (context.People.Any())
            {
                foreach (var Person in context.People)
                {
                    context.People.Remove(Person);
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

            if (context.ExperienceTypes.Any())
            {
                foreach (var ExperienceType in context.ExperienceTypes)
                {
                    context.ExperienceTypes.Remove(ExperienceType);
                }
                context.SaveChanges();
                AddExperienceTypes(context);
            }
            else
            {
                AddExperienceTypes(context);
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
            };
            foreach (Description d in Descriptions)
            {
                context.Descriptions.Add(d);
            }
            context.SaveChanges();
        }

        private static void AddExperienceTypes(ResumeContext context)
        {
            var ExperienceTypes = new ExperienceType[]
            {
                //V, J or T
            };
            foreach (ExperienceType e in ExperienceTypes)
            {
                context.ExperienceTypes.Add(e);
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
                    Role = "",
                    Organization = "",
                    CurrentlyStillWorking = true,
                    YearsService = 2,
                },
                new Experience
                {
                    Role = "",
                    Organization = "",
                    CurrentlyStillWorking = true,
                    YearsService = 2,
                },
                new Experience
                {
                    Role = "",
                    Organization = "",
                    CurrentlyStillWorking = true,
                    YearsService = 2,
                },
                new Experience
                {
                    Role = "",
                    Organization = "",
                    CurrentlyStillWorking = true,
                    YearsService = 2,
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
                    PersonID = 1,
                    EventType = "Conference",
                    Role = "Poster Presenter",
                    Description = "ACS- American Chemical Society National Conference Denver, Co",
                    EventDate = DateTime.Parse("03-01-2015")
                },
                 new Event
                {
                    PersonID = 1,
                    EventType = "Conference",
                    Role = "Poster Presenter",
                    Description = "INBRE- IDeA Networks of Biomedical Research Excellence Santa Fe, NM",
                    EventDate = DateTime.Parse("03-01-2015")
                },
                 new Event
                {
                    PersonID = 1,
                    EventType = "Conference",
                    Role = "Panel",
                    Description = "SKC- Shared Knowledge Conference: Engaging Students in STEM",
                    EventDate = DateTime.Parse("04-01-2015")
                },
                 new Event
                {
                    PersonID = 1,
                    EventType = "Hack-a-thon",
                    Role = "3rd Place Winner",
                    Description = "Suncode in Oakland, California Hosted by Powerhouse (of 24 teams)",
                    EventDate = DateTime.Parse("04-01-2018")
                },
                  new Event
                {
                    PersonID = 1,
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
                    PersonID = 1,
                    Degree = "Bachlors of Science in Biochemistry",
                    School = "University of New Mexico",
                    GraduationDate = DateTime.Parse("05-01-2015")
                },
                new Education
                {
                    PersonID = 1,
                    Degree = "PHP Full-Stack Web Development",
                    School = "Deep Dive Coding Bootcamp",
                    GraduationDate = DateTime.Parse("05-01-2017")
                },
                new Education
                {
                    PersonID = 1,
                    Degree = ".NET Development",
                    School = "Deep Dive Coding Bootcamp",
                    GraduationDate = DateTime.Parse("03-21-2019")
                },
                new Education
                {
                    PersonID = 1,
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
                    PersonID = 1,
                    Skill = "Freelance photographer and videographer with 8+ years of experience in Adobe products: Lightroom, Photoshop, More recently Premiere cut Pro and Illustrator.",
                    //YearsExperience = 10
                },
                new PersonalSkill
                {
                    PersonID = 1,
                    Skill = "International Traveler- I enjoy traveling and have comfortably been all over the US and Canada and have traveled internationally to China and India.",
                    //YearsExperience = 9
                },
                new PersonalSkill
                {
                    PersonID = 1,
                    Skill = "Years of theatre and film experience as well as  Public Speaking instruction has helped my confidence with giving talks in-front of large crowds.",
                    //YearsExperience = 10
                }
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
                    FirstName = "Danielle ",
                    LastName = "Isles Martin",
                    PhoneNumber = 505-803-7519,
                    Email = "danielleislesmartin@gmail.com"
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
