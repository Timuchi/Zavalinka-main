using System.ComponentModel.DataAnnotations.Schema;
using Zavalinka.Common.Base;

namespace Zavalinka.DB.Entities;

public class TeamEntity : BaseModel
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
    [Column(TypeName = "jsonb")]
    public List<Guid> Users { get; set; }
}