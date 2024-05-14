using Zavalinka.Domain.Dto.Authentication.RestoringPassword.ForgotPassword;
using Zavalinka.Domain.Dto.Authentication.RestoringPassword.RestorePassword;

namespace Zavalinka.BL.Authentication.RestoringPassword
{
    public interface IRestorePasswordService
    {
        Task<ForgotPasswordResponseDto> ForgotPassword(ForgotPasswordRequestDto email);
        Task<RestorePasswordResponseDto> RestorePassword(RestorePasswordRequestDto data);
    }
}