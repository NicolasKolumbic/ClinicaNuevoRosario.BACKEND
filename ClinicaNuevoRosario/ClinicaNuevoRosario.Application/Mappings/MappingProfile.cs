using AutoMapper;
using ClinicaNuevoRosario.Application.Features.Appointments.Commands.AddAppointment;
using ClinicaNuevoRosario.Application.Features.Appointments.Commands.UpdateAppointment;
using ClinicaNuevoRosario.Application.Features.Doctors.Commands.AddDoctor;
using ClinicaNuevoRosario.Application.Features.Doctors.Commands.UpdateDoctor;
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
            CreateMap<AddAppointmentCommand, Domain.Appointment>();
            CreateMap<UpdateAppointmentCommand, Domain.Appointment>();
            CreateMap<Patient, PantientResponse>();
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
