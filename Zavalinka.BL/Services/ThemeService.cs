using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zavalinka.DB.Entities;
using Zavalinka.DB.Repository.Round;
using Zavalinka.DB.Repository.Theme;
using Zavalinka.DB.Repository.ThemeRound;
using Zavalinka.Domain.Dto.Theme;
using Zavalinka.Domain.Interfaces;

namespace Zavalinka.BL.Services;

public class ThemeService : IThemeService
{
    private readonly IThemeRepository _themeRepository;
    private readonly IThemeRoundRepository _roundRepository;
    private readonly IMapper _mapper;

    public ThemeService(IThemeRepository baseRepository, IMapper mapper, IThemeRoundRepository roundRepository)
    {
        _themeRepository = baseRepository;
        _mapper = mapper;
        _roundRepository = roundRepository;
    }

    public async Task<ThemeDto> AddTheme(string theme, string defenition)
    {
        var themeEntity = new ThemeEntity
        {
            Theme = theme,
            CorrectAnswer = defenition
        };

        await _themeRepository.Create(themeEntity);

        var result = _mapper.Map<ThemeDto>(themeEntity);

        return result;
    }

    public async Task<PageThemeResponseDto> GetThemes(int take, int skip)
    {
        var themes = _themeRepository.FindByCondition(p => true);

        var total = themes.Count();

        var themesEntities = await themes.Skip(skip).Take(take).ToListAsync();

        var result = new PageThemeResponseDto
        {
            Themes = _mapper.Map<IEnumerable<ThemeDto>>(themesEntities),
            Total = total
        };

        return result;
    }

    public async Task<ThemeDto> GetThemeByRoundId(Guid roundId)
    {
        var round = _roundRepository.GetOne(p => p.RoundId == roundId);

        var entity = _themeRepository.GetOne(p => p.Id == round.ThemeId);

        var result = _mapper.Map<ThemeDto>(entity);

        return result;
    }

    public async Task DeleteTheme(Guid themeId)
    {
        _themeRepository.Delete(themeId);
    }
}