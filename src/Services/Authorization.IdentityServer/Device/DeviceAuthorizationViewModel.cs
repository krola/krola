using Krola.Authorization.IdentityServer.Consent;

namespace Krola.Authorization.IdentityServer.Device
{
    public class DeviceAuthorizationViewModel : ConsentViewModel
    {
        public string UserCode { get; set; }
        public bool ConfirmUserCode { get; set; }
    }
}