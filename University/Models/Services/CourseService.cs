using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Models.DB;

namespace University.Models.Services
{
    public class CourseService : ICourseService
    {
        private readonly UniversityContext _db;

        public CourseService(UniversityContext db)
        {
            _db = db;
        }

        public IEnumerable<Course> Courses => _db.Courses;

        public Course Get(int id)
        {
            var course = _db.Courses
              .Include(course => course.Groups)
              .FirstOrDefault(course => course.CourseId == id);
            return course;
        }

        public IEnumerable<Course> GetCourses()
        {
            return _db.Courses;
        }
    }
}
