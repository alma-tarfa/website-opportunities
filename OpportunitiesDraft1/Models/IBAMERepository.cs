using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpportunitiesDraft1.Models
{
   public interface IBAMERepository
    {
        BAME GetGAME(int Id);
        IEnumerable<BAME> GetAllBAME();
        BAME Add(BAME bame);
        BAME Update(BAME BAMEChanges);
        BAME Delete(int id);
    }
}
