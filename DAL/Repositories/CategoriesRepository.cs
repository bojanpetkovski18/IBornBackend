using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext db;

        public CategoryRepository(ApplicationDbContext _db)
            => db = _db;

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await db.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int? id)
        {
            return await db.Categories.FindAsync(id);
        }

        public void AddCategory(Category category)
        {
            db.Categories.Add(category); 
        }

        public void UpdateCategory(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
        }

        public void DeleteCategory(Category category)
        {
            db.Categories.Remove(category);
        }

        public bool DoesExist(int? id)
        {
            return db.Categories.Any(e => e.CategoryId == id);
        }

        public async void SaveChanges()
        {
            await Task.Run(() => db.SaveChangesAsync());
        }

        
    }
}
