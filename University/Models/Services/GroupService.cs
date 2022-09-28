using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Models.DB;

namespace University.Models.Services
{
    public class GroupService : IGroupService
    {
        private readonly UniversityContext _db;
        public GroupService(UniversityContext db)
        {
            _db = db;
        }

        public IEnumerable<Group> Groups => _db.Groups;

        public Group Get(int id)
        {
            var group = _db.Groups
              .Include(group => group.Students)
              .FirstOrDefault(group => group.GroupId == id);
            return group;
        }

        public IEnumerable<Group> GetGroups()
        {
            return _db.Groups;
        }

        public void Update(Group group)
        {
            _db.Entry(group).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
