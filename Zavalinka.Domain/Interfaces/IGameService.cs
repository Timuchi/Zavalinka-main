using Zavalinka.Domain.Dto.Game;

namespace Zavalinka.Domain.Interfaces;

public interface IGameService
{
    Task<GameResponseDto> CreateGame(CreateGameRequestDto createGameRequestDto);

    Task<GameResponseDto> GetActiveGame();
}