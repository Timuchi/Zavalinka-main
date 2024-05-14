using System.Security.Claims;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zavalinka.DB.Entities;
using Zavalinka.DB.Repository.Team;
using Zavalinka.DB.Repository.User;
using Zavalinka.Domain.Dto.Team;
using Zavalinka.Domain.Interfaces;

namespace Zavalinka.BL.Services;

public class TeamsService : ITeamsService
{
    private readonly IUserRepository _userRepository;
    private readonly ITeamRepository _teamRepository;
    private readonly IMapper _mapper;

    public TeamsService(IUserRepository userRepository, ITeamRepository teamRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _teamRepository = teamRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TeamDto>> GetTeams()
    {
        var selected = await _teamRepository.FindByCondition(p => true)
            .OrderBy(p => p.DateCreated)
            .ToListAsync();

        var result = _mapper.Map<List<TeamDto>>(selected);

        return result;
    }

    public async Task AddUserIntoTeam(Guid userId, Guid teamId)
    {
        var newTeam = _teamRepository.GetOne(t => t.Id == teamId);
        
        var user = await _userRepository.GetById(userId);

        var teams =  _teamRepository.FindByCondition(t => true).ToList();

        TeamEntity oldteam = null;
        
        foreach (var team in teams)
        {
            var contains = team.Users.Contains(userId);

            if (contains)
            {
                oldteam = team;
            }
        }

        if (oldteam is not null)
        {
            if (oldteam.Id == newTeam.Id)
            {
                return;
            }
            
            var users = oldteam.Users.ToList();

            users.Remove(user.Id);

            oldteam.Users = users;

            await _teamRepository.Update(oldteam);
        }

        var newTeamUsers = newTeam.Users.ToList();
        
        newTeamUsers.Add(user.Id);

        newTeam.Users = newTeamUsers;

        await _teamRepository.Update(newTeam);
    }
}