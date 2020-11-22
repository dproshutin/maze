using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebMaze.Models;

namespace WebMaze.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            var model = new StudentViewModel();
            model.CurrentTime = DateTime.Now;
            model.DayOfWeek = model.CurrentTime.DayOfWeek.ToString();
            model.CurrentUserName = "Ivan Petrov";
            return View(model);
        }

        public IActionResult Mark()
        {
            return View();
        }
    }
}
