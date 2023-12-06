using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Departments.OrderBy(x => x.Name).ToListAsync();
        }
    }
}