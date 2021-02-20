using DAL.Entities;
using DAL.Interfaces;
using DBL.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DBL.Logic
{
    public class ProductLogic
    {
        private readonly IProductRepository repository;

        public ProductLogic(IProductRepository _repository)
            => repository = _repository;

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await repository.GetAllProducts();
        }

        public async Task<Product> GetProductById(int? id)
        {
            return await repository.GetProductById(id);
        }

        public void AddProduct(ProductViewModel product)
        {
            DAL.Entities.Product _product = new Product
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                CategoryId = product.CategoryId,
                BrandId = product.BrandId,
                ProductImg = product.ProductImg,
                ProductPrice = product.ProductPrice,
                ProductDiscount = product.ProductDiscount,
                Quantity = product.Quantity,
                Rating = product.Rating,
                Description = product.Description
            };
            repository.AddProduct(_product);
        }

        public void UpdateProduct(ProductViewModel product)
        {
            DAL.Entities.Product _product = new Product
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                CategoryId = product.CategoryId,
                BrandId = product.BrandId,
                ProductImg = product.ProductImg,
                ProductPrice = product.ProductPrice,
                ProductDiscount = product.ProductDiscount,
                Quantity = product.Quantity,
                Rating = product.Rating,
                Description = product.Description
            };
            repository.UpdateProduct(_product);
        }

        public void DeleteProduct(Product product)
        {
            repository.DeleteProduct(product);
        }

        public bool DoesExist(int? id)
        {
            return repository.DoesExist(id);
        }

        public async void SaveChanges()
        {
            await Task.Run(() => repository.SaveChanges());
        }
    }
}
