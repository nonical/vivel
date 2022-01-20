using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Vivel.Database;
using Vivel.Interfaces;
using Vivel.Model.Dto;
using Vivel.Model.Requests.User;

namespace Vivel.Services
{
    public class UserService : BaseCRUDService<UserDTO, User, UserSearchRequest, object, UserUpdateRequest>, IUserService
    {
        public UserService(vivelContext context, IMapper mapper) : base(context, mapper) { }

        public override async Task<List<UserDTO>> Get(UserSearchRequest request = null)
        {
            var query = _context.Set<User>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.BloodType))
            {
                query = query.Where(x => x.BloodType == request.BloodType);
            }

            if (request?.Verified != null)
            {
                query = query.Where(x => x.Verified == request.Verified);
            }

            return _mapper.Map<List<UserDTO>>(await query.ToListAsync());
        }
    }
}
