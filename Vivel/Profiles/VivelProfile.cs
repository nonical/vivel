﻿using System.Linq;
using Ardalis.SmartEnum;
using AutoMapper;
using Vivel.Model.Dto;
using Vivel.Model.Enums;
using Vivel.Model.Requests.Donation;
using Vivel.Model.Requests.Drive;
using Vivel.Model.Requests.Faq;
using Vivel.Model.Requests.Hospital;
using Vivel.Model.Requests.Notification;
using Vivel.Model.Requests.PresetBadge;
using Vivel.Model.Requests.User;

namespace Vivel.Profiles
{
    public class VivelProfile : Profile
    {
        private void EnumNameConverter<T>() where T : SmartEnum<T, int>
        {
            CreateMap<string, T>().ConvertUsing(s => SmartEnum<T>.FromName(s, false));
            CreateMap<T, string>().ConvertUsing(s => s.Name);
        }

        public VivelProfile()
        {
            // Custom Type Converters
            EnumNameConverter<BloodType>();
            EnumNameConverter<DriveStatus>();
            EnumNameConverter<DonationStatus>();

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
            CreateMap<Database.User, UserDetailsDTO>()
                .ForMember(destination => destination.DonationCount, o => o.MapFrom(source => source.Donations.Count))
                .ForMember(destination => destination.LastDonation, o => o.MapFrom(source => source.Donations.Where(x => x.Status == DonationStatus.Approved).OrderBy(x => x.UpdatedAt).Last().UpdatedAt))
                .ForMember(destination => destination.LitresDonated, o => o.MapFrom(source => source.Donations.Sum(x => x.Amount) * 0.001));
            CreateMap<Database.User, UserUpdateRequest>().ReverseMap();

            CreateMap<Database.Drive, DriveDTO>().ReverseMap();
            CreateMap<Database.Drive, DriveInsertRequest>().ReverseMap();
            CreateMap<Database.Drive, DriveUpdateRequest>().ReverseMap();

            CreateMap<Database.Donation, DonationDTO>().ReverseMap();
            CreateMap<Database.Donation, DonationInsertRequest>().ReverseMap();
            CreateMap<Database.Donation, DonationUpdateRequest>().ReverseMap();

            CreateMap<Database.Badge, BadgeDTO>()
                .ForMember(destination => destination.Name, o => o.MapFrom(source => source.PresetBadge.Name))
                .ForMember(destination => destination.Description, o => o.MapFrom(source => source.PresetBadge.Description))
                .ForMember(destination => destination.Picture, o => o.MapFrom(source => source.PresetBadge.Picture))
                .ForMember(destination => destination.CreatedAt, o => o.MapFrom(source => source.CreatedAt));
        }
    }
}
