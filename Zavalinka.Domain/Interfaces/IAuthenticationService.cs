using Zavalinka.Domain.Dto.Authentication;
using Zavalinka.Domain.Dto.Authentication.Login;
using Zavalinka.Domain.Dto.Authentication.Register;

namespace Zavalinka.Domain.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAuthenticationService
    {
        Task<UserLoginResponseDto> Login(UserLoginRequestDto data);
        Task<UserRegisterResponseDto> Register(UserRegisterRequestDto data);
        Task UpdatePassword(UserPasswordUpdateDto data);
    }
}