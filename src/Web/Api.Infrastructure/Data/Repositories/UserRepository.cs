using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Krola.Web.Api.Core.Dto;
using Krola.Web.Api.Core.Dto.GatewayResponses.Repositories;
using Krola.Web.Api.Core.Interfaces.Gateways.Repositories;
using Krola.Web.Api.Core.Specifications;
using Krola.Web.Api.Infrastructure.Identity;
using Krola.Domain.Authorization;

namespace Krola.Web.Api.Infrastructure.Data.Repositories
{
    internal sealed class UserRepository : Repository<User>, IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        

        public UserRepository(UserManager<AppUser> userManager, IMapper mapper, AppDbContext appDbContext): base(appDbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<CreateUserResponse> Create(string firstName, string lastName, string email, string userName, string password)
        {
            var appUser = new AppUser {Email = email, UserName = userName};
            var identityResult = await _userManager.CreateAsync(appUser, password);

            if (!identityResult.Succeeded) return new CreateUserResponse(appUser.Id, false,identityResult.Errors.Select(e => new Error(e.Code, e.Description)));
          
            var user = new User(firstName, lastName, appUser.Id, appUser.UserName);
            _dbContext.Set<User>().Add(user);
            await _dbContext.SaveChangesAsync();

            return new CreateUserResponse(appUser.Id, identityResult.Succeeded, identityResult.Succeeded ? null : identityResult.Errors.Select(e => new Error(e.Code, e.Description)));
        }

        public async Task<User> FindByName(string userName)
        {
            var appUser = await _userManager.FindByNameAsync(userName);
            return appUser == null ? null : _mapper.Map(appUser, await GetSingleBySpec(new UserSpecification(appUser.Id)));
        }

        public async Task<bool> CheckPassword(User user, string password)
        {
            return await _userManager.CheckPasswordAsync(_mapper.Map<AppUser>(user), password);
        }
    }
}
