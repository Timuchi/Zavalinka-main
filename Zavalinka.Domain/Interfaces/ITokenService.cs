using Zavalinka.Domain.Dto.User;
using Zavalinka.Domain.Token;

namespace Zavalinka.Domain.Interfaces
{
    public interface ITokenService
    {
        TokenModel CreateToken(UserModelDto user);

        /*Guid GetCurrentUserId();

        string GetClaim(string token, string claimType);*/
    }
}