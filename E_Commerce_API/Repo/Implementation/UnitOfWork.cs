using E_Commerce_API.Data;
using E_Commerce_API.Models;
using E_Commerce_API.Repo.Contract;

namespace E_Commerce_API.Repo.Implementation
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly App_Database_Context _db;
        public IGenericRepo<User> User { get; }
        public IGenericRepo<Order> Order { get; }
        public IGenericRepo<Category> Category { get; }
        public IGenericRepo<OrderItem> OrderItem { get; }
        public IGenericRepo<Product> Product { get; }
        public ICategory CustomCategory { get; }
        public IProduct CustomProduct { get; }
        public IOrder CustomOrder { get; }
        public IAuthRepo CustomAuth { get; }
        public async Task<int> Save()
        {
            return await _db.SaveChangesAsync();
        }

        public UnitOfWork(IGenericRepo<User> user, IGenericRepo<Order> order, IGenericRepo<Category> category, IGenericRepo<OrderItem> orderItem , IGenericRepo<Product> product,App_Database_Context db, ICategory customCategory, IProduct customProduct,IOrder cusomtrepo, IAuthRepo customAuth)
        {
            _db = db;
            User = user;
            Order = order;
            Category = category;
            OrderItem = orderItem;
            Product = product;
            CustomCategory = customCategory;
            CustomProduct = customProduct;
            CustomOrder = cusomtrepo;
            CustomAuth = customAuth;
        }
    }
}
