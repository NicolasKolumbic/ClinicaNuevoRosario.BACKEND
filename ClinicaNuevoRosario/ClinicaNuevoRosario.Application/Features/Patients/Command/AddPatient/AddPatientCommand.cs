using ClinicaNuevoRosario.Application.Models.Doctors;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.Patients.Command.AddPatient
{
    public class AddPatientCommand: IRequest<int>
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public double PhoneNumber { get; set; }
        public double IdentificationNumber { get; set; }
        public HealthInsuranceDto HealthInsurance { get; set; }
        public PlanDto Plan { get; set; }
    }
}
