using System.Threading.Tasks;
using Krola.Web.Api.Core.Dto;

namespace Krola.Web.Api.Core.Interfaces.Services
{
    public interface IJwtFactory
    {
        Task<AccessToken> GenerateEncodedToken(string id, string userName);
    }
}
