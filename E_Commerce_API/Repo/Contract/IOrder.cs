using E_Commerce_API.Models;

namespace E_Commerce_API.Repo.Contract
{
    public interface IOrder
    {
        Task<decimal> TotalRevenueCompleted();
        Task<List<Order>> GetAll();
    }
}
