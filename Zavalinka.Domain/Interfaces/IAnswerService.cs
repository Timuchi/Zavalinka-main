using System.Security.Claims;
using Zavalinka.Domain.Dto.Answer;

namespace Zavalinka.Domain.Interfaces;

public interface IAnswerService
{
    /// <summary>
    /// Добавить вариант определения к раунду по теме 
    /// </summary>
    /// <param name="textAnswer"></param>
    /// <param name="roundId"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<AnswerDto> AddAnswerToTheme(string textAnswer, Guid roundId, Guid userId);
    
    /// <summary>
    /// ПРоголосовать за определнный вариант термина
    /// </summary>
    /// <param name="answerId"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task VoteToAnswer(Guid answerId, Guid userId);

    /// <summary>
    /// Получить термины команд на текущий раунд
    /// </summary>
    /// <param name="roundId"></param>
    /// <returns></returns>
    Task<IEnumerable<AnswerDto>> GetRoundAnswers(Guid roundId);
}