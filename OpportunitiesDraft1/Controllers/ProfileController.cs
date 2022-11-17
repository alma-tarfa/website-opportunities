using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpportunitiesDraft1.Models;
using OpportunitiesDraft1.Security;
using OpportunitiesDraft1.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OpportunitiesDraft1.Controllers
{
    [Route("[controller]/[action]")]
    public class ProfileController: Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ILogger<ProfileController> logger;
        private readonly IWebHostEnvironment _environment;
        private readonly IPartnerRepository _partnerRepository;
        private readonly IOpportunistRepository _opportunistRepository;
        private readonly IDataProtector protector;

        public ProfileController(IDataProtectionProvider dataProtectionProvider,
                               DataProtectionPurposeStrings dataProtectionPurposeStrings, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<ProfileController> logger,IPartnerRepository partnerRepository, IOpportunistRepository opportunistRepository, IWebHostEnvironment environment)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
            _partnerRepository = partnerRepository;
            _opportunistRepository = opportunistRepository;
            _environment = environment;
            protector = dataProtectionProvider
               .CreateProtector(dataProtectionPurposeStrings.OpportunistIdRouteValue)
               .CreateProtector(dataProtectionPurposeStrings.PartnerIdRouteValue);
        }
        
        //[Route("~/profile")]
        [AllowAnonymous]
        public ViewResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ViewResult Details( int? id)
        {
            logger.LogTrace("Trace Log");
            logger.LogDebug("Debug Log");
            logger.LogInformation("Information Log");
            logger.LogWarning("Warning Log");
            logger.LogError("Error Log");
            logger.LogCritical("Critical Log");

          //  int userId = Convert.ToInt32(protector.Unprotect(id));
            int userId = (int)id;

            Opportunist opportunist = _opportunistRepository.GetOpportunist(userId);
            Partner partner = _partnerRepository.GetPartner(userId);

            if (opportunist == null && partner == null)
            {
                Response.StatusCode = 404;
                return View("UserNotFound", userId);
            }
            if (partner == null && opportunist != null)
            {
                OpportunistDetailsViewModel opportunistDetailsViewModel = new OpportunistDetailsViewModel()
                {
                    Opportunist = opportunist,

                };

                return View(opportunistDetailsViewModel);
            }
            
                PartnerDetailsViewModel partnerDetailsViewModel = new PartnerDetailsViewModel()
                {
                    Partner = partner,

                };
                return View(partnerDetailsViewModel);
           
        }
      
    }
}
