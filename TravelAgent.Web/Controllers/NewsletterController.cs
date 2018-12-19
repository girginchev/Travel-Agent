namespace TravelAgent.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TravelAgent.Services.Mail;
    using TravelAgent.Services.Newsletter;
    using TravelAgent.Web.Infrastructure.Extensions;

    public class NewsletterController : Controller
    {
        private readonly IMailService emailService;
        private readonly INewsletterService newsletterService;

        public NewsletterController(IMailService emailService, INewsletterService newsletterService)
        {
            this.emailService = emailService;
            this.newsletterService = newsletterService;
        }


        [HttpPost]
        public async Task<IActionResult> SendEmailInitial(string email, string subject, string message)
        {
            var model = newsletterService.Create(email);
            var view = this.View(model);
            message = view.ToHtml(this.HttpContext);
            subject = "Confirm your registration for Tour Agency subscribtion";

            await emailService.SendEmail(email, subject, message);

            return RedirectToAction(
            nameof(HomeController.Index),
            "Home",
            new { area = string.Empty });
        }

        public IActionResult Confirm(string email, string key)
        {
            var added = newsletterService.Add(email, key);

            if (!added)
            {
                TempData.AddErrorMessage($"This email {email} is already registered or parameters are invalid");
            }
            else
            {
                TempData.AddSuccessMessage($"Your email {email} was successfully subscribed for newsletters!");
            }


            return RedirectToAction(
                nameof(HomeController.Index),
                "Home",
                new { area = string.Empty });
        }

        public IActionResult Reject(string email, string key)
        {
            var unsubscribed = newsletterService.UnSubscribe(email, key);

            if (!unsubscribed)
            {
                TempData.AddErrorMessage($"This email {email} is not currently subscribed");
            }
            else
            {
                TempData.AddSuccessMessage($"Your email {email} was successfully Unsubscribed!");
            }
            
            return RedirectToAction(
                nameof(HomeController.Index),
                "Home",
                new { area = string.Empty });
        }
    }
}
