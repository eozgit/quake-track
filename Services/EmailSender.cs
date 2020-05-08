using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace QuakeTrack.Services
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private readonly IConfiguration Configuration;

        public Task SendEmailAsync(string email, string subject, string message)
        {
            var sendGridUser = Configuration["SendGridUser"];
            var sendGridKey = Configuration["SendGridKey"];
            var client = new SendGridClient(sendGridKey);
            var msg = new SendGridMessage
            {
                From = new EmailAddress("no-reply@quake-track.azurewebsites.net", sendGridUser),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            return client.SendEmailAsync(msg);
        }
    }
}