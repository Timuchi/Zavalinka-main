namespace Zavalinka.Domain.Dto.Game;

public class CreateGameRequestDto
{
    public IEnumerable<Guid> ThemeIDs { get; set; }
    
    public IEnumerable<Guid> TeamIds { get; set; }
}