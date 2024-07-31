using HandsOnEFDBFirst.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HandsOnEFDBFirst.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly MyDb1Context myDb1Context;
        public DepartmentController()
        {
            myDb1Context = new MyDb1Context();
        }

        public IActionResult Index()

        {
            var departments = myDb1Context.Departments.ToList();
            return View(departments);
        }
        public IActionResult Details(string DeptCode) 

        { 
            var departments=myDb1Context.Departments.SingleOrDefault(d=>d.DeptCode== DeptCode);
            return View(departments);
        }
    }
}
