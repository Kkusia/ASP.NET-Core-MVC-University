using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Models.DB;
using University.Models.Services;

namespace University.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _service;

        public StudentsController(IStudentService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var students = _service.Students.ToList();
            return View(students);
        }
        public IActionResult Edit(int id)
        {
            var student = _service.Students.Where(x => x.StudentId == id).FirstOrDefault();
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            var parameter = student.GroupId;
            Student foundStudent = _service.Get(student.StudentId);
            foundStudent.FirstName = student.FirstName;
            foundStudent.LastName = student.LastName;
            _service.Update(foundStudent);
            return RedirectToAction("Details", "Groups", new { @id = parameter });
        }
    }
}
