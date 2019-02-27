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
    public class DescriptionsController : Controller
    {
        private readonly ResumeContext _context;

        public DescriptionsController(ResumeContext context)
        {
            _context = context;
        }

        // GET: Descriptions
        public async Task<IActionResult> Index()
        {
            var resumeContext = _context.Descriptions.Include(d => d.Experience);
            return View(await resumeContext.ToListAsync());
        }

        // GET: Descriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var description = await _context.Descriptions
                .Include(d => d.Experience)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (description == null)
            {
                return NotFound();
            }

            return View(description);
        }

        // GET: Descriptions/Create
        public IActionResult Create()
        {
            ViewData["ExperienceID"] = new SelectList(_context.Experiences, "ID", "ID");
            return View();
        }

        // POST: Descriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ExperienceID,Duties")] Description description)
        {
            if (ModelState.IsValid)
            {
                _context.Add(description);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExperienceID"] = new SelectList(_context.Experiences, "ID", "ID", description.ExperienceID);
            return View(description);
        }

        // GET: Descriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var description = await _context.Descriptions.SingleOrDefaultAsync(m => m.ID == id);
            if (description == null)
            {
                return NotFound();
            }
            ViewData["ExperienceID"] = new SelectList(_context.Experiences, "ID", "ID", description.ExperienceID);
            return View(description);
        }

        // POST: Descriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ExperienceID,Duties")] Description description)
        {
            if (id != description.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(description);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DescriptionExists(description.ID))
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
            ViewData["ExperienceID"] = new SelectList(_context.Experiences, "ID", "ID", description.ExperienceID);
            return View(description);
        }

        // GET: Descriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var description = await _context.Descriptions
                .Include(d => d.Experience)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (description == null)
            {
                return NotFound();
            }

            return View(description);
        }

        // POST: Descriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var description = await _context.Descriptions.SingleOrDefaultAsync(m => m.ID == id);
            _context.Descriptions.Remove(description);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DescriptionExists(int id)
        {
            return _context.Descriptions.Any(e => e.ID == id);
        }
    }
}
