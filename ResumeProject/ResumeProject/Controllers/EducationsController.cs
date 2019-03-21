using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResumeProject.Data;
using ResumeProject.Models;

namespace ResumeProject.Controllers
{
    [Authorize]
    public class EducationsController : Controller
    {
        private readonly ResumeContext _context;

        public EducationsController(ResumeContext context)
        {
            _context = context;
        }

        // GET: Educations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Educations.ToListAsync());
        }

        // GET: Educations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var education = await _context.Educations
                .SingleOrDefaultAsync(m => m.ID == id);
            if (education == null)
            {
                return NotFound();
            }

            return View(education);
        }

        // GET: Educations/Create
        public IActionResult Create()
        {
            ViewData["PersonID"] = new SelectList(_context.People, "ID", "FullName");
            return View();
        }

        // POST: Educations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PersonID,GraduationDate,Degree,School")] Education education)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(education);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(education);
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save new Education");
               
            }
            return View(education);
        }

        // GET: Educations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education = await _context.Educations.SingleOrDefaultAsync(m => m.ID == id);
            if (education == null)
            {
                return NotFound();
            }
            ViewData["PersonID"] = new SelectList(_context.People, "ID", "FullName", education.PersonID);
            return View(education);
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var educationToUpdate = await _context.Educations.SingleOrDefaultAsync(e => e.ID == id);
            if (await TryUpdateModelAsync<Education>(
                educationToUpdate, 
                "",
                e => e.Degree, e => e.School, e => e.GraduationDate))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes to education.");
                }
            }
            ViewData["PersonID"] = new SelectList(_context.People, "ID", "FullName", educationToUpdate.PersonID);
            return View(educationToUpdate);
        }

        // GET: Educations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education = await _context.Educations
                .SingleOrDefaultAsync(m => m.ID == id);
            if (education == null)
            {
                return NotFound();
            }
            
            return View(education);
        }

        // POST: Educations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var education = await _context.Educations.SingleOrDefaultAsync(m => m.ID == id);
            _context.Educations.Remove(education);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EducationExists(int id)
        {
            return _context.Educations.Any(e => e.ID == id);
        }
    }
}
