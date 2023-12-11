using MediatR;
using Microsoft.AspNetCore.Http;

namespace ClinicaNuevoRosario.Application.Features.BackupRestore
{
    public class GenerateBackupDatabaseQuery: IRequest<MemoryStream>
    {
        public string fileName { get; set; }
    }
}
