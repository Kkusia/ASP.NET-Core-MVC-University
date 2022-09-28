using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Models.DB;

namespace University.Models.Services
{
    public interface ICourseService
    {
        IEnumerable<Course> Courses { get; }
        IEnumerable<Course> GetCourses();
        Course Get(int id);
    }
}
