using MediatR;
using Microsoft.AspNetCore.Http;

namespace ClinicaNuevoRosario.Application.Features.BackupRestore.Command
{
    public class RestoreDatabaseCommand: IRequest<int>
    {   
        public IFormFile File { get; set; }
        public string DatabaseName { get; set; }
    }
}
