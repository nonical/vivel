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
            // Faq
            CreateMap<Database.Faq, FaqDTO>();
            CreateMap<FaqInsertRequest, Database.Faq>();
            CreateMap<FaqUpdateRequest, Database.Faq>();

            // PresetBadge
            CreateMap<Database.PresetBadge, PresetBadgeDTO>();
            CreateMap<PresetBadgeUpsertRequest, Database.PresetBadge>();

            // Hospital
            CreateMap<Database.Hospital, HospitalDTO>()
                .ForMember(destination => destination.Latitude, o => o.MapFrom(source => source.Location.Y))
                .ForMember(destination => destination.Longitude, o => o.MapFrom(source => source.Location.X));
            CreateMap<HospitalUpsertRequest, Database.Hospital>()
                .ForMember(destination => destination.Location, o => o.MapFrom(source => GeographyHelper.CreatePoint(source.Longitude, source.Latitude)));

            //  Notification
            CreateMap<Database.Notification, NotificationDTO>();
            CreateMap<NotificationInsertRequest, Database.Notification>();

            // User
            CreateMap<Database.User, UserDTO>()
                .ForMember(destination => destination.Latitude, o => o.MapFrom(source => source.Location.Y))
                .ForMember(destination => destination.Longitude, o => o.MapFrom(source => source.Location.X))
                .ForMember(destination => destination.BloodType, o => o.MapFrom(source => source.BloodType.Name));
            CreateMap<Database.User, UserDetailsDTO>()
                .ForMember(destination => destination.BloodType, o => o.MapFrom(source => source.BloodType.Name))
                .ForMember(destination => destination.DonationCount, o => o.MapFrom(source => source.Donations.Count))
                .ForMember(destination => destination.LastDonation, o => o.MapFrom(source => source.Donations.Where(x => x.Status.Name == "Approved").OrderBy(x => x.UpdatedAt).Last().UpdatedAt))
                .ForMember(destination => destination.LitresDonated, o => o.MapFrom(source => source.Donations.Sum(x => x.Amount) * 0.001));
            CreateMap<UserUpdateRequest, Database.User>()
                .ForMember(destination => destination.Location, o => o.MapFrom(source => GeographyHelper.CreatePoint(source.Longitude, source.Latitude)));

            // Drive
            CreateMap<Database.Drive, DriveDTO>()
                .ForMember(destination => destination.BloodType, o => o.MapFrom(source => source.BloodType.Name))
                .ForMember(destination => destination.Status, o => o.MapFrom(source => source.Status.Name));
            CreateMap<Database.Drive, DriveDetailsDTO>()
                .ForMember(destination => destination.BloodType, o => o.MapFrom(source => source.BloodType.Name))
                .ForMember(destination => destination.AmountLeft, o => o.MapFrom(source => source.Amount - source.Donations.Where(x => x.Status.Name == "Approved").Sum(x => x.Amount)))
                .ForMember(destination => destination.PendingCount, o => o.MapFrom(source => source.Donations.Where(x => x.Status.Name == "Pending").Count()))
                .ForMember(destination => destination.ScheduledCount, o => o.MapFrom(source => source.Donations.Where(x => x.Status.Name == "Scheduled").Count()))
                .ForMember(destination => destination.Status, o => o.MapFrom(source => source.Status.Name));
            CreateMap<DriveInsertRequest, Database.Drive>()
                .ForPath(s => s.BloodType, opt => opt.Ignore());
            CreateMap<DriveUpdateRequest, Database.Drive>()
                .ForPath(s => s.Status, opt => opt.Ignore())
                .ForPath(s => s.BloodType, opt => opt.Ignore());

            // Donation
            CreateMap<Database.Donation, DonationDTO>()
                .ForMember(destination => destination.UserName, o => o.MapFrom(source => source.User.UserName))
                .ForMember(destination => destination.BloodType, o => o.MapFrom(source => source.Drive.BloodType.Name))
                .ForMember(destination => destination.HospitalName, o => o.MapFrom(source => source.Drive.Hospital.Name))
                .ForMember(destination => destination.Status, o => o.MapFrom(source => source.Status.Name))
                .ForMember(destination => destination.ErythrocyteCount, o => o.MapFrom(source => source.DonationReport.ErythrocyteCount))
                .ForMember(destination => destination.LeukocyteCount, o => o.MapFrom(source => source.DonationReport.LeukocyteCount))
                .ForMember(destination => destination.PlateletCount, o => o.MapFrom(source => source.DonationReport.PlateletCount))
                .ForMember(destination => destination.Note, o => o.MapFrom(source => source.DonationReport.Note));
            CreateMap<DonationInsertRequest, Database.Donation>();
            CreateMap<DonationUpdateRequest, Database.Donation>()
                .ForPath(s => s.Status, opt => opt.Ignore())
                .ForPath(s => s.Drive.BloodType, opt => opt.Ignore());

            // DonationReport
            CreateMap<DonationUpdateRequest, Database.DonationReport>();
            CreateMap<DonationInsertRequest, Database.DonationReport>();

            // Badge
            CreateMap<Database.Badge, BadgeDTO>()
                .ForMember(destination => destination.Name, o => o.MapFrom(source => source.Name))
                .ForMember(destination => destination.Description, o => o.MapFrom(source => source.PresetBadge.Description))
                .ForMember(destination => destination.Picture, o => o.MapFrom(source => source.PresetBadge.Picture))
                .ForMember(destination => destination.CreatedAt, o => o.MapFrom(source => source.CreatedAt));
        }
    }
}
