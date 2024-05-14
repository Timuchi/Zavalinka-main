using System.ComponentModel.DataAnnotations.Schema;
using Zavalinka.Common.Base;

namespace Zavalinka.DB.Entities;

public class ThemeRoundEntity : BaseModel
{
    public Guid ThemeId { get; set; }
    
    public Guid RoundId { get; set; }
    
    [ForeignKey(nameof(ThemeId))]
    public ThemeEntity Theme { get; set; }
}