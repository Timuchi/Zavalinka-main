using System.ComponentModel.DataAnnotations.Schema;
using Zavalinka.Common.Base;

namespace Zavalinka.DB.Entities;

public class AnswerEntity : BaseModel
{
    public Guid RoundId { get; set; }
    
    public Guid TeamId { get; set; }
    
    [Column(TypeName = "jsonb")]
    public List<Guid> TeamVotes { get; set; }
    
    public string Answer { get; set; }
    
    [ForeignKey(nameof(RoundId))]
    public RoundEntity Round { get; set; }
    
    [ForeignKey(nameof(TeamId))]
    public TeamEntity Team { get; set; }
}