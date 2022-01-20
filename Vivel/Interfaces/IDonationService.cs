using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vivel.Database;
using Vivel.Model.Dto;
using Vivel.Model.Requests.Donation;

namespace Vivel.Interfaces
{
    public interface IDonationService : IBaseCRUDService<DonationDTO, DonationSearchRequest, DonationInsertRequest, DonationUpdateRequest>
    {
    }
}
