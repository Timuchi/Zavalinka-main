using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zavalinka.Domain.Interfaces;

namespace Zavalinka.Api.Controllers;

/// <summary>
/// Контроллер
/// </summary>
[ApiController]
[Authorize]
[Route("/api/[controller]")]
public class TeamController : ControllerBase
{
    private readonly ITeamsService _teamsService;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="teamsService"></param>
    public TeamController(ITeamsService teamsService)
    {
        _teamsService = teamsService;
    }

    /// <summary>
    /// Вступить в команду
    /// </summary>
    /// <param name="teamId">Идентификатор команды</param>
    /// <returns></returns>
    [HttpPut("{teamId}")]
    public async Task<IActionResult> JoinIntoTeam(Guid teamId)
    {
        var userId = GetCurrentUserId();

         await _teamsService.AddUserIntoTeam(userId, teamId);

         return Ok();
    }

    /// <summary>
    /// Получить список команд
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetTeamlist()
    {
        var result =  await _teamsService.GetTeams();

        return Ok(result);
    }
    
    private Guid GetCurrentUserId()
    {
        var test = HttpContext.User.FindFirst(p => p.Type == ClaimTypes.Name)?.Value;

        Guid.TryParse(test, out var userId);

        return userId;
    }
}