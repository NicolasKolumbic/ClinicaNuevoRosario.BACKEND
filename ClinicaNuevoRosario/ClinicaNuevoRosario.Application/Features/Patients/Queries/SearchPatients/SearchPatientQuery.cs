using ClinicaNuevoRosario.Application.Models.Pantients;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.Patients.Queries.SearchPatients
{
    public class SearchPatientQuery: IRequest<List<PatientDto>>
    {
        public string Text { get; set; }
    }
}
