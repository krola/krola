using System.Linq;
using System.Threading.Tasks;
using Krola.Web.Api.Core.Dto.UseCaseRequests;
using Krola.Web.Api.Core.Dto.UseCaseResponses;
using Krola.Web.Api.Core.Interfaces;
using Krola.Web.Api.Core.Interfaces.Gateways.Repositories;
using Krola.Web.Api.Core.Interfaces.UseCases;

namespace Krola.Web.Api.Core.UseCases
{
    public sealed class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(RegisterUserRequest message, IOutputPort<RegisterUserResponse> outputPort)
        {
            var response = await _userRepository.Create(message.FirstName, message.LastName,message.Email, message.UserName, message.Password);
            outputPort.Handle(response.Success ? new RegisterUserResponse(response.Id, true) : new RegisterUserResponse(response.Errors.Select(e => e.Description)));
            return response.Success;
        }
    }
}
