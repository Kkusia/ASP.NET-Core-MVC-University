using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Models.DB;
using University.Models.Services;

namespace University.Controllers
{
    public class GroupsController : Controller
    {
        private readonly IGroupService _service;

        public GroupsController(IGroupService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var groups = _service.Groups.ToList();
            return View(groups);
        }

        public IActionResult Details(int id)
        {
            var groups = _service.Get(id);
            return View(groups.Students.ToList());
        }
        public IActionResult Edit(int id)
        {
            var group = _service.Groups.Where(x => x.GroupId == id).FirstOrDefault();
            return View(group);
        }

        [HttpPost]
        public IActionResult Edit(Group group)
        {
            var id = group.GroupId;
            Group foundGroup = _service.Get(id);
            foundGroup.Name = group.Name;
            _service.Update(foundGroup);
            return RedirectToAction("Details", "Courses", new { @id = id });
        }
    }
}
