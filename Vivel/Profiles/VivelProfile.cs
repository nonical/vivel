using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vivel.Model.Dto;
using Vivel.Model.Requests.Faq;
using Vivel.Model.Requests.PresetBadge;

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
            CreateMap<Database.PresetBadge, PresetBadgeInsertRequest>().ReverseMap();
            CreateMap<Database.PresetBadge, PresetBadgeUpdateRequest>().ReverseMap();
        }
    }
}
