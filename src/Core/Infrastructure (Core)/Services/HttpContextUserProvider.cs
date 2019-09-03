using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Krola.Core.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Krola.Core.Infrastructure.Services
{
    public class HttpContextUserProvider : IHttpContextUserProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private const string UserClaimType = "sub";

        public HttpContextUserProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Guid> GetUserId()
        {
            var claim = _httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == UserClaimType);

            return await Task.FromResult<Guid>(new Guid(claim.Value));
        }
    }
}
