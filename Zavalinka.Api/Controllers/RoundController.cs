using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zavalinka.Domain.Interfaces;

namespace Zavalinka.Api.Controllers;

[ApiController]
[Authorize]
[Route("/api/[controller]")]
public class RoundController : ControllerBase
{
    private readonly IAnswerService _answerService;
    private readonly IRoundService _roundService;
    private readonly IThemeService _themeService;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="answerService"></param>
    /// <param name="roundService"></param>
    public RoundController(
        IAnswerService answerService,
        IRoundService roundService,
        IThemeService themeService)
    {
        _answerService = answerService;
        _roundService = roundService;
        _themeService = themeService;
    }

    /// <summary>
    /// Получить активный раунд
    /// </summary>
    /// <param name="gameId">Идентификатор игры</param>
    /// <returns></returns>
    [HttpGet("{gameId}")]
    public async Task<IActionResult> GetActiveRound(Guid gameId)
    {
        var result = await _roundService.GetActiveRound(gameId);

        return Ok(result);
    }

    /// <summary>
    /// Получить тему текущего раунда
    /// </summary>
    /// <param name="roundId">Идентификатор раунда</param>
    /// <returns></returns>
    [HttpGet("game/{roundId}")]
    public async Task<IActionResult> GetRoundTheme(Guid roundId)
    {
        var result = await _themeService.GetThemeByRoundId(roundId);

        return Ok(result);
    }

    /// <summary>
    /// Получить определения данные командами
    /// </summary>
    /// <param name="roundId"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetTeamAnswers(Guid roundId)
    {
        var result = await _answerService.GetRoundAnswers(roundId);

        return Ok(result);
    }

    /// <summary>
    /// ДОбавить вариант ответа от имени команды
    /// </summary>
    /// <param name="answer">Текст определения</param>
    /// <param name="roundId">Идентификатор команды</param>
    /// <returns></returns>
    [HttpPost("{roundId}")]
    public async Task<IActionResult> AddAnswerToThemeRound(string answer, Guid roundId)
    {
        var userId = GetCurrentUserId();

        var result = await _answerService.AddAnswerToTheme(answer, roundId, userId);

        return Ok(result);
    }

    /// <summary>
    /// Проголосовать командой за вариант ответа
    /// </summary>
    /// <param name="answerId"></param>
    /// <returns></returns>
    [HttpPut("{answerId}")]
    public async Task<IActionResult> VoteToAnswer(Guid answerId)
    {
        var userInfo = GetCurrentUserId();

        await _answerService.VoteToAnswer(answerId, userInfo);

        return Ok();
    }
    
    /// <summary>
    /// Закончить и начать следующий раунд
    /// </summary>
    /// <param name="roundId">Идентификатор раунда</param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> EndActiveRound(Guid roundId)
    {
        await _roundService.EndRound(roundId);

        return Ok();
    }
    
    private Guid GetCurrentUserId()
    {
        var test = HttpContext.User.FindFirst(p => p.Type == ClaimTypes.Name)?.Value;

        Guid.TryParse(test, out var userId);

        return userId;
    }
}