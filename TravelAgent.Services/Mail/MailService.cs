namespace TravelAgent.Services.Mail
{
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;
    using TravelAgent.Services.Newsletter.Models;

    public class MailService : IMailService
    {
        private readonly IConfiguration configuration;

        public MailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task SendEmail(string email, string subject, string message)
        {
            using (var client = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = this.configuration["Email:Email"],
                    Password = this.configuration["Email:Password"]
                };

                client.Credentials = credential;
                client.Host = configuration["Email:Host"];
                client.Port = int.Parse(configuration["Email:Port"]);
                client.EnableSsl = true;

                using (var emailMessage = new MailMessage())
                {
                    emailMessage.To.Add(new MailAddress(email));
                    emailMessage.From = new MailAddress(configuration["Email:Email"]);
                    emailMessage.Subject = subject;
                    emailMessage.Body = message;
                    emailMessage.IsBodyHtml = true;
                    try
                    {
                        client.Send(emailMessage);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
                                    ex.ToString());
                    }
                }
            }
            await Task.CompletedTask;
        }

        public async Task SendNewsletter(List<SubscribersServiceModel> subscribers, string subject, string message)
        {
            using (var client = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = this.configuration["Email:Email"],
                    Password = this.configuration["Email:Password"]
                };

                client.Credentials = credential;
                client.Host = configuration["Email:Host"];
                client.Port = int.Parse(configuration["Email:Port"]);
                client.EnableSsl = true;

                foreach (var subscriber in subscribers)
                {
                    if (string.IsNullOrWhiteSpace(subscriber.Id) || string.IsNullOrWhiteSpace(subscriber.Email))
                    {
                        continue;
                    }
                    using (var emailMessage = new MailMessage())
                    {
                        emailMessage.To.Add(new MailAddress(subscriber.Email));
                        emailMessage.From = new MailAddress(configuration["Email:Email"]);
                        emailMessage.Subject = subject;
                        var rejectMessage = $"<br/>If you don't want to receive newsletter anymore, please <a href=\"https://localhost:5001/Newsletter/Reject?email={subscriber.Email}&key={subscriber.Id}\">reject here!</a>";
                        var infoMessage = $"<br/>This is information message containing links only to our travels. You don't have to fill any credentials";
                        emailMessage.Body = message + rejectMessage + infoMessage;
                        emailMessage.IsBodyHtml = true;
                        try
                        {
                            client.Send(emailMessage);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
                                        ex.ToString());
                        }
                    }
                }
            }
            await Task.CompletedTask;
        }

        public async Task SendReservationConfirmEmail(string email, string reservationId)
        {
            using (var client = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = this.configuration["Email:Email"],
                    Password = this.configuration["Email:Password"]
                };

                client.Credentials = credential;
                client.Host = configuration["Email:Host"];
                client.Port = int.Parse(configuration["Email:Port"]);
                client.EnableSsl = true;

                using (var emailMessage = new MailMessage())
                {
                    emailMessage.To.Add(new MailAddress(email));
                    emailMessage.From = new MailAddress(configuration["Email:Email"]);
                    emailMessage.Subject = "Confirmed reservation";
                    emailMessage.Body = $"Thank you for the payment! We will wait you :)";
                    emailMessage.IsBodyHtml = true;
                    try
                    {
                        client.Send(emailMessage);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
                                    ex.ToString());
                    }
                }
            }
            await Task.CompletedTask;
        }

        public async Task SendReservationEmail(string email, string reservationId)
        {
            using (var client = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = this.configuration["Email:Email"],
                    Password = this.configuration["Email:Password"]
                };

                client.Credentials = credential;
                client.Host = configuration["Email:Host"];
                client.Port = int.Parse(configuration["Email:Port"]);
                client.EnableSsl = true;

                using (var emailMessage = new MailMessage())
                {
                    emailMessage.To.Add(new MailAddress(email));
                    emailMessage.From = new MailAddress(configuration["Email:Email"]);
                    emailMessage.Subject = "Successful reservation";
                    emailMessage.Body = $"Thank you for your reservation! You can check your reservation details on our web page, using your reservation Id number {reservationId}";
                    emailMessage.IsBodyHtml = true;
                    try
                    {
                        client.Send(emailMessage);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
                                    ex.ToString());
                    }
                }
            }
            await Task.CompletedTask;
        }
    }
}
