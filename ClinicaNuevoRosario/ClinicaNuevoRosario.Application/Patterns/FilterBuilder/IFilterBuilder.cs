using ClinicaNuevoRosario.Application.Helpers;
using ClinicaNuevoRosario.Application.Models.Doctors;
using ClinicaNuevoRosario.Domain;

namespace ClinicaNuevoRosario.Application.Patterns.FilterBuilder
{
    public interface IFilterBuilder
    {
        FilterBuilder BuildStartEndDateFilter(DateTime? startDate, DateTime? endDate);
        FilterBuilder BuildByMonthFilter(DateTime? dateTime);
        FilterBuilder BuildAppointmentTypeFilter(ServiceTypes? serviceType);
        FilterBuilder BuildAppointmentStateFilter(AppointmentStates? appointmentState);
        FilterBuilder BuildHealthInsuranceFilter(int? healthInsuranceId);
        FilterBuilder BuildDoctorFilter(int? doctorId);
        FilterBuilder BuildMedicalSpecialityFilter(int? medicalSpecialtyId);
    }
}
