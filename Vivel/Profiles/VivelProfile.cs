using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vivel.Model.Dto;
using Vivel.Model.Requests.Faq;
using Vivel.Model.Requests.PresetBadge;
using Vivel.Model.Requests.Hospital;
using Vivel.Model.Requests.Notification;
using Vivel.Model.Requests.User;

namespace Vivel.Profiles
{
    public class VivelProfile : Profile
    {
        public VivelProfile()
        {
            CreateMap<Database.Faq, FaqDTO>().ReverseMap();
            CreateMap<Database.Faq, FaqInsertRequest>().ReverseMap();
            CreateMap<Database.Faq, FaqUpdateRequest>().ReverseMap();


            CreateMap<Database.PresetBadge, PresetBadgeDTO>().ReverseMap();
            CreateMap<Database.PresetBadge, PresetBadgeUpsertRequest>().ReverseMap();

            CreateMap<Database.Hospital, HospitalDTO>().ReverseMap();
            CreateMap<Database.Hospital, HospitalUpsertRequest>().ReverseMap();

            CreateMap<Database.Notification, NotificationDTO>().ReverseMap();
            CreateMap<Database.Notification, NotificationInsertRequest>().ReverseMap();

            CreateMap<Database.User, UserDTO>().ReverseMap();
            CreateMap<Database.User, UserUpsertRequest>().ReverseMap();
        }
    }
}
