using Microsoft.AspNetCore.Identity;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Aplication
{
    public class DummyEmailSender : IEmailSender<Collaborator>
    {
        public Task SendConfirmationLinkAsync(Collaborator user, string email, string confirmationLink)
        {
            return Task.CompletedTask;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Task.CompletedTask;
        }

        public Task SendPasswordResetCodeAsync(Collaborator user, string email, string resetCode)
        {
            return Task.CompletedTask;
        }

        public Task SendPasswordResetLinkAsync(Collaborator user, string email, string resetLink)
        {
            return Task.CompletedTask;
        }
    }

}
