using Microsoft.VisualStudio.TestTools.UnitTesting;
using University.Models.Services;
using Moq;
using University.Models.DB;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace TestsForUniversity
{
    [TestClass]
    public class ServiceMVCTests 
    {
        [TestMethod]
        public void CourseServiceTest()
        {
            var logger = new LoggerFactory().CreateLogger<CourseService>();
            var _db = new DbContextOptionsBuilder<UniversityContext>().UseInMemoryDatabase("University").Options;
            var serviceMock = new Mock<ICourseService>();
            serviceMock.Setup(u => u.GetCourses());
            using (var db = new UniversityContext(_db))
            {
                db.Set<Course>().Add(new Course()
                {
                    CourseId = 1,
                    Name = "1Course",
                    Description = "desc1"
                });
                db.Set<Course>().Add(new Course()
                {
                    CourseId = 2,
                    Name = "2Course",
                    Description = "desc2"
                });
                db.SaveChanges();
            }
            using (var db = new UniversityContext(_db))
            {
                var service = new CourseService(db);
                var result = service.Get(2);
                Assert.IsNotNull(result);
                Assert.AreEqual(2, result.CourseId);
                Assert.AreEqual("2Course", result.Name);
                Assert.AreEqual("desc2", result.Description);
            }
        }
        [TestMethod]
        public void GroupServiceTest()
        {
            var logger = new LoggerFactory().CreateLogger<GroupService>();
            var _db = new DbContextOptionsBuilder<UniversityContext>().UseInMemoryDatabase("University").Options;
            var serviceMock = new Mock<IGroupService>();
            serviceMock.Setup(u => u.GetGroups());
            using (var db = new UniversityContext(_db))
            {
                db.Set<Group>().Add(new Group()
                {
                    GroupId = 1,
                    CourseId = 1,
                    Name = "Group1"
                });
                db.Set<Group>().Add(new Group()
                {
                    GroupId = 2,
                    CourseId = 2,
                    Name = "Group2"
                });
                db.SaveChanges();
            }
            using (var db = new UniversityContext(_db))
            {
                var service = new GroupService(db);
                var result = service.Get(1);
                Assert.IsNotNull(result);
                Assert.AreEqual(1, result.CourseId);
                Assert.AreEqual("Group1", result.Name);
                Assert.AreEqual(1, result.GroupId);
            }
        }
        [TestMethod]
        public void StudentServiceTest()
        {
            var logger = new LoggerFactory().CreateLogger<StudentService>();
            var _db = new DbContextOptionsBuilder<UniversityContext>().UseInMemoryDatabase("University").Options;
            var serviceMock = new Mock<IStudentService>();
            serviceMock.Setup(u => u.GetStudents());
            using (var db = new UniversityContext(_db))
            {
                db.Set<Student>().Add(new Student()
                {
                    StudentId = 1,
                    GroupId = 1,
                    FirstName = "Anna",
                    LastName = "Petrova"
                });
                db.Set<Student>().Add(new Student()
                {
                    StudentId = 2,
                    GroupId = 2,
                    FirstName = "Anton",
                    LastName = "Petrov"
                });
                db.SaveChanges();
            }
            using (var db = new UniversityContext(_db))
            {
                var service = new StudentService(db);
                var result = service.Get(2);
                Assert.IsNotNull(result);
                Assert.AreEqual(2, result.StudentId);
                Assert.AreEqual(2, result.GroupId);
                Assert.AreEqual("Anton", result.FirstName);
                Assert.AreEqual("Petrov", result.LastName);
            }
        }
    }
}
