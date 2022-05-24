using AutoMapper;
using ClinicaNuevoRosario.Application.Contracts.Identity;
using ClinicaNuevoRosario.Application.Models.User;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.Users.Queries
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, User>
    {
        private readonly IMapper _mapper;
        private readonly IUserService<User> _userService;
        public Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
