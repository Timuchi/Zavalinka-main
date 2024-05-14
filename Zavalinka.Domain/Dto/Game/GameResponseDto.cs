using Zavalinka.Common.Base;
using Zavalinka.Domain.Dto.Round;

namespace Zavalinka.Domain.Dto.Game;

public class GameResponseDto : BaseModel
{
    /// <summary>
    /// Активна ли игра на данный момент
    /// </summary>
    public bool Active { get; set; }
    
    /// <summary>
    /// Идентификаторы команд
    /// </summary>
    public IEnumerable<Guid> Teams { get; set; }
    
    /// <summary>
    /// Раунды
    /// </summary>
    public List<RoundDto> Rounds { get; set; }
}