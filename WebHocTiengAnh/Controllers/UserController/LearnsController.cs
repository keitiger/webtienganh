using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebHocTiengAnh.Models;

namespace WebHocTiengAnh.Controllers.UserController
{
    public class LearnsController : Controller
    {
        private readonly DBcontext _context;

        public LearnsController(DBcontext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Topics.ToListAsync());
        }

        public async Task<IActionResult> Topic(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.topic = _context.Topics.FirstOrDefault(x => x.Id == id).NameTopic;
                return View(await _context.Lessons.Where(x => x.TopicId == id).ToListAsync());
            }
        }
        public async Task<IActionResult> Excercise(int? id)
        {
            ViewBag.idlesson = id;
            return View(await _context.Exercises.Where(x=>x.LessonId==id).ToListAsync());
        }
        public string CheckAnswer(int id, string answer)
        {
            var check = _context.Exercises.Where(x => x.Id==id).FirstOrDefault();
            if (check.TrueAnswer == answer)
            {
                return "Dung";
            }
            else
            {
                return "Sai";
            }
                
        } 
    }
}
