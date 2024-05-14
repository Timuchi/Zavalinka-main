using Zavalinka.DB.Entities;
using Zavalinka.DB.Repository.Base;

namespace Zavalinka.DB.Repository.RestoringCode
{
    public class RestoringCodeRepository : BaseRepository<RestoringCodeEntity>, IRestoringCodeRepository
    {
        public RestoringCodeRepository(AppDbContext context) : base(context)
        {
        }
    }
}