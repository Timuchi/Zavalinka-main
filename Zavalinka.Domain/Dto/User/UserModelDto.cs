using Zavalinka.Common.Base;
using Zavalinka.Common.Enums.Roles;

namespace Zavalinka.Domain.Dto.User
{
    public class UserModelDto : BaseModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        
        public UserRoles Role { get; set; }
    }
}