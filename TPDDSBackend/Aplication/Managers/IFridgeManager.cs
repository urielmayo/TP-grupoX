using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Aplication.Managers
{
    public interface IFridgeManager
    {
        public Task<Fridge> FindByIdAsync(int Id);
        public Task<bool> DeleteAsync(Fridge fridge);
    }
}
