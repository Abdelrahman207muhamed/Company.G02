using Company.G02.BLL.Repositories;
using Company.G02.DAL.Models;
using Company.G02.PL.Dtos;
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
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateDepartmentDto model)
        {

            if (ModelState.IsValid) //Server Side Validation 
            {
                var department = new Department()
                {
                    Code=model.Code,
                    Name=model.Name,
                    CreateAt=model.CreateAt 
                };


               var count = _departmentRepository.Add(department);
                if (count > 0) 
                {
                    return RedirectToAction(nameof(Index));
                }
            }


            return View(model);
        }
    }
}
