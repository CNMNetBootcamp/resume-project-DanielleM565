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
    public class PersonalSkillsController : Controller
    {
        private readonly ResumeContext _context;

        public PersonalSkillsController(ResumeContext context)
        {
            _context = context;
        }

        // GET: PersonalSkills
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonalSkills.ToListAsync());
        }

        // GET: PersonalSkills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalSkill = await _context.PersonalSkills
                .SingleOrDefaultAsync(m => m.ID == id);
            if (personalSkill == null)
            {
                return NotFound();
            }

            return View(personalSkill);
        }

        // GET: PersonalSkills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonalSkills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PersonID,Skill")] PersonalSkill personalSkill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personalSkill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personalSkill);
        }

        // GET: PersonalSkills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalSkill = await _context.PersonalSkills.SingleOrDefaultAsync(m => m.ID == id);
            if (personalSkill == null)
            {
                return NotFound();
            }
            return View(personalSkill);
        }

        // POST: PersonalSkills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PersonID,Skill")] PersonalSkill personalSkill)
        {
            if (id != personalSkill.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalSkill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalSkillExists(personalSkill.ID))
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
            return View(personalSkill);
        }

        // GET: PersonalSkills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalSkill = await _context.PersonalSkills
                .SingleOrDefaultAsync(m => m.ID == id);
            if (personalSkill == null)
            {
                return NotFound();
            }

            return View(personalSkill);
        }

        // POST: PersonalSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personalSkill = await _context.PersonalSkills.SingleOrDefaultAsync(m => m.ID == id);
            _context.PersonalSkills.Remove(personalSkill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalSkillExists(int id)
        {
            return _context.PersonalSkills.Any(e => e.ID == id);
        }
    }
}
