using Microsoft.EntityFrameworkCore;
using TPDDSBackend.Domain.EF.DBContexts;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Aplication.Managers
{
    public class FridgeManager : BaseManager<Fridge>
    {
        public FridgeManager(ApplicationDbContext dbContext) : base (dbContext)
        {}

        public async Task<Fridge> FindByIdAsync(int Id)
        {
            return await _dbContext.Fridge.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }
    }
}
