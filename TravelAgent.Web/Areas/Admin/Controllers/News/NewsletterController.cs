namespace TravelAgent.Web.Areas.Admin.Controllers.News
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading.Tasks;
    using TravelAgent.Services.Html;
    using TravelAgent.Services.Mail;
    using TravelAgent.Services.Newsletter;
    using TravelAgent.Web.Areas.Admin.Models.Newsletter;
    using TravelAgent.Web.Controllers;
    using TravelAgent.Web.Infrastructure.Extensions;

    [Area(WebConstants.AdminArea)]
    [Authorize(Roles = WebConstants.AdministratorRole)]
    public class NewsController : Controller
    {
        private readonly IMailService emailService;
        private readonly INewsletterService newsletterSerice;
        private readonly IHtmlService html;

        public NewsController(IMailService emailService, INewsletterService newsletterSerice, IHtmlService html)
        {
            this.emailService = emailService;
            this.newsletterSerice = newsletterSerice;
            this.html = html;
        }

        public IActionResult CreateAndSend()
        {
            return View(new AddNewsletterFormViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAndSend(AddNewsletterFormViewModel model)
        {
            var subscribers = newsletterSerice.GetAllScubscribersEmails().ToList();
            var message = html.Sanitize(model.Content);
            var subject = model.Subject;

            await emailService.SendNewsletter(subscribers, subject, message);

            TempData.AddSuccessMessage($"Newsletter sent successfully!");

            return RedirectToAction(
                nameof(HomeController.Index),
                "Home",
                new { area = string.Empty });
        }
    }
}
