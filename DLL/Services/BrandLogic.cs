using DAL.Entities;
using DAL.Interfaces;
using DBL.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DBL.Services
{
    public class BrandLogic
    {
        private readonly IBrandRepository repository;

        public BrandLogic(IBrandRepository _repository)
            => repository = _repository;

        public async Task<IEnumerable<Brand>> GetAllBrands()
        {
            return await repository.GetAllBrands();
        }

        public async Task<Brand> GetBrandById(int? id)
        {
            return await repository.GetBrandById(id);
        }

        public void AddBrand(BrandViewModel brand)
        {
            DAL.Entities.Brand _brand = new Brand
            {
                BrandId = brand.BrandId,
                BrandName = brand.BrandName,
                BrandImg = brand.BrandImg
            };
            repository.AddBrand(_brand);
        }

        public void UpdateBrand(BrandViewModel brand)
        {
            DAL.Entities.Brand _brand = new Brand
            {
                BrandId = brand.BrandId,
                BrandName = brand.BrandName,
                BrandImg = brand.BrandImg
            };
            repository.UpdateBrand(_brand);
        }

        public void DeleteBrand(Brand brand)
        {
            repository.DeleteBrand(brand);
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
