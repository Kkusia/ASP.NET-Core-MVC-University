using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Models.DB;

namespace University.Models.Services
{
    public interface IStudentService
    {
        IEnumerable<Student> Students { get; }
        IEnumerable<Student> GetStudents();
        Student Get(int id);
        void Update(Student student);
    }
}
