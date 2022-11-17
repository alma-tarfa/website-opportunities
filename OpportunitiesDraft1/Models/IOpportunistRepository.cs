using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpportunitiesDraft1.Models
{
    public interface IOpportunistRepository
    {
        Opportunist GetOpportunist(int Id);
        IEnumerable<Opportunist> GetAllOpportunist();
        Opportunist Add(Opportunist opportunist);
        Opportunist Update(Opportunist opportunistChanges);
        Opportunist Delete(int id);
    }
}
