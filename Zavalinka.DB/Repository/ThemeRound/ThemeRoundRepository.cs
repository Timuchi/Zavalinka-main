using Zavalinka.DB.Entities;
using Zavalinka.DB.Repository.Base;

namespace Zavalinka.DB.Repository.ThemeRound;

public class ThemeRoundRepository : BaseRepository<ThemeRoundEntity>, IThemeRoundRepository
{
    public ThemeRoundRepository(AppDbContext context) : base(context)
    {
    }
}