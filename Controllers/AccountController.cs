using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpportunitiesDraft1.Models;
using OpportunitiesDraft1.ViewModels;

namespace OpportunitiesDraft1.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ILogger<AccountController> logger;
        private readonly IBAMERepository _bameRepository;
        private readonly IPartnerRepository _partnerRepository;
        private readonly IOpportunistRepository _opportunistRepository;
        private readonly IWebHostEnvironment _environment;
        
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<AccountController> logger, IBAMERepository bameRepository, IPartnerRepository partnerRepository, IOpportunistRepository opportunistRepository, IWebHostEnvironment environment)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
            _bameRepository = bameRepository;
            _partnerRepository = partnerRepository;
            _opportunistRepository = opportunistRepository;
            _environment = environment;
        }
   

        public IActionResult Blazor()
        {

            return View("_Host");
        }

       
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
        
        [HttpGet]
        [AllowAnonymous]
        public ViewResult Register()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public ViewResult RegisterOpportunist()
        {
            return View();
        }

       
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterOpportunist(RegisterViewModelOpportunist model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFileOpportunist(model);

                var newOpportunist = new Opportunist
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password,
                    Mentorship = model.Mentorship,
                    StartUp = model.StartUp,
                    Partnership = model.Partnership,
                    Sponsorship = model.Sponsorship,
                    BusinessOpportunities = model.BusinessOpportunities,
                    WorkPlacement = model.WorkPlacement,
                    JobOpportunities = model.JobOpportunities,
                    WorkshopTraining = model.WorkshopTraining,
                    AllyShip = model.AllyShip,
                    PersonalStatement = model.PersonalStatement,
                    AdditionalMessage = model.AdditionalMessage,

                    PhotoPath = uniqueFileName
                };

                _opportunistRepository.Add(newOpportunist);

                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    UserType = "Opportunist"
                };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = token }, Request.Scheme);

                    logger.Log(LogLevel.Warning, confirmationLink);


                    ViewBag.ErrorTitle = "Registration Sucessful";
                    ViewBag.ErrorMessage = "Before you can login, please confirm your " +
                        "email, by clicking on the confirmation link we have emailed you";
                    return View("Error");

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(model);
        }
        [Route("/registerPartner")]
        [HttpGet]
        [AllowAnonymous]
        public ViewResult RegisterPartner()
        {
            return View();
        }
        [Route("/registerPartner")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterPartner(RegisterViewModelPartner model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFilePartner(model);

                var newPartner = new Partner
                {
                    Name = model.Name,
                    Company = model.Company,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    Password = model.Password,
                    Mentorship = model.Mentorship,
                    StartUp = model.StartUp,
                    Partnership = model.Partnership,
                    Sponsorship = model.Sponsorship,
                    BusinessOpportunities = model.BusinessOpportunities,
                    AllyShip = model.AllyShip,
                    WorkPlacement = model.WorkPlacement,
                    JobOpportunities = model.JobOpportunities,
                    WorkshopTraining = model.WorkshopTraining,
                    AdditionalMessage = model.AdditionalMessage,
                    PhotoPath = uniqueFileName
                };

                _partnerRepository.Add(newPartner);

                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    UserType = "Partner"
    };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = token }, Request.Scheme);

                    logger.Log(LogLevel.Warning, confirmationLink);


                    ViewBag.ErrorTitle = "Registration Sucessful";
                    ViewBag.ErrorMessage = "Before you can login, please confirm your " +
                        "email, by clicking on the confirmation link we have emailed you";
                    return View("Error");

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            var redirectUrl = Url.Action("ExternalLoginCallBack", "Account", new { ReturnUrl = returnUrl });
            var properties = signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("login", "account");
            }

            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"The User ID {userId} is invalid";
                return View("NotFound");
            }

            var result = await userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
            {
                return View();
            }

            ViewBag.ErrorTitle = "Email cannot be confirmed";
            return View("Error");
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl)
        {
            LoginViewModel model = new LoginViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };
            return View(model);
        }
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            LoginViewModel loginViewModel = new LoginViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };
            if (remoteError != null)
            {
                ModelState.AddModelError(string.Empty, $"Error from external provider: {remoteError}");
                return View("Login", loginViewModel);
            }
            var info = await signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ModelState.AddModelError(string.Empty, "Error loading exteral login information.");

                return View("Login", loginViewModel);
            }
            var email = info.Principal.FindFirstValue(ClaimTypes.Email);



            ApplicationUser user = null;
            if (email != null)
            {
                user = await userManager.FindByEmailAsync(email);
                if (user != null && !user.EmailConfirmed)
                {
                    ModelState.AddModelError(string.Empty, "Email not confirmed yet");
                    return View("Login", loginViewModel);
                }
            }
            var signInResult = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            if (signInResult.Succeeded)
            {
                return LocalRedirect(returnUrl);
               

            }
            else
            {
                if (email != null)
                {
                    if (user == null)
                    {
                        user = new ApplicationUser
                        {
                            UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
                            Email = info.Principal.FindFirstValue(ClaimTypes.Email)
                        };
                        await userManager.CreateAsync(user);
                        var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                        var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = token }, Request.Scheme);

                        logger.Log(LogLevel.Warning, confirmationLink);

                        ViewBag.ErrorTitle = "Registration Sucessful";
                        ViewBag.ErrorMessage = "Before you can login, please confirm your " +
                            "email, by clicking on the confirmation link we have emailed you";
                        return View("Error");
                    }
                    await userManager.AddLoginAsync(user, info);
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);

                }
                ViewBag.ErrorTitle = $"Email claim not received from: {info.LoginProvider}";
                ViewBag.ErrorMessage = "Please contact support on support@opportunitees.com";
                return View("Error");
            }



        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            model.ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user != null && !user.EmailConfirmed &&
                                    (await userManager.CheckPasswordAsync(user, model.Password)))
                {
                    ModelState.AddModelError(string.Empty, "Email not confirmed yet");
                    return View(model);
                }

                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password,
                                        model.RememberMe, true);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Profile");

                        
                    }
                }

                if (result.IsLockedOut)
                {
                    return View("AccountLocked");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user != null && await userManager.IsEmailConfirmedAsync(user))
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);

                    var passwordResetLink = Url.Action("ResetPassword", "Account",
                            new { email = model.Email, token = token }, Request.Scheme);

                    logger.Log(LogLevel.Warning, passwordResetLink);

                    return View("ForgotPasswordConfirmation");
                }

                return View("ForgotPasswordConfirmation");
            }

            return View(model);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string token, string email)
        {
            if (token == null || email == null)
            {
                ModelState.AddModelError("", "Invalid password reset token");
            }
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);
                    if (result.Succeeded)
                    {
                        if (await userManager.IsLockedOutAsync(user))
                        {
                            await userManager.SetLockoutEndDateAsync(user, DateTimeOffset.UtcNow);
                        }

                        return View("ResetPasswordConfirmation");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }

                return View("ResetPasswordConfirmation");
            }

            return View(model);
        }
        private string ProcessUploadedFileOpportunist(RegisterViewModelOpportunist model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
                uniqueFileName = $"{Guid.NewGuid().ToString()}_{model.Photo.FileName}";
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }

            }

            return uniqueFileName;
        }
        private string ProcessUploadedFilePartner(RegisterViewModelPartner model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
                uniqueFileName = $"{Guid.NewGuid().ToString()}_{model.Photo.FileName}";
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }

            }

            return uniqueFileName;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult BAME()
        {

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult BAME(BAMEViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFileBAME(model);

                var newBAME = new BAME
                {
                    BusinessName = model.BusinessName,
                    Statement = model.Statement,
                    Description = model.Description,
                    WebsiteLink = model.WebsiteLink,
                    FacebookLink = model.FacebookLink,
                    InstagramLink = model.InstagramLink,
                    PhotoPath = uniqueFileName
                };

                _bameRepository.Add(newBAME);

                return RedirectToAction("ConfirmBAME","account");
            }
            ViewBag.ErrorTitle = "Details cannot be accepted";
            return View("Error");

        }
       
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ConfirmBAME()
        {
            return View();
        }
        private string ProcessUploadedFileBAME(BAMEViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
                uniqueFileName = $"{Guid.NewGuid().ToString()}_{model.Photo.FileName}";
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }

            }

            return uniqueFileName;
        }

    }
}
