﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
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
            return View(await _context.Lessons.Where(x => x.TopicId == id).ToListAsync());
        }
    }
}