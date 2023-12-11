using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Application.Models;
using MediatR;
using Microsoft.Extensions.Options;

namespace ClinicaNuevoRosario.Application.Features.BackupRestore
{
    public class GenerateBackupDatabaseQueryHandler : IRequestHandler<GenerateBackupDatabaseQuery, MemoryStream>
    {
        private readonly IAdministratorRepository _administratorRepository;
        private readonly string _connectionString;
        public GenerateBackupDatabaseQueryHandler(
            IAdministratorRepository administratorRepository,
            IOptions<ConnectionString> connectionString
        )
        {
            _administratorRepository = administratorRepository;
            _connectionString = connectionString.Value.DefaultConnection;
        }


        public Task<MemoryStream> Handle(GenerateBackupDatabaseQuery request, CancellationToken cancellationToken)
        {
            var memory = _administratorRepository.GenerateBackup(this._connectionString, request.fileName);

            return memory;
        }
    }
}
