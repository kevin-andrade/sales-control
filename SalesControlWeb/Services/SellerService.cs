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

        public Seller FindById(int id)
        {
            return _context.Sellers.FirstOrDefault(obj => obj.Id == id);
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var obj = _context.Sellers.Find(id);
            _context.Sellers.Remove(obj);
            _context.SaveChanges();
        }
    }
}