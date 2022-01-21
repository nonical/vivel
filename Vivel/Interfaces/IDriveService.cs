using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vivel.Database;
using Vivel.Model.Dto;
using Vivel.Model.Requests.Donation;
using Vivel.Model.Requests.Drive;

namespace Vivel.Interfaces
{
    public interface IDriveService : IBaseCRUDService<DriveDTO, DriveSearchRequest, DriveInsertRequest, DriveUpdateRequest>
    {
        Task<List<DonationDTO>> Donations(string id, DonationSearchRequest request);
    }
}
