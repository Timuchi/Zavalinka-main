using System.ComponentModel.DataAnnotations.Schema;
using Zavalinka.Common.Base;

namespace Zavalinka.DB.Entities;

/// <summary>
/// Модель игры
/// </summary>
public class GameEntity : BaseModel
{
    /// <summary>
    /// Активна ли игра на данный момент
    /// </summary>
    public bool Active { get; set; }
    
    /// <summary>
    /// Идентификаторы команд
    /// </summary>
    [Column(TypeName = "jsonb")]
    public IEnumerable<Guid> Teams { get; set; }
}