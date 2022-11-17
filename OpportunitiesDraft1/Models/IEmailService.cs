using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpportunitiesDraft1.Models
{
    public interface IEmailService
    {
        void Send(ContactMessage message);
    }
}
