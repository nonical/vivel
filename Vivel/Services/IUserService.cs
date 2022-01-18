using Vivel.Model.Dto;
using Vivel.Model.Requests.User;

namespace Vivel.Services
{
    public interface IUserService : IBaseCRUDService<UserDTO, UserSearchRequest, object, UserUpdateRequest>
    {
    }
}
