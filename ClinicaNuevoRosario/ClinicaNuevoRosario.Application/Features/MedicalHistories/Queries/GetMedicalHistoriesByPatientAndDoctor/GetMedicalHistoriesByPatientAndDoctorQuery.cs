using ClinicaNuevoRosario.Application.Models.MedicalHistories;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.MedicalHistories.Queries.GetMedicalHistoriesByPatientAndDoctor
{
    public class GetMedicalHistoriesByPatientAndDoctorQuery: IRequest<List<MedicalHistoryDto>>
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
    }
}
