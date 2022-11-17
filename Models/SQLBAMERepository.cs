using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpportunitiesDraft1.Models
{
    public class SQLBAMERepository : IBAMERepository
    {
        private readonly AppDbContext context;

        public SQLBAMERepository(AppDbContext context)
        {
            this.context = context;
        }
        public BAME Add(BAME bame)
        {
            context.BAMEs.Add(bame);
            context.SaveChanges();
            return bame;
        }

        public BAME Delete(int id)
        {
            BAME bame = context.BAMEs.Find(id);
            if (bame != null)
            {
                context.BAMEs.Remove(bame);
                context.SaveChanges();
            }
            return bame;
        }

        public IEnumerable<BAME> GetAllBAME()
        {
            return context.BAMEs;
        }

        public BAME GetGAME(int Id)
        {
            return context.BAMEs.Find(Id);
        }

        public BAME Update(BAME BAMEChanges)
        {
            var bame = context.BAMEs.Attach(BAMEChanges);
            bame.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return BAMEChanges;
        }
    }
}
