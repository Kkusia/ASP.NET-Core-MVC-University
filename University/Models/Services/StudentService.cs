using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Models.DB;

namespace University.Models.Services
{
    public class StudentService : IStudentService
    {
        private readonly UniversityContext _db;

        public StudentService(UniversityContext db)
        {
            _db = db;
        }

        public IEnumerable<Student> Students => _db.Students;

        public Student Get(int id)
        {
            var student = _db.Students
              .FirstOrDefault(student => student.StudentId == id);
            return student;
        }

        public IEnumerable<Student> GetStudents()
        {
            return _db.Students;
        }

        public void Update(Student student)
        {
            _db.Entry(student).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
