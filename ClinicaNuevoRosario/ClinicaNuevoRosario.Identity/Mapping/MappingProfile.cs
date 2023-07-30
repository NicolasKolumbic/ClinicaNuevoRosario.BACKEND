using AutoMapper;
using ClinicaNuevoRosario.Application.Models.Doctors;
using ClinicaNuevoRosario.Domain;
using ClinicaNuevoRosario.Identity.Models;

namespace ClinicaNuevoRosario.Identity.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, UserChat>();
        }
    }
}
