using ClinicaNuevoRosario.Application.Models;

namespace ClinicaNuevoRosario.Application.Contracts.External
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
