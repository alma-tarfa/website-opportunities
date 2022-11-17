using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpportunitiesDraft1.Models
{
    public interface INewsletterRepository
    {
        Newsletter GetMailingListItem(int Id);
        IEnumerable<Newsletter> GetAllMailingList();
        Newsletter Add(Newsletter newsletter);
        Newsletter Update(Newsletter newsletterChanges);
        Newsletter Delete(int id);
    }
}
