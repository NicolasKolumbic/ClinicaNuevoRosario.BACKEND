using ClinicaNuevoRosario.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaNuevoRosario.Domain
{
    public class Plan: BaseDomainModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
