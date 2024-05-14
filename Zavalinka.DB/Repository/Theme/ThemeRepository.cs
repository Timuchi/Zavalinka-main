using Zavalinka.DB.Entities;
using Zavalinka.DB.Repository.Base;

namespace Zavalinka.DB.Repository.Theme;

public class ThemeRepository : BaseRepository<ThemeEntity>, IThemeRepository
{
    public ThemeRepository(AppDbContext context) : base(context)
    {
    }
}