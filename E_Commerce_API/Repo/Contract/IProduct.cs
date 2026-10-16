using E_Commerce_API.Models;

namespace E_Commerce_API.Repo.Contract
{
    public interface IProduct
    {
        Task<List<Product>> Pagination(int? categoryId, int pageNumber, int pageSize, string SortBy);
        Task<Product> SecondMostExpensive(int?CategoryId);
        Task<List<Product>> SearchName(string Name);
    }
}
