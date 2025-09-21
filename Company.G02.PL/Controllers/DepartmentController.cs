using Company.G02.BLL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Company.G02.PL.Controllers
{
    // MVC Controller
    public class DepartmentController : Controller
    {
        private readonly IDepartmentReposiatory _departmentRepository;//NULL

        //ASK CLR Create Object From DepartmentReposiatory

        public DepartmentController(IDepartmentReposiatory departmentReposiatory)
        {
            _departmentRepository = departmentReposiatory; 
        }

        [HttpGet] //Get : /Department/Index
        public IActionResult Index()
        {
           // DepartmentReposiatory departmentReposiatory = new DepartmentReposiatory();
            var departments = _departmentRepository.GetAll();
             
            return View(departments);
        }
    }
}
