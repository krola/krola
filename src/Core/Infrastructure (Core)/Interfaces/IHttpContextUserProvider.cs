using System;
using System.Threading.Tasks;

namespace Krola.Core.Infrastructure.Interfaces
{
    public interface IHttpContextUserProvider
    {
        Task<Guid> GetUserId();
    }
}
