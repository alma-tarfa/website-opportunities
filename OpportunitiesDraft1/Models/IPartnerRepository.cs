using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpportunitiesDraft1.Models
{
    public interface IPartnerRepository
    {
        Partner GetPartner(int Id);
        IEnumerable<Partner> GetAllPartner();
        Partner Add(Partner partner);
        Partner Update(Partner partnerChanges);
        Partner Delete(int id);
    }
}
