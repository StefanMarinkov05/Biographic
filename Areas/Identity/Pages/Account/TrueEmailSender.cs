using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace Biographic.Areas.Identity.Pages.Account
{    public class TrueEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }

}
