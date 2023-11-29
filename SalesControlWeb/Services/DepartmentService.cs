using SalesControlWeb.Models;

namespace SalesControlWeb.Services
{
    public class DepartmentService
    {
        private readonly SalesControlWebDbContext _context;

        public DepartmentService(SalesControlWebDbContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Departments.OrderBy(x => x.Name).ToList();
        }
    }
}