using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zavalinka.DB.Entities;
using Zavalinka.DB.Repository.AnswerRepository;
using Zavalinka.DB.Repository.Team;
using Zavalinka.DB.Repository.User;
using Zavalinka.Domain.Dto.Answer;
using Zavalinka.Domain.Dto.Round;
using Zavalinka.Domain.Interfaces;

namespace Zavalinka.BL.Services;

public class AnswerService : IAnswerService
{
    private readonly IAnswerRepository _answerRepository;
    private readonly IUserRepository _userRepository;
    private readonly ITeamRepository _teamRepository;
    private readonly IMapper _mapper;

    public AnswerService(
        IAnswerRepository answerRepository,
        IUserRepository userRepository,
        ITeamRepository teamRepository,
        IMapper mapper)
    {
        _answerRepository = answerRepository;
        _userRepository = userRepository;
        _teamRepository = teamRepository;
        _mapper = mapper;
    }


    public async Task<AnswerDto> AddAnswerToTheme(string textAnswer, Guid roundId, Guid userId)
    {
        var user = await _userRepository.GetById(userId);

        var userTeam = _teamRepository.GetOne(p => p.Users.Contains(user.Id));
        
        var answer =  _answerRepository.GetOne(p => p.RoundId == roundId && p.TeamId == userTeam.Id);

        if (answer is not null)
        {
            return null;
        }

        var newAnswer = new AnswerEntity
        {
            RoundId = roundId,
            TeamId = userTeam.Id,
            Answer = textAnswer,
            TeamVotes = new List<Guid>()
        };

        await _answerRepository.Create(newAnswer);

        var result = _mapper.Map<AnswerDto>(newAnswer);

        return result;
    }

    public async Task VoteToAnswer(Guid answerId, Guid userId)
    {
        var user = await _userRepository.GetById(userId);

        var userTeam = _teamRepository.GetOne(p => p.Users.Contains(user!.Id));

        if (userTeam is null)
        {
            return;
        }

        var votableAnswer = _answerRepository.GetOne(p => p.Id == answerId);

        if (votableAnswer is null)
        {
            return;
        }

        if (votableAnswer.TeamVotes.Contains(userTeam.Id))
        {
            return;
        }
        
        votableAnswer.TeamVotes.Add(userTeam.Id);

        await _answerRepository.Update(votableAnswer);
    }

    public async Task<IEnumerable<AnswerDto>> GetRoundAnswers(Guid roundId)
    {
        var entities = _answerRepository.FindByCondition(p => p.RoundId == roundId).AsEnumerable();

        var result = _mapper.Map<IEnumerable<AnswerDto>>(entities);
        
        return result;
    }
}