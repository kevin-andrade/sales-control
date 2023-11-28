using SalesControlWeb.Models;

namespace SalesControlWeb.Services
{
    public class SellerService
    {
        private readonly SalesControlWebDbContext _context;

        public SellerService(SalesControlWebDbContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Sellers.ToList();
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}