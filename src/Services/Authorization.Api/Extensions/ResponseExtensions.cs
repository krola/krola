using Microsoft.AspNetCore.Http;
using Krola.Authorization.Api.Helpers;

namespace Krola.Authorization.Api.Extensions
{
    public static class ResponseExtensions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", Strings.RemoveAllNonPrintableCharacters(message));
            // CORS
            response.Headers.Add("access-control-expose-headers", "Application-Error");
        }
    }
}
