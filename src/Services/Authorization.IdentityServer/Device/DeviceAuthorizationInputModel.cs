using Krola.Authorization.IdentityServer.Consent;

namespace Krola.Authorization.IdentityServer.Device
{
    public class DeviceAuthorizationInputModel : ConsentInputModel
    {
        public string UserCode { get; set; }
    }
}