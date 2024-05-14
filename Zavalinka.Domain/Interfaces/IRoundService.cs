using Zavalinka.Domain.Dto.Round;

namespace Zavalinka.Domain.Interfaces;

public interface IRoundService
{
    Task EndRound(Guid roundId);

    Task<RoundDto> GetActiveRound(Guid gameId);
}