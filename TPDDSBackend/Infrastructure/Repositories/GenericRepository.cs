
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TPDDSBackend.Domain.EF.DBContexts;

namespace TPDDSBackend.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly ApplicationDbContext _dbContext;
        protected DbSet<T> Entities;
        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext  = dbContext;
            Entities = _dbContext.Set<T>();
        }
        public async Task<bool> Delete(int id)
        {
            T? entity = await GetById(id);
            if (entity is null)
                return false;

            Entities.Remove(entity);
            _dbContext.SaveChanges();
            return true;
        }

        public IQueryable<T> GetAll()=> 
            Entities.AsQueryable();

        public async Task<T?> GetById(int id)=>
            await Entities
            .FindAsync(id);

        public async Task<T> Insert(T value)
        {
            var insertedValue = await Entities.AddAsync(value);
            await _dbContext.SaveChangesAsync();
            return insertedValue.Entity;
        }

        public void Update(T value)
        {
            Entities.Update(value);
            _dbContext.SaveChanges();
        }
            

    }
}
