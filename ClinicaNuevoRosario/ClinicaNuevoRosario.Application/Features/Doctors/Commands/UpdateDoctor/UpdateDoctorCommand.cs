using MediatR;

namespace ClinicaNuevoRosario.Application.Features.Doctors.Commands.UpdateDoctor
{
    public class UpdateDoctorCommand: IRequest<int>
    {
        public int DoctorId { get; set; }
        public string MedicalLicense { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string IdentificationNumber { get; set; }
    }
}
