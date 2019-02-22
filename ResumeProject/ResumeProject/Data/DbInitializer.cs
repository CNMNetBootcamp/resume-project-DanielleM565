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
                //add conferences and hack-athons here
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
                new Education{}
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
            };
            foreach (Person p in People)
            {
                context.People.Add(p);
            }
            context.SaveChanges();
        }

    }
}
