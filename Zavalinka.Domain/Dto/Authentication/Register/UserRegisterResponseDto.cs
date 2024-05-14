using Zavalinka.Domain.Dto.Token;

namespace Zavalinka.Domain.Dto.Authentication.Register
{
    public class UserRegisterResponseDto
    {
        public Guid Id { get; set; }
        public TokenModelDto Token { get; set; }
    }
}