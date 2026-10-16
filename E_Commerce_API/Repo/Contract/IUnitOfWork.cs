using E_Commerce_API.Models;

namespace E_Commerce_API.Repo.Contract
{
    public interface IUnitOfWork
    {
        IGenericRepo<User> User { get; }
        IGenericRepo<Order> Order { get; }
        IGenericRepo<Category> Category { get; }
        IGenericRepo<OrderItem> OrderItem { get; }
        IGenericRepo<Product> Product { get; }
        ICategory CustomCategory { get; }
        IProduct CustomProduct { get; }
        IOrder CustomOrder { get; }
        IAuthRepo CustomAuth {  get; }
        Task<int> Save();
    }
}
