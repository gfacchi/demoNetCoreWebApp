using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using demoWebAppCore.Models;

namespace demoWebAppCore.Controllers
{
    public class StudentsExamsController : Controller
    {
        private readonly EsameDiStatoContext _context;

        public StudentsExamsController(EsameDiStatoContext context)
        {
            _context = context;
        }

        // GET: StudentsExams
        public async Task<IActionResult> Index()
        {
            var esameDiStatoContext = _context.StudentsExams.Include(s => s.PpkfkexamNavigation).Include(s => s.PpkfkstudentNavigation);
            return View(await esameDiStatoContext.ToListAsync());
        }

        // GET: StudentsExams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentsExams = await _context.StudentsExams
                .Include(s => s.PpkfkexamNavigation)
                .Include(s => s.PpkfkstudentNavigation)
                .SingleOrDefaultAsync(m => m.Ppkfkstudent == id);
            if (studentsExams == null)
            {
                return NotFound();
            }

            return View(studentsExams);
        }

        // GET: StudentsExams/Create
        public IActionResult Create()
        {
            ViewData["Ppkfkexam"] = new SelectList(_context.Exams, "Pkexam", "Subject");
            ViewData["Ppkfkstudent"] = new SelectList(_context.Students, "Pkstudent", "Name");
            return View();
        }

        // POST: StudentsExams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ppkfkstudent,Ppkfkexam,Grade")] StudentsExams studentsExams)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentsExams);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Ppkfkexam"] = new SelectList(_context.Exams, "Pkexam", "Subject", studentsExams.Ppkfkexam);
            ViewData["Ppkfkstudent"] = new SelectList(_context.Students, "Pkstudent", "Name", studentsExams.Ppkfkstudent);
            return View(studentsExams);
        }

        // GET: StudentsExams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentsExams = await _context.StudentsExams.SingleOrDefaultAsync(m => m.Ppkfkstudent == id);
            if (studentsExams == null)
            {
                return NotFound();
            }
            ViewData["Ppkfkexam"] = new SelectList(_context.Exams, "Pkexam", "Subject", studentsExams.Ppkfkexam);
            ViewData["Ppkfkstudent"] = new SelectList(_context.Students, "Pkstudent", "Name", studentsExams.Ppkfkstudent);
            return View(studentsExams);
        }

        // POST: StudentsExams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Ppkfkstudent,Ppkfkexam,Grade")] StudentsExams studentsExams)
        {
            if (id != studentsExams.Ppkfkstudent)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentsExams);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentsExamsExists(studentsExams.Ppkfkstudent))
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
            ViewData["Ppkfkexam"] = new SelectList(_context.Exams, "Pkexam", "Subject", studentsExams.Ppkfkexam);
            ViewData["Ppkfkstudent"] = new SelectList(_context.Students, "Pkstudent", "Name", studentsExams.Ppkfkstudent);
            return View(studentsExams);
        }

        // GET: StudentsExams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentsExams = await _context.StudentsExams
                .Include(s => s.PpkfkexamNavigation)
                .Include(s => s.PpkfkstudentNavigation)
                .SingleOrDefaultAsync(m => m.Ppkfkstudent == id);
            if (studentsExams == null)
            {
                return NotFound();
            }

            return View(studentsExams);
        }

        // POST: StudentsExams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentsExams = await _context.StudentsExams.SingleOrDefaultAsync(m => m.Ppkfkstudent == id);
            _context.StudentsExams.Remove(studentsExams);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentsExamsExists(int id)
        {
            return _context.StudentsExams.Any(e => e.Ppkfkstudent == id);
        }
    }
}
