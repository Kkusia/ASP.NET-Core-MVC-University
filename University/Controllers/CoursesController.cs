using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Models.Services;

namespace University.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseService _service;

        public CoursesController(ICourseService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var courses = _service.Courses.ToList();
            return View(courses);
        }
        public IActionResult Details(int id)
        {
            var course = _service.Get(id);
            return View(course.Groups.ToList());
        }
    }
}
