using ClinicaNuevoRosario.Application.Contracts.External;
using ClinicaNuevoRosario.Application.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ClinicaNuevoRosario.Infrastructure.Email
{
    public class EmailService : IEmailService
    {
        public EmailService(IOptions<EmailSettings> emailSetting, ILogger<EmailService> logger)
        {
            this.emailSetting = emailSetting.Value;
            this.logger = logger;
        }

        public EmailSettings emailSetting { get; }
        public ILogger<EmailService> logger { get; }



        public async Task<bool> SendEmail(Application.Models.Email email)
        {
            var client = new SendGridClient(emailSetting.ApiKey);
            var subject = email.Subject;
            var to = new EmailAddress(email.To);
            var body = email.Body;

            var from = new EmailAddress()
            {
                Email = emailSetting.FromAdress,
                Name = emailSetting.FromName
            };

            var sendgrindMessage = MailHelper.CreateSingleEmail(from, to, subject, body, body);
            /*var response = await client.SendEmailAsync(sendgrindMessage);

            if (response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }*/

            return true;

            logger.LogError("El email no pudo ser enviado");

            return false;

        }
    }
}
