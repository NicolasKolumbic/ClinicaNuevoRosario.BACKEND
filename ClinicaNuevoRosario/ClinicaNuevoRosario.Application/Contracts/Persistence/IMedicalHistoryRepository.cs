using ClinicaNuevoRosario.Domain;

namespace ClinicaNuevoRosario.Application.Contracts.Persistence
{
    public interface IMedicalHistoryRepository: IAsyncRepository<MedicalHistory>
    {
    }
}
