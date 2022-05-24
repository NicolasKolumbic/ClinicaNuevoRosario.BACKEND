using AutoMapper;
using ClinicaNuevoRosario.Application.Contracts.Identity;
using ClinicaNuevoRosario.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicaNuevoRosario.Identity.Services
{
    public class UserService : IUserService<ApplicationUser>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task DeleteAsync(ApplicationUser entity)
        {
             await _userManager.DeleteAsync(entity);
        }

        public async Task<ApplicationUser> GetUserByAsync(Expression<Func<ApplicationUser, bool>> predicate)
        {
          return await _userManager.Users.FirstAsync(predicate);
        }

       
    }
}
