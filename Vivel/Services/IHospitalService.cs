using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vivel.Database;
using Vivel.Model.Dto;
using Vivel.Model.Requests.Hospital;

namespace Vivel.Services
{
    public interface IHospitalService : IBaseCRUDService<HospitalDTO, HospitalSearchRequest, HospitalInsertRequest, HospitalUpdateRequest>
    {
    }
}
