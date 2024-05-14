using Zavalinka.Common.Base;

namespace Zavalinka.Domain.Dto.Round;

public class RoundDto : BaseModel
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
}