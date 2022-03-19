using Vivel.Model.Dto;
using Vivel.Model.Requests.Donation;

namespace Vivel.Interfaces
{
    public interface IDonationService : IBaseCRUDService<DonationDTO, DonationSearchRequest, DonationInsertRequest, DonationUpdateRequest>
    {
    }
}
