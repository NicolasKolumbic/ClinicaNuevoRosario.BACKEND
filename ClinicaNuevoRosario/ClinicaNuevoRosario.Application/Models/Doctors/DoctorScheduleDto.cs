namespace ClinicaNuevoRosario.Application.Models.Doctors
{
    public class DoctorScheduleDto
    {
        public int DoctorScheduleId { get; set; }
        public int Day { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public int? AppointmentDuration { get; set; }
    }
}
