using AutoMapper;
using Zavalinka.DB.Repository.Round;
using Zavalinka.Domain.Dto.Round;
using Zavalinka.Domain.Interfaces;

namespace Zavalinka.BL.Services;

public class RoundService : IRoundService
{
    private readonly IRoundRepository _roundRepository;
    private readonly IMapper _mapper;

    public RoundService( IRoundRepository roundRepository, IMapper mapper)
    {
        _roundRepository = roundRepository;
        _mapper = mapper;
    }

    public async Task EndRound(Guid roundId)
    {
        var oldRound = _roundRepository.GetOne(p => p.Id == roundId);

        if (oldRound is null)
        {
            return;
        }

        oldRound.Active = false;

        var newRound = _roundRepository.GetOne(p =>
            p.GameId == oldRound.GameId && p.RoundNumber == oldRound.RoundNumber + 1);

        if (newRound is null)
        {
            return;
        }

        newRound.Active = true;
        await _roundRepository.Update(newRound);
        await _roundRepository.Update(oldRound);
    }

    public async Task<RoundDto> GetActiveRound(Guid gameId)
    {
        var roundEntity = _roundRepository.GetOne(p => p.GameId == gameId && p.Active);

        if (roundEntity is null)
        {
            return null;
        }

        var result = _mapper.Map<RoundDto>(roundEntity);

        return result;
    }
}