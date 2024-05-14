using Zavalinka.Common.Base;

namespace Zavalinka.Domain.Dto.Team;

public class TeamDto : BaseModel
{
    /// <summary>
    /// Название команды участников
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Краткое описание 
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    /// Идентификатор картинки команды
    /// </summary>
    public string IconId { get; set; }
    
    /// <summary>
    /// Члены команды
    /// </summary>
    public List<Guid> Users { get; set; }
}