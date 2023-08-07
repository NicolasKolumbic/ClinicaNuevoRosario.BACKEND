using AutoMapper;
using ClinicaNuevoRosario.Application.Helpers;
using ClinicaNuevoRosario.Application.Models.Doctors;
using ClinicaNuevoRosario.Domain;
using System.Linq.Expressions;

namespace ClinicaNuevoRosario.Application.Patterns.FilterBuilder
{
    public class FilterBuilder: FilterBuilderBase<Appointment>, IFilterBuilder
    { 

        public FilterBuilder BuildAppointmentStateFilter(AppointmentStates? appointmentState)
        {
            if (appointmentState != null)
            {
                Expression<Func<Appointment, bool>> expression = (appointment) => appointment.AppointmentStateId == (int)appointmentState;

                base.AddExpression(expression);
            }

            return this;
        }

        public FilterBuilder BuildAppointmentTypeFilter(ServiceTypes? serviceType)
        {
            if (serviceType != null)
            {
                Expression<Func<Appointment, bool>> expression = (appointment) => appointment.ServiceTypeId == (int)serviceType;

                base.AddExpression(expression);
            }

            return this;
        }

        public FilterBuilder BuildByMonthFilter(DateTime? dateTime)
        {
            if (dateTime != null )
            {
                Expression<Func<Appointment, bool>> expression = (appointment) => appointment.Time.Month == dateTime.Value.Month && appointment.Time.Year == dateTime.Value.Year;

                base.AddExpression(expression);
            }

            return this;
        }

        public FilterBuilder BuildDoctorFilter(int? doctorId)
        {
            if (doctorId > 0)
            {
                Expression<Func<Appointment, bool>> expression = (appointment) => appointment.DoctorId == doctorId;

                base.AddExpression(expression);
            }

            return this;
        }

        public FilterBuilder BuildMedicalSpecialityFilter(int? medicalSpecialtyId)
        {
            if (medicalSpecialtyId > 0)
            {
                Expression<Func<Appointment, bool>> expression = (appointment) => appointment.Doctor.MedicalSpecialties.Exists(x => x.Id == medicalSpecialtyId);

                base.AddExpression(expression);
            }

            return this;
        }

        public FilterBuilder BuildHealthInsuranceFilter(int? healthInsuranceId)
        {
            if (healthInsuranceId != null)
            {
                Expression<Func<Appointment, bool>> expression = (appointment) => appointment.Patient.Plan.HealthInsurance.Id == healthInsuranceId;

                base.AddExpression(expression);
            }

            return this;
        }

        public FilterBuilder BuildStartEndDateFilter(DateTime? dateFrom, DateTime? dateTo)
        {
            if (dateFrom.HasValue && dateTo.HasValue)
            {
                Expression<Func<Appointment, bool>> expression = (e) => e.CreateDate >= dateFrom & e.CreateDate <= dateTo;

                base.AddExpression(expression);
            }

            return this;
        }

    }
}
