namespace ClinicaNuevoRosario.Application.Models.ReportGenerator
{
    public class HealthInsuranceReport
    {
        public string PatientFullName { get; set; }
        public int HealthInsuranceNumber { get; set; }
        public string Date { get; set; }
        public string Plan { get; set; }
        public string HealthInsuranceName { get; set; }
        public string ProfesionalFullName { get; set; }
        public string ServiceType { get; set; }
    }
}
