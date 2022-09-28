using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Models.DB
{
    public partial class Group
    {
        public Group()
        {
            Students = new HashSet<Student>();
        }
        public int GroupId { get; set; }
        public int? CourseId { get; set; }
        public string Name { get; set; }
        public Course Course { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
