using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpportunitiesDraft1.Models
{
    public class SQLNewsletterRepository :INewsletterRepository
    {
        private readonly AppDbContext context;
        public SQLNewsletterRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Newsletter Add(Newsletter newsletter)
        {
            context.Newsletters.Add(newsletter);
            context.SaveChanges();
            return newsletter;
        }

        public Newsletter Delete(int id)
        {
            Newsletter newsletter = context.Newsletters.Find(id);
            if (newsletter != null)
            {
                context.Newsletters.Remove(newsletter);
                context.SaveChanges();
            }
            return newsletter;
        }

        public IEnumerable<Newsletter> GetAllMailingList()
        {
            return context.Newsletters;
        }

        public Newsletter GetMailingListItem(int Id)
        {
            return context.Newsletters.Find(Id);
        }

        public Newsletter Update(Newsletter newsletterChanges)
        {
            var newsletter = context.Newsletters.Attach(newsletterChanges);
            newsletter.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return newsletterChanges;
        }
    }
}
