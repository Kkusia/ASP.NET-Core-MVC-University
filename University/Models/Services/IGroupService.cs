using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Models.DB;

namespace University.Models.Services
{
    public interface IGroupService
    {
        IEnumerable<Group> Groups { get; }
        IEnumerable<Group> GetGroups();
        Group Get(int id);
        void Update(Group group);
    }
}
