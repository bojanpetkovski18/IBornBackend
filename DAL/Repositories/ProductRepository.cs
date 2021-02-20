using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext db;

        public ProductRepository(ApplicationDbContext _db)
           => db = _db;

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await db.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int? id)
        {
            return await db.Products.FindAsync(id);
        }

        public void AddProduct(Product product)
        {
            db.Products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
        }

        public void DeleteProduct(Product product)
        {
            db.Products.Remove(product);
        }

        public bool DoesExist(int? id)
        {
            return db.Products.Any(e => e.ProductId == id);
        }

        public async void SaveChanges()
        {
            await Task.Run(() => db.SaveChangesAsync());
        }
    }
}
