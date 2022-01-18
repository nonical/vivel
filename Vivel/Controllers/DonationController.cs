using Vivel.Model.Requests.Faq;
using Vivel.Services;
using Vivel.Model.Dto;
using Vivel.Model.Requests.Donation;

namespace Vivel.Controllers
{
    public class DonationController : BaseCRUDController<DonationDTO, DonationSearchRequest, DonationInsertRequest, DonationUpdateRequest>
    {
        public DonationController(IDonationService service) : base(service)
        {
        }
    }
}
