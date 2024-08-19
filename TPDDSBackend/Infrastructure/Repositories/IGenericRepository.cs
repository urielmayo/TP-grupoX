namespace TPDDSBackend.Infrastructure.Repositories
{
    public interface IGenericRepository<T>
    {
        Task<T> Insert(T value);
        Task<T?> GetById(int id);
        IQueryable<T> GetAll();
        void Update(T value);
        Task<bool> Delete(int id);
    }
}
