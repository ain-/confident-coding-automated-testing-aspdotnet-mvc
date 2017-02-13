﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ForgetTheMilk.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View(Tasks);
        }

        public static readonly List<string> Tasks = new List<string>();

        [HttpPost]
        public IActionResult Add(string task)
        {
            Tasks.Add(task);
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
