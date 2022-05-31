using AutoMapper;
using ClinicaNuevoRosario.Application.Features.Appointments.Commands.AddAppointment;
using ClinicaNuevoRosario.Application.Features.Appointments.Commands.UpdateAppointment;
using ClinicaNuevoRosario.Application.Features.Doctors.Commands.AddDoctor;
using ClinicaNuevoRosario.Application.Features.Doctors.Commands.UpdateDoctor;
using ClinicaNuevoRosario.Application.Models.Doctors;
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
            CreateMap<Appointment, AppointmentModel>();
            CreateMap<AddAppointmentCommand, Appointment>();
            CreateMap<UpdateAppointmentCommand, Appointment>();

        }
    }
}
