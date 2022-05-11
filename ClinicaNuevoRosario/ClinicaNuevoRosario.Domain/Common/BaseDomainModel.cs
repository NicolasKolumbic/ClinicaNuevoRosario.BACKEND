namespace ClinicaNuevoRosario.Domain.Common
{
    public abstract class BaseDomainModel
    {
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
