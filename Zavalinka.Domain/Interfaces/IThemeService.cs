using Zavalinka.Domain.Dto.Theme;

namespace Zavalinka.Domain.Interfaces;

public interface IThemeService
{
    Task<ThemeDto> AddTheme(string theme, string defenition);

    Task<ThemeDto> GetThemeByRoundId(Guid roundId);

    Task<PageThemeResponseDto> GetThemes(int take, int skip);

    Task DeleteTheme(Guid themeId);
}