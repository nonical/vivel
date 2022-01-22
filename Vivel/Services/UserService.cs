﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Vivel.Database;
using Vivel.Interfaces;
using Vivel.Model.Dto;
using Vivel.Model.Enums;
using Vivel.Model.Requests.Notification;
using Vivel.Model.Requests.User;

namespace Vivel.Services
{
    public class UserService : BaseCRUDService<UserDTO, User, UserSearchRequest, object, UserUpdateRequest>, IUserService
    {
        public UserService(vivelContext context, IMapper mapper) : base(context, mapper) { }

        public override async Task<List<UserDTO>> Get(UserSearchRequest request = null)
        {
            var query = _context.Users.AsQueryable();

            if (request?.BloodType?.Count > 0)
            {
                query = query.Where(user => request.BloodType.Select(x => BloodType.FromName(x, false)).Any(z => z == user.BloodType));
            }

            if (request?.Verified != null)
            {
                query = query.Where(x => x.Verified == request.Verified);
            }

            return _mapper.Map<List<UserDTO>>(await query.ToListAsync());
        }

        public async Task<UserDetailsDTO> Details(string id)
        {
            var entity = await _context.Users.Include(x => x.Donations).Where(x => x.UserId == id).FirstAsync();

            return _mapper.Map<UserDetailsDTO>(entity);
        }


        public async Task<List<DonationDTO>> Donations(string id)
        {
            var entities = await _context.Donations.Where(x => x.UserId == id).ToListAsync();

            return _mapper.Map<List<DonationDTO>>(entities);
        }

        public async Task<DonationDTO> Donation(string userId, string donationId)
        {
            var entities = await _context.Donations.Where(x => x.UserId == userId && x.DonationId == donationId).FirstOrDefaultAsync();

            return _mapper.Map<DonationDTO>(entities);
        }

        public async Task<List<NotificationDTO>> Notifications(string id, NotificationSearchRequest request)
        {
            var entities = _context.Notifications.Where(x => x.UserId == id).AsQueryable();

            if (request?.LinkId != null)
            {
                entities = entities.Where(x => x.LinkId == request.LinkId);
            }

            if (request?.LinkId != null && request.LinkType != null)
            {
                entities = entities.Where(x => x.LinkId == request.LinkId && x.LinkType == request.LinkType);
            }

            var list = await entities.ToListAsync();

            return _mapper.Map<List<NotificationDTO>>(entities);
        }

        public async Task<List<BadgeDTO>> Badges(string id)
        {
            var entities = await _context.Badges.Include(x => x.PresetBadge).Where(x => x.UserId == id).ToListAsync();

            return _mapper.Map<List<BadgeDTO>>(entities);
        }

    }
}
