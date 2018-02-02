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
    public class ExamsController : Controller
    {
        private readonly EsameDiStatoContext _context;

        public ExamsController(EsameDiStatoContext context)
        {
            _context = context;
        }

        // GET: Exams
        public async Task<IActionResult> Index()
        {
            return View(await _context.Exams.ToListAsync());
        }

        // GET: Exams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exams = await _context.Exams
                .SingleOrDefaultAsync(m => m.Pkexam == id);
            if (exams == null)
            {
                return NotFound();
            }

            return View(exams);
        }

        // GET: Exams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Exams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Pkexam,ExDate,Subject")] Exams exams)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exams);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exams);
        }

        // GET: Exams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exams = await _context.Exams.SingleOrDefaultAsync(m => m.Pkexam == id);
            if (exams == null)
            {
                return NotFound();
            }
            return View(exams);
        }

        // POST: Exams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Pkexam,ExDate,Subject")] Exams exams)
        {
            if (id != exams.Pkexam)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exams);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamsExists(exams.Pkexam))
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
            return View(exams);
        }

        // GET: Exams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exams = await _context.Exams
                .SingleOrDefaultAsync(m => m.Pkexam == id);
            if (exams == null)
            {
                return NotFound();
            }

            return View(exams);
        }

        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exams = await _context.Exams.SingleOrDefaultAsync(m => m.Pkexam == id);
            _context.Exams.Remove(exams);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamsExists(int id)
        {
            return _context.Exams.Any(e => e.Pkexam == id);
        }
    }
}
