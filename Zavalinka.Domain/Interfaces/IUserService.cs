using Zavalinka.Domain.Dto.User;
using Zavalinka.Domain.Dto.User.Update;

namespace Zavalinka.Domain.Interfaces
{
    public interface IUserService
    {
        
        Task<UserUpdateResponseDto> Edit(UserUpdateRequestDto data);
        
        Task<UserModelResponseDto> GetByUserName(string name);
        
        Task<UserModelResponseDto> GetById(Guid id);
        
        Task<UserModelResponseDto> Delete(Guid id);
    }
}