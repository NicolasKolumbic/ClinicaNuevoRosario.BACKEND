using ClinicaNuevoRosario.Application.Models.User;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.Users.Queries
{
    public class GetUserQuery: IRequest<User>
    {
    }
}
