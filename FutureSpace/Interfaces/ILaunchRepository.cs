using FutureSpace.Models;

namespace FutureSpace.Interfaces
{
    public interface ILaunchRepository
    {
        void Update(Launch launch);
        void Delete(Launch launch);
        Task<Launch> GetById(string id);
        Task<IEnumerable<Launch>> GetAll();
        Task<bool> SaveAllAsync();
    }
}
