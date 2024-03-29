﻿using ClinicaNuevoRosario.Domain;

namespace ClinicaNuevoRosario.Application.Models.Doctors
{
    public class GetHealthInsuranceDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public bool IsActive { get; set; }
    }
}
