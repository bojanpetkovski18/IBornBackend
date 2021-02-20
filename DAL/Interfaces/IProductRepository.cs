using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int? id);
        void AddProduct(Product category);
        void UpdateProduct (Product category);
        void DeleteProduct (Product category);
        bool DoesExist(int? id);
        void SaveChanges();
    }
}
