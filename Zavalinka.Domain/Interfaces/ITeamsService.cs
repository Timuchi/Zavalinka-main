using System.Security.Claims;
using Zavalinka.Domain.Dto.Team;

namespace Zavalinka.Domain.Interfaces;

public interface ITeamsService
{
    Task<IEnumerable<TeamDto>> GetTeams();

    Task AddUserIntoTeam(Guid userId, Guid teamId);
}