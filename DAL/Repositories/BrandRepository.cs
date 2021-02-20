using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ApplicationDbContext db;

        public BrandRepository(ApplicationDbContext _db)
            => db = _db;

        public async Task<IEnumerable<Brand>> GetAllBrands()
        {
            return await db.Brands.ToListAsync();
        }

        public async Task<Brand> GetBrandById(int? id)
        {
            return await db.Brands.FindAsync(id);
        }

        public void AddBrand(Brand brand)
        {
            db.Brands.Add(brand);
        }

        public void UpdateBrand(Brand brand)
        {
            db.Entry(brand).State = EntityState.Modified;
        }

        public void DeleteBrand(Brand brand)
        {
            db.Brands.Remove(brand);
        }

        public bool DoesExist(int? id)
        {
            return db.Brands.Any(e => e.BrandId == id);
        }

        public async void SaveChanges()
        {
            await Task.Run(() => db.SaveChangesAsync());
        }
    }
}
