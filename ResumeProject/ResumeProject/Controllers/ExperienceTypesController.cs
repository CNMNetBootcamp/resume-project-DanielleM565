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
    public class ExperienceTypesController : Controller
    {
        private readonly ResumeContext _context;

        public ExperienceTypesController(ResumeContext context)
        {
            _context = context;
        }

        // GET: ExperienceTypes
        public async Task<IActionResult> Index()
        {
            var resumeContext = _context.ExperienceTypes.Include(e => e.Experience);
            return View(await resumeContext.ToListAsync());
        }

        // GET: ExperienceTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experienceType = await _context.ExperienceTypes
                .Include(e => e.Experience)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (experienceType == null)
            {
                return NotFound();
            }

            return View(experienceType);
        }

        // GET: ExperienceTypes/Create
        public IActionResult Create()
        {
            ViewData["ExperienceID"] = new SelectList(_context.Experiences, "ID", "ID");
            return View();
        }

        // POST: ExperienceTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ExperienceID,ExpType")] ExperienceType experienceType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(experienceType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExperienceID"] = new SelectList(_context.Experiences, "ID", "ID", experienceType.ExperienceID);
            return View(experienceType);
        }

        // GET: ExperienceTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experienceType = await _context.ExperienceTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (experienceType == null)
            {
                return NotFound();
            }
            ViewData["ExperienceID"] = new SelectList(_context.Experiences, "ID", "ID", experienceType.ExperienceID);
            return View(experienceType);
        }

        // POST: ExperienceTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ExperienceID,ExpType")] ExperienceType experienceType)
        {
            if (id != experienceType.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(experienceType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExperienceTypeExists(experienceType.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExperienceID"] = new SelectList(_context.Experiences, "ID", "ID", experienceType.ExperienceID);
            return View(experienceType);
        }

        // GET: ExperienceTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experienceType = await _context.ExperienceTypes
                .Include(e => e.Experience)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (experienceType == null)
            {
                return NotFound();
            }

            return View(experienceType);
        }

        // POST: ExperienceTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var experienceType = await _context.ExperienceTypes.SingleOrDefaultAsync(m => m.ID == id);
            _context.ExperienceTypes.Remove(experienceType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExperienceTypeExists(int id)
        {
            return _context.ExperienceTypes.Any(e => e.ID == id);
        }
    }
}
