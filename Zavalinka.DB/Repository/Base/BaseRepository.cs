using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Zavalinka.Common.Base;

namespace Zavalinka.DB.Repository.Base
{
    public abstract class BaseRepository<TModel>
        where TModel : BaseModel
    {
        private readonly AppDbContext _context;

        protected BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public TModel? GetOne (Func<TModel, bool> predicate)
            => _context.Set<TModel>().AsNoTracking().FirstOrDefault(predicate);
        

        public async Task<TModel> Create (TModel item)
        {
            item.DateCreated = DateTime.UtcNow;
            await _context.Set<TModel>().AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }
        
        public async Task CreateRangeAsync(IEnumerable<TModel> items)
        {
            await _context.Set<TModel>().AddRangeAsync(items);
            await _context.SaveChangesAsync();
        }

        public async Task<TModel> Update (TModel item)
        {
            item.DateUpdated = DateTime.UtcNow;
            _context.Set<TModel>().Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
        
        public async Task<TModel>? UpdateAsync(TModel item)
        {
            _context.Set<TModel>().Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
        
        public async Task<TModel> GetById(Guid id)
            => await _context.Set<TModel>().FindAsync(id);
        

        public async Task<TModel> Delete(Guid id)
        {
            var item = await _context.Set<TModel>().FindAsync(id);
            if (item == null)
                return null;

            _context.Set<TModel>().Remove(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public IQueryable<TModel> FindByCondition(Expression<Func<TModel, bool>> expression)
            => _context.Set<TModel>()
                .Where(expression)
                .AsNoTracking();
    }
}