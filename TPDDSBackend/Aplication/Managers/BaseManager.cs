using Microsoft.EntityFrameworkCore;
using TPDDSBackend.Domain.EF.DBContexts;

namespace TPDDSBackend.Aplication.Managers
{
    public class BaseManager<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        //private static ApplicationDbContext contextInstance = null;
        //public static ApplicationDbContext contextSingleton
        //{
        //    get
        //    {
        //        if (contextInstance == null)
        //            contextInstance = new ApplicationDbContext();
        //        return contextInstance;
        //    }
        //}

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
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
