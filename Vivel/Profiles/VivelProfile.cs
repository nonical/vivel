using System.Linq;
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
        public VivelProfile()
        {
            // Custom Type Converters
            CreateMap<string, BloodType>().ConvertUsing(s => BloodType.FromName(s, false));
            CreateMap<BloodType, string>().ConvertUsing(s => s.Name);

            CreateMap<string, DriveStatus>().ConvertUsing(s => DriveStatus.FromName(s, false));
            CreateMap<DriveStatus, string>().ConvertUsing(s => s.Name);

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
                // TODO: Status property in the following map should be replaced with an enum one
                .ForMember(destination => destination.LastDonation, o => o.MapFrom(source => source.Donations.Where(x => x.Status == "Finished").OrderBy(x => x.UpdatedAt).Last().UpdatedAt))
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
