using AutoMapper;
using Zavalinka.DB.Entities;
using Zavalinka.Domain.Dto.Answer;
using Zavalinka.Domain.Dto.Authentication.Login;
using Zavalinka.Domain.Dto.Authentication.Register;
using Zavalinka.Domain.Dto.Authentication.RestoringPassword.ForgotPassword;
using Zavalinka.Domain.Dto.Authentication.RestoringPassword.RestorePassword;
using Zavalinka.Domain.Dto.Game;
using Zavalinka.Domain.Dto.Round;
using Zavalinka.Domain.Dto.Team;
using Zavalinka.Domain.Dto.Theme;
using Zavalinka.Domain.Dto.Token;
using Zavalinka.Domain.Dto.User;
using Zavalinka.Domain.Dto.User.Update;
using Zavalinka.Domain.Token;

namespace Zavalinka.Domain.Profiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<UserEntity, UserModelDto>();
            CreateMap<UserEntity, UserLoginResponseDto>();
            CreateMap<UserEntity, UserRegisterResponseDto>();
            CreateMap<UserEntity, UserModelResponseDto>();
            CreateMap<UserEntity, UserUpdateResponseDto>();
            CreateMap<UserEntity, UserLoginResponseDto>();
            CreateMap<UserEntity, UserRegisterResponseDto>();
            CreateMap<UserEntity, UserModelResponseDto>();
            CreateMap<UserEntity, UserUpdateResponseDto>();

            CreateMap<TokenModel, TokenModelDto>();

            CreateMap<UserRegisterRequestDto, UserEntity>();
            CreateMap<UserRegisterRequestDto, UserModelDto>();

            CreateMap<ForgotPasswordRequestDto, ForgotPasswordResponseDto>();
            CreateMap<ForgotPasswordRequestDto, ForgotPasswordResponseDto>();
            
            CreateMap<RestorePasswordRequestDto, RestorePasswordResponseDto>();
            CreateMap<RestorePasswordRequestDto, RestorePasswordResponseDto>();

            CreateMap<GameEntity, GameResponseDto>().ReverseMap();
            CreateMap<RoundEntity, RoundDto>().ReverseMap();
            CreateMap<ThemeEntity, ThemeDto>().ReverseMap();
            CreateMap<TeamEntity, TeamDto>().ReverseMap();
            CreateMap<AnswerEntity, AnswerDto>().ReverseMap();
        }
    }
}