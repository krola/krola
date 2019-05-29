using Krola.Web.Api.Core.Dto.UseCaseRequests;
using Krola.Web.Api.Core.Dto.UseCaseResponses;

namespace Krola.Web.Api.Core.Interfaces.UseCases
{
    public interface IRegisterUserUseCase : IUseCaseRequestHandler<RegisterUserRequest, RegisterUserResponse>
    {
    }
}
