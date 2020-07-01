using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebHocTiengAnh.Models;

namespace WebHocTiengAnh.Controllers.AdminController
{
    public class LessonExercisesController : Controller
    {
        private readonly DBcontext _context;

        public LessonExercisesController(DBcontext context)
        {
            _context = context;
        }

        // GET: LessonExercises
        public async Task<IActionResult> Index()
        {
            var dBcontext = _context.LessonExercises.Include(l => l.Exercise).Include(l => l.Lesson);
            return View(await dBcontext.ToListAsync());
        }

        // GET: LessonExercises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lessonExercise = await _context.LessonExercises
                .Include(l => l.Exercise)
                .Include(l => l.Lesson)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lessonExercise == null)
            {
                return NotFound();
            }

            return View(lessonExercise);
        }

        // GET: LessonExercises/Create
        public IActionResult Create()
        {
            ViewData["ExerciseId"] = new SelectList(_context.Exercises, "Id", "Id");
            ViewData["LessonId"] = new SelectList(_context.Lessons, "Id", "Id");
            return View();
        }

        // POST: LessonExercises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LessonId,ExerciseId")] LessonExercise lessonExercise)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lessonExercise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExerciseId"] = new SelectList(_context.Exercises, "Id", "Id", lessonExercise.ExerciseId);
            ViewData["LessonId"] = new SelectList(_context.Lessons, "Id", "Id", lessonExercise.LessonId);
            return View(lessonExercise);
        }

        // GET: LessonExercises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lessonExercise = await _context.LessonExercises.FindAsync(id);
            if (lessonExercise == null)
            {
                return NotFound();
            }
            ViewData["ExerciseId"] = new SelectList(_context.Exercises, "Id", "Id", lessonExercise.ExerciseId);
            ViewData["LessonId"] = new SelectList(_context.Lessons, "Id", "Id", lessonExercise.LessonId);
            return View(lessonExercise);
        }

        // POST: LessonExercises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LessonId,ExerciseId")] LessonExercise lessonExercise)
        {
            if (id != lessonExercise.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lessonExercise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LessonExerciseExists(lessonExercise.Id))
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
            ViewData["ExerciseId"] = new SelectList(_context.Exercises, "Id", "Id", lessonExercise.ExerciseId);
            ViewData["LessonId"] = new SelectList(_context.Lessons, "Id", "Id", lessonExercise.LessonId);
            return View(lessonExercise);
        }

        // GET: LessonExercises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lessonExercise = await _context.LessonExercises
                .Include(l => l.Exercise)
                .Include(l => l.Lesson)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lessonExercise == null)
            {
                return NotFound();
            }

            return View(lessonExercise);
        }

        // POST: LessonExercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lessonExercise = await _context.LessonExercises.FindAsync(id);
            _context.LessonExercises.Remove(lessonExercise);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LessonExerciseExists(int id)
        {
            return _context.LessonExercises.Any(e => e.Id == id);
        }
    }
}
