using System.Linq;
using AutoMapper;
using Vivel.Helpers;
using Vivel.Model.Dto;
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
            CreateMap<Database.Faq, FaqDTO>().ReverseMap();
            CreateMap<Database.Faq, FaqInsertRequest>().ReverseMap();
            CreateMap<Database.Faq, FaqUpdateRequest>().ReverseMap();

            CreateMap<Database.PresetBadge, PresetBadgeDTO>().ReverseMap();
            CreateMap<Database.PresetBadge, PresetBadgeUpsertRequest>().ReverseMap();

            CreateMap<Database.Hospital, HospitalDTO>()
                .ForMember(destination => destination.Latitude, o => o.MapFrom(source => source.Location.Y))
                .ForMember(destination => destination.Longitude, o => o.MapFrom(source => source.Location.X))
                .ReverseMap();
            CreateMap<HospitalUpsertRequest, Database.Hospital>()
                .ForMember(destination => destination.Location, o => o.MapFrom(source => GeographyHelper.CreatePoint(source.Longitude, source.Latitude)));

            CreateMap<Database.Notification, NotificationDTO>().ReverseMap();
            CreateMap<Database.Notification, NotificationInsertRequest>().ReverseMap();

            CreateMap<Database.User, UserDTO>()
                .ForMember(destination => destination.Latitude, o => o.MapFrom(source => source.Location.Y))
                .ForMember(destination => destination.Longitude, o => o.MapFrom(source => source.Location.X))
                .ForMember(destination => destination.BloodType, o => o.MapFrom(source => source.BloodType.Name))
                .ReverseMap();
            CreateMap<Database.User, UserDetailsDTO>()
                .ForMember(destination => destination.BloodType, o => o.MapFrom(source => source.BloodType.Name))
                .ForMember(destination => destination.DonationCount, o => o.MapFrom(source => source.Donations.Count))
                .ForMember(destination => destination.LastDonation, o => o.MapFrom(source => source.Donations.Where(x => x.Status.Name == "Approved").OrderBy(x => x.UpdatedAt).Last().UpdatedAt))
                .ForMember(destination => destination.LitresDonated, o => o.MapFrom(source => source.Donations.Sum(x => x.Amount) * 0.001));
            CreateMap<UserUpdateRequest, Database.User>()
                .ForMember(destination => destination.Location, o => o.MapFrom(source => GeographyHelper.CreatePoint(source.Longitude, source.Latitude)));

            CreateMap<Database.Drive, DriveDTO>()
                .ForMember(destination => destination.BloodType, o => o.MapFrom(source => source.BloodType.Name))
                .ForMember(destination => destination.Status, o => o.MapFrom(source => source.Status.Name))
                .ReverseMap();
            CreateMap<Database.Drive, DriveDetailsDTO>()
                .ForMember(destination => destination.BloodType, o => o.MapFrom(source => source.BloodType.Name))
                .ForMember(destination => destination.AmountLeft, o => o.MapFrom(source => source.Amount - source.Donations.Where(x => x.Status.Name == "Approved").Sum(x => x.Amount)))
                .ForMember(destination => destination.PendingCount, o => o.MapFrom(source => source.Donations.Where(x => x.Status.Name == "Pending").Count()))
                .ForMember(destination => destination.ScheduledCount, o => o.MapFrom(source => source.Donations.Where(x => x.Status.Name == "Scheduled").Count()))
                .ForMember(destination => destination.Status, o => o.MapFrom(source => source.Status.Name));
            CreateMap<Database.Drive, DriveInsertRequest>()
                .ForMember(destination => destination.BloodType, o => o.MapFrom(source => source.BloodType.Name))
                .ReverseMap();
            CreateMap<Database.Drive, DriveUpdateRequest>()
                .ForMember(destination => destination.BloodType, o => o.MapFrom(source => source.BloodType.Name))
                .ReverseMap();

            CreateMap<Database.Donation, DonationDTO>()
                .ForMember(destination => destination.UserName, o => o.MapFrom(source => source.User.UserName))
                .ForMember(destination => destination.BloodType, o => o.MapFrom(source => source.Drive.BloodType.Name))
                .ForMember(destination => destination.HospitalName, o => o.MapFrom(source => source.Drive.Hospital.Name))
                .ForMember(destination => destination.Status, o => o.MapFrom(source => source.Status.Name))
                .ForMember(destination => destination.ErythrocyteCount, o => o.MapFrom(source => source.DonationReport.ErythrocyteCount))
                .ForMember(destination => destination.LeukocyteCount, o => o.MapFrom(source => source.DonationReport.LeukocyteCount))
                .ForMember(destination => destination.PlateletCount, o => o.MapFrom(source => source.DonationReport.PlateletCount))
                .ForMember(destination => destination.Note, o => o.MapFrom(source => source.DonationReport.Note))
                .ReverseMap();
            CreateMap<Database.Donation, DonationInsertRequest>()
                .ReverseMap();
            CreateMap<Database.Donation, DonationUpdateRequest>()
                .ForMember(destination => destination.Status, o => o.MapFrom(source => source.Status.Name))
                .ForMember(destination => destination.BloodType, o => o.MapFrom(source => source.Drive.BloodType.Name))
                .ReverseMap()
                .ForPath(s => s.Status.Name, opt => opt.Ignore());

            CreateMap<Database.DonationReport, DonationUpdateRequest>().ReverseMap();
            CreateMap<Database.DonationReport, DonationInsertRequest>().ReverseMap();

            CreateMap<Database.Badge, BadgeDTO>()
                .ForMember(destination => destination.Name, o => o.MapFrom(source => source.Name))
                .ForMember(destination => destination.Description, o => o.MapFrom(source => source.PresetBadge.Description))
                .ForMember(destination => destination.Picture, o => o.MapFrom(source => source.PresetBadge.Picture))
                .ForMember(destination => destination.CreatedAt, o => o.MapFrom(source => source.CreatedAt));
        }
    }
}
