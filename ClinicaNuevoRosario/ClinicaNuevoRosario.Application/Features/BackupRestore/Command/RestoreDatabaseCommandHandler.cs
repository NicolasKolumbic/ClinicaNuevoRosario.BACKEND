using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;

namespace ClinicaNuevoRosario.Application.Features.BackupRestore.Command
{
    public class RestoreDatabaseCommandHandler : IRequestHandler<RestoreDatabaseCommand, int>
    {

        private readonly IAdministratorRepository _administratorRepository;
        private readonly string _connectionString;
        private readonly string _sqlServerPath;
        public RestoreDatabaseCommandHandler(
            IAdministratorRepository administratorRepository,
            IOptions<ConnectionString> connectionString,
            IOptions<SQLServerPath> sqlServerPath
        )
        {
            _administratorRepository = administratorRepository;
            _connectionString = connectionString.Value.DefaultConnection;
            _sqlServerPath = sqlServerPath.Value.SqlServerBasePath;
        }
        public Task<int> Handle(RestoreDatabaseCommand request, CancellationToken cancellationToken)
        {
            var localDatabasePath = this.SaveFile(request.File);
            if (localDatabasePath != null) {
                var restoreDatabaseSetting = new RestoreDatabaseSetting(
                    request.DatabaseName,
                    this._connectionString,
                    this._sqlServerPath,
                    localDatabasePath
                  );
                this._administratorRepository.RestoreDatabase(restoreDatabaseSetting);
            }

            return Task.FromResult(1);
            
        }

        private string SaveFile(IFormFile file)
        {
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "backups");
            var fullPath = String.Empty;

            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                fullPath = Path.Combine(pathToSave, fileName);
              
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                  file.CopyToAsync(stream);
                }
            }

            return fullPath;
            
        }
    }
}
