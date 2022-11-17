using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpportunitiesDraft1.Models;
using OpportunitiesDraft1.ViewModels;

namespace OpportunitiesDraft1.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private EmailAddress FromAndToEmailAddress;
        private IEmailService EmailService;
        private readonly IWebHostEnvironment _environment;
        private readonly INewsletterRepository _newsletterRepository;
        public HomeController(EmailAddress _fromAddress,
            IEmailService _emailService, INewsletterRepository newsletterRepository, IWebHostEnvironment environment, ILogger<HomeController> logger)
        {
            FromAndToEmailAddress = _fromAddress;
            EmailService = _emailService;
            _newsletterRepository = newsletterRepository;
            _environment = environment;
            _logger = logger;
        }

        [Route("~/")]
        [Route("/Home")]
        [Route("~/Home/Index")]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }
        [Route("~/contact")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Contact()
        {
            return View();
        }

        [Route("~/contact")]
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                ContactMessage msgToSend = new ContactMessage
                {
                    FromAddresses = new List<EmailAddress> { FromAndToEmailAddress },
                    ToAddresses = new List<EmailAddress> { FromAndToEmailAddress },
                    Message = $"Here is your message: Name: {model.Name}, " +
                        $"Email: {model.Email}, Phone Number: {model.PhoneNumber}, Message: {model.Message}",
                    Interest = $"Contact Form -{model.Interest} "
                };

                EmailService.Send(msgToSend);
                return RedirectToAction("ConfirmFormSubmit");
            }
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ConfirmFormSubmit()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Newsletter()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ConfirmMailingList()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Newsletter(NewsletterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newNewsletterItem = new Newsletter
                {
                    Name = model.Name,
                    Email = model.Email
                };
                _newsletterRepository.Add(newNewsletterItem);

                return RedirectToAction("ConfirmMailingList");
            }
            return View();
        }

        [Route("~/Partners")]
        [AllowAnonymous]
        public IActionResult Partners()
        {
            return View();
        }
        [Route("~/Opportunists")]
        [AllowAnonymous]
        public IActionResult Opportunists()
        {
            return View();
        }
        [Route("~/BAMEBusinesses")]
        [AllowAnonymous]
        public IActionResult BAMEBusinesses()
        {
            return View();
        }
        [Route("~/Events")]
        [AllowAnonymous]
        public IActionResult Events()
        {
            return View();
        }
        [Route("~/Blog")]
        [AllowAnonymous]
        public IActionResult Blog()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [AllowAnonymous]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
