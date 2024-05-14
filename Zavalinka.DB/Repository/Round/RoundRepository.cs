using Zavalinka.DB.Entities;
using Zavalinka.DB.Repository.Base;

namespace Zavalinka.DB.Repository.Round;

public class RoundRepository : BaseRepository<RoundEntity>, IRoundRepository
{
    public RoundRepository(AppDbContext context) : base(context)
    {
    }
}