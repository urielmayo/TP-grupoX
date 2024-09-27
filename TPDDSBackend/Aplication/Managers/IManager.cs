using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Aplication.Managers
{
    public interface IManager<T> where T : class
    {
        public Task<T> FindByIdAsync(int Id);
        public Task<bool> DeleteAsync(T fridge);

        public Task<bool> Save(T entity, int id = 0);
    }
}
