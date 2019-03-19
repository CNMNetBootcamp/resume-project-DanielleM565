using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ResumeProject.Models;
using ResumeProject.Data;
using Microsoft.EntityFrameworkCore;

namespace ResumeProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ResumeContext _context;

        public HomeController(ResumeContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? ExperienceID)
        {
            var person = await _context.People
                .Include(e => e.Educations)
                .Include(f => f.Events)
                .Include(g => g.PersonalSkills)
                .Include(h => h.Experiences)
                    .ThenInclude(i => i.Descriptions)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.FirstName == "Danielle");

            return View(person);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
