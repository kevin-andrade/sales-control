using Microsoft.EntityFrameworkCore;
using SalesControlWeb.Models;
using SalesControlWeb.Services.Exceptions;

namespace SalesControlWeb.Services
{
    public class SellerService
    {
        private readonly SalesControlWebDbContext _context;

        public SellerService(SalesControlWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Sellers.ToListAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            var seller = await _context.Sellers
                .Include(obj => obj.Department)
                .FirstOrDefaultAsync(obj => obj.Id == id);
            
            if (seller != null)
            {
                return seller;
            }
            throw new NotFoundException($"Seller with ID {id} and department not found");
        }

        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Sellers.FindAsync(id);
            _context.Sellers.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Seller obj)
        {
            var hasAny = await _context.Sellers.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}