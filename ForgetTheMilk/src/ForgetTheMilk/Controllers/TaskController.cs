using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

        public static readonly List<Task> Tasks = new List<Task>();

        [HttpPost]
        public IActionResult Add(string task)
        {
            var taskItem = new Task {Description = task};
            var dueDatePattern = new Regex(@"may\s(\d)");
            var hasDueDate = dueDatePattern.IsMatch(task);
            if (hasDueDate)
            {
                var dueDate = dueDatePattern.Match(task);
                var day = Convert.ToInt32(dueDate.Groups[1].Value);
                taskItem.DueDate = new DateTime(DateTime.Today.Year, 5, day);
            }
            Tasks.Add(taskItem);
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View();
        }
    }

    public class Task
    {
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
