﻿namespace ClinicaNuevoRosario.Domain
{
    public class Doctor: Person
    {
        public Doctor()
        {
            DoctorSchedules = new List<DoctorSchedule>();
            MedicalSpecialties = new List<MedicalSpecialty>();
            Plans = new List<Plan>();
            MedicalHistories = new List<MedicalHistory>();
        }

        public string MedicalLicense { get; set; } = String.Empty;  
        public bool IsActive { get; set; }
        public int AppointmentDurationDefault { get; set; } = 15;
        public string? SystemEmail { get; set; }
        public virtual List<DoctorSchedule> DoctorSchedules { get; set; }
        public virtual List<MedicalSpecialty> MedicalSpecialties { get; set; }
        public virtual List<MedicalHistory> MedicalHistories { get; set; }
        public virtual List<Plan> Plans { get; set; }


    }
}
