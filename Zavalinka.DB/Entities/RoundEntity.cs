using System.ComponentModel.DataAnnotations.Schema;
using Zavalinka.Common.Base;

namespace Zavalinka.DB.Entities;

/// <summary>
/// Модель раунда
/// </summary>
public class RoundEntity : BaseModel
{
    /// <summary>
    /// Номер раунда
    /// </summary>
    public int RoundNumber { get; set; }
    
    /// <summary>
    /// Идентификатор игры
    /// </summary>
    public Guid GameId { get; set; }
    
    /// <summary>
    /// Активен ли текущий раунд в игре
    /// </summary>
    public bool Active { get; set; }
    
    [ForeignKey(nameof(GameId))]
    public GameEntity Game { get; set; }
}