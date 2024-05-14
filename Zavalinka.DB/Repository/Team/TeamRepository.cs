using Zavalinka.DB.Entities;
using Zavalinka.DB.Repository.Base;

namespace Zavalinka.DB.Repository.Team;

public class TeamRepository : BaseRepository<TeamEntity>, ITeamRepository
{
    public TeamRepository(AppDbContext context) : base(context)
    {
    }
}