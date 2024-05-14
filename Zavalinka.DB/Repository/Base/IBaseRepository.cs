using System.Linq.Expressions;
using Zavalinka.Common.Base;

namespace Zavalinka.DB.Repository.Base
{
    public interface IBaseRepository<TModel>
        where TModel : BaseModel
    {
        Task<TModel> Create(TModel data);
        Task CreateRangeAsync(IEnumerable<TModel> items);
        Task<TModel> GetById(Guid id);
        TModel GetOne(Func<TModel, bool> predicate);
        Task<TModel> Update(TModel item);

        Task<TModel>? UpdateAsync(TModel item);
        
        
        
        Task<TModel> Delete(Guid id);

        IQueryable<TModel> FindByCondition(Expression<Func<TModel, bool>> expression);
    }
}