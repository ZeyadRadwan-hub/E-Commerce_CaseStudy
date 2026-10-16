using E_Commerce_API.Data;
using E_Commerce_API.Models;
using E_Commerce_API.Repo.Contract;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Repo.Implementation
{
    public class CategoryRepo:ICategory
    {
        private readonly App_Database_Context _db;
        public CategoryRepo(App_Database_Context db)
        {
            _db = db;
        }

        public async Task<List<Category>> GetAll()
        {
            var x = await _db.Categories.ToListAsync();
            return x;
        }
    }
}
