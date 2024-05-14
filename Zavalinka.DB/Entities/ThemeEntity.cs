using Zavalinka.Common.Base;

namespace Zavalinka.DB.Entities;

/// <summary>
/// Модель вопроса раунда
/// </summary>
public class ThemeEntity : BaseModel
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