namespace E_Commerce_API.Repo.Contract
{
    public interface IGenericRepo<T> where T : class
    {
        Task AddObject(T entity);
        void DeleteObject(int id);
        void UpdateObject(T entity);
        Task<T> GetById(int id); 
    }
}
