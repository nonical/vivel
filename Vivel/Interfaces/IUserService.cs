using Vivel.Model.Dto;
using Vivel.Model.Requests.User;

namespace Vivel.Interfaces
{
    public interface IUserService : IBaseCRUDService<UserDTO, UserSearchRequest, object, UserUpdateRequest>
    {
    }
}
