using DAL.Entities;
using DAL.Interfaces;
using DBL.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DBL.Services
{
    public class CategoryLogic
    {
        private readonly ICategoryRepository repository;

        public CategoryLogic(ICategoryRepository _repository)
            => repository = _repository;

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await repository.GetAllCategories();
        }

        public async Task<Category> GetCategoryById(int? id)
        {
            return await repository.GetCategoryById(id);
        }

        public void AddCategory(CategoryViewModel category)
        {
            DAL.Entities.Category _category = new Category
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };

            repository.AddCategory(_category);
        }

        public void UpdateCategory(CategoryViewModel category)
        {
            DAL.Entities.Category _category = new Category
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };

            repository.UpdateCategory(_category);
        }

        public void DeleteCategory(Category category)
        {
            repository.DeleteCategory(category);
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
