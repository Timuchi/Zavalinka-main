using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zavalinka.DB.Entities;
using Zavalinka.DB.Repository.Game;
using Zavalinka.DB.Repository.Round;
using Zavalinka.DB.Repository.Team;
using Zavalinka.DB.Repository.ThemeRound;
using Zavalinka.Domain.Dto.Game;
using Zavalinka.Domain.Dto.Round;
using Zavalinka.Domain.Interfaces;

namespace Zavalinka.BL.Services;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;
    private readonly IRoundRepository _roundRepository;
    private readonly IThemeRoundRepository _themeRoundRepository;
    private readonly ITeamRepository _teamRepository;
    private readonly IMapper _mapper;

    public GameService(
        IGameRepository gameRepository, 
        IRoundRepository roundRepository, 
        IThemeRoundRepository themeRoundRepository, 
        ITeamRepository teamRepository, IMapper mapper)
    {
        _gameRepository = gameRepository;
        _roundRepository = roundRepository;
        _themeRoundRepository = themeRoundRepository;
        _teamRepository = teamRepository;
        _mapper = mapper;
    }

    public async Task<GameResponseDto> GetActiveGame()
    {
        var gameEntity = _gameRepository.GetOne(p => p.Active);

        if (gameEntity is null)
        {
            return null;
        }

        var result = _mapper.Map<GameResponseDto>(gameEntity);

        var rounds = await _roundRepository.FindByCondition(p => p.GameId == gameEntity.Id).ToListAsync();

        result.Rounds = _mapper.Map<List<RoundDto>>(rounds);

        return result;
    }

    public async Task<GameResponseDto> CreateGame(CreateGameRequestDto requestDto)
    {
        var result = _gameRepository.GetOne(p => p.Active);

        var teams = await _teamRepository.FindByCondition(p => requestDto.TeamIds.Contains(p.Id)).ToListAsync();

        if (result is not null)
        {
            result.Active = false;

            await _gameRepository.Update(result)!;
        }

        var gameEntity = new GameEntity
        {
            Active = true,
            Teams = teams.Select(p => p.Id)
        };

        await _gameRepository.Create(gameEntity);

        var i = 1;

        var themeRounds = new List<ThemeRoundEntity>();
        var rounds = new List<RoundEntity>();

        foreach (var themeId in requestDto.ThemeIDs)
        {
            var themeRound = new ThemeRoundEntity
            {
                ThemeId = themeId,
            };

            var roundEntity = new RoundEntity
            {
                RoundNumber = i,
                GameId = gameEntity.Id,
                Active = false,
            };

            if (i == 1)
            {
                roundEntity.Active = true;
            }

            themeRound.RoundId = roundEntity.Id;

            themeRounds.Add(themeRound);
            rounds.Add(roundEntity);
            i++;
        }
        
        await _themeRoundRepository.CreateRangeAsync(themeRounds);
        
        await _roundRepository.CreateRangeAsync(rounds);

        var gameDto = _mapper.Map<GameResponseDto>(gameEntity);

        gameDto.Rounds = _mapper.Map<List<RoundDto>>(rounds);

        return gameDto;
    }
}