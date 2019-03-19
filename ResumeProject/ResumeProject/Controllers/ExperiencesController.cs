using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResumeProject.Data;
using ResumeProject.Models;

namespace ResumeProject.Controllers
{
    public class ExperiencesController : Controller
    {
        private readonly ResumeContext _context;

        public ExperiencesController(ResumeContext context)
        {
            _context = context;
        }

        // GET: Experiences
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["ExpierenceTypeSortParam"] = String.IsNullOrEmpty(sortOrder) ? "type_desc" : "";
            ViewData["CurrentSort"] = sortOrder;

            var type = from e in _context.Experiences
                       select e;

            //switch (sortOrder)
            //{
            //    case "type_desc":
            //        type = types.OrderByDescending(y => y.ExpierenceType);
            //        break;
            //    default:
            //        type = types.OrderBy(y => y.ExpierenceType);
            //        break;
            //}

            var resumeContext = _context.Experiences.Include(e => e.People);
            return View(await resumeContext.ToListAsync());
        }

        // GET: Experiences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experience = await _context.Experiences
                .Include(d => d.Descriptions)
                .Include(e => e.People)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (experience == null)
            {
                return NotFound();
            }

            return View(experience);
        }

        // GET: Experiences/Create
        public IActionResult Create()
        {
            ViewData["PersonID"] = new SelectList(_context.People, "ID", "FullName");
            //ViewData["ExpierenceType"] = new SelectList("Volunteering", "Work", "Teaching");

            return View();
        }

        // POST: Experiences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PersonID,Role,Organization,CurrentlyStillWorking,YearsService,ExperienceType")] Experience experience)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(experience);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["PersonID"] = new SelectList(_context.People, "ID", "ID", experience.PersonID);
                //ViewData["ExpierenceType"] = new SelectList(_context.Experiences, "ID", "Volunteering", "Work", "Teaching");
            }
            catch (DbUpdateException)
            {

                ModelState.AddModelError("", "Unable to save new Expierence");
            }
            return View(experience);
        }

        // GET: Experiences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experience = await _context.Experiences.SingleOrDefaultAsync(m => m.ID == id);
            if (experience == null)
            {
                return NotFound();
            }
            ViewData["PersonID"] = new SelectList(_context.People, "ID", "FullName", experience.PersonID);
            return View(experience);
        }

        // POST: Experiences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var experienceToUpdate = await _context.Experiences.SingleOrDefaultAsync(e => e.ID == id);
            if (await TryUpdateModelAsync<Experience>(experienceToUpdate, "",
            e => e.Role, e => e.Organization, e => e.CurrentlyStillWorking, e => e.YearsService))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes to Experience.");
                }
            }
            ViewData["PersonID"] = new SelectList(_context.People, "ID", "ID", experienceToUpdate.PersonID);
            ViewData["ExpierenceType"] = new SelectList("Volunteering", "Work", "Teaching");
            return View(experienceToUpdate);
        }

        // GET: Experiences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experience = await _context.Experiences
                .Include(e => e.People)
                .Include(y => y.Descriptions)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (experience == null)
            {
                return NotFound();
            }

            return View(experience);
        }

        // POST: Experiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var experience = await _context.Experiences.SingleOrDefaultAsync(m => m.ID == id);
            _context.Experiences.Remove(experience);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExperienceExists(int id)
        {
            return _context.Experiences.Any(e => e.ID == id);
        }
    }
}
