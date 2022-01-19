using Vivel.Model.Dto;
using Vivel.Model.Requests.Donation;
using Vivel.Model.Requests.Faq;
using Vivel.Services;

namespace Vivel.Controllers
{
    public class DonationController : BaseCRUDController<DonationDTO, DonationSearchRequest, DonationInsertRequest, DonationUpdateRequest>
    {
        public DonationController(IDonationService service) : base(service)
        {
        }
    }
}
