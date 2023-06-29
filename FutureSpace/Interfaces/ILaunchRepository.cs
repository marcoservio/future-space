using FutureSpace.Models;

namespace FutureSpace.Interfaces
{
    public interface ILaunchRepository
    {
        void Update(Launch launch);
        void Delete(Launch launch);
        Task<Launch> GetById(Guid id);
        Task<IEnumerable<Launch>> GetAll();
        Task<bool> SaveAllAsync();
    }
}
