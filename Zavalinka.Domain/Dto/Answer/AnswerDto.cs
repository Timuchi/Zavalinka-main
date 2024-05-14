using Zavalinka.Common.Base;

namespace Zavalinka.Domain.Dto.Answer;

public class AnswerDto : BaseModel
{
    /// <summary>
    /// Идетификатор раунда
    /// </summary>
    public Guid RoundId { get; set; }
    
    /// <summary>
    /// Идентификатор команды давшей ответ
    /// </summary>
    public Guid TeamId { get; set; }
    
    /// <summary>
    /// Идентификаторы команд, проголосовавшие за это определение
    /// </summary>
    public List<Guid> TeamVotes { get; set; }
    
    /// <summary>
    /// Текст определения
    /// </summary>
    public string Answer { get; set; }
}