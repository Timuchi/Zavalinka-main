using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zavalinka.Domain.Interfaces;

namespace Zavalinka.Api.Controllers;

[ApiController]
[AllowAnonymous]
[Route("/api/[controller]")]
public class ThemeController : ControllerBase
{
    private readonly IThemeService _themeService;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="themeService"></param>
    public ThemeController(IThemeService themeService)
    {
        _themeService = themeService;
    }

    /// <summary>
    /// Добавить новый термин
    /// </summary>
    /// <param name="theme"></param>
    /// <param name="definition"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateTheme(string theme, string definition)
    {
        var result = await _themeService.AddTheme(theme, definition);

        return Ok(result);
    }

    /// <summary>
    /// Получить страницу терминов
    /// </summary>
    /// <param name="take"></param>
    /// <param name="skip"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetPage([FromQuery] int take, [FromQuery] int skip)
    {
        var result = await _themeService.GetThemes(take, skip);

        return Ok(result);
    }

    /// <summary>
    /// Удалить термин
    /// </summary>
    /// <param name="themeId"></param>
    /// <returns></returns>
    [HttpDelete("{themeId}")]
    public async Task<IActionResult> Delete(Guid themeId)
    {
        await _themeService.DeleteTheme(themeId);

        return Ok();
    }
    
    private Guid GetCurrentUserId()
    {
        var test = HttpContext.User.FindFirst(p => p.Type == ClaimTypes.Name)?.Value;

        Guid.TryParse(test, out var userId);

        return userId;
    }
}