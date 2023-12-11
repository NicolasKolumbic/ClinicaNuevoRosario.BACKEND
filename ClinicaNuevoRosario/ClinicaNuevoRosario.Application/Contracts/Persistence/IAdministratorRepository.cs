using ClinicaNuevoRosario.Application.Models;

namespace ClinicaNuevoRosario.Application.Contracts.Persistence
{
    public interface IAdministratorRepository
    {
        public Task<MemoryStream> GenerateBackup(string connectionString, string filename);

        public Task<int> RestoreDatabase(RestoreDatabaseSetting setting);

    }
}
