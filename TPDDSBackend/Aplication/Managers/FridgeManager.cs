using TPDDSBackend.Domain.EF.DBContexts;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Aplication.Managers
{
    public class FridgeManager : BaseManager<Fridge>
    {
        public FridgeManager(ApplicationDbContext dbContext) : base (dbContext)
        {       }
    }
}
