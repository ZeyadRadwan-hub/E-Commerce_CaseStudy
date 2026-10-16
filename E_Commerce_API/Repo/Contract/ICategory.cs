using E_Commerce_API.Models;

namespace E_Commerce_API.Repo.Contract
{
    public interface ICategory
    {
        Task<List<Category>> GetAll();
    }
}
