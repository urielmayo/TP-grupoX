using Microsoft.EntityFrameworkCore;
using TPDDSBackend.Domain.EF.DBContexts;

namespace TPDDSBackend.Aplication.Managers
{
    public class BaseManager<T> where T : class
    {
        private static ApplicationDbContext contextInstance = null;
        public static ApplicationDbContext contextSingleton
        {
            get
            {
                if (contextInstance == null)
                    contextInstance = new ApplicationDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext>());
                return contextInstance;
            }
        }

        public async Task<bool> Save(T entity, int id = 0)
        {
            try
            {
                if (id == 0)
                    contextSingleton.Entry(entity).State = EntityState.Added;
                else
                    contextSingleton.Entry(entity).State = EntityState.Modified;

                var result = await contextSingleton.SaveChangesAsync() > 0;
                contextSingleton.Entry(entity).State = EntityState.Detached;
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
