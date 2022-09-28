using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Models.DB
{
    public partial class Course
    {
        public Course()
        {
            Groups = new HashSet<Group>();
        }
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
