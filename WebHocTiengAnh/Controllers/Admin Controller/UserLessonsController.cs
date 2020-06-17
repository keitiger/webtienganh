using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebHocTiengAnh.Models;
using WebHocTiengAnh.Models.Entities;

namespace WebHocTiengAnh.Controllers
{
    public class UserLessonsController : Controller
    {
        private readonly DBcontext _context;

        public UserLessonsController(DBcontext context)
        {
            _context = context;
        }

        // GET: UserLessons
        public async Task<IActionResult> Index()
        {
            var dBcontext = _context.UserLesson.Include(u => u.Lesson).Include(u => u.User);
            return View(await dBcontext.ToListAsync());
        }

        // GET: UserLessons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userLesson = await _context.UserLesson
                .Include(u => u.Lesson)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userLesson == null)
            {
                return NotFound();
            }

            return View(userLesson);
        }

        // GET: UserLessons/Create
        public IActionResult Create()
        {
            ViewData["LessonId"] = new SelectList(_context.Lessons, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Password");
            return View();
        }

        // POST: UserLessons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,LessonId")] UserLesson userLesson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userLesson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LessonId"] = new SelectList(_context.Lessons, "Id", "Id", userLesson.LessonId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Password", userLesson.UserId);
            return View(userLesson);
        }

        // GET: UserLessons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userLesson = await _context.UserLesson.FindAsync(id);
            if (userLesson == null)
            {
                return NotFound();
            }
            ViewData["LessonId"] = new SelectList(_context.Lessons, "Id", "Id", userLesson.LessonId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Password", userLesson.UserId);
            return View(userLesson);
        }

        // POST: UserLessons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,LessonId")] UserLesson userLesson)
        {
            if (id != userLesson.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userLesson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserLessonExists(userLesson.Id))
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
            ViewData["LessonId"] = new SelectList(_context.Lessons, "Id", "Id", userLesson.LessonId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Password", userLesson.UserId);
            return View(userLesson);
        }

        // GET: UserLessons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userLesson = await _context.UserLesson
                .Include(u => u.Lesson)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userLesson == null)
            {
                return NotFound();
            }

            return View(userLesson);
        }

        // POST: UserLessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userLesson = await _context.UserLesson.FindAsync(id);
            _context.UserLesson.Remove(userLesson);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserLessonExists(int id)
        {
            return _context.UserLesson.Any(e => e.Id == id);
        }
    }
}
