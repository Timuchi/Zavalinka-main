using Zavalinka.Domain.Dto.Token;

namespace Zavalinka.Domain.Dto.Authentication.Login
{
    public class UserLoginResponseDto
    {
        public Guid Id { get; set; }
        public TokenModelDto Token { get; set; }
    }
}