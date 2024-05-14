namespace Zavalinka.Domain.Dto.Theme;

public class PageThemeResponseDto
{
    public IEnumerable<ThemeDto> Themes { get; set; }
    
    public int Total { get; set; }
}