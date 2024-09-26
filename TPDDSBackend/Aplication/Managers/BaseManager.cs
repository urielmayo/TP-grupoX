using Microsoft.EntityFrameworkCore;
using TPDDSBackend.Domain.EF.DBContexts;

namespace TPDDSBackend.Aplication.Managers
{
    public class BaseManager<T> where T : class
    {
        protected readonly ApplicationDbContext _dbContext;

        public BaseManager(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<bool> Save(T entity, int id = 0)
        {
            try
            {
                if (id == 0)
                    _dbContext.Entry(entity).State = EntityState.Added;
                else
                    _dbContext.Entry(entity).State = EntityState.Modified;

                var result = await _dbContext.SaveChangesAsync() > 0;
                _dbContext.Entry(entity).State = EntityState.Detached;
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            try
            {
                _dbContext.Remove(entity);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
