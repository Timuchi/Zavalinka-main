using Zavalinka.Common.Base;

namespace Zavalinka.Domain.Dto.Theme;

public class ThemeDto : BaseModel
{
    /// <summary>
    /// Тема
    /// </summary>
    public string Theme { get; set; }
    
    /// <summary>
    /// Правильное определение для темы
    /// </summary>
    public string CorrectAnswer { get; set; }
}