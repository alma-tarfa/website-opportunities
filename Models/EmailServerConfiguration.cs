using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpportunitiesDraft1.Models
{
    public class EmailServerConfiguration
    {
       // public EmailServerConfiguration(int _smtpPort = 587, string _smtpServer = "smtp.gmail.com", string _smptDomain = "gmail.com")
        public EmailServerConfiguration(int _smtpPort = 587)
            //string _smtpServer = "smtp.gmail.com", string _smptDomain = "gmail.com")
        {
            SmtpPort =_smtpPort;
            //SmtpServer = _smtpServer;
           // SmtpDomain = _smptDomain;
        }
        public string SmtpServer { get; set; }
        public int SmtpPort { get; }
        public string SmtpDomain { get; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
    }
}
