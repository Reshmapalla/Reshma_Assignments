using HandsOnEFDBFirst.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HandsOnEFDBFirst.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly MyDb1Context myDb1Context;
        public EmployeeController()
        {
            myDb1Context = new MyDb1Context();
        }
        public IActionResult Index()
        {
            var employees = myDb1Context.EmpDetails.ToList();
            return View(employees);

        }

        public IActionResult Details(int employeeId)
        {
            var employee=myDb1Context.EmpDetails.SingleOrDefault(e=>e.EmpId== employeeId);
            return View(employee);
        }
    }
}
