using AutoMapper;
using ClinicaNuevoRosario.Application.Features.Appointments.Commands.AddAppointment;
using ClinicaNuevoRosario.Application.Features.Appointments.Commands.UpdateAppointment;
using ClinicaNuevoRosario.Application.Features.Doctors.Commands.AddDoctor;
using ClinicaNuevoRosario.Application.Features.Doctors.Commands.UpdateDoctor;
using ClinicaNuevoRosario.Application.Features.Patients.Command.AddPatient;
using ClinicaNuevoRosario.Application.Models.Doctors;
using ClinicaNuevoRosario.Application.Models.Pantients;
using ClinicaNuevoRosario.Domain;

namespace ClinicaNuevoRosario.Application.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Doctor, DoctorViewModel>()
                .ForMember(f => f.DoctorId, s => s.MapFrom(sx => sx.Id))
                .ForMember(f => f.PhoneNumber, s => s.MapFrom(xs => (double)xs.PhoneNumber));
            CreateMap<AddDoctorCommand, Doctor>();
            CreateMap<UpdateDoctorCommand, Doctor>().ForMember(f => f.Id, s => s.MapFrom(sx => sx.DoctorId));
            CreateMap<Appointment, AppointmentDto>()
                .ForMember(x => x.AppointmentId, x => x.MapFrom(s => s.Id));
            CreateMap<AddAppointmentCommand, Domain.Appointment>()
                .ForMember(x => x.PatientId, x => x.MapFrom(s => s.Patient.PatientId))
                .ForMember(x => x.DoctorId, x => x.MapFrom(s => s.Doctor.DoctorId))
                .ForMember(x => x.HealthInsuranceId, x => x.MapFrom(s => s.Patient.HealthInsurance.Id))
                .ForMember(x => x.Doctor, x => x.Ignore())
                .ForMember(x => x.HealthInsurance, x => x.Ignore())
                .ForMember(x => x.Patient, x => x.Ignore());
            CreateMap<UpdateAppointmentCommand, Domain.Appointment>();
            CreateMap<Patient, PatientDto>()
                .ForMember(x => x.PatientId, x => x.MapFrom(s => s.Id));
            CreateMap<PatientDto, Patient>()
                .ForMember(x => x.Id, x => x.MapFrom(s => s.PatientId));
            CreateMap<AddPatientCommand, Patient>()
                .ForMember(x => x.Id, x => x.MapFrom(s => s.PatientId))
                .ForMember(x => x.HealthInsuranceId, x => x.MapFrom(s => s.HealthInsurance.Id))
                .ForMember(x => x.PlanId, x => x.MapFrom(s => s.Plan.Id))
                .ForMember(x => x.HealthInsurance, x => x.Ignore())
                .ForMember(x => x.Plan, x => x.Ignore());
            CreateMap<HealthInsurance, HealthInsuranceDto>();
            CreateMap<HealthInsuranceDto, HealthInsurance>();
            CreateMap<PlanDto, Plan>();
            CreateMap<Plan, PlanDto>();
            CreateMap<Doctor, DoctorDto>()
                .ForMember(x => x.DoctorId, x => x.MapFrom(s => s.Id))
                .ForMember(x => x.MedicalSpecialties, x => x.MapFrom(s => s.DoctorMedicalSpecialties.Select(x => x.MedicalSpecialty)));
            CreateMap<DoctorSchedule, DoctorScheduleDto>()
                .ForMember(x => x.DoctorScheduleId, x => x.MapFrom(s => s.Id));
            CreateMap<MedicalSpecialty, MedicalSpecialtyDto>()
                .ForMember(x => x.MedicalSpecialtyId, x => x.MapFrom(s => s.Id));

        }
    }
}
