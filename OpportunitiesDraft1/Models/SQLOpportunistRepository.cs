using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpportunitiesDraft1.Models
{
    public class SQLOpportunistRepository : IOpportunistRepository
    {
        private readonly AppDbContext context;
        public SQLOpportunistRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Opportunist Add(Opportunist opportunist)
        {
            context.Opportunists.Add(opportunist);
            context.SaveChanges();
            return opportunist;
        }

        public Opportunist Delete(int id)
        {
            Opportunist opportunist = context.Opportunists.Find(id);
            if (opportunist != null)
            {
                context.Opportunists.Remove(opportunist);
                context.SaveChanges();
            }
            return opportunist;
        }

        public IEnumerable<Opportunist> GetAllOpportunist()
        {
            return context.Opportunists;
        }

        public Opportunist GetOpportunist(int Id)
        {
            return context.Opportunists.Find(Id);
        }

        public Opportunist Update(Opportunist opportunistChanges)
        {
            var opportunist = context.Opportunists.Attach(opportunistChanges);
            opportunist.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return opportunistChanges;
        }
    }
}
