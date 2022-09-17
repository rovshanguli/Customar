using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Service.Services.Interfaces;
using System.Linq.Expressions;

namespace Service.Services
{
    public class GenericService<T> : IGenericService<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> entities;
        public GenericService(AppDbContext context)
        {
            _context = context;
            entities = _context.Set<T>();
        }
        public async Task<T> CreateAsync(T entity)
        {

            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await entities.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task SoftDeleteAsync(T entity)
        {
            if (entity is null) throw new ArgumentNullException();

            entity.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity is null) throw new ArgumentNullException();

            entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await entities.FindAsync(predicate);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await entities.Where(m => m.IsDeleted == false).OrderByDescending(m => m.Id).ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {

            T entity = await entities.FirstOrDefaultAsync(m => m.Id == id);

            if (entity is null) throw new NullReferenceException();

            return entity;
        }



        public async Task UpdateAsync(T entity)
        {
            if (entity is null) throw new ArgumentNullException();

            entities.Update(entity);

            await _context.SaveChangesAsync();
        }


    }
}
