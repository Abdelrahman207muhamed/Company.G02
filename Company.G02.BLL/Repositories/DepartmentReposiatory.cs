using Company.G02.DAL.Data.Contexts;
using Company.G02.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.G02.BLL.Repositories
{
    public class DepartmentReposiatory : IDepartmentRepository
    {
        // Readonly => Can't Assign New Value 
        private  readonly CompanyDbContext _context;//Null
      
        public DepartmentReposiatory()
        {
            _context= new CompanyDbContext();
        }
        public IEnumerable<Department> GetAll()
        {
          // using CompanyDbContext context = new CompanyDbContext();
            return _context.Departments.ToList();
        }
        public Department? Get(int id)
        {
            //using CompanyDbContext context = new CompanyDbContext();
            return _context.Departments.Find(id);
        }
        public int Add(Department model)
        {
           // using CompanyDbContext context = new CompanyDbContext();
            _context.Departments.Add(model);
           return _context.SaveChanges();
        }
        public int Update(Department model)
        {
            //using CompanyDbContext context = new CompanyDbContext();
            _context.Departments.Update(model);
            return _context.SaveChanges();
        }

        public int Delete(Department model)
        {
           // using CompanyDbContext context = new CompanyDbContext();
            _context.Departments.Remove(model);
            return _context.SaveChanges();
        }

    }
}
