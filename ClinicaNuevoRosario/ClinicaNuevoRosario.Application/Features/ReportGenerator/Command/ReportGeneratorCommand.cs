using ClinicaNuevoRosario.Application.Models.ReportGenerator;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.ReportGenerator.Command
{
    public class ReportGeneratorCommand : IRequest<byte[]>
    {
        public string FileTitle { get; set; }
        public List<HealthInsuranceReport> ReportData { get; set; }

    }
}
