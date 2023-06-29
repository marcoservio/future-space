using FutureSpace.Context;
using FutureSpace.Interfaces;
using FutureSpace.Models;

using Microsoft.EntityFrameworkCore;

namespace FutureSpace.Repositories
{
    public class LaunchRepository : ILaunchRepository
    {
        private readonly AppDbContext _context;

        public LaunchRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Delete(Launch launch)
        {
            _context.Launchers.Remove(launch);
        }

        public async Task<IEnumerable<Launch>> GetAll()
        {
            return await _context.Launchers.ToListAsync();
        }

        public async Task<Launch> GetById(Guid id)
        {
            return await _context.Launchers.FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Launch launch)
        {
            _context.Launchers.Update(launch);
        }
    }
}
