using Holstic_LastDance.AppDataContext;
using Microsoft.EntityFrameworkCore;

namespace Holstic_LastDance.Repo
{
    public class Repo<T> : Irepo<T> where T : class
    {
        public AppDataContextt _context;

        public Repo(AppDataContextt context)
        {
            _context = context;
        }

        public async Task Create(T entity)
        {
            _context.Set<T>().AddAsync(entity);
        }

        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
