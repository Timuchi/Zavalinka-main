using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Prng;
using Zavalinka.Domain.Dto.Game;
using Zavalinka.Domain.Interfaces;

namespace Zavalinka.Api.Controllers;

[ApiController]
//[Authorize]
[AllowAnonymous]
[Route("/api/[controller]")]
public class GameController : ControllerBase
{
    private readonly IGameService _gameService;
    private readonly IAnswerService _answerService;
    
    public GameController(IGameService gameService, IAnswerService answerService)
    {
        _gameService = gameService;
        _answerService = answerService;
    }

    /// <summary>
    /// Создать новую игру, закрыв старую
    /// </summary>
    /// <param name="createGameRequestDto">Модель создания новой игры</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateGame(CreateGameRequestDto createGameRequestDto)
    {
        var createGame = await _gameService.CreateGame(createGameRequestDto);

        return Ok(createGame);
    }

    /// <summary>
    /// Получить текущую игру
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetActiveGame()
    {
        var activeGame = await _gameService.GetActiveGame();

        return Ok(activeGame);
    }
    
    private Guid GetCurrentUserId()
    {
        var test = HttpContext.User.FindFirst(p => p.Type == ClaimTypes.Name)?.Value;

        Guid.TryParse(test, out var userId);

        return userId;
    }
}