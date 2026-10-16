using E_Commerce_API.Data;
using E_Commerce_API.Repo.Contract;

namespace E_Commerce_API.Repo.Implementation
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly App_Database_Context _db;
        public GenericRepo(App_Database_Context db)
        {
            _db = db;
        }

        public async Task AddObject(T entity)
        {
           await _db.Set<T>().AddAsync(entity);
        }

        public void DeleteObject(int id)
        {
            var x = _db.Set<T>().Find(id);
            _db.Set<T>().Remove(x);
        }

        public async Task<T> GetById(int id)
        {
            var x = await _db.Set<T>().FindAsync(id);
            return x;
        }

        public void UpdateObject(T entity)
        {
            _db.Set<T>().Update(entity);
        }
    }
}
