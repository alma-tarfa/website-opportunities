using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpportunitiesDraft1.Models
{
    public class SQLPartnerRepository : IPartnerRepository
    {
        private readonly AppDbContext context;

        public SQLPartnerRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Partner Add(Partner partner)
        {
            context.Partners.Add(partner);
            context.SaveChanges();
            return partner;
        }

        public Partner Delete(int id)
        {
            Partner partner = context.Partners.Find(id);
            if (partner != null)
            {
                context.Partners.Remove(partner);
                context.SaveChanges();
            }
            return partner;
        }

        public IEnumerable<Partner> GetAllPartner()
        {
            return context.Partners;

        }
        public Partner GetPartner(int Id)
        {
            return context.Partners.Find(Id);

        }
        public Partner Update(Partner partnerChanges)
        {
            var employee = context.Partners.Attach(partnerChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return partnerChanges;
        }
    }
}
