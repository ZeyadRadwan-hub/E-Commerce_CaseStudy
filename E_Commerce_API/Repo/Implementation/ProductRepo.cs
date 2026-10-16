using E_Commerce_API.Data;
using E_Commerce_API.Models;
using E_Commerce_API.Repo.Contract;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Repo.Implementation
{
    public class ProductRepo:IProduct
    {
        private readonly App_Database_Context _db;
        public ProductRepo(App_Database_Context db)
        {
            _db = db;
        }

        public async Task<List<Product>> Pagination(int? categoryId,
            int pageNumber, int pageSize, string SortBy)
        {
            var res = _db.Products.AsQueryable();

            if (categoryId.HasValue)
            {
                res = res.Where(x => x.CategoryId == categoryId.Value);
            }

            if (SortBy == "Name" || SortBy == "name")
            {
                res = res.OrderBy(x => x.Name);
            }
            else if (SortBy == "Price" || SortBy == "price")
            {
                res = res.OrderBy(x => x.Price);
            }

            res = res
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            return await res.ToListAsync();
        }

        public async Task<Product> SecondMostExpensive(int? CategoryId)
        {
            var x = await _db.Products.Where(x => x.CategoryId != CategoryId).OrderByDescending(x => x.Price).Skip(1).FirstOrDefaultAsync();
            return x;
        }

        public Task<List<Product>> SearchName(string Name)
        {
            var src = _db.Products.Where(x => x.Name.Contains(Name)).ToListAsync();
            return src;
        }

    }
}
