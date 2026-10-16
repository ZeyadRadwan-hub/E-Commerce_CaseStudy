using E_Commerce_API.Data;
using E_Commerce_API.Models;
using E_Commerce_API.Repo.Contract;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Repo.Implementation
{
    public class OrderRepo:IOrder
    {
        private readonly App_Database_Context _db;
        public OrderRepo(App_Database_Context db)
        {
            _db = db;
        }

        public Task<decimal> TotalRevenueCompleted()
        {
            var x = _db.Orders.Where(x => x.OrderStatus == "completed" || x.OrderStatus == "Completed").SumAsync(x => x.ToatalAmount);
            return x;
        }
        public async Task<List<Order>> GetAll()
        {
            var x = await _db.Orders.ToListAsync();
            return x;
        }
    }
}
