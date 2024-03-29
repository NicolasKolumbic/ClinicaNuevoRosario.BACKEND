﻿using ClinicaNuevoRosario.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaNuevoRosario.Domain
{
    public class MedicalSpecialty: BaseDomainModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Doctor> Doctors { get; set; }
    }
}
