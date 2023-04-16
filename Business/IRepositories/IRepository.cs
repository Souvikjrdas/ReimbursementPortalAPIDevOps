namespace Business.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>?> GetAllAsync();
        void Add(T ob);
        void Remove(T ob);
        Task<T?> GetAsync(int id);
    }
}